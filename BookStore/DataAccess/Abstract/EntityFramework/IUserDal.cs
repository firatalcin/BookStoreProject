using DataAccess.Repositories;
using Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract.EntityFramework
{
    public interface IUserDal : IGenericRepository<User>
    {
    }
}