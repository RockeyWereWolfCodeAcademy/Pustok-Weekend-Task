using Pustok_Weekend_Task.Models;

namespace Pustok_Weekend_Task.Areas.Admin.ViewModels.AdminProductVM
{
    public class AdminProductListVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal ExTax { get; set; }
        public bool IsAvailable { get; set; }
        public decimal ActualPrice { get; set; }
        public decimal SellPrice { get; set; }
        public float Discount { get; set; }
        public string ActiveImageUrl { get; set; }
        public string AuthorFullName { get; set; }
        public string CategoryName { get; set; }
        public bool IsDeleted { get; set; }
    }
}
