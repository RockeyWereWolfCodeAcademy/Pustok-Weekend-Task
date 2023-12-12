using Pustok_Weekend_Task.Models;

namespace Pustok_Weekend_Task.Areas.Admin.ViewModels.AdminBlogVM
{
    public class AdminBlogListVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
