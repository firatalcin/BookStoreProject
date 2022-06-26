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
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public BooksController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var book = await _bookService.GetAllAsync();
            var bookDto = _mapper.Map<List<BookListDto>>(book);
            return Ok(bookDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var book = await _bookService.GetByIdAsync(id);
            var bookDto = _mapper.Map<BookListDto>(book);
            return Ok(bookDto);
        }

        [HttpPost]
        public async Task<IActionResult> Save(BookAddDto dto)
        {
            await _bookService.AddAsync(_mapper.Map<Book>(dto));
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(BookUpdateDto dto)
        {
            await _bookService.UpdateAsync(_mapper.Map<Book>(dto));
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _bookService.GetByIdAsync(id);
            await _bookService.RemoveAsync(book);
            return Ok();
        }
    }
}