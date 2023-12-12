namespace Pustok_Weekend_Task.ViewModels.BlogVM
{
    public class BlogListVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string Description { get; set; }
        public DateOnly CreatedAt { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public string ImgUrl { get; set; }
    }
}
