using System.ComponentModel.DataAnnotations;

namespace Pustok_Weekend_Task.Models
{
    public class Author
    {
        public int Id { get; set; }
        [MaxLength(16)]
        public string Name { get; set; }
        [MaxLength(16)]
        public string Surname { get; set; }
        public IEnumerable<Product>? Products { get; set; }
        public IEnumerable<Blog>? Blogs { get; set; }
    }
}
