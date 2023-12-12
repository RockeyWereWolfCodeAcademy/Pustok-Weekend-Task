using Pustok_Weekend_Task.Models;

namespace Pustok_Weekend_Task.ViewModels.ProductVM
{
    public class ProductDetailsVM
    {
        public string Name { get; set; }
        public string About { get; set; }
        public string Description { get; set; }
        public decimal ExTax { get; set; }
        public string AuthorName { get; set; }
        public string ProductCode { get; set; }
        public bool IsAvailable { get; set; }
        public decimal Price { get; set; }
        public float Discount { get; set; }
        public IEnumerable<string> ImageURLs { get; set; }
        public IEnumerable<string> Tags { get; set; }
    }
}
