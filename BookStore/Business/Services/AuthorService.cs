using Core.Model;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class AuthorService : GenericService<Author>, IAuthorService
    {
        public AuthorService(IGenericRepository<Author> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}