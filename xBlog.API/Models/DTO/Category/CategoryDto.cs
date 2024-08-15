namespace xBlog.API.Models.DTO.Category
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsVisible { get; set; } = true;
    }
}
