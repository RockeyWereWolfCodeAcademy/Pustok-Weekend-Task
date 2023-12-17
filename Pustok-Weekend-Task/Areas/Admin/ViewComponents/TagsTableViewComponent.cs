using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok_Weekend_Task.Areas.Admin.ViewModels.AdminTagVM;
using Pustok_Weekend_Task.Contexts;

namespace Pustok_Weekend_Task.Areas.Admin.ViewComponents
{
    public class TagsTableViewComponent : ViewComponent
    {
        PustokDbContext _context;
        public TagsTableViewComponent(PustokDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _context.Tags.Select(tag => new AdminTagListVM
            {
                Id = tag.Id,
                Name = tag.Name
            }).ToListAsync());
        }
    }
}
