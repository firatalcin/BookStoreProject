using BookStore.Business.Abstract;
using BookStore.DataAccess.Abstract;
using BookStore.Entities.Concrete;
using System;
using System.Collections.Generic;

namespace BookStore.Business.Concrete
{
    public class CartManager : ICartService
    {
        ICartDal _cartDal;

        public CartManager(ICartDal cartDal)
        {
            _cartDal = cartDal;
        }

        public void Add(Cart entity)
        {
            _cartDal.Add(entity);
        }

        public void Delete(int id)
        {
            _cartDal.Delete(id);
        }

        public Cart Get(int id)
        {
            return _cartDal.Get(x => x.Id == id);
        }

        public List<Cart> GetAll()
        {
            return _cartDal.GetAll();
        }

        public void Update(Cart entity)
        {
            _cartDal.Update(entity);
        }
    }
}
