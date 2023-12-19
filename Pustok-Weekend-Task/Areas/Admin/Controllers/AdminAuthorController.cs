using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok_Weekend_Task.Areas.Admin.ViewModels.AdminAuthorVM;
using Pustok_Weekend_Task.Areas.Admin.ViewModels.AdminSliderVM;
using Pustok_Weekend_Task.Contexts;
using Pustok_Weekend_Task.Helpers;
using Pustok_Weekend_Task.Models;

namespace Pustok_Weekend_Task.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Authorize(Roles = "SuperAdmin, Admin, Moderator")]
	public class AdminAuthorController : Controller
    {
        PustokDbContext _context { get; }
        public AdminAuthorController(PustokDbContext context)
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
        public async Task<IActionResult> Create(AdminAuthorCreateVM authorVM)
        {
            TempData["Response"] = "temp";
            if (!ModelState.IsValid)
            {
                return View(authorVM);
            }
            Author author = new Author
            {
                Name = authorVM.Name,
                Surname = authorVM.Surname,
            };
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
            TempData["Response"] = "created";
            return RedirectToAction(nameof(Index), "AdminHome");
        }
        public async Task<IActionResult> Delete(int? id)
        {
            TempData["Response"] = "temp";
            if (id == null) return BadRequest();
            var data = await _context.Authors.FindAsync(id);
            if (data == null) return NotFound();
            _context.Authors.Remove(data);
            await _context.SaveChangesAsync();
            TempData["Response"] = "deleted";
            return RedirectToAction(nameof(Index), "AdminHome");
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return BadRequest();
            var data = await _context.Authors.FindAsync(id);
            if (data == null) return NotFound();
            return View(new AdminAuthorUpdateVM
            {
                Name = data.Name,
                Surname = data.Surname,
            });
        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id, AdminAuthorUpdateVM authorVM)
        {
            TempData["Response"] = "temp";
            if (id == null) return BadRequest();
            var data = await _context.Authors.FindAsync(id);
            if (data == null) return NotFound();
            if (!ModelState.IsValid)
            {
                return View(authorVM);
            }
            data.Name = authorVM.Name;
            data.Surname = authorVM.Surname;
            await _context.SaveChangesAsync();
            TempData["Response"] = "updated";
            return RedirectToAction(nameof(Index), "AdminHome");
        }
    }
}
