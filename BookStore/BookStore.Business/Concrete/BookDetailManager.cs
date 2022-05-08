using BookStore.Business.Abstract;
using BookStore.DataAccess.Abstract;
using BookStore.DataAccess.Concrete.EntityFramework;
using BookStore.Entities.Concrete;
using System;
using System.Collections.Generic;

namespace BookStore.Business.Concrete
{
    public class BookDetailManager : IBookDetailService
    {
        IBookDetailDal _bookDetailDal;

        public BookDetailManager(IBookDetailDal bookDetailDal)
        {
            _bookDetailDal = bookDetailDal;
        }

        public void Add(BookDetail entity)
        {
            _bookDetailDal.Add(entity);
        }

        public void Delete(int id)
        {
            _bookDetailDal.Delete(id);
        }

        public BookDetail Get(int id)
        {
            return _bookDetailDal.Get(x => x.Id == id);
        }

        public List<BookDetail> GetAll()
        {
            return _bookDetailDal.GetAll();
        }

        public void Update(BookDetail entity)
        {
           _bookDetailDal.Update(entity);
        }
    }
}
