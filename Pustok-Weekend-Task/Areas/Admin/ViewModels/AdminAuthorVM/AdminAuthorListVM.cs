using System.ComponentModel.DataAnnotations;

namespace Pustok_Weekend_Task.Areas.Admin.ViewModels.AdminAuthorVM
{
    public class AdminAuthorListVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
