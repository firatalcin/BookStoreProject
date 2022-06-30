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
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;
        private readonly IValidator<Author> _authorValidator;

        public AuthorsController(IMapper mapper, IAuthorService authorService, IValidator<Author> authorValidator)
        {
            _mapper = mapper;
            _authorService = authorService;
            _authorValidator = authorValidator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var author = await _authorService.GetAllAsync();
            var authorDtos = _mapper.Map<List<AuthorListDto>>(author);
            return Ok(authorDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var author = await _authorService.GetByIdAsync(id);
            var authorDtos = _mapper.Map<AuthorListDto>(author);
            return Ok(authorDtos);
        }

        [HttpPost]
        public async Task<IActionResult> Save(AuthorAddDto dto)
        {
            var result = _authorValidator.Validate(_mapper.Map<Author>(dto));
            if (result.IsValid)
            {
                await _authorService.AddAsync(_mapper.Map<Author>(dto));
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Update(AuthorUpdateDto dto)
        {
            var result = _authorValidator.Validate(_mapper.Map<Author>(dto));
            if (result.IsValid)
            {
                await _authorService.UpdateAsync(_mapper.Map<Author>(dto));
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var author = await _authorService.GetByIdAsync(id);
            await _authorService.RemoveAsync(author);
            return Ok();
        }
    }
}