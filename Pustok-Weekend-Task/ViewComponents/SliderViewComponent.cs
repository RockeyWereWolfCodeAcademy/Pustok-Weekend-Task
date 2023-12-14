using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok_Weekend_Task.Contexts;
using Pustok_Weekend_Task.ViewModels.SliderVM;

namespace Pustok_Weekend_Task.ViewComponents
{
	public class SliderViewComponent : ViewComponent
	{
		PustokDbContext _context { get; }

		public SliderViewComponent(PustokDbContext context)
		{
			_context = context;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View(await _context.Sliders.Select(slider => new SliderListVM
			{
				Title = slider.Title,
				Description = slider.Description,
				Price = slider.Price,
				IsLeft = slider.IsLeft,
				ImgUrl = slider.ImgUrl
			}).ToListAsync());
		}
	}
}
