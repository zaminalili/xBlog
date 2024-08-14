namespace xBlog.API.Models.Domains
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsVisible { get; set; } = true;

        // Navigation properties
        public ICollection<Blog> Blogs { get; set; }
    }
}
