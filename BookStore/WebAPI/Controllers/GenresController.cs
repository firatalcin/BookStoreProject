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
    public class GenresController : ControllerBase
    {
        private readonly IGenericService<Genre> _service;
        private readonly IMapper _mapper;

        public GenresController(IGenreService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var genres = await _service.GetAllAsync();
            var genresDtos = _mapper.Map<List<GenreListDto>>(genres.ToList());
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
            await _service.AddAsync(_mapper.Map<Genre>(genreDto));
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(GenreUpdateDto genreDto)
        {
            await _service.UpdateAsync(_mapper.Map<Genre>(genreDto));
            return Ok();
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