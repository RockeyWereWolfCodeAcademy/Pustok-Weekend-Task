using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pustok_Weekend_Task.ExternalServices.Interfaces;
using Pustok_Weekend_Task.Helpers.Enums;
using Pustok_Weekend_Task.Models;
using Pustok_Weekend_Task.ViewModels.AuthVM;
using System.Data;

namespace Pustok_Weekend_Task.Controllers
{
    public class AuthController : Controller
    {
        SignInManager<AppUser> _signInManager { get; }
        UserManager<AppUser> _userManager { get; }
        RoleManager<IdentityRole> _roleManager { get; }
        IEmailService _emailService { get; }

        public AuthController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IEmailService emailService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _emailService = emailService;
        }

		public IActionResult SendMail()
		{
            _emailService.Send("mi71k9d7p@code.edu.az", "Test", "test mail");
			return Ok();
        }
		public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var user = new AppUser
            {
                FullName = vm.Name +" "+vm.Surname,
                Email = vm.Email,
                UserName = vm.Username
            };
			var result = await _userManager.CreateAsync(user, vm.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
					ModelState.AddModelError("", error.Description);
				}
				return View(vm);
			}
			var roleResult = await _userManager.AddToRoleAsync(user, Roles.Member.ToString());
			if (!roleResult.Succeeded)
			{
				ModelState.AddModelError("", "Something went wrong. Please contact admin");
				return View(vm);
			}

			//SendEmail();

            return RedirectToAction("Index", "Home");
        }
		public IActionResult Login()
		{
			return View();
		}
		[HttpPost] 
		public async Task<IActionResult> Login(string? returnUrl, LoginVM vm)
		{
			AppUser user = await _userManager.FindByEmailAsync(vm.UsernameOrEmail) ?? await _userManager.FindByNameAsync(vm.UsernameOrEmail);
			if (user == null)
			{
				ModelState.AddModelError("", "Username or password is wrong");
				return View(vm);
			}
			var result = await _signInManager.PasswordSignInAsync(user, vm.Password, vm.IsRemember, true);
			if (!result.Succeeded)
			{
				if (result.IsLockedOut)
                {
                    ModelState.AddModelError("", "Too many attempts wait until " + DateTime.Parse(user.LockoutEnd.ToString()).ToString("HH:mm"));
                }
				else
				{
					ModelState.AddModelError("", "Username or password is wrong");
				}
				return View(vm);
			}
			if (!ModelState.IsValid)
			{
				return View(vm);
			}
			if (returnUrl != null)
			{
				return LocalRedirect(returnUrl);
			}
			return RedirectToAction("Index", "Home");
		}

		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index", "Home");
		}
		public async Task<bool> CreateRoles()
		{
			foreach (var item in Enum.GetValues(typeof(Roles)))
			{
				if (!await _roleManager.RoleExistsAsync(item.ToString()))
				{
					var result = await _roleManager.CreateAsync(new IdentityRole
					{
						Name = item.ToString()
					});
					if (!result.Succeeded)
					{
						return false;
					}
				}
			}
			return true;
		}
	}
}
