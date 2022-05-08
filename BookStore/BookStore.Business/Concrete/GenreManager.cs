using BookStore.Business.Abstract;
using BookStore.DataAccess.Abstract;
using BookStore.Entities.Concrete;
using System;
using System.Collections.Generic;

namespace BookStore.Business.Concrete
{
    public class GenreManager : IGenreService
    {
        IGenreDal _genreDal;

        public GenreManager(IGenreDal genreDal)
        {
            _genreDal = genreDal;
        }

        public void Add(Genre entity)
        {
            _genreDal.Add(entity);
        }

        public void Delete(int id)
        {
            _genreDal.Delete(id);
        }

        public Genre Get(int id)
        {
            return _genreDal.Get(x => x.Id == id);
        }

        public List<Genre> GetAll()
        {
            return _genreDal.GetAll();
        }

        public void Update(Genre entity)
        {
            _genreDal.Update(entity);
        }
    }
}
