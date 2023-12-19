namespace Pustok_Weekend_Task.Helpers
{
    public static class ImageFileHelper
    {
        public static async Task<string> SaveAsync(this IFormFile file, string path)
        {
            string extension = Path.GetExtension(file.FileName);
            string fileName = Path.GetFileNameWithoutExtension(file.FileName).Length > 64 ?
                file.FileName.Substring(0, 64) :
                Path.GetFileNameWithoutExtension(file.FileName);
            fileName = Path.Combine(path, Path.GetRandomFileName() + fileName + extension);
            using (FileStream fs = File.Create(Path.Combine(PathConstants.RootPath, fileName)))
            {
                await file.CopyToAsync(fs);
            }
            return fileName;
        }
        public static bool IsValidSize(this IFormFile file, float kb)
            => file.FileName.Length <= kb;
        public static bool IsImageType(this IFormFile file)
            => file.ContentType.Contains("image");
    }
}
