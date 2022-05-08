using BookStore.Business.Abstract;
using BookStore.DataAccess.Abstract;
using BookStore.Entities.Concrete;
using System;
using System.Collections.Generic;

namespace BookStore.Business.Concrete
{
    public class BookManager : IBookService
    {
        IBookDal _bookDal;

        public BookManager(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }

        public void Add(Book entity)
        {
            _bookDal.Add(entity);
        }

        public void Delete(int id)
        {
            _bookDal.Delete(id);
        }

        public Book Get(int id)
        {
            return _bookDal.Get(x => x.Id == id);
        }

        public List<Book> GetAll()
        {
            return _bookDal.GetAll();
        }

        public void Update(Book entity)
        {
            _bookDal.Update(entity);
        }
    }
}
