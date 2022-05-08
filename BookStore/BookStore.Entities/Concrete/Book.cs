using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Entities.Concrete
{
    public class Book : BaseEntity
    {
        public string BookName { get; set; }
        public int UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int PageCount { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public int BookDetailId { get; set; }

        public Book()
        {
            Cart_Books = new HashSet<Book_Cart>();
        }

        //Relational

        public Author Author { get; set; }
        public Genre Genre { get; set; }
        public BookDetail BookDetail { get; set; }

        public ICollection<Book_Cart> Cart_Books { get; set; }
    }
}
