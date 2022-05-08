using BookStore.Business.Abstract;
using BookStore.DataAccess.Abstract;
using BookStore.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Business.Concrete
{
    public class AuthorManager : IAuthorService
    {
        IAuthorDal _authorDal;

        public AuthorManager(IAuthorDal authorDal)
        {
            _authorDal = authorDal;
        }

        public void Add(Author entity)
        {
            _authorDal.Add(entity);
        }

        public void Delete(int id)
        {
            _authorDal.Delete(id);
        }

        public Author Get(int id)
        {
           return _authorDal.Get(x => x.Id == id);
        }

        public List<Author> GetAll()
        {
            return _authorDal.GetAll();
        }

        public void Update(Author entity)
        {
            _authorDal.Update(entity);
        }
    }
}
