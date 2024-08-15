using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using xBlog.API.Models.Domains;
using xBlog.API.Models.DTO.Category;
using xBlog.API.Repositories;

namespace xBlog.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var categoriesDomainModel = await categoryRepository.GetAllAsync();

            // mapping
            var categoriesDto = mapper.Map<List<CategoryDto>>(categoriesDomainModel);

            return Ok(categoriesDto);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllInvisible()
        {

            var categoriesDomainModel = await categoryRepository.GetAllInvisibleAsync();

            // mapping
            var categoriesDto = mapper.Map<List<CategoryDto>>(categoriesDomainModel);

            return Ok(categoriesDto);
        }


        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var categoryDomainModel = await categoryRepository.GetByIdAsync(id);

            if (categoryDomainModel is null)
                return NotFound();

            var categoryDto = mapper.Map<CategoryDto>(categoryDomainModel);

            return Ok(categoryDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddCategoryRequestDto addCategoryRequestDto)
        {

            var categoryDomainModel = mapper.Map<Category>(addCategoryRequestDto);

            await categoryRepository.CreateAsync(categoryDomainModel);

            var categoryDto = mapper.Map<CategoryDto>(categoryDomainModel);

            return CreatedAtAction(nameof(GetById), new { id = categoryDto.Id }, categoryDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateCategoryRequestDto updateCategoryRequestDto)
        {
            // mapping
            var categoryDomainModel = mapper.Map<Category>(updateCategoryRequestDto);

            categoryDomainModel = await categoryRepository.UpdateAsync(id, categoryDomainModel);

            if (categoryDomainModel == null)
                return NotFound();

            // map domain model back to dto
            var categoryDto = mapper.Map<CategoryDto>(categoryDomainModel);

            return Ok(categoryDto);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> ChangeVisible([FromRoute] Guid id)
        {
            var categoryDomainModel = await categoryRepository.ChangeVisibleAsync(id);

            if (categoryDomainModel == null)
                return NotFound();

            // mapping
            var CategoryDto = mapper.Map<CategoryDto>(categoryDomainModel);

            return Ok(CategoryDto);
        }
    }
}
