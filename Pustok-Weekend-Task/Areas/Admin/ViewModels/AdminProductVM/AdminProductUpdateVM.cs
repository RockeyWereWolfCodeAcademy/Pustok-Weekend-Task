using System.ComponentModel.DataAnnotations;

namespace Pustok_Weekend_Task.Areas.Admin.ViewModels.AdminProductVM
{
    public class AdminProductUpdateVM
    {
        [MaxLength(16)]
        public string Name { get; set; }
        [MaxLength(32)]
        public string About { get; set; }
        [MaxLength(64)]
        public string Description { get; set; }
        public string ProductCode { get; set; }
        public decimal ExTax { get; set; }
        public bool IsAvailable { get; set; }
        public decimal ActualPrice { get; set; }
        [Range(0, 100)]
        public float Discount { get; set; }
        public decimal SellPrice { get; set; }
        public IFormFile ActiveImg { get; set; }
        public IFormFileCollection Images { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<int> TagIds { get; set; }
    }
}
