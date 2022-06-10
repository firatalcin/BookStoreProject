using Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Model
{
    public class Order : BaseEntity
    {
        public Guid BookId { get; set; }
        public Guid UserId { get; set; }
        public int TotalPrice { get; set; }
        public int Quantity { get; set; }

        public ICollection<Book> Books { get; set; }
        public User User { get; set; }
    }
}