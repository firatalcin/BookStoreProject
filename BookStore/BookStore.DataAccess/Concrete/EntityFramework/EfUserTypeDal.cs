using BookStore.DataAccess.Abstract;
using BookStore.DataAccess.Repository;
using BookStore.Entities.Concrete;

namespace BookStore.DataAccess.Concrete.EntityFramework
{
    public class EfUserTypeDal : Repository<UserType>, IUserTypeDal
    {

    }


}
