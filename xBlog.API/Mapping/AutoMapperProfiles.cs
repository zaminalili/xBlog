using AutoMapper;
using xBlog.API.Models.Domains;
using xBlog.API.Models.DTO.Category;

namespace xBlog.API.Mapping
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<AddCategoryRequestDto, Category>().ReverseMap();
            CreateMap<UpdateCategoryRequestDto, Category>().ReverseMap();
        }
    }
}
