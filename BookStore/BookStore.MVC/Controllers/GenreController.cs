using BookStore.Business.Abstract;
using BookStore.Business.Concrete;
using BookStore.DataAccess.Concrete.EntityFramework;
using BookStore.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.MVC.Controllers
{
    public class GenreController : Controller
    {
        GenreManager genreManager = new GenreManager(new EfGenreDal());

        //public GenreController(IGenreService genreService)
        //{
        //    _genreService = genreService;
        //}

        public IActionResult Index()
        {
            var list = genreManager.GetAll();
            return View(list);
        }

        public IActionResult AddGenre()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddGenre(Genre genre)
        {
            genreManager.Add(genre); 
            return RedirectToAction("Index");
        }
    }
}
