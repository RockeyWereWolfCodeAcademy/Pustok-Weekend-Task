namespace Pustok_Weekend_Task.ViewModels.BlogVM
{
    public class BlogDetailsVM
    {
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string Description { get; set; }
        public DateOnly CreatedAt { get; set; }
        public DateOnly UpdatedAt { get; set; }
        public string ImgUrl { get; set; }
        public IEnumerable<string> Tags { get; set; }
    }
}
