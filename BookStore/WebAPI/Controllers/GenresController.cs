using AutoMapper;
using Business.Validations;
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
    public class GenresController : ControllerBase
    {
        private readonly IGenericService<Genre> _service;
        private readonly IMapper _mapper;
        private readonly IValidator<Genre> _genreValidator;

        public GenresController(IGenreService service, IMapper mapper, IValidator<Genre> genreValidator)
        {
            _service = service;
            _mapper = mapper;
            _genreValidator = genreValidator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var genres = await _service.GetAllAsync();
            var genresDtos = _mapper.Map<List<GenreListDto>>(genres);
            return Ok(genresDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var genres = await _service.GetByIdAsync(id);
            var genresDtos = _mapper.Map<GenreListDto>(genres);
            return Ok(genresDtos);
        }

        [HttpPost]
        public async Task<IActionResult> Save(GenreAddDto genreDto)
        {
            var result = _genreValidator.Validate(_mapper.Map<Genre>(genreDto));
            if (result.IsValid)
            {
                await _service.AddAsync(_mapper.Map<Genre>(genreDto));
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Update(GenreUpdateDto genreDto)
        {
            var result = _genreValidator.Validate(_mapper.Map<Genre>(genreDto));
            if (result.IsValid)
            {
                await _service.UpdateAsync(_mapper.Map<Genre>(genreDto));
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var genre = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(genre);
            return Ok();
        }
    }
}