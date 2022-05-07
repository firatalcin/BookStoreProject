using BookStore.DataAccess.Repository;
using BookStore.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Abstract
{
    public interface IBookDal : IRepository<Book>
    {
        
    }
}
