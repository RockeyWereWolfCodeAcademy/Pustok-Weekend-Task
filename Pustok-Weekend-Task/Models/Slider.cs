using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pustok_Weekend_Task.Models
{
    public class Slider
    {
        public int Id { get; set; }
        [MaxLength(16)]
        public string Title { get; set; }
        [MaxLength(32)]
        public string Description { get; set; }
        [MaxLength(64)]
        public string ImgUrl { get; set; }
        [Column(TypeName = "smallmoney")]
        public decimal Price { get; set; }
        public bool IsLeft { get; set; }

    }
}
