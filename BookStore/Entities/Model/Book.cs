using Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Model
{
    public class Book : BaseEntity
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public int PageCount { get; set; }
        public Guid AuthorId { get; set; }
        public Guid GenreId { get; set; }

        public Author Author { get; set; }
        public Genre Genre { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}