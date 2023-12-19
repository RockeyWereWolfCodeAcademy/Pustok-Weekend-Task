﻿using System.ComponentModel.DataAnnotations;

namespace Pustok_Weekend_Task.ViewModels.AuthVM
{
	public class RegisterVM
	{
		[Required, MaxLength(36)]
		public string Name { get; set; }
		[Required, MaxLength(36)]
		public string Surname { get; set; }
		[Required, DataType(DataType.EmailAddress)]
		public string Email { get; set; }
		[Required, MaxLength(24)]
		public string Username { get; set; }
		[Required, DataType(DataType.Password), Compare(nameof(ConfirmPassword))]
		public string Password { get; set; }
		[Required, DataType(DataType.Password)]
		public string ConfirmPassword { get; set; }
	}
}
