using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok_Weekend_Task.Areas.Admin.ViewModels.AdminBlogVM;
using Pustok_Weekend_Task.Contexts;
using Pustok_Weekend_Task.Models;

namespace Pustok_Weekend_Task.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminBlogController : Controller
    {
        PustokDbContext _context { get; }
        public AdminBlogController(PustokDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Authors = _context.Authors;
            ViewBag.Tags = _context.Tags;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AdminBlogCreateVM blogVM)
        {
            TempData["Response"] = "temp";
            if (!await _context.Authors.AnyAsync(author => author.Id == blogVM.AuthorId))
            {
                ModelState.AddModelError("AuthorId", "Author does not exist!");
            }
            if (!ModelState.IsValid)
            {
                ViewBag.Authors = _context.Authors;
                ViewBag.Tags = _context.Tags;
                return View(blogVM);
            }
            Blog blog = new Blog
            {
                Title = blogVM.Title,
                Description = blogVM.Description,
                AuthorId = blogVM.AuthorId,
                BlogTags = blogVM.TagIds?.Select(id => new BlogTag
                {
                    TagId = id,
                }).ToList(),
            };
            await _context.AddAsync(blog);
            await _context.SaveChangesAsync();
            TempData["Response"] = "created";
            return RedirectToAction(nameof(Index), "AdminHome");
        }
        public async Task<IActionResult> Delete(int? id)
        {
            TempData["Response"] = "temp";
            if (id == null) return BadRequest();
            var data = await _context.Blogs.FindAsync(id);
            if (data == null) return NotFound();
            data.IsDeleted = true;
            await _context.SaveChangesAsync();
            TempData["Response"] = "deleted";
            return RedirectToAction(nameof(Index), "AdminHome");
        }
        public async Task<IActionResult> Update(int? id)
        {
            ViewBag.Authors = _context.Authors;
            ViewBag.Tags = _context.Tags;
            if (id == null) return BadRequest();
            var data = await _context.Blogs.Include(b => b.BlogTags).SingleOrDefaultAsync(b => b.Id == id);
            if (data == null) return NotFound();
            return View(new AdminBlogUpdateVM
            {
                Title = data.Title,
                Description = data.Description,
                AuthorId = data.AuthorId,
                TagIds = data.BlogTags.Select(b => b.TagId),
            });
        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id, AdminBlogUpdateVM blogVM)
        {
            TempData["Response"] = "temp";
            var data = await _context.Blogs.FindAsync(id);
            if (data == null) return NotFound();
            if (!await _context.Authors.AnyAsync(author => author.Id == blogVM.AuthorId))
            {
                ModelState.AddModelError("AuthorId", "Author does not exist!");
            }
            if (!ModelState.IsValid)
            {
                ViewBag.Authors = _context.Authors;
                return View(blogVM);
            }
            data.Title = blogVM.Title;
            data.Description = blogVM.Description;
            data.AuthorId = blogVM.AuthorId;
            if (!Enumerable.SequenceEqual(data.BlogTags?.Select(b => b.TagId), blogVM.TagIds))
            {
                data.BlogTags = blogVM.TagIds.Select(id => new BlogTag
                {
                    TagId = id,
                }).ToList();
            }
            data.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            TempData["Response"] = "updated";
            return RedirectToAction(nameof(Index), "AdminHome");
        }
    }
}
