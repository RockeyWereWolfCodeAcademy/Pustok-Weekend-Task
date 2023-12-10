using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Pustok_Weekend_Task.ViewModels.SliderVM
{
    public class SliderListVM
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public decimal Price { get; set; }
        public bool IsLeft { get; set; }
    }
}
