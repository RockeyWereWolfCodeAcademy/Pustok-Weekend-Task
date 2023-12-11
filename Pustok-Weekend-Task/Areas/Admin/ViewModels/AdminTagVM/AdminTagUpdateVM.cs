using System.ComponentModel.DataAnnotations;

namespace Pustok_Weekend_Task.Areas.Admin.ViewModels.AdminTagVM
{
    public class AdminTagUpdateVM
    {
        [MaxLength(16)]
        public string Name { get; set; }
    }
}
