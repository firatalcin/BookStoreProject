using BookStore.Business.Abstract;
using BookStore.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        IGenreService _genreService;    

        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        public IActionResult GetGenre()
        {
            var genres = _genreService.GetAll();
            return Ok(genres);
        }


        [HttpGet("{id}")]
        public IActionResult GeyById(int id)
        {
            var genres = _genreService.Get(id);
            return Ok(genres);
        }

        [HttpPost]
        public IActionResult AddGenre([FromBody] Genre genre)
        {
            genre.Books = null;
            _genreService.Add(genre);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult EditGenre(int id, [FromBody] Genre genre)
        {
            var updatedGenre = _genreService.Get(id);
            updatedGenre.Name = updatedGenre.Name == null ? updatedGenre.Name : genre.Name;
            _genreService.Update(updatedGenre);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveGenre(int id)
        {
           _genreService.Delete(id);
            return Ok();
        }
    }
}
