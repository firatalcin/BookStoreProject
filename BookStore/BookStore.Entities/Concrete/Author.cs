using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Entities.Concrete
{
    public class Author : BaseEntity
    {
        public string AuthorName { get; set; }
        public string AuthorSurname { get; set; }

        public Author()
        {
            Books = new HashSet<Book>();
        }

        //Relational

        public ICollection<Book> Books { get; set; }
    }
}
