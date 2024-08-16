using FluentValidation;
using xBlog.API.Models.DTO.Category;

namespace xBlog.API.Validators
{
    public class UpdateCategoryValidator: AbstractValidator<UpdateCategoryRequestDto>
    {
        public UpdateCategoryValidator() 
        {
            RuleFor(c => c.Name).NotEmpty().NotNull().MaximumLength(15);
        }
    }
}
