using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Travel.Domain.Common;

namespace Travel.Domain.Entities
{
    public class Book
    {

        public int ISBNId { get; set; }
        public string Title { get; set; }

        public string Synopsis { get; set; }

        public string NumberPages { get; set; }

        
        public virtual Editorial Editorial { get; set; }
        
        public virtual ICollection<AuthorHasBook> AuthorHasBooks { get; set; }
    }
}
