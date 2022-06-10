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
        public int AuthorId { get; set; }
        public int GenreId { get; set; }

        public Author Author { get; set; }
    }
}