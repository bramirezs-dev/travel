using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Domain.Entities;
using Travel.Infraestructure.Persistence.Contexts;

namespace Travel.Unit.Context
{
    public class SeedData
    {
        public static void SeedDataContext(TravelDbContext context) {

            context.Database.EnsureCreated();

            var esditorial = new Editorial
            {
                Id = 1,
                Name = "Panamericana"
            };

            context.Editorials.Add(esditorial);

            var author = new Author
            {
                Id = 1,
                Name = "Pepito Perez"
            };

            context.Authors.Add(author);

            var book = new Book
            {
                ISBNId = 1,
                NumberPages = "265",
                Synopsis = "Resumen1",
                Title = "Hola Mundo desde test unit",
                Editorial= esditorial

            };

            context.Books.Add(book);

            var authorHasBook = new AuthorHasBook
            {
                Id=1,
                Author = author,
                Book = book
            };


            context.AuthorHasBooks.Add(authorHasBook);

        }
    }
}
