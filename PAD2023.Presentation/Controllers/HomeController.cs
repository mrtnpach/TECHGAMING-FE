using Microsoft.AspNetCore.Mvc;
using PAD2023.Presentation.Models;
using StoreServiceReference;
using System.Diagnostics;

namespace PAD2023.Presentation.Controllers
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
            HomeViewModel model = new HomeViewModel() 
            {
                BuiltPCs = ProductCategory.BuiltPC,
                Components = ProductCategory.Components,
                Notebooks = ProductCategory.Notebook,
                Peripherals = ProductCategory.Peripheral
            };

            return View(model);
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