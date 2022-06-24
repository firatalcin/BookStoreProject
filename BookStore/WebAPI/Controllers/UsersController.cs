using AutoMapper;
using Core.DTOs;
using Core.Model;
using Core.Services;
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

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
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
            await _userService.AddAsync(_mapper.Map<User>(dto));
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UserUpdateDto dto)
        {
            await _userService.UpdateAsync(_mapper.Map<User>(dto));
            return Ok();
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