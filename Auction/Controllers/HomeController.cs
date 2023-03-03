using Auction.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Auction.Data;

namespace Auction.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context; 
        }

        public IActionResult Index(string search = "")
        {
            if (_context.AuctionItem == null)
            {
                return Problem("There are no auctions! Make one or come back later!");
            }

            var auctions = from a in _context.AuctionItem select a;

            if (search == "")
            {
                auctions = auctions.Where(a => a.Title!.Contains(search) || a.Description!.Contains(search));
            }

            return View(auctions);
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