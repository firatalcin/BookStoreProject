using Core.Model;
using Core.Repositories;
using DataAccess.Contexts;

namespace DataAccess.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(BookStoreDbContext context) : base(context)
        {
        }
    }
}