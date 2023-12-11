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
                Title = data.Title,
                Description = data.Description,
                Price = data.Price,
                IsLeft = data.IsLeft,
            });
        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id, AdminSliderUpdateVM sliderVM)
        {
            TempData["Response"] = "temp";
            if (id == null) return BadRequest();
            var data = await _context.Sliders.FindAsync(id);
            if (data == null) return NotFound();
            if (sliderVM.ImgFile != null)
            {
                if (!sliderVM.ImgFile.IsImageType())
                {
                    ModelState.AddModelError("ImgFile", "File must be image");
                }
                if (!sliderVM.ImgFile.IsValidSize(1000))
                {
                    ModelState.AddModelError("ImgFile", "File cant be larger than 1 mb");
                }
            }
            if (!ModelState.IsValid)
            {
                return View(sliderVM);
            }
            data.Title = sliderVM.Title;
            data.Description = sliderVM.Description;
            data.Price = sliderVM.Price;
            data.IsLeft = sliderVM.IsLeft;
            data.ImgUrl = sliderVM.ImgFile == null ? data.ImgUrl : await sliderVM.ImgFile.SaveAsync(PathConstants.SliderImage);
            await _context.SaveChangesAsync();
            TempData["Response"] = "updated";
            return RedirectToAction(nameof(Index), "AdminHome");
        }
    }
}
