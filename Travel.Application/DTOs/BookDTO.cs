using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Application.DTOs
{
    public class BookDTO 
    {
        public int ISBNId { get; set; }
        public string Title { get; set; }

        public string Synopsis { get; set; }

        public string NumberPages { get; set; }

        public EditorialDTO Editorial { get; set; }
    }
}
