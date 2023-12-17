using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok_Weekend_Task.Areas.Admin.ViewModels.AdminCategoryVM;
using Pustok_Weekend_Task.Contexts;

namespace Pustok_Weekend_Task.Areas.Admin.ViewComponents
{
    public class CategoriesTableViewComponent : ViewComponent
    {
        PustokDbContext _context { get; }
        public CategoriesTableViewComponent(PustokDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _context.Categories.Select(category => new AdminCategoryListVM
            {
                Id = category.Id,
                Name = category.Name,
                ParentName = _context.Categories.First(x => x.Id == category.ParentCategoryId).Name
            }).ToListAsync());
        }
    }
}
