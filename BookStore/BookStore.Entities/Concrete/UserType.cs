using BookStore.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Entities.Concrete
{
    public class UserType : BaseEntity
    {
        public Role Role { get; set; }

       

        //Relational

        public ICollection<User> Users { get; set; }
    }
}
