using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok_Weekend_Task.Areas.Admin.ViewModels.AdminAuthorVM;
using Pustok_Weekend_Task.Contexts;

namespace Pustok_Weekend_Task.Areas.Admin.ViewComponents
{
    public class AuthorsTableViewComponent : ViewComponent
    {
        PustokDbContext _context { get; }
        public AuthorsTableViewComponent(PustokDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _context.Authors.Select(author => new AdminAuthorListVM
            {
                Id = author.Id,
                Name = author.Name,
                Surname = author.Surname,

            }).ToListAsync());
        }
    }
}
