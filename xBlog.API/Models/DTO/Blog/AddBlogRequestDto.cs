namespace xBlog.API.Models.DTO.Blog
{
    public class AddBlogRequestDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string? ImageUrl { get; set; }

        public Guid CategoryId { get; set; }
        public Guid UserId { get; set; }
    }
}
