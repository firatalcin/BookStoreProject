using DataAccess.Abstract.EntityFramework;
using DataAccess.Contexts;
using DataAccess.Repositories;
using Entities.Model;

namespace DataAccess.Concrete.EntityFramework
{
    public class OrderDal : GenericRepository<Order>, IOrderDal
    {
        public OrderDal(BookStoreDbContext context) : base(context)
        {
        }
    }
}