using BookStore.Business.Abstract;
using BookStore.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BookStore.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        IGenreService _genreService;    

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet(Name = "GetGenre")]
        public IActionResult GetGenre()
        {
            var genres = _genreService.GetAll();
            return Ok(genres);
        }

        [HttpPost(Name = "AddGenre")]
        public IActionResult AddGenre([FromBody] Genre genre)
        {
            _genreService.Add(genre);
            return Ok();
        }

    }
}
