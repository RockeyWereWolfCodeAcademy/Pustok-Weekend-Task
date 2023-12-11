using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok_Weekend_Task.Areas.Admin.ViewModels.AdminAuthorVM;
using Pustok_Weekend_Task.Areas.Admin.ViewModels.AdminCategoryVM;
using Pustok_Weekend_Task.Areas.Admin.ViewModels.AdminHomeVM;
using Pustok_Weekend_Task.Areas.Admin.ViewModels.AdminProductVM;
using Pustok_Weekend_Task.Areas.Admin.ViewModels.AdminSliderVM;
using Pustok_Weekend_Task.Areas.Admin.ViewModels.AdminTagVM;
using Pustok_Weekend_Task.Contexts;

namespace Pustok_Weekend_Task.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminHomeController : Controller
    {
        PustokDbContext _context { get; }
        public AdminHomeController(PustokDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var models = new AdminHomeListVM();
            models.Sliders = await _context.Sliders.Select(slider => new AdminSliderListVM
            {
                Id = slider.Id,
                Title = slider.Title,
                Description = slider.Description,
                Price = slider.Price,
                ImgUrl = slider.ImgUrl,
                IsLeft = slider.IsLeft
            }).ToListAsync();
            models.Tags = await _context.Tags.Select(tag => new AdminTagListVM
            {
                Id = tag.Id,
                Name = tag.Name
            }).ToListAsync();
            models.Authors = await _context.Authors.Select(author => new AdminAuthorListVM
            {
                Id = author.Id,
                Name = author.Name,
                Surname = author.Surname,

            }).ToListAsync();
            models.Products = await _context.Products.Select(product => new AdminProductListVM
            {
                Id = product.Id,
                Name = product.Name,
                ExTax = product.ExTax,
                IsAvailable = product.IsAvailable,
                ActualPrice = product.ActualPrice,
                SellPrice = product.SellPrice,
                Discount = product.Discount,
                ActiveImageUrl = product.ActiveImgUrl,
                AuthorFullName = product.Author.Name+ " " + product.Author.Surname,
                CategoryName = product.Category.Name,
                IsDeleted = product.IsDeleted
            }).ToListAsync();
            models.Categories = await _context.Categories.Select(category => new AdminCategoryListVM
            {
                Id = category.Id,
                Name = category.Name,
                ParentName = _context.Categories.First(x=> x.Id == category.ParentCategoryId).Name
            }).ToListAsync();
            return View(models);
        }
    }
}
