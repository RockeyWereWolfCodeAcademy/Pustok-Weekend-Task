using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Pustok_Weekend_Task.Areas.Admin.ViewModels.AdminSliderVM
{
	public class AdminSliderCreateVM
	{
		[MaxLength(16)]
		public string Title { get; set; }
		[MaxLength(32)]
		public string Description { get; set; }
		public IFormFile ImgFile { get; set; }
		public decimal Price { get; set; }
		public bool IsLeft { get; set; }
	}
}
