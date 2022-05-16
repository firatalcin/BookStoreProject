using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Entities.Concrete
{
    public class Cart : BaseEntity
    {
        public DateTime OrderDate { get; set; } 
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }

        public Cart()
        {
            OrderDate = DateTime.Now;
        }

        //Relational

        public Book Book { get; set; }
        public User User { get; set; }


    }
}
