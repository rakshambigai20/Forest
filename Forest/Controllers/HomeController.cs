using Forest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Forest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private AppSettingsModel appSetting;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult DownloadTerms()
        {
            return File("/Documents/Tc.pdf", "application/pdf", "Tc.pdf");
        }

        public IActionResult Index()
        {
            return View(Index);
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
