using BookStore.Business.Abstract;
using BookStore.DataAccess.Abstract;
using BookStore.Entities.Concrete;
using System;
using System.Collections.Generic;

namespace BookStore.Business.Concrete
{
    public class Book_CartManager : IBook_CartService
    {
        IBook_CartDal _book_CartDal;

        public Book_CartManager(IBook_CartDal book_CartDal)
        {
            _book_CartDal = book_CartDal;
        }

        public void Add(Book_Cart entity)
        {
            _book_CartDal.Add(entity);
        }

        public void Delete(int id)
        {
            _book_CartDal.Delete(id);
        }

        public Book_Cart Get(int id)
        {
            return _book_CartDal.Get(x => x.Id == id);
        }

        public List<Book_Cart> GetAll()
        {
            return _book_CartDal.GetAll();
        }

        public void Update(Book_Cart entity)
        {
            _book_CartDal.Update(entity);
        }
    }
}
