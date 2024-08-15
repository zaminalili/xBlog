using AutoMapper;
using xBlog.API.Models.Domains;
using xBlog.API.Models.DTO.Category;
using xBlog.API.Models.DTO.User;

namespace xBlog.API.Mapping
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<AddCategoryRequestDto, Category>().ReverseMap();
            CreateMap<UpdateCategoryRequestDto, Category>().ReverseMap();

            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<AddUserRequestDto, User>().ReverseMap();
            CreateMap<UpdateUserRequestDto, User>().ReverseMap();
        }
    }
}
