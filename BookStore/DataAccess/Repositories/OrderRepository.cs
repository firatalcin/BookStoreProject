using Core.Model;
using DataAccess.Contexts;

namespace DataAccess.Repositories
{
    public class OrderRepository : GenericRepository<Order>
    {
        public OrderRepository(BookStoreDbContext context) : base(context)
        {
        }
    }
}