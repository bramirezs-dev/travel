﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Application.DTOs
{
    public class AuthorHasBookDTO
    {
        public AuthorDTO Author { get; set; }
        public List<BookDTO> Books { get; set; }
    }
}
