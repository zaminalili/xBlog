namespace xBlog.API.Models.Domains
{
    public class Blog
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string? ImageUrl { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? LastEditedDate { get; set; }

        // Foreign keys
        public Guid CategoryId { get; set; }
        public Guid UserId { get; set; }

        // Navigation properties
        public Category Category { get; set; }
        public User User { get; set; }
    }
}
