using StoreServiceReference;

namespace PAD2023.Presentation.Models
{
    public class HomeViewModel
    {
        // No es optimo, pero lo mas directo
        public ProductCategory BuiltPCs { get; set; }
        public ProductCategory Notebooks { get; set; }
        public ProductCategory Components { get; set; }
        public ProductCategory Peripherals { get; set; }

        // Faltan los tops
    }
}
