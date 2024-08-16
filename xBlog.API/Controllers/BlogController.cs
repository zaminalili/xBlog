using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using xBlog.API.Models.Domains;
using xBlog.API.Models.DTO.Blog;
using xBlog.API.Models.DTO.Category;
using xBlog.API.Models.DTO.User;
using xBlog.API.Repositories;

namespace xBlog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogRepository blogRepository;
        private readonly IMapper mapper;

        public BlogController(IBlogRepository blogRepository, IMapper mapper)
        {
            this.blogRepository = blogRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var blogDomainModel = await blogRepository.GetByIdAsync(id);

            if (blogDomainModel is null)
                return NotFound();

            var blogDto = mapper.Map<BlogDto>(blogDomainModel);

            return Ok(blogDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var blogsDomainModel = await blogRepository.GetAllAsync();

            // mapping
            var blogsDto = mapper.Map<List<BlogDto>>(blogsDomainModel);

            return Ok(blogsDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddBlogRequestDto addBlogRequestDto)
        {

            var blogDomainModel = mapper.Map<Blog>(addBlogRequestDto);

            await blogRepository.CreateAsync(blogDomainModel);

            var blogDto = mapper.Map<BlogDto>(blogDomainModel);

            return CreatedAtAction(nameof(GetById), new { id = blogDto.Id }, blogDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateBlogRequestDto updateBlogRequestDto)
        {
            // mapping
            var blogDomainModel = mapper.Map<Blog>(updateBlogRequestDto);

            blogDomainModel = await blogRepository.UpdateAsync(id, blogDomainModel);

            if (blogDomainModel == null)
                return NotFound();

            // map domain model back to dto
            var blogDto = mapper.Map<BlogDto>(blogDomainModel);

            return Ok(blogDto);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            var blogDomainModel = await blogRepository.DeleteAsync(id);

            if (blogDomainModel == null)
                return NotFound();

            // mapping
            var blogDto = mapper.Map<BlogDto>(blogDomainModel);

            return Ok(blogDto);
        }
    }
}
