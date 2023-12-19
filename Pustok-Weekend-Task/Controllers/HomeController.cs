using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok_Weekend_Task.Contexts;
using Pustok_Weekend_Task.ViewModels.BlogVM;
using Pustok_Weekend_Task.ViewModels.HomeVM;
using Pustok_Weekend_Task.ViewModels.ProductVM;
using Pustok_Weekend_Task.ViewModels.SliderVM;
using System.Reflection;

namespace Pustok_Weekend_Task.Controllers
{
    public class HomeController : Controller
    {
        PustokDbContext _context { get; }
        public HomeController(PustokDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult>  Index()
        {
            var models = new HomeListVM();

			models.Products = await _context.Products.Where(product=> product.IsDeleted == false).Select(product => new ProductListVM
			{
                Id = product.Id,
				Name = product.Name,
				AuthorName = product.Author.Name +" "+product.Author.Surname,
                ActiveImgUrl = product.ActiveImgUrl,
                SellPrice = product.SellPrice,
                Discount = product.Discount,
                Category = product.Category.Name,
			}).ToListAsync();
            models.Blogs = await _context.Blogs.Where(blog=> blog.IsDeleted == false).Select(blog=> new BlogListVM
            {
                Id=blog.Id,
                Title = blog.Title,
                Description = blog.Description,
                AuthorName = blog.Author.Name+" "+blog.Author.Surname,
                CreatedAt = DateOnly.FromDateTime(blog.CreatedAt),
                ImgUrl= blog.ImgUrl,
            }).ToListAsync();
            return View(models);
        }
		public IActionResult AccessDenied()
		{
			return View();
		}
	}
}
