namespace xBlog.API.Models.DTO.Blog
{
    public class BlogDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string? ImageUrl { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? LastEditedDate { get; set; }

        public Guid CategoryId { get; set; }
        public Guid UserId { get; set; }

        public Category Category { get; set; }
        public User User { get; set; }
    }
}
