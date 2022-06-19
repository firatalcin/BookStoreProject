using Core.Model;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWork;

namespace Business.Services
{
    public class GenreService : GenericService<Genre>, IGenreService
    {
        public GenreService(IGenericRepository<Genre> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}