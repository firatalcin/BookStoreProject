﻿using BookStore.Business.Abstract;
using BookStore.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public IActionResult GetAuthor()
        {
            var authorList = _authorService.GetAll();
            return Ok(authorList);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var author = _authorService.Get(id);
            return Ok(author);
        }

        [HttpPut("{id}")]
        public IActionResult EditAuthor(int id, [FromBody] Author author)
        {
            var UpdatedAuthor = _authorService.Get(id);
            UpdatedAuthor.AuthorName = UpdatedAuthor.AuthorName == default ? UpdatedAuthor.AuthorName : author.AuthorName;
            UpdatedAuthor.AuthorSurname = UpdatedAuthor.AuthorSurname == default ? UpdatedAuthor.AuthorSurname : author.AuthorSurname;
            _authorService.Update(UpdatedAuthor);
            return Ok();
        }

        [HttpPost]
        public IActionResult AddAuthor([FromBody] Author author)
        {
            author.Books = null;
            _authorService.Add(author);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            _authorService.Delete(id);
            return Ok();
        }
    }
}