using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok_Weekend_Task.Areas.Admin.ViewModels.AdminAuthorVM;
using Pustok_Weekend_Task.Areas.Admin.ViewModels.AdminCategoryVM;
using Pustok_Weekend_Task.Contexts;
using Pustok_Weekend_Task.Models;

namespace Pustok_Weekend_Task.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Authorize(Roles = "SuperAdmin, Admin, Moderator")]
	public class AdminCategoryController : Controller
    {
        PustokDbContext _context { get; }
        public AdminCategoryController(PustokDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            ViewBag.Categories = _context.Categories;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AdminCategoryCreateVM categoryVM)
        {
            TempData["Response"] = "temp";
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = _context.Categories;
                return View(categoryVM);
            }
            Category category = new Category
            {
                Name = categoryVM.Name,
                ParentCategoryId = categoryVM.ParentCategoryId,
            };
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            TempData["Response"] = "created";
            return RedirectToAction(nameof(Index), "AdminHome");
        }
        public async Task<IActionResult> Delete(int? id)
        {
            TempData["Response"] = "temp";
            if (id == null) return BadRequest();
            var data = await _context.Categories.FindAsync(id);
            if (data == null) return NotFound();
            _context.Categories.Remove(data);
            await _context.SaveChangesAsync();
            TempData["Response"] = "deleted";
            return RedirectToAction(nameof(Index), "AdminHome");
        }
        public async Task<IActionResult> Update(int? id)
        {
            ViewBag.Categories = _context.Categories;
            if (id == null) return BadRequest();
            var data = await _context.Categories.FindAsync(id);
            if (data == null) return NotFound();
            return View(new AdminCategoryUpdateVM
            {
                Name = data.Name,
                ParentCategoryId = data.ParentCategoryId,
            });
        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id, AdminCategoryUpdateVM categoryVM)
        {
            TempData["Response"] = "temp";
            if (id == null) return BadRequest();
            var data = await _context.Categories.FindAsync(id);
            if (data == null) return NotFound();
            if (categoryVM.ParentCategoryId == data.Id)
            {
                ModelState.AddModelError("ParentCategoryId", "Child and parent cannot be same!");
            }
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = _context.Categories;
                return View(categoryVM);
            }
            data.Name = categoryVM.Name;
            data.ParentCategoryId = categoryVM.ParentCategoryId;
            await _context.SaveChangesAsync();
            TempData["Response"] = "updated";
            return RedirectToAction(nameof(Index), "AdminHome");
        }
    }
}
