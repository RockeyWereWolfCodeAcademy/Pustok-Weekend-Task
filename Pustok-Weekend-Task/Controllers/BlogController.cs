using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok_Weekend_Task.Contexts;
using Pustok_Weekend_Task.ViewModels.BlogVM;

namespace Pustok_Weekend_Task.Controllers
{
    public class BlogController : Controller
    {
        PustokDbContext _context { get; }
        public BlogController(PustokDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return BadRequest();
            var data = _context.Blogs
             .Where(b => b.Id == id)
             .Select(b => new BlogDetailsVM
             {
                 Title = b.Title,
                 AuthorName = b.Author.Name+" "+b.Author.Surname,
                 Description = b.Description,
                 CreatedAt = DateOnly.FromDateTime(b.CreatedAt),
                 UpdatedAt = DateOnly.FromDateTime(b.UpdatedAt),
                 ImgUrl = b.ImgUrl,
                 Tags = b.BlogTags.Select(pt => pt.Tag.Name),
             })
             .SingleOrDefault();
            if (data == null) return NotFound();
            return View(data);
        }
    }
}
