using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using Pustok_Weekend_Task.Contexts;
using Pustok_Weekend_Task.Models;
using Pustok_Weekend_Task.ViewModels.ProductVM;
using Pustok_Weekend_Task.ViewModels.ProductVM.BasketVM;
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
            var data = _context.Products
             .Where(p => p.Id == id)
             .Select(p => new ProductDetailsVM
             {
                 Name = p.Name,
                 About = p.About,
                 Description = p.Description,
                 ExTax = p.ExTax,
                 ProductCode = p.ProductCode,
                 IsAvailable = p.IsAvailable,
                 Price = p.SellPrice,
                 Discount = p.Discount,
                 ImageURLs = p.Images.Select(img => img.ImageUrl),
                 Tags = p.ProductTags.Select(pt => pt.Tag.Name),
                 AuthorName = p.Author.Name + " " + p.Author.Surname
             })
             .SingleOrDefault();

            if (data == null) return NotFound();

            return View(data);
        }
        public IActionResult GetBasket()
        {
            return ViewComponent("Basket");
        }
        public async Task<IActionResult> AddToBasket(int? id)
        {
            if (id == null || id == 0)  BadRequest();
            if (!_context.Products.Any(p => p.Id == id)) NotFound();
            var basket = JsonConvert.DeserializeObject<List<BasketProductAndCountVM>>(HttpContext.Request.Cookies["basket"]??"[]");
            var existItem = basket.Find(b => b.Id == id);
            if (existItem == null)
            {
                basket.Add(new BasketProductAndCountVM
                {
                    Id = (int)id,
                    Count = 1
                });
            } else
            {
                existItem.Count++;
            }
            HttpContext.Response.Cookies.Append("basket", JsonConvert.SerializeObject(basket));
            return Ok();
        }
    }
}
