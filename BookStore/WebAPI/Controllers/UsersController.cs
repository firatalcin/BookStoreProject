using AutoMapper;
using Core.DTOs;
using Core.Model;
using Core.Services;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IValidator<User> _userValidator;

        public UsersController(IUserService userService, IMapper mapper, IValidator<User> userValidator)
        {
            _userService = userService;
            _mapper = mapper;
            _userValidator = userValidator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var user = await _userService.GetAllAsync();
            var userDto = _mapper.Map<List<UserListDto>>(user);
            return Ok(userDto);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            var userDto = _mapper.Map<UserListDto>(user);
            return Ok(userDto);
        }

        [HttpPost]
        public async Task<IActionResult> Save(UserAddDto dto)
        {
            var result = _userValidator.Validate(_mapper.Map<User>(dto));
            if (result.IsValid)
            {
                await _userService.AddAsync(_mapper.Map<User>(dto));
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UserUpdateDto dto)
        {
            var result = _userValidator.Validate(_mapper.Map<User>(dto));
            if (result.IsValid)
            {
                await _userService.UpdateAsync(_mapper.Map<User>(dto));
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            await _userService.RemoveAsync(user);
            return Ok();
        }
    }
}