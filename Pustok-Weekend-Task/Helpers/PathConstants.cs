﻿namespace Pustok_Weekend_Task.Helpers
{
    public class PathConstants
    {
        public static string RootPath { get; set; }
        public static string SliderImage => Path.Combine("savedimages", "slider");
        public static string ProductImage => Path.Combine("savedimages", "product");
    }
}