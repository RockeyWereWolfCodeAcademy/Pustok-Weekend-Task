using System.ComponentModel.DataAnnotations;

namespace Pustok_Weekend_Task.Models
{
    public class Category
    {
        public int Id { get; set; }
        [MaxLength(16)]
        public string Name { get; set; }
        public int ParentCategoryId { get; set; }
        public IEnumerable<Category>? ChildCategories { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
