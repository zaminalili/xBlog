using FluentValidation;
using xBlog.API.Models.DTO.Blog;

namespace xBlog.API.Validators
{
    public class CreateBlogValidator: AbstractValidator<AddBlogRequestDto>
    {
        public CreateBlogValidator()
        {
            RuleFor(b => b.Title).NotEmpty().NotNull().MaximumLength(30);
            RuleFor(b => b.Content).NotEmpty().NotNull().MaximumLength(1000);
           
        }
    }
}
