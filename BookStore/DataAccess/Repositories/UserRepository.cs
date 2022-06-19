using Core.Model;
using Core.Repositories;
using DataAccess.Contexts;

namespace DataAccess.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(BookStoreDbContext context) : base(context)
        {
        }
    }
}