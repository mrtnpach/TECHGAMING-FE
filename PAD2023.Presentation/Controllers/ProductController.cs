using Microsoft.AspNetCore.Mvc;

namespace PAD2023.Presentation.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
