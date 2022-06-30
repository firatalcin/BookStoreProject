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
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;
        private readonly IValidator<Book> _bookValidator;

        public BooksController(IBookService bookService, IMapper mapper, IValidator<Book> bookValidator)
        {
            _bookService = bookService;
            _mapper = mapper;
            _bookValidator = bookValidator;
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
            var result = _bookValidator.Validate(_mapper.Map<Book>(dto));
            if (result.IsValid)
            {
                await _bookService.AddAsync(_mapper.Map<Book>(dto));
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Update(BookUpdateDto dto)
        {
            var result = _bookValidator.Validate(_mapper.Map<Book>(dto));
            if (result.IsValid)
            {
                await _bookService.UpdateAsync(_mapper.Map<Book>(dto));
                return Ok();
            }
            return BadRequest();
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