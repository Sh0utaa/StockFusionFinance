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
        private readonly UserManager<IdentityUser> _userManager;
        public HomeController(IYahooApi service, AuthSystemDBContext context, UserManager<IdentityUser> userManager)
        {
            _yahooApi = service;
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(string symbol)
        {
            if(!string.IsNullOrWhiteSpace(symbol))
            {
                var model = await _yahooApi.GetStockInfo(symbol);
                //ClaimsPrincipal currentUser = this.User;
                var user = await _userManager.GetUserAsync(User);
                IndexViewModel newModel = new()
                {
                    StockData = model
                };
                return View(newModel);
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}