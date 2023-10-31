using StoreServiceReference;

namespace PAD2023.Presentation.Models
{
    public class ProductViewModel
    {
        // Pide Id por aparte, no es ideal, pero evita ajustes mayores
        public ProductViewModel(int id, ProductInfo productInfo)
        {
            Id = id;
            Name = productInfo.Name;
            Description = productInfo.Description;
            Price = productInfo.Price;
            Brand = productInfo.Brand;
            Rating = productInfo.Rating;
            ShortDescription = productInfo.ShortDescription;
            Category = productInfo.Category;

            if(productInfo.ImageURLs != null)
            {
                ImageUrl = productInfo.ImageURLs;
            }
            else
            {
                ImageUrl = new List<string>();
            }
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public ProductCategory Category { get; set; }
        public string? Description { get; set; }
        public string? ShortDescription { get; set; }
        public decimal Price { get; set; }
        public decimal ConvertedPrice { get; set; }
        public Brand Brand { get; set; }
        public int Rating { get; set; }
        //public int Stock { get; set; }
        public List<string>? ImageUrl { get; set; }
    }
}
