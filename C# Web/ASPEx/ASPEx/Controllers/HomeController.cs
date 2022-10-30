using ASPEx.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASPEx.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Title = "Home\nHello World!";
            ViewBag.Message = "This is the home page.";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Nums(int count)
        {
            ViewBag.Count = count;
            return View();
        }
        public IActionResult About()
        {
            ViewBag.Message = "This is an asp app.";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}