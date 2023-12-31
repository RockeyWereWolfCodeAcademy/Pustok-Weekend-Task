﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pustok_Weekend_Task.Contexts;

namespace Pustok_Weekend_Task.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Authorize(Roles = "SuperAdmin, Admin, Moderator")]
	public class AdminHomeController : Controller
    { 
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetMyViewComponent(int calledPage)
        {
            return ViewComponent("ProductsTable", new { page = calledPage });
        }
    }
}
