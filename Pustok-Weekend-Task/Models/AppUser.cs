using Microsoft.AspNetCore.Identity;

namespace Pustok_Weekend_Task.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
        public string? ProfileImageURL { get; set; }
    }
}
