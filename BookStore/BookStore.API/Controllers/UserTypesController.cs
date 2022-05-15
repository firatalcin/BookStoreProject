using BookStore.Business.Abstract;
using BookStore.Entities.Concrete;
using BookStore.Entities.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTypesController : ControllerBase
    {
        IUserTypeService _userTypeService;

        public UserTypesController(IUserTypeService userTypeService)
        {
            _userTypeService = userTypeService;
        }

        [HttpGet]
        public IActionResult GetUserType()
        {
            //List<string> list = new List<string>()
            //{
            //    "Admin = 1",
            //    "Customer = 2"              
            //};

            var list = _userTypeService.GetAll();
      
            return Ok(list);
        }


    }
}
