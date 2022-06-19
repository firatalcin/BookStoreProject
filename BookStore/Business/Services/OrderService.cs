using Core.Model;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWork;

namespace Business.Services
{
    public class OrderService : GenericService<Order>, IOrderService
    {
        public OrderService(IGenericRepository<Order> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}