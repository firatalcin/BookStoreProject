using DataAccess.Abstract.EntityFramework;
using DataAccess.Contexts;
using DataAccess.Repositories;
using Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class AuthorDal : GenericRepository<Author>, IAuthorDal
    {
        public AuthorDal(BookStoreDbContext context) : base(context)
        {
        }
    }
}