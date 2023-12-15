using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pustok_Weekend_Task.Contexts;
using Pustok_Weekend_Task.ViewModels.ProductVM.BasketVM;

namespace Pustok_Weekend_Task.ViewComponents
{
    public class BasketViewComponent : ViewComponent
    {
        PustokDbContext _context { get; }
        public BasketViewComponent(PustokDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = JsonConvert.DeserializeObject<List<BasketProductAndCountVM>>(HttpContext.Request.Cookies["basket"] ?? "[]");
            var products = _context.Products.Where(p => items.Select(i => i.Id).Contains(p.Id));
            List<BasketProductItemVM> basketItems = new();
            foreach (var item in products)
            {
                basketItems.Add(new BasketProductItemVM
                {
                    Id = item.Id,
                    Discount = item.Discount,
                    ImageUrl = item.ActiveImgUrl,
                    Name = item.Name,
                    Price = item.SellPrice,
                    Count = items.FirstOrDefault(x => x.Id == item.Id).Count
                });
            }
            return View(basketItems);
        }
    }
}
