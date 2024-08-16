using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using xBlog.API.Models.Domains;
using xBlog.API.Models.DTO.Category;
using xBlog.API.Models.DTO.User;
using xBlog.API.Repositories;

namespace xBlog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var userDomainModel = await userRepository.GetByIdAsync(id);

            if (userDomainModel is null)
                return NotFound();

            var userDto = mapper.Map<UserDto>(userDomainModel);

            return Ok(userDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddUserRequestDto addUserRequestDto)
        {

            var userDomainModel = mapper.Map<User>(addUserRequestDto);

            await userRepository.CreateAsync(userDomainModel);

            var userDto = mapper.Map<UserDto>(userDomainModel);

            return CreatedAtAction(nameof(GetById), new { id = userDto.Id }, userDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateUserRequestDto updateUserRequestDto)
        {
            // mapping
            var userDomainModel = mapper.Map<User>(updateUserRequestDto);

            userDomainModel = await userRepository.UpdateAsync(id, userDomainModel);

            if (userDomainModel == null)
                return NotFound();

            // map domain model back to dto
            var userDto = mapper.Map<UserDto>(userDomainModel);

            return Ok(userDto);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            var userDomainModel = await userRepository.DeleteAsync(id);

            if (userDomainModel == null)
                return NotFound();

            // mapping
            var UserDto = mapper.Map<UserDto>(userDomainModel);

            return Ok(UserDto);
        }
    }
}
