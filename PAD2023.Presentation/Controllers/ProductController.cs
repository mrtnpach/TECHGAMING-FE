using Microsoft.AspNetCore.Mvc;
using PAD2023.Presentation.Client;
using PAD2023.Presentation.Controllers;
using PAD2023.Presentation.DTOs;
using PAD2023.Presentation.Models;
using StoreServiceReference;

namespace PAD2023.Presentation.Controllers
{
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private IClient _httpClient;

        public ProductController(IClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Details(int id, string name)
        {
            try
            {
                StoreServiceSoapClient proxy =
                    new StoreServiceSoapClient(StoreServiceSoapClient.EndpointConfiguration.StoreServiceSoap);
                Product product = proxy.GetProductById(id);

                if (product == null) return NotFound();

                // La API no convierte a ARS, por ahora usa BRL. Buscar otra que si lo haga.
                // La URI deberia estar en appsetings
                CurrencyConversionDTO result = await _httpClient
                    .GetAsync<CurrencyConversionDTO>(
                    "https://api.freecurrencyapi.com/v1/latest?apikey=fca_live_Mzw3L17vwBMbce25mKE27MHwp8zMdr5eDBtgLDUx&base_currency=USD&currencies=BRL");

                ProductViewModel model = new ProductViewModel(product.ObjectId, product.ProductInfo);
                model.ConvertedPrice = model.Price * (decimal)result.data.BRL;

                _httpClient.Dispose();

                return View(model);
            }
            catch
            {
                return View("../Shared/Error");
            }
        }
    }

}
