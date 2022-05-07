using BookStore.DataAccess.Repository;
using BookStore.Entities.Concrete;

namespace BookStore.DataAccess.Abstract
{
    public interface IUserDal : IRepository<User>
    {

    }
}
