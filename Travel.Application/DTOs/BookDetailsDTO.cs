using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Application.DTOs
{
    public class BookDetailsDTO
    {
        public string Title { get; set; }
        public string Synopsis { get; set; }
        public string NumberPages { get; set; }
        public List<AuthorDTO> Author { get; set; }
        public EditorialDTO Editorial { get; set; }
    }
}
