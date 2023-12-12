using Pustok_Weekend_Task.ViewModels.BlogVM;
using Pustok_Weekend_Task.ViewModels.ProductVM;
using Pustok_Weekend_Task.ViewModels.SliderVM;

namespace Pustok_Weekend_Task.ViewModels.HomeVM
{
    public class HomeListVM
    {
        public IEnumerable<SliderListVM> Sliders { get; set; }
        public IEnumerable<ProductListVM> Products { get; set; }
        public IEnumerable<BlogListVM> Blogs { get; set; }
    }
}
