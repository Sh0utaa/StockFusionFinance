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
using System.Linq;
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
            var user = await _userManager.GetUserAsync(User);

            StockFusionFinanceModel portfolioModel = new StockFusionFinanceModel();

            portfolioModel.PortfolioList = await _context.Portfolio
                .Where(t => t.Id == user.Id)
                .OrderBy(t => t.Symbol)
                .ToListAsync();

            return View(portfolioModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(StockFusionFinanceModel model)
        {
            if (!string.IsNullOrWhiteSpace(model.Transactions.Symbol))
            {
                var user = await _userManager.GetUserAsync(User);
                var stockInfo = await _yahooApi.GetStockInfo(model.Transactions.Symbol);

                TransactionsModel transactions = new TransactionsModel()
                {
                    Id = user.Id,
                    Symbol = stockInfo.Data.Symbol,
                    CurrentPrice = (double)stockInfo.Data.CurrentPrice,
                    Time = DateTime.Now,
                    Quantity = model.Transactions.Quantity,
                    Cost = Math.Round((double)(stockInfo.Data.CurrentPrice * model.Transactions.Quantity), 3),
                    Action = model.Transactions.Action,
                };

                _context.Transactions.Add(transactions);
                await _context.SaveChangesAsync();


                StockFusionFinanceModel portfolioModel = new StockFusionFinanceModel();

                portfolioModel.PortfolioList = await _context.Portfolio
                    .Where(t => t.Id == user.Id)
                    .OrderBy(t => t.Symbol)
                    .ToListAsync();

                if (portfolioModel.PortfolioList.Count() == 0 || !portfolioModel.PortfolioList.Any(item => item.Symbol == stockInfo.Data.Symbol))
                {
                    PortfolioModel portfolio = new PortfolioModel()
                    {
                        Id = user.Id,
                        Symbol = stockInfo.Data.Symbol,
                        Name = stockInfo.Data.ShortName,
                        Shares = model.Transactions.Quantity,
                        Cost = Math.Round((double)(stockInfo.Data.CurrentPrice * model.Transactions.Quantity), 3),
                    };
                    _context.Portfolio.Add(portfolio);
                    await _context.SaveChangesAsync();
                }
                else if(portfolioModel.PortfolioList.Any(item => item.Symbol == stockInfo.Data.Symbol))
                {
                    PortfolioModel existingPortfolio = portfolioModel.PortfolioList.First(item => item.Symbol == stockInfo.Data.Symbol);

                    int updatedShares = existingPortfolio.Shares;

                    if (model.Transactions.Action == "Sell")
                    {
                        updatedShares -= model.Transactions.Quantity;
                    }
                    else
                    {
                        updatedShares += model.Transactions.Quantity;
                    }

                    // Update specific properties of the existing portfolio
                    existingPortfolio.Shares = updatedShares;
                    existingPortfolio.Cost = Math.Round((double)(stockInfo.Data.CurrentPrice * updatedShares), 3);

                    // Entity Framework will track the changes and generate SQL to update the database
                    await _context.SaveChangesAsync();
                }

                //update the portfolio table where Symbol == model.Data.Symbol
                //grab the original sybol, then add/subtract the count
                //update the cost

            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> History()
        {
            var user = await _userManager.GetUserAsync(User);

            StockFusionFinanceModel newModel = new StockFusionFinanceModel();

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