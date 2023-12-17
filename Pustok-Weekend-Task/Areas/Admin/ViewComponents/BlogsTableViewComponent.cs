using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok_Weekend_Task.Areas.Admin.ViewModels.AdminBlogVM;
using Pustok_Weekend_Task.Contexts;

namespace Pustok_Weekend_Task.Areas.Admin.ViewComponents
{
    public class BlogsTableViewComponent : ViewComponent
    {
        PustokDbContext _context { get; }
        public BlogsTableViewComponent(PustokDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _context.Blogs.Select(blog => new AdminBlogListVM
            {
                Id = blog.Id,
                Title = blog.Title,
                AuthorName = blog.Author.Name + " " + blog.Author.Surname,
                IsDeleted = blog.IsDeleted,
                CreatedAt = blog.CreatedAt,
                UpdatedAt = blog.UpdatedAt
            }).ToListAsync());
        }
    }
}
