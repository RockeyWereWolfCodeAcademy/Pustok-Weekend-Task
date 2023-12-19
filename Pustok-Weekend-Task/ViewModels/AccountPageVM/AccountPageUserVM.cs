using System.ComponentModel.DataAnnotations;

namespace Pustok_Weekend_Task.ViewModels.AccountPageVM
{
	public class AccountPageUserVM
	{
        public string Username { get; set; }
		[MaxLength(36)]
		public string Name { get; set; }
		[MaxLength(36)]
		public string Surname { get; set; }
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }
        public string? ProfileImageURL { get; set; }
        public IFormFile? ProfileImage { get; set; }
    }
}
