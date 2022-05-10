using BookStore.Business.Abstract;
using BookStore.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult GetBook()
        {
           var bookList = _bookService.GetAll();
            return Ok(bookList);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var book = _bookService.Get(id);
            return Ok(book);
        }
     

        [HttpPost]
        public IActionResult AddBook([FromBody] Book book)
        {
            book.Cart_Books = null;
            book.Author = null;
            book.Genre = null;
            book.BookDetail = null;
            _bookService.Add(book);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult EditBook(int id, [FromBody] Book book)
        {
            var updatedBook = _bookService.Get(id);
            updatedBook.BookName = book.BookName;
            updatedBook.AuthorId = book.AuthorId;
            updatedBook.GenreId = book.GenreId;
            updatedBook.UnitPrice = book.UnitPrice;
            updatedBook.UnitsInStock = book.UnitsInStock;
            updatedBook.PageCount = book.PageCount;
            _bookService.Update(updatedBook);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveBook(int id)
        {           
            _bookService.Delete(id);
            return Ok();
        }
    }
}
