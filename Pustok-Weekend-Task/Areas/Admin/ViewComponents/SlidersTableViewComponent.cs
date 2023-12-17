using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok_Weekend_Task.Areas.Admin.ViewModels.AdminSliderVM;
using Pustok_Weekend_Task.Contexts;

namespace Pustok_Weekend_Task.Areas.Admin.ViewComponents
{
    [Area("Admin")]
    public class SlidersTableViewComponent : ViewComponent
    {
        PustokDbContext _context { get; }
        public SlidersTableViewComponent(PustokDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _context.Sliders.Select(slider => new AdminSliderListVM
            {
                Id = slider.Id,
                Title = slider.Title,
                Description = slider.Description,
                Price = slider.Price,
                ImgUrl = slider.ImgUrl,
                IsLeft = slider.IsLeft
            }).ToListAsync());
        }
    }
}
