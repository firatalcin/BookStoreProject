using BookStore.Business.Abstract;
using BookStore.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        ICartService _cartService;
        IBookService _bookService;

        public CartController(ICartService cartService, IBookService bookService)
        {
            _cartService = cartService;
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult GetCart()
        {
            var list = _cartService.GetAll();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var cart = _cartService.Get(id);
            return Ok(cart);
        }

        [HttpPost]
        public IActionResult AddCart([FromBody] Cart cart)
        {
            cart.Book = null;
            cart.User = null;
            var book = _bookService.Get(cart.BookId);
            book.UnitsInStock -= cart.Quantity;
            cart.Price = cart.Quantity * book.UnitPrice;
            _cartService.Add(cart);
            _bookService.Update(book);
            return Ok();
        }

        [HttpPut]
        public IActionResult EditCart(int id,[FromBody] Cart cart)
        {
            var oldCart = _cartService.Get(id);
            var book = _bookService.Get(cart.BookId);
            if(cart.Quantity > oldCart.Quantity)
            {
                book.UnitsInStock -= cart.Quantity;
            }
            else if(cart.Quantity < oldCart.Quantity)
            {
                book.UnitsInStock += cart.Quantity;
            }
            
            cart.Price = cart.Quantity * book.UnitPrice;
            _cartService.Update(cart);
            _bookService.Update(book);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveCart(int id)
        {
            _cartService.Delete(id);
            return Ok();
        }

    }
}
