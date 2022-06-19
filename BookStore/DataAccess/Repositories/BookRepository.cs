using Core.Model;
using Core.Repositories;
using DataAccess.Contexts;

namespace DataAccess.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(BookStoreDbContext context) : base(context)
        {
        }
    }
}