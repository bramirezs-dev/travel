using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Domain.Common;

namespace Travel.Domain.Entities
{
    public class AuthorHasBook:BaseEntity
    {

        public virtual Author Author { get; set; }

        public virtual Book Book { get; set; }

    }
}
