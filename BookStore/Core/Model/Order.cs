using Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class Order : BaseEntity
    {
        public int BookId { get; set; }
        public int UserId { get; set; }
        public int TotalPrice { get; set; }
        public int Quantity { get; set; }

        public ICollection<Book> Books { get; set; }
        public User User { get; set; }
    }
}