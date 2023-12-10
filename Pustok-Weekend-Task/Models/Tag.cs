using System.ComponentModel.DataAnnotations;

namespace Pustok_Weekend_Task.Models
{
    public class Tag
    {
        public int Id { get; set; }
        [MaxLength(16)]
        public string Name { get; set; }
        public IEnumerable<ProductTag> ProductTags { get; set; }
    }
}
