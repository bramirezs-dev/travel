using AutoMapper;
using GenFu;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Travel.Application.DTOs;
using Travel.Application.Features.Book.Querys.GetAllBooks;
using Travel.Domain.Entities;
using Travel.Infraestructure.Persistence.Contexts;
using Travel.Infraestructure.Persistence.Repositories;
using Xunit;
namespace Travel.Unit
{
    public class BooksServiceTest
    {

        private IEnumerable<Book> GetDataTestBook() {

            Random rnd = new Random();
            int month = rnd.Next(1, 1000);

            A.Configure<BookDTO>().Fill(x => x.Title).AsArticleTitle()
                                   .Fill(x => x.ISBNId, () => { return month; })
                                   .Fill(x => x.Editorial.Name, () => { return "prueba"; })
                                   .Fill(x => x.Editorial.Id, () => { return month; });

            var lista = A.ListOf<Book>(30);

            lista[0].ISBNId = 1001;

            return lista;
        }


        private Mock<TravelDbContext> CreateContext() {

            

            var dataTest = GetDataTestBook().AsQueryable();
            var dbSet = new Mock<DbSet<Book>>();
            dbSet.As<IQueryable<Book>>().Setup(x=>x.Provider).Returns(dataTest.Provider);
            dbSet.As<IQueryable<Book>>().Setup(x => x.Expression).Returns(dataTest.Expression);
            dbSet.As<IQueryable<Book>>().Setup(x => x.ElementType).Returns(dataTest.ElementType);
            dbSet.As<IQueryable<Book>>().Setup(x => x.GetEnumerator()).Returns(dataTest.GetEnumerator());
            dbSet.As<IAsyncEnumerable<Book>>().Setup(x=>x.GetAsyncEnumerator(new System.Threading.CancellationToken()))
                .Returns(new AsyncEnumerator<Book>(dataTest.GetEnumerator()));
            var context = new Mock<TravelDbContext>();

         
            context.Setup(x => x.Books).Returns(dbSet.Object);

            return context;
        }

        [Fact]


        ///Pruaba sin completar falta crear el contexto de pruebas para poder realizar los test correspondiente
        public async void GetAllBooks() {

        /*Linea para poder debbugear la prueba*/
        System.Diagnostics.Debugger.Launch();
            var mockContext = CreateContext();
            var mockRepository = new Mock<BookRepositoryAsync>(mockContext.Object);
            var mapConfig = new MapperConfiguration(cfg => {
                cfg.AddProfile(new MappingTest());
            });

            var mapper = mapConfig.CreateMapper();
            GetAllBooksQueryHandler getAllBooksQueryHandler = new GetAllBooksQueryHandler(mockRepository.Object, mapper);
            GetAllBooksQuery getAllBooksQuery = new GetAllBooksQuery();

            var lista=await getAllBooksQueryHandler.Handle(getAllBooksQuery, new System.Threading.CancellationToken());
            Assert.True(lista.Data.Any());
        }
    }
}
