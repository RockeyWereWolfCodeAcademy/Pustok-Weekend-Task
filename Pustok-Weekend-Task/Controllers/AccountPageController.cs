using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pustok_Weekend_Task.Contexts;
using Pustok_Weekend_Task.Helpers;
using Pustok_Weekend_Task.Models;
using Pustok_Weekend_Task.ViewModels.AccountPageVM;

namespace Pustok_Weekend_Task.Controllers
{
	public class AccountPageController : Controller
	{
		PustokDbContext _context { get; }
		UserManager<AppUser> _userManager { get; }
		public AccountPageController(PustokDbContext context, UserManager<AppUser> userManager)
		{
			_context = context;
			_userManager = userManager;
		}

		public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> PageHome(string? username)
		{
			string identity = User.Identity.Name;
			if (identity != username || identity == null)
			{
				return NotFound();
			}
			var user = await _userManager.FindByNameAsync(username);
			if (user == null)
			{
				return NotFound();
			}
			var userVM = new AccountPageUserVM
			{
				Username = user.UserName,
				Email = user.Email,
				Name = user.FullName.Split(' ')[0],
				Surname = user.FullName.Split(' ')[1],
				ProfileImageURL = user.ProfileImageURL,
			};
			return View(userVM);
		}
		[HttpPost]
		public async Task<IActionResult> PageHome(string? username, AccountPageUserVM userVM)
		{
			var user = await _userManager.FindByNameAsync(username);
			if (user == null)
			{
				return NotFound();
			}
			if (userVM.ProfileImage != null)
			{
				if (!userVM.ProfileImage.IsImageType())
				{
					ModelState.AddModelError("ImgFile", "File must be image");
				}
				if (!userVM.ProfileImage.IsValidSize(1000))
				{
					ModelState.AddModelError("ImgFile", "File cant be larger than 1 mb");
				}
			}
			if (!ModelState.IsValid)
			{
				return View(userVM);
			}
			user.FullName = userVM.Name + " " + userVM.Surname;
			user.Email = userVM.Email;
			user.ProfileImageURL = userVM.ProfileImage == null ? user.ProfileImageURL : await userVM.ProfileImage.SaveAsync(PathConstants.UserImage);

			await _userManager.UpdateAsync(user);

			return View(userVM);
		}
	}
}
