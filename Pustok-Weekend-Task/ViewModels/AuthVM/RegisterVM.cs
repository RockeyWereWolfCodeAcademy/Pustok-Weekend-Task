using System.ComponentModel.DataAnnotations;

namespace Pustok_Weekend_Task.ViewModels.AuthVM
{
	public class RegisterVM
	{
		[Required(ErrorMessage = "Enter your name"), MaxLength(36)]
		public string Name { get; set; }
		[Required(ErrorMessage = "Enter your surname"), MaxLength(36)]
		public string Surname { get; set; }
		[Required, DataType(DataType.EmailAddress)]
		public string Email { get; set; }
		[Required(ErrorMessage = "Enter your username"), MaxLength(24)]
		public string Username { get; set; }
		[Required, DataType(DataType.Password), Compare(nameof(ConfirmPassword))]
		public string Password { get; set; }
		[Required, DataType(DataType.Password)]
		public string ConfirmPassword { get; set; }
	}
}
