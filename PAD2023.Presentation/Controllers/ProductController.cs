using Microsoft.AspNetCore.Mvc;
using PAD2023.Presentation.Models;
using StoreServiceReference;

namespace PAD2023.Presentation.Controllers
{
    [Route("[controller]")]
    public class ProductController : Controller
    {
        [HttpGet("{name}")]
        public IActionResult Details(int id, string name)
        {
            try
            {
                StoreServiceSoapClient proxy =
                    new StoreServiceSoapClient(StoreServiceSoapClient.EndpointConfiguration.StoreServiceSoap);
                Product product = proxy.GetProductById(id);

                if (product == null) return NotFound();

                ProductViewModel model = new ProductViewModel(product.Id, product.ProductInfo);

                return View(model);
            }
            catch
            {
                return View("../Shared/Error");
            }
        }
    }
}
