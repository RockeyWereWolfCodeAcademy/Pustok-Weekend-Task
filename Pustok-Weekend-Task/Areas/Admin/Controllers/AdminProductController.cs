using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pustok_Weekend_Task.Areas.Admin.ViewModels.AdminProductVM;
using Pustok_Weekend_Task.Contexts;
using Pustok_Weekend_Task.Helpers;
using Pustok_Weekend_Task.Models;

namespace Pustok_Weekend_Task.Areas.Admin.Controllers
{
    public class AdminProductController : Controller
    {
        PustokDbContext _context { get; }
        public AdminProductController(PustokDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> CreateProduct()
        {
            ViewBag.Categories = _context.Categories;
            ViewBag.Authors = _context.Authors;
            ViewBag.Tags = _context.Tags;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(AdminProductCreateVM productVM)
        {
            TempData["Response"] = "temp";
            if (productVM.ActualPrice > productVM.SellPrice)
            {
                ModelState.AddModelError("ActualPrice", "Sell price must be bigger than cost price");
            }
            if (!await _context.Categories.AnyAsync(c => c.Id == productVM.CategoryId))
            {
                ModelState.AddModelError("CategoryId", "Category doesnt exist");
            }
            if (!await _context.Authors.AnyAsync(c => c.Id == productVM.AuthorId))
            {
                ModelState.AddModelError("AuthorId", "Author doesnt exist");
            }
            if (await _context.Tags.Where(c => productVM.TagIds.Contains(c.Id)).Select(c => c.Id).CountAsync() != productVM.TagIds.Count())
            {
                ModelState.AddModelError("TagIds", "one of tags doesnt exist!");
            }
            if (productVM.ActiveImg != null)
            {
                if (!productVM.ActiveImg.IsImageType())
                {
                    ModelState.AddModelError("ImgFile", "File must be image");
                }
                if (!productVM.ActiveImg.IsValidSize(1000))
                {
                    ModelState.AddModelError("ImgFile", "File cant be larger than 1 mb");
                }
            }
            foreach (var img in productVM.Images)
            {
                if (!img.IsImageType())
                {
                    ModelState.AddModelError("", "Wrong file type (" + img.FileName + ")");
                    //message += "Wrong file type (" + img.FileName + ") \r\n";
                }
                if (!img.IsValidSize(1000))
                {
                    ModelState.AddModelError("", "File cant be larger than 1 mb");
                    //message += "Files length must be less than kb (" + img.FileName + ") \r\n";
                }
            }
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = _context.Categories;
                ViewBag.Authors = _context.Authors;
                ViewBag.Tags = _context.Tags;
                return View(productVM);
            }
            Product product = new Product
            {
                Name = productVM.Name,
                ExTax = productVM.ExTax,
                ActualPrice = productVM.ActualPrice,
                SellPrice = productVM.SellPrice,
                Discount = productVM.Discount,
                About = productVM.About,
                Description = productVM.Description,
                IsAvailable = productVM.IsAvailable,
                CategoryId = productVM.CategoryId,
                AuthorId = productVM.AuthorId,
                ProductCode = productVM.ProductCode,
                ProductTags = productVM.TagIds.Select(id => new ProductTag
                {
                    TagId = id,
                }).ToList(),
                Images = productVM.Images.Select(i => new ProductImage
                {
                    ImageUrl = i.SaveAsync(PathConstants.ProductImage).Result,
                }).ToList(),
                ActiveImgUrl = await productVM.ActiveImg.SaveAsync(PathConstants.ProductImage)
            };
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            TempData["Response"] = "created";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteProduct(int? id)
        {
            TempData["Response"] = "temp";
            if (id == null) return BadRequest();
            var data = await _context.Products.FindAsync(id);
            if (data == null) return NotFound();
            data.IsDeleted = true;
            await _context.SaveChangesAsync();
            TempData["Response"] = "deleted";
            return RedirectToAction(nameof(Index));
        }
    }
}
