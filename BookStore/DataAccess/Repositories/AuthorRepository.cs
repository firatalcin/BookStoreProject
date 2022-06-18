using Core.Model;
using DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class AuthorRepository : GenericRepository<Author>
    {
        public AuthorRepository(BookStoreDbContext context) : base(context)
        {
        }
    }
}