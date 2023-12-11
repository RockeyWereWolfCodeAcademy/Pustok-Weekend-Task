using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok_Weekend_Task.Areas.Admin.ViewModels.AdminSliderVM;
using Pustok_Weekend_Task.Areas.Admin.ViewModels.AdminTagVM;
using Pustok_Weekend_Task.Contexts;
using Pustok_Weekend_Task.Helpers;
using Pustok_Weekend_Task.Models;

namespace Pustok_Weekend_Task.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminTagController : Controller
    {
        PustokDbContext _context { get; }
        public AdminTagController(PustokDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AdminTagCreateVM tagVM)
        {
            TempData["Response"] = "temp";
            if (!ModelState.IsValid)
            {
                return View(tagVM);
            }
            Tag Tag = new Tag
            {
                Name = tagVM.Name,
            };
            await _context.Tags.AddAsync(Tag);
            await _context.SaveChangesAsync();
            TempData["Response"] = "created";
            return RedirectToAction(nameof(Index), "AdminHome");
        }
        public async Task<IActionResult> Delete(int? id)
        {
            TempData["Response"] = "temp";
            if (id == null) return BadRequest();
            var data = await _context.Tags.FindAsync(id);
            if (data == null) return NotFound();
            _context.Tags.Remove(data);
            await _context.SaveChangesAsync();
            TempData["Response"] = "deleted";
            return RedirectToAction(nameof(Index), "AdminHome");
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return BadRequest();
            var data = await _context.Tags.FindAsync(id);
            if (data == null) return NotFound();
            return View(new AdminTagUpdateVM
            {
                Name = data.Name,
            });
        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id, AdminTagUpdateVM tagVM)
        {
            TempData["Response"] = "temp";
            if (id == null) return BadRequest();
            var data = await _context.Tags.FindAsync(id);
            if (data == null) return NotFound();
            if (!ModelState.IsValid)
            {
                return View(tagVM);
            }
            data.Name = tagVM.Name;
            await _context.SaveChangesAsync();
            TempData["Response"] = "updated";
            return RedirectToAction(nameof(Index), "AdminHome");
        }
    }
}
