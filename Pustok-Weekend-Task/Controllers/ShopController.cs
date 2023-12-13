using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pustok_Weekend_Task.Contexts;
using Pustok_Weekend_Task.ViewModels.ProductVM;

namespace Pustok_Weekend_Task.Controllers
{
    public class ShopController : Controller
    {
		PustokDbContext _context { get; }
		public ShopController(PustokDbContext context)
		{
			_context = context;
		}
		public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ShopGrid(int page = 1, int count = 4)
        {
			var items = await _context.Products.Where(p => !p.IsDeleted).Skip(count * (page - 1)).Take(count).Select(p => new ProductListVM
			{
				Id = p.Id,
				Category = p.Category.Name,
				Discount = p.Discount,
				Name = p.Name,
				ActiveImgUrl = p.ActiveImgUrl,
				SellPrice = p.SellPrice,
			}).ToListAsync();
			return View(items);
		}
		public async Task<IActionResult> ShopProductLoad(int page = 1, int count = 4)
        {
			var items = await _context.Products.Where(p => !p.IsDeleted).Skip(count * (page-1)).Take(count).Select(p => new ProductListVM
			{
				Id = p.Id,
				Category = p.Category.Name,
				Discount = p.Discount,
				Name = p.Name,
				ActiveImgUrl = p.ActiveImgUrl,
				SellPrice = p.SellPrice,
			}).ToListAsync();
			//int totalCount = await _context.Products.CountAsync(x => !x.IsDeleted);
			return PartialView("_ShopProductPartial", items);
        }
    }
}
