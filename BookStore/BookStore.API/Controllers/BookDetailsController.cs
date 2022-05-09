using BookStore.Business.Abstract;
using BookStore.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookDetailsController : ControllerBase
    {
        IBookDetailService _bookDetailService;

        public BookDetailsController(IBookDetailService bookDetailService)
        {
            _bookDetailService = bookDetailService;
        }

        [HttpGet]
        public IActionResult GetBookDetail()
        {
            var bookDetailList = _bookDetailService.GetAll();
            return Ok(bookDetailList);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var bookDetail = _bookDetailService.Get(id);
            return Ok(bookDetail);
        }

        //[HttpPost]
        //public IActionResult AddBookDetail([FromBody] BookDetail bookDetail)
        //{
        //    bookDetail.Book = 
        //    _bookDetailService.Add(bookDetail);
        //}
    }
}
