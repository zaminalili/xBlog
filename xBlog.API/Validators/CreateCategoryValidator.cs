using FluentValidation;
using xBlog.API.Models.DTO.Category;

namespace xBlog.API.Validators
{
    public class CreateCategoryValidator: AbstractValidator<AddCategoryRequestDto>
    {
        public CreateCategoryValidator() 
        {
            RuleFor(c => c.Name).NotEmpty().NotNull().MaximumLength(15);
        }
    }
}
