using BookStore.Business.Abstract;
using BookStore.DataAccess.Abstract;
using BookStore.Entities.Concrete;
using System;
using System.Collections.Generic;

namespace BookStore.Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public void Add(User entity)
        {
            _userDal.Add(entity);
        }

        public void Delete(int id)
        {
            _userDal.Delete(id);
        }

        public User Get(int id)
        {
            return _userDal.Get(x => x.Id == id);
        }

        public List<User> GetAll()
        {
            return _userDal.GetAll();
        }

        public void Update(User entity)
        {
            _userDal.Update(entity);
        }
    }
}
