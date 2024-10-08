﻿namespace xBlog.API.Models.Domains
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; } = DateTime.Now;

        // Navigation properties
        public ICollection<Blog> Blogs { get; set; }

    }
}
