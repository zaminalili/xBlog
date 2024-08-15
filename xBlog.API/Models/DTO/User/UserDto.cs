namespace xBlog.API.Models.DTO.User
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
    }
}
