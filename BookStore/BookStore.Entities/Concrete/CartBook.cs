using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Entities.Concrete
{
    public class CartBook : BaseEntity
    {
        public int CartId { get; set; }
        public int BookId { get; set; }

        //Relational

        public Cart Cart { get; set; }
        public Book Book { get; set; }
    }
}
