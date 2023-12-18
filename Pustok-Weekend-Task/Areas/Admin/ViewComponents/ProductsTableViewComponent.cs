using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok_Weekend_Task.Areas.Admin.ViewModels.AdminCommonVM;
using Pustok_Weekend_Task.Areas.Admin.ViewModels.AdminProductVM;
using Pustok_Weekend_Task.Contexts;

namespace Pustok_Weekend_Task.Areas.Admin.ViewComponents
{
    public class ProductsTableViewComponent : ViewComponent
    {
        PustokDbContext _context { get; }
        public ProductsTableViewComponent(PustokDbContext context)
        {
            _context = context;
        }
        //public async Task<IViewComponentResult> InvokeAsync()
        //{
        //    return View(await _context.Products.Select(product => new AdminProductListVM
        //    {
        //        Id = product.Id,
        //        Name = product.Name,
        //        ExTax = product.ExTax,
        //        IsAvailable = product.IsAvailable,
        //        ActualPrice = product.ActualPrice,
        //        SellPrice = product.SellPrice,
        //        Discount = product.Discount,
        //        ActiveImageUrl = product.ActiveImgUrl,
        //        AuthorFullName = product.Author.Name + " " + product.Author.Surname,
        //        CategoryName = product.Category.Name,
        //        IsDeleted = product.IsDeleted
        //    }).ToListAsync());
        //}
        public async Task<IViewComponentResult> InvokeAsync(int page = 1, int count = 3)
        {
            var items = _context.Products.Where(product => !product.IsDeleted).Skip((page - 1) * count).Take(count).Select(product => new AdminProductListVM
            {

                Id = product.Id,
                Name = product.Name,
                ExTax = product.ExTax,
                IsAvailable = product.IsAvailable,
                ActualPrice = product.ActualPrice,
                SellPrice = product.SellPrice,
                Discount = product.Discount,
                ActiveImageUrl = product.ActiveImgUrl,
                AuthorFullName = product.Author.Name + " " + product.Author.Surname,
                CategoryName = product.Category.Name,
                IsDeleted = product.IsDeleted
            });
            int totalCount = await _context.Products.CountAsync(x => !x.IsDeleted);
            AdminPaginationVM<IEnumerable<AdminProductListVM>> pag = new(count, totalCount, page, (int)Math.Ceiling((decimal)totalCount / count), items);

            return View(pag);
        }
    }
}
