﻿using System.ComponentModel.DataAnnotations;

namespace Pustok_Weekend_Task.Areas.Admin.ViewModels.AdminCategoryVM
{
    public class AdminCategoryUpdateVM
    {
        [Required, MaxLength(16)]
        public string Name { get; set; }
        public int ParentCategoryId { get; set; }
    }
}
