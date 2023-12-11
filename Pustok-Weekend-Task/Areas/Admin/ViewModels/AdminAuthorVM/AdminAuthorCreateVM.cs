using System.ComponentModel.DataAnnotations;

namespace Pustok_Weekend_Task.Areas.Admin.ViewModels.AdminAuthorVM
{
    public class AdminAuthorCreateVM
    {
        [MaxLength(16)]
        public string Name { get; set; }
        [MaxLength(16)]
        public string Surname { get; set; }
    }
}
