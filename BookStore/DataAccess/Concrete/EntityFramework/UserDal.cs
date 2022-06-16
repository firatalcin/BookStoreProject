using DataAccess.Abstract.EntityFramework;
using DataAccess.Contexts;
using DataAccess.Repositories;
using Entities.Model;

namespace DataAccess.Concrete.EntityFramework
{
    public class UserDal : GenericRepository<User>, IUserDal
    {
        public UserDal(BookStoreDbContext context) : base(context)
        {
        }
    }
}