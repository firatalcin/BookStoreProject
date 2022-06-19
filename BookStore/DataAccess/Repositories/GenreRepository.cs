using Core.Model;
using Core.Repositories;
using DataAccess.Contexts;

namespace DataAccess.Repositories
{
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        public GenreRepository(BookStoreDbContext context) : base(context)
        {
        }
    }
}