using NuGet.Protocol;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pustok_Weekend_Task.Models
{
    public class Product
    {
        public int Id { get; set; }
        [MaxLength(16)]
        public string Name { get; set; }
        [MaxLength(32)]
        public string About { get; set; }
        [MaxLength(64)]
        public string Description { get; set; }
        public string ProductCode { get; set; }
        [Column(TypeName = "smallmoney")]
        public decimal ExTax { get; set; }
        public bool IsAvailable { get; set; }
        [Column(TypeName = "smallmoney")]
        public decimal ActualPrice { get; set; } 
        public float Discount { get; set; }
        [Column(TypeName = "smallmoney")]
        public decimal SellPrice { get; set;}
        public string ActiveImgUrl { get; set; }
        public IEnumerable<ProductImage> Images { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public bool IsDeleted { get; set; }
        public IEnumerable<ProductTag> ProductTags { get; set; }
    }
}
