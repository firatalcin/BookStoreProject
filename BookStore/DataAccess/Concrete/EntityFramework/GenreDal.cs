using DataAccess.Abstract.EntityFramework;
using DataAccess.Contexts;
using DataAccess.Repositories;
using Entities.Model;

namespace DataAccess.Concrete.EntityFramework
{
    public class GenreDal : GenericRepository<Genre>, IGenreDal
    {
        public GenreDal(BookStoreDbContext context) : base(context)
        {
        }
    }
}