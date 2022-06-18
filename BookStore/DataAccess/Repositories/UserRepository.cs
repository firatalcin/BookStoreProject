using Core.Model;
using DataAccess.Contexts;

namespace DataAccess.Repositories
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(BookStoreDbContext context) : base(context)
        {
        }
    }
}