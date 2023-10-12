using AuthSystem.Areas.Identity.Data;
using AuthSystem.Data;
using AuthSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockFusion_Finance.API;
using StockFusion_Finance.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace AuthSystem.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IYahooApi _yahooApi;
        private readonly AuthSystemDBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public HomeController(IYahooApi service, AuthSystemDBContext context, UserManager<ApplicationUser> userManager)
        {
            _yahooApi = service;
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> History(string symbol, int quantity, string action)
        {
            var user = await _userManager.GetUserAsync(User);

            IndexViewModel newModel = new IndexViewModel(); // Initialize the view model

            if (!string.IsNullOrWhiteSpace(symbol))
            {
                var model = await _yahooApi.GetStockInfo(symbol);

                TransactionsModel transactions = new TransactionsModel()
                {
                    Id = user.Id,
                    Symbol = model.Data.Symbol,
                    CurrentPrice = (double)model.Data.CurrentPrice,
                    Time = DateTime.Now,
                    Quantity = quantity,
                    Cost = (double)(model.Data.CurrentPrice * quantity),
                    Action = action,
                };

                _context.Transactions.Add(transactions);
                await _context.SaveChangesAsync();

                // Retrieve all transactions for the user
                newModel.TransactionsList = await _context.Transactions
                    .Where(t => t.Id == user.Id)
                    .OrderByDescending(t => t.Time)
                    .ToListAsync();

                newModel.StockData = model;
            }
            else
            {
                newModel.TransactionsList = await _context.Transactions
                    .Where(t => t.Id == user.Id)
                    .OrderByDescending(t => t.Time)
                    .ToListAsync(); ;
            }

            return View(newModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}