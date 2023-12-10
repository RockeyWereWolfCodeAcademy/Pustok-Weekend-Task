using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Pustok_Weekend_Task.Areas.Admin.ViewModels.AdminSliderVM
{
    public class AdminSliderListVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public decimal Price { get; set; }
        public bool IsLeft { get; set; }
    }
}
