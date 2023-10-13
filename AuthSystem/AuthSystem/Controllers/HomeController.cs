using AuthSystem.Areas.Identity.Data;
using AuthSystem.Data;
using AuthSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using StockFusion_Finance.API;
using StockFusion_Finance.Models;
using System.Diagnostics;
using System.Security.Claims;
using static System.Net.Mime.MediaTypeNames;

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

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(IndexViewModel model)
        {
            if (!string.IsNullOrWhiteSpace(model.Transactions.Symbol))
            {
                var user = await _userManager.GetUserAsync(User);

                IndexViewModel newModel = new IndexViewModel();

                var stockInfo = await _yahooApi.GetStockInfo(model.Transactions.Symbol);

                TransactionsModel transactions = new TransactionsModel()
                {
                    Id = user.Id,
                    Symbol = stockInfo.Data.Symbol,
                    CurrentPrice = (double)stockInfo.Data.CurrentPrice,
                    Time = DateTime.Now,
                    Quantity = model.Transactions.Quantity,
                    Cost = (double)(stockInfo.Data.CurrentPrice * model.Transactions.Quantity),
                    Action = model.Transactions.Action,
                };

                _context.Transactions.Add(transactions);
                await _context.SaveChangesAsync();
            }
            return View();
        }

            public async Task<IActionResult> History()
        {
            var user = await _userManager.GetUserAsync(User);

            IndexViewModel newModel = new IndexViewModel();

            newModel.TransactionsList = await _context.Transactions
                .Where(t => t.Id == user.Id)
                .OrderByDescending(t => t.Time)
                .ToListAsync();


            return View(newModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}