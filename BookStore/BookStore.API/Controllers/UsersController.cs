using BookStore.Business.Abstract;
using BookStore.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetUser()
        {
            var list = _userService.GetAll();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.Get(id);
            return Ok(user);
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] User user)
        {
            user.Cart = null;
            user.UserType = null;
            _userService.Add(user);
            return Ok();
        }

        [HttpPut]
        public IActionResult EditUser([FromBody] User user)
        {
            _userService.Update(user);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveUser(int id)
        {
            _userService.Delete(id);
            return Ok();
        }
    }
}
