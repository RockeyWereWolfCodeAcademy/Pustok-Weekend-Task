using System.ComponentModel.DataAnnotations;

namespace Pustok_Weekend_Task.Areas.Admin.ViewModels.AdminBlogVM
{
    public class AdminBlogCreateVM
    {
        [Required, MaxLength(32)]
        public string Title { get; set; }
        [MaxLength(256)]
        public string? Description { get; set; }
        public int AuthorId { get; set; }
        public IEnumerable<int> TagIds { get; set; }
        public IFormFile ImgFile { get; set; }
    }
}
