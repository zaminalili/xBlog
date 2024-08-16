namespace xBlog.API.Models.DTO.Blog
{
    public class UpdateBlogRequestDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string? ImageUrl { get; set; }

        public DateTime? LastEditedDate { get; set; }
        public Guid CategoryId { get; set; }
    }
}
