using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Domain.Common;

namespace Travel.Domain.Entities
{
    public class Author:BaseEntity
    {
        public string Name { get; set; }
        public string SureName { get; set; }

        public virtual ICollection<AuthorHasBook> AuthorHasBooks { get; set; }
    }
}
