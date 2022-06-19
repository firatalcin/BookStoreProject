using Core.Model;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWork;

namespace Business.Services
{
    public class UserService : GenericService<User>, IUserService
    {
        public UserService(IGenericRepository<User> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}