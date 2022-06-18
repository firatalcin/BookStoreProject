using Core.Model;
using DataAccess.Contexts;

namespace DataAccess.Repositories
{
    public class BookRepository : GenericRepository<Book>
    {
        public BookRepository(BookStoreDbContext context) : base(context)
        {
        }
    }
}