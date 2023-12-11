using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok_Weekend_Task.Contexts;
using Pustok_Weekend_Task.Models;
using Pustok_Weekend_Task.ViewModels.ProductVM;
using System.Threading.Tasks.Dataflow;

namespace Pustok_Weekend_Task.Controllers
{
    public class ProductController : Controller
    {
        PustokDbContext _context { get; }
        public ProductController(PustokDbContext context)
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
            var data = await _context.Products.FindAsync(id);
            if (data == null) return NotFound();
            var productImageData = await _context.ProductImages.Where(x => x.ProductId == id).ToListAsync();
            var productTagDataQuery = from ProductTag in _context.ProductTags
                                      join Tag in _context.Tags
                                      on ProductTag.TagId equals Tag.Id
                                      where ProductTag.ProductId == id
                                      select Tag.Name;
            
            return View(new ProductDetailsVM
            {
                Name = data.Name,
                About = data.About,
                Description = data.Description,
                ExTax = data.ExTax,
                ProductCode = data.ProductCode,
                IsAvailable = data.IsAvailable,
                Price = data.SellPrice,
                Discount = data.Discount,
                ImageURLs = productImageData.Select(img=> img.ImageUrl).ToList(),
                Tags = productTagDataQuery.ToList(),
                //AuthorName = data.Author.Name + " " + data.Author.Surname,
            });
        }
    }
}
