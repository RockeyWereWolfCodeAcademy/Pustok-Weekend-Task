using System.ComponentModel.DataAnnotations;

namespace Pustok_Weekend_Task.Models
{
    public class Blog
    {
        public int Id { get; set; }
        [Required, MaxLength(32)]
        public string Title { get; set; }
        [MaxLength(256)]
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public bool IsDeleted { get; set; }
        public IEnumerable<BlogTag> BlogTags { get; set; }
        public string ImgUrl { get; set; }
    }
}