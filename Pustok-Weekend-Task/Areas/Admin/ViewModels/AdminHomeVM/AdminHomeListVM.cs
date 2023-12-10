using Pustok_Weekend_Task.Areas.Admin.ViewModels.AdminAuthorVM;
using Pustok_Weekend_Task.Areas.Admin.ViewModels.AdminCategoryVM;
using Pustok_Weekend_Task.Areas.Admin.ViewModels.AdminProductVM;
using Pustok_Weekend_Task.Areas.Admin.ViewModels.AdminSliderVM;
using Pustok_Weekend_Task.Areas.Admin.ViewModels.AdminTagVM;

namespace Pustok_Weekend_Task.Areas.Admin.ViewModels.AdminHomeVM
{
    public class AdminHomeListVM
    {
        public IEnumerable<AdminSliderListVM>? Sliders { get; set; }
        public IEnumerable<AdminProductListVM>? Products { get; set; }
        public IEnumerable<AdminCategoryListVM>? Categories { get; set; }
        public IEnumerable<AdminAuthorListVM>? Authors { get; set; }
        public IEnumerable<AdminTagListVM>? Tags { get; set; }
    }
}
