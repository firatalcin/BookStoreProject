using Core.Model;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWork;

namespace Business.Services
{
    public class BookService : GenericService<Book>, IBookService
    {
        public BookService(IGenericRepository<Book> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}