using Core.Model;
using DataAccess.Contexts;

namespace DataAccess.Repositories
{
    public class GenreRepository : GenericRepository<Genre>
    {
        public GenreRepository(BookStoreDbContext context) : base(context)
        {
        }
    }
}