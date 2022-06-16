using DataAccess.Abstract.EntityFramework;
using DataAccess.Contexts;
using DataAccess.Repositories;
using Entities.Model;

namespace DataAccess.Concrete.EntityFramework
{
    public class BookDal : GenericRepository<Book>, IBookDal
    {
        public BookDal(BookStoreDbContext context) : base(context)
        {
        }
    }
}