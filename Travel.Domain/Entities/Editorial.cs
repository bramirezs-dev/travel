using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Domain.Common;

namespace Travel.Domain.Entities
{
    public class Editorial:BaseEntity
    {
        public string Name { get; set; }

        public string Headquarters { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
