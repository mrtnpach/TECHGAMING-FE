using Microsoft.AspNetCore.Mvc;
using PAD2023.Presentation.Models;
using StoreServiceReference;

namespace PAD2023.Presentation.Controllers
{
    [Route("[controller]")]
    public class CategoriasController : Controller
    {
        public IActionResult Index()
        {
            try
            {
                StoreServiceSoapClient proxy =
                    new StoreServiceSoapClient(StoreServiceSoapClient.EndpointConfiguration.StoreServiceSoap);
                List<Product> result = proxy.GetAllProducts();

                List<ProductViewModel> model = result
                    .Select(p => new ProductViewModel(p.ObjectId, p.ProductInfo)).ToList();
                
                return View(model);
            }
            catch (Exception)
            {
                return View("../Shared/Error");
            }
        }

        [HttpGet("[action]")]
        public IActionResult Category(ProductCategory category, string categoryString)
        {
            try
            {
                StoreServiceSoapClient proxy =
                    new StoreServiceSoapClient(StoreServiceSoapClient.EndpointConfiguration.StoreServiceSoap);
                List<Product> result = proxy.GetProductsByCategory(category);

                ViewData["Category"] = categoryString;
                List<ProductViewModel> model = result.Select(p => new ProductViewModel(p.ObjectId, p.ProductInfo)).ToList();

                return View(model);
            }
            catch (Exception)
            {
                return View("../Shared/Error");
            }
        }
    }
}
