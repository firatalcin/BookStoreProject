using BookStore.DataAccess.Abstract;
using BookStore.DataAccess.Repository;
using BookStore.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Concrete.EntityFramework
{
    public class EfAuthorDal : Repository<Author>, IAuthorDal
    {
       
    }
}
