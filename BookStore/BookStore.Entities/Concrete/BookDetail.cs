using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Entities.Concrete
{
    public class BookDetail : BaseEntity
    {
        public int BookID { get; set; }
        public string PublisherName { get; set; }
        public DateTime? PublishedDate { get; set; }
        
        //Relational

        public Book Book { get; set; }
    }
}
