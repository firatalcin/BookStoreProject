using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Entities.Concrete
{
    public class Book_Cart : BaseEntity
    {
        public int BookId { get; set; }
        public int CartId { get; set; }
       

        //Relational

        public Cart Cart { get; set; }
        public Book Book { get; set; }
    }
}
