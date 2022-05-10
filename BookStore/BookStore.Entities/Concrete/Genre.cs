using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Entities.Concrete
{
    public class Genre : BaseEntity
    {
        public string Name { get; set; }

 
        //Relational
        public ICollection<Book> Books { get; set; }
    }
}
