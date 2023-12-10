using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok_Weekend_Task.Contexts;
using Pustok_Weekend_Task.ViewModels.HomeVM;
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
            models.Sliders = await _context.Sliders.Select(slider => new SliderListVM
            {
                Title = slider.Title,
                Description = slider.Description,
                Price = slider.Price,
                IsLeft = slider.IsLeft,
                ImgUrl = slider.ImgUrl
            }).ToListAsync();
            return View(models);
        }
    }
}
