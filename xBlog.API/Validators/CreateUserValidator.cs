using FluentValidation;
using xBlog.API.Models.DTO.User;

namespace xBlog.API.Validators
{
    public class CreateUserValidator: AbstractValidator<AddUserRequestDto>
    {
        public CreateUserValidator()
        {
            RuleFor(u => u.Username).NotEmpty().MaximumLength(20);
            RuleFor(u => u.Email).NotEmpty().MaximumLength(30).EmailAddress();
            RuleFor(u => u.Password).NotEmpty().MinimumLength(8).Matches("^(?=.*\\d).*$");
        }
    }
}
