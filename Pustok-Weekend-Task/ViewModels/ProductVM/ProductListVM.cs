namespace Pustok_Weekend_Task.ViewModels.ProductVM
{
	public class ProductListVM
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public string ActiveImgUrl { get; set; }
        public decimal SellPrice { get; set; }
        public float Discount { get; set; }
        public string Category { get; set; }
        public string? About { get; set; }
    }
}
