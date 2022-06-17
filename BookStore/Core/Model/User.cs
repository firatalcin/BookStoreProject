using Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}