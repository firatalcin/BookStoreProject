using BookStore.Business.Abstract;
using BookStore.DataAccess.Abstract;
using BookStore.Entities.Concrete;
using System;
using System.Collections.Generic;

namespace BookStore.Business.Concrete
{
    public class UserTypeManager : IUserTypeService
    {
        IUserTypeDal _userTypeDal;

        public UserTypeManager(IUserTypeDal userTypeDal)
        {
            _userTypeDal = userTypeDal;
        }

        public void Add(UserType entity)
        {
            _userTypeDal.Add(entity);
        }

        public void Delete(int id)
        {
            _userTypeDal.Delete(id);
        }

        public UserType Get(int id)
        {
            return _userTypeDal.Get(x => x.Id == id);
        }

        public List<UserType> GetAll()
        {
            return _userTypeDal.GetAll();
        }

        public void Update(UserType entity)
        {
            _userTypeDal.Update(entity);
        }
    }
}
