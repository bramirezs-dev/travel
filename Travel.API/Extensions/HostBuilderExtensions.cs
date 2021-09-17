using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel.Domain.Entities;
using Travel.Infraestructure.Persistence.Contexts;

namespace Travel.API.Extensions
{
    public static class HostBuilderExtensions
    {
        public static IHost SeedData(this IHost host) {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var travelDbContext = services.GetRequiredService<TravelDbContext>();
                // crear la base de datos y las migraciones que esten pendientes
                travelDbContext.Database.Migrate();
                
                if (!travelDbContext.Books.Any())
                {
                    SeedDataTables(travelDbContext);
                }
            }

            return host;
        }

        public static void SeedDataTables(TravelDbContext travelDbContext) {
            List<Editorial> editorial = new List<Editorial>
            {
                new Editorial(){ Headquarters="Bogota",Name="Panamericana"},
                new Editorial(){ Headquarters="Cali",Name="Acantilado"},
                new Editorial(){ Headquarters="Medellin",Name="Aguilar"},
                new Editorial(){ Headquarters="Manizales",Name="Akal"},
                new Editorial(){ Headquarters="Bogota",Name="Alba"},
                new Editorial(){ Headquarters="Bogota",Name="Alfaguara"},
                new Editorial(){ Headquarters="Pereira",Name="Alianza"},
                new Editorial(){ Headquarters="Bogota",Name="Almadía"},
                new Editorial(){ Headquarters="Santa Marta",Name="Anagrama"},
                new Editorial(){ Headquarters="Bogota",Name="Tecnos "},
            };

            travelDbContext.Editorials.AddRange(editorial);
            travelDbContext.SaveChangesAsync().Wait();
            List<Author> Autore = new List<Author> {

                new Author {Name="William",SureName=" Shakespeare" },
                new Author {Name="James ",SureName=" Joyce" },
                new Author {Name="George ",SureName=" Orwell" },
                new Author {Name="Charles ",SureName=" Dickens" },
                new Author {Name="Ernest ",SureName=" Hemmingway" },
                new Author {Name="Gabriel",SureName=" Márquez" },
            };

            travelDbContext.Authors.AddRange(Autore);
            travelDbContext.SaveChangesAsync().Wait();
            List<Book> books = new List<Book> {
                new Book{ Editorial=editorial[0],NumberPages="200",Title="La mayor aventura jamás contada."
                ,Synopsis=@"Lorem Ipsum es simplemente el texto de relleno de las imprentas y archivos de texto. 
                            Lorem Ipsum ha sido el texto de relleno estándar de las industrias desde el año 1500, 
                            cuando un impresor (N. del T. persona que se dedica a la imprenta) desconocido usó una 
                            galería de textos y los mezcló de tal manera que logró hacer un libro de textos especimen. No sólo sobrevivió 500 años
                          , sino que tambien ingresó como texto de relleno en documentos electrónicos
                          , quedando esencialmente igual al original. 
                            Fue popularizado en los 60s con la creación de las hojas Letraset, las cuales contenian pasajes de Lorem Ipsum
                           , y más recientemente con software de autoedición, como por ejemplo Aldus PageMaker, el cual incluye versiones de Lorem Ipsum."
                },
                  new Book{ Editorial=editorial[1],NumberPages="200",Title="A la caza del hacker."
                ,Synopsis=@"Lorem Ipsum es simplemente el texto de relleno de las imprentas y archivos de texto. 
                            Lorem Ipsum ha sido el texto de relleno estándar de las industrias desde el año 1500, 
                            cuando un impresor (N. del T. persona que se dedica a la imprenta) desconocido usó una 
                            galería de textos y los mezcló de tal manera que logró hacer un libro de textos especimen. No sólo sobrevivió 500 años
                          , sino que tambien ingresó como texto de relleno en documentos electrónicos
                          , quedando esencialmente igual al original. 
                            Fue popularizado en los 60s con la creación de las hojas Letraset, las cuales contenian pasajes de Lorem Ipsum
                           , y más recientemente con software de autoedición, como por ejemplo Aldus PageMaker, el cual incluye versiones de Lorem Ipsum."
                },
                    new Book{ Editorial=editorial[2],NumberPages="200",Title="El juego más peligroso de la Red."
                ,Synopsis=@"Lorem Ipsum es simplemente el texto de relleno de las imprentas y archivos de texto. 
                            Lorem Ipsum ha sido el texto de relleno estándar de las industrias desde el año 1500, 
                            cuando un impresor (N. del T. persona que se dedica a la imprenta) desconocido usó una 
                            galería de textos y los mezcló de tal manera que logró hacer un libro de textos especimen. No sólo sobrevivió 500 años
                          , sino que tambien ingresó como texto de relleno en documentos electrónicos
                          , quedando esencialmente igual al original. 
                            Fue popularizado en los 60s con la creación de las hojas Letraset, las cuales contenian pasajes de Lorem Ipsum
                           , y más recientemente con software de autoedición, como por ejemplo Aldus PageMaker, el cual incluye versiones de Lorem Ipsum."
                },
                      new Book{ Editorial=editorial[1],NumberPages="200",Title="Los vigilantes de Marte"
                ,Synopsis=@"Lorem Ipsum es simplemente el texto de relleno de las imprentas y archivos de texto. 
                            Lorem Ipsum ha sido el texto de relleno estándar de las industrias desde el año 1500, 
                            cuando un impresor (N. del T. persona que se dedica a la imprenta) desconocido usó una 
                            galería de textos y los mezcló de tal manera que logró hacer un libro de textos especimen. No sólo sobrevivió 500 años
                          , sino que tambien ingresó como texto de relleno en documentos electrónicos
                          , quedando esencialmente igual al original. 
                            Fue popularizado en los 60s con la creación de las hojas Letraset, las cuales contenian pasajes de Lorem Ipsum
                           , y más recientemente con software de autoedición, como por ejemplo Aldus PageMaker, el cual incluye versiones de Lorem Ipsum."
                },
                        new Book{ Editorial=editorial[2],NumberPages="200",Title="Juventud en rebeldía"
                ,Synopsis=@"Lorem Ipsum es simplemente el texto de relleno de las imprentas y archivos de texto. 
                            Lorem Ipsum ha sido el texto de relleno estándar de las industrias desde el año 1500, 
                            cuando un impresor (N. del T. persona que se dedica a la imprenta) desconocido usó una 
                            galería de textos y los mezcló de tal manera que logró hacer un libro de textos especimen. No sólo sobrevivió 500 años
                          , sino que tambien ingresó como texto de relleno en documentos electrónicos
                          , quedando esencialmente igual al original. 
                            Fue popularizado en los 60s con la creación de las hojas Letraset, las cuales contenian pasajes de Lorem Ipsum
                           , y más recientemente con software de autoedición, como por ejemplo Aldus PageMaker, el cual incluye versiones de Lorem Ipsum."
                },
                          new Book{ Editorial=editorial[3],NumberPages="200",Title="El secreto que escondía el patio del colegio."
                ,Synopsis=@"Lorem Ipsum es simplemente el texto de relleno de las imprentas y archivos de texto. 
                            Lorem Ipsum ha sido el texto de relleno estándar de las industrias desde el año 1500, 
                            cuando un impresor (N. del T. persona que se dedica a la imprenta) desconocido usó una 
                            galería de textos y los mezcló de tal manera que logró hacer un libro de textos especimen. No sólo sobrevivió 500 años
                          , sino que tambien ingresó como texto de relleno en documentos electrónicos
                          , quedando esencialmente igual al original. 
                            Fue popularizado en los 60s con la creación de las hojas Letraset, las cuales contenian pasajes de Lorem Ipsum
                           , y más recientemente con software de autoedición, como por ejemplo Aldus PageMaker, el cual incluye versiones de Lorem Ipsum."
                },
                            new Book{ Editorial=editorial[4],NumberPages="200",Title="Aquel primer verano."
                ,Synopsis=@"Lorem Ipsum es simplemente el texto de relleno de las imprentas y archivos de texto. 
                            Lorem Ipsum ha sido el texto de relleno estándar de las industrias desde el año 1500, 
                            cuando un impresor (N. del T. persona que se dedica a la imprenta) desconocido usó una 
                            galería de textos y los mezcló de tal manera que logró hacer un libro de textos especimen. No sólo sobrevivió 500 años
                          , sino que tambien ingresó como texto de relleno en documentos electrónicos
                          , quedando esencialmente igual al original. 
                            Fue popularizado en los 60s con la creación de las hojas Letraset, las cuales contenian pasajes de Lorem Ipsum
                           , y más recientemente con software de autoedición, como por ejemplo Aldus PageMaker, el cual incluye versiones de Lorem Ipsum."
                },
                new Book{ Editorial=editorial[5],NumberPages="200",Title="El perro que no sabía ladrar"
                ,Synopsis=@"Lorem Ipsum es simplemente el texto de relleno de las imprentas y archivos de texto. 
                            Lorem Ipsum ha sido el texto de relleno estándar de las industrias desde el año 1500, 
                            cuando un impresor (N. del T. persona que se dedica a la imprenta) desconocido usó una 
                            galería de textos y los mezcló de tal manera que logró hacer un libro de textos especimen. No sólo sobrevivió 500 años
                          , sino que tambien ingresó como texto de relleno en documentos electrónicos
                          , quedando esencialmente igual al original. 
                            Fue popularizado en los 60s con la creación de las hojas Letraset, las cuales contenian pasajes de Lorem Ipsum
                           , y más recientemente con software de autoedición, como por ejemplo Aldus PageMaker, el cual incluye versiones de Lorem Ipsum."
                },

                new Book{ Editorial=editorial[6],NumberPages="200",Title="El patinete mágico"
                ,Synopsis=@"Lorem Ipsum es simplemente el texto de relleno de las imprentas y archivos de texto. 
                            Lorem Ipsum ha sido el texto de relleno estándar de las industrias desde el año 1500, 
                            cuando un impresor (N. del T. persona que se dedica a la imprenta) desconocido usó una 
                            galería de textos y los mezcló de tal manera que logró hacer un libro de textos especimen. No sólo sobrevivió 500 años
                          , sino que tambien ingresó como texto de relleno en documentos electrónicos
                          , quedando esencialmente igual al original. 
                            Fue popularizado en los 60s con la creación de las hojas Letraset, las cuales contenian pasajes de Lorem Ipsum
                           , y más recientemente con software de autoedición, como por ejemplo Aldus PageMaker, el cual incluye versiones de Lorem Ipsum."
                },
                new Book{ Editorial=editorial[7],NumberPages="200",Title="Cuando el bosque habla"
                ,Synopsis=@"Lorem Ipsum es simplemente el texto de relleno de las imprentas y archivos de texto. 
                            Lorem Ipsum ha sido el texto de relleno estándar de las industrias desde el año 1500, 
                            cuando un impresor (N. del T. persona que se dedica a la imprenta) desconocido usó una 
                            galería de textos y los mezcló de tal manera que logró hacer un libro de textos especimen. No sólo sobrevivió 500 años
                          , sino que tambien ingresó como texto de relleno en documentos electrónicos
                          , quedando esencialmente igual al original. 
                            Fue popularizado en los 60s con la creación de las hojas Letraset, las cuales contenian pasajes de Lorem Ipsum
                           , y más recientemente con software de autoedición, como por ejemplo Aldus PageMaker, el cual incluye versiones de Lorem Ipsum."
                },
                new Book{ Editorial=editorial[8],NumberPages="200",Title="Luisa y el laberinto encantado"
                ,Synopsis=@"Lorem Ipsum es simplemente el texto de relleno de las imprentas y archivos de texto. 
                            Lorem Ipsum ha sido el texto de relleno estándar de las industrias desde el año 1500, 
                            cuando un impresor (N. del T. persona que se dedica a la imprenta) desconocido usó una 
                            galería de textos y los mezcló de tal manera que logró hacer un libro de textos especimen. No sólo sobrevivió 500 años
                          , sino que tambien ingresó como texto de relleno en documentos electrónicos
                          , quedando esencialmente igual al original. 
                            Fue popularizado en los 60s con la creación de las hojas Letraset, las cuales contenian pasajes de Lorem Ipsum
                           , y más recientemente con software de autoedición, como por ejemplo Aldus PageMaker, el cual incluye versiones de Lorem Ipsum."
                },
                new Book{ Editorial=editorial[9],NumberPages="200",Title="¿Dónde se esconde el capitán...?"
                ,Synopsis=@"Lorem Ipsum es simplemente el texto de relleno de las imprentas y archivos de texto. 
                            Lorem Ipsum ha sido el texto de relleno estándar de las industrias desde el año 1500, 
                            cuando un impresor (N. del T. persona que se dedica a la imprenta) desconocido usó una 
                            galería de textos y los mezcló de tal manera que logró hacer un libro de textos especimen. No sólo sobrevivió 500 años
                          , sino que tambien ingresó como texto de relleno en documentos electrónicos
                          , quedando esencialmente igual al original. 
                            Fue popularizado en los 60s con la creación de las hojas Letraset, las cuales contenian pasajes de Lorem Ipsum
                           , y más recientemente con software de autoedición, como por ejemplo Aldus PageMaker, el cual incluye versiones de Lorem Ipsum."
                },
                new Book{ Editorial=editorial[1],NumberPages="200",Title="El invierno más frío sin ti"
                ,Synopsis=@"Lorem Ipsum es simplemente el texto de relleno de las imprentas y archivos de texto. 
                            Lorem Ipsum ha sido el texto de relleno estándar de las industrias desde el año 1500, 
                            cuando un impresor (N. del T. persona que se dedica a la imprenta) desconocido usó una 
                            galería de textos y los mezcló de tal manera que logró hacer un libro de textos especimen. No sólo sobrevivió 500 años
                          , sino que tambien ingresó como texto de relleno en documentos electrónicos
                          , quedando esencialmente igual al original. 
                            Fue popularizado en los 60s con la creación de las hojas Letraset, las cuales contenian pasajes de Lorem Ipsum
                           , y más recientemente con software de autoedición, como por ejemplo Aldus PageMaker, el cual incluye versiones de Lorem Ipsum."
                },
                new Book{ Editorial=editorial[0],NumberPages="200",Title="La mayor aventura jamás contada."
                ,Synopsis=@"Lorem Ipsum es simplemente el texto de relleno de las imprentas y archivos de texto. 
                            Lorem Ipsum ha sido el texto de relleno estándar de las industrias desde el año 1500, 
                            cuando un impresor (N. del T. persona que se dedica a la imprenta) desconocido usó una 
                            galería de textos y los mezcló de tal manera que logró hacer un libro de textos especimen. No sólo sobrevivió 500 años
                          , sino que tambien ingresó como texto de relleno en documentos electrónicos
                          , quedando esencialmente igual al original. 
                            Fue popularizado en los 60s con la creación de las hojas Letraset, las cuales contenian pasajes de Lorem Ipsum
                           , y más recientemente con software de autoedición, como por ejemplo Aldus PageMaker, el cual incluye versiones de Lorem Ipsum."
                },
                  new Book{ Editorial=editorial[1],NumberPages="200",Title="A la caza del hacker."
                ,Synopsis=@"Lorem Ipsum es simplemente el texto de relleno de las imprentas y archivos de texto. 
                            Lorem Ipsum ha sido el texto de relleno estándar de las industrias desde el año 1500, 
                            cuando un impresor (N. del T. persona que se dedica a la imprenta) desconocido usó una 
                            galería de textos y los mezcló de tal manera que logró hacer un libro de textos especimen. No sólo sobrevivió 500 años
                          , sino que tambien ingresó como texto de relleno en documentos electrónicos
                          , quedando esencialmente igual al original. 
                            Fue popularizado en los 60s con la creación de las hojas Letraset, las cuales contenian pasajes de Lorem Ipsum
                           , y más recientemente con software de autoedición, como por ejemplo Aldus PageMaker, el cual incluye versiones de Lorem Ipsum."
                },
                    new Book{ Editorial=editorial[2],NumberPages="200",Title="El juego más peligroso de la Red."
                ,Synopsis=@"Lorem Ipsum es simplemente el texto de relleno de las imprentas y archivos de texto. 
                            Lorem Ipsum ha sido el texto de relleno estándar de las industrias desde el año 1500, 
                            cuando un impresor (N. del T. persona que se dedica a la imprenta) desconocido usó una 
                            galería de textos y los mezcló de tal manera que logró hacer un libro de textos especimen. No sólo sobrevivió 500 años
                          , sino que tambien ingresó como texto de relleno en documentos electrónicos
                          , quedando esencialmente igual al original. 
                            Fue popularizado en los 60s con la creación de las hojas Letraset, las cuales contenian pasajes de Lorem Ipsum
                           , y más recientemente con software de autoedición, como por ejemplo Aldus PageMaker, el cual incluye versiones de Lorem Ipsum."
                },
                      new Book{ Editorial=editorial[1],NumberPages="200",Title="Los vigilantes de Marte"
                ,Synopsis=@"Lorem Ipsum es simplemente el texto de relleno de las imprentas y archivos de texto. 
                            Lorem Ipsum ha sido el texto de relleno estándar de las industrias desde el año 1500, 
                            cuando un impresor (N. del T. persona que se dedica a la imprenta) desconocido usó una 
                            galería de textos y los mezcló de tal manera que logró hacer un libro de textos especimen. No sólo sobrevivió 500 años
                          , sino que tambien ingresó como texto de relleno en documentos electrónicos
                          , quedando esencialmente igual al original. 
                            Fue popularizado en los 60s con la creación de las hojas Letraset, las cuales contenian pasajes de Lorem Ipsum
                           , y más recientemente con software de autoedición, como por ejemplo Aldus PageMaker, el cual incluye versiones de Lorem Ipsum."
                },
                        new Book{ Editorial=editorial[2],NumberPages="200",Title="Juventud en rebeldía"
                ,Synopsis=@"Lorem Ipsum es simplemente el texto de relleno de las imprentas y archivos de texto. 
                            Lorem Ipsum ha sido el texto de relleno estándar de las industrias desde el año 1500, 
                            cuando un impresor (N. del T. persona que se dedica a la imprenta) desconocido usó una 
                            galería de textos y los mezcló de tal manera que logró hacer un libro de textos especimen. No sólo sobrevivió 500 años
                          , sino que tambien ingresó como texto de relleno en documentos electrónicos
                          , quedando esencialmente igual al original. 
                            Fue popularizado en los 60s con la creación de las hojas Letraset, las cuales contenian pasajes de Lorem Ipsum
                           , y más recientemente con software de autoedición, como por ejemplo Aldus PageMaker, el cual incluye versiones de Lorem Ipsum."
                },
                          new Book{ Editorial=editorial[3],NumberPages="200",Title="El secreto que escondía el patio del colegio."
                ,Synopsis=@"Lorem Ipsum es simplemente el texto de relleno de las imprentas y archivos de texto. 
                            Lorem Ipsum ha sido el texto de relleno estándar de las industrias desde el año 1500, 
                            cuando un impresor (N. del T. persona que se dedica a la imprenta) desconocido usó una 
                            galería de textos y los mezcló de tal manera que logró hacer un libro de textos especimen. No sólo sobrevivió 500 años
                          , sino que tambien ingresó como texto de relleno en documentos electrónicos
                          , quedando esencialmente igual al original. 
                            Fue popularizado en los 60s con la creación de las hojas Letraset, las cuales contenian pasajes de Lorem Ipsum
                           , y más recientemente con software de autoedición, como por ejemplo Aldus PageMaker, el cual incluye versiones de Lorem Ipsum."
                },
                            new Book{ Editorial=editorial[4],NumberPages="200",Title="Aquel primer verano."
                ,Synopsis=@"Lorem Ipsum es simplemente el texto de relleno de las imprentas y archivos de texto. 
                            Lorem Ipsum ha sido el texto de relleno estándar de las industrias desde el año 1500, 
                            cuando un impresor (N. del T. persona que se dedica a la imprenta) desconocido usó una 
                            galería de textos y los mezcló de tal manera que logró hacer un libro de textos especimen. No sólo sobrevivió 500 años
                          , sino que tambien ingresó como texto de relleno en documentos electrónicos
                          , quedando esencialmente igual al original. 
                            Fue popularizado en los 60s con la creación de las hojas Letraset, las cuales contenian pasajes de Lorem Ipsum
                           , y más recientemente con software de autoedición, como por ejemplo Aldus PageMaker, el cual incluye versiones de Lorem Ipsum."
                },
                new Book{ Editorial=editorial[5],NumberPages="200",Title="El perro que no sabía ladrar"
                ,Synopsis=@"Lorem Ipsum es simplemente el texto de relleno de las imprentas y archivos de texto. 
                            Lorem Ipsum ha sido el texto de relleno estándar de las industrias desde el año 1500, 
                            cuando un impresor (N. del T. persona que se dedica a la imprenta) desconocido usó una 
                            galería de textos y los mezcló de tal manera que logró hacer un libro de textos especimen. No sólo sobrevivió 500 años
                          , sino que tambien ingresó como texto de relleno en documentos electrónicos
                          , quedando esencialmente igual al original. 
                            Fue popularizado en los 60s con la creación de las hojas Letraset, las cuales contenian pasajes de Lorem Ipsum
                           , y más recientemente con software de autoedición, como por ejemplo Aldus PageMaker, el cual incluye versiones de Lorem Ipsum."
                },
                new Book{ Editorial=editorial[6],NumberPages="200",Title="El patinete mágico"
                ,Synopsis=@"Lorem Ipsum es simplemente el texto de relleno de las imprentas y archivos de texto. 
                            Lorem Ipsum ha sido el texto de relleno estándar de las industrias desde el año 1500, 
                            cuando un impresor (N. del T. persona que se dedica a la imprenta) desconocido usó una 
                            galería de textos y los mezcló de tal manera que logró hacer un libro de textos especimen. No sólo sobrevivió 500 años
                          , sino que tambien ingresó como texto de relleno en documentos electrónicos
                          , quedando esencialmente igual al original. 
                            Fue popularizado en los 60s con la creación de las hojas Letraset, las cuales contenian pasajes de Lorem Ipsum
                           , y más recientemente con software de autoedición, como por ejemplo Aldus PageMaker, el cual incluye versiones de Lorem Ipsum."
                },
                new Book{ Editorial=editorial[7],NumberPages="200",Title="Cuando el bosque habla"
                ,Synopsis=@"Lorem Ipsum es simplemente el texto de relleno de las imprentas y archivos de texto. 
                            Lorem Ipsum ha sido el texto de relleno estándar de las industrias desde el año 1500, 
                            cuando un impresor (N. del T. persona que se dedica a la imprenta) desconocido usó una 
                            galería de textos y los mezcló de tal manera que logró hacer un libro de textos especimen. No sólo sobrevivió 500 años
                          , sino que tambien ingresó como texto de relleno en documentos electrónicos
                          , quedando esencialmente igual al original. 
                            Fue popularizado en los 60s con la creación de las hojas Letraset, las cuales contenian pasajes de Lorem Ipsum
                           , y más recientemente con software de autoedición, como por ejemplo Aldus PageMaker, el cual incluye versiones de Lorem Ipsum."
                },
                new Book{ Editorial=editorial[8],NumberPages="200",Title="Luisa y el laberinto encantado"
                ,Synopsis=@"Lorem Ipsum es simplemente el texto de relleno de las imprentas y archivos de texto. 
                            Lorem Ipsum ha sido el texto de relleno estándar de las industrias desde el año 1500, 
                            cuando un impresor (N. del T. persona que se dedica a la imprenta) desconocido usó una 
                            galería de textos y los mezcló de tal manera que logró hacer un libro de textos especimen. No sólo sobrevivió 500 años
                          , sino que tambien ingresó como texto de relleno en documentos electrónicos
                          , quedando esencialmente igual al original. 
                            Fue popularizado en los 60s con la creación de las hojas Letraset, las cuales contenian pasajes de Lorem Ipsum
                           , y más recientemente con software de autoedición, como por ejemplo Aldus PageMaker, el cual incluye versiones de Lorem Ipsum."
                },
                new Book{ Editorial=editorial[9],NumberPages="200",Title="¿Dónde se esconde el capitán...?"
                ,Synopsis=@"Lorem Ipsum es simplemente el texto de relleno de las imprentas y archivos de texto. 
                            Lorem Ipsum ha sido el texto de relleno estándar de las industrias desde el año 1500, 
                            cuando un impresor (N. del T. persona que se dedica a la imprenta) desconocido usó una 
                            galería de textos y los mezcló de tal manera que logró hacer un libro de textos especimen. No sólo sobrevivió 500 años
                          , sino que tambien ingresó como texto de relleno en documentos electrónicos
                          , quedando esencialmente igual al original. 
                            Fue popularizado en los 60s con la creación de las hojas Letraset, las cuales contenian pasajes de Lorem Ipsum
                           , y más recientemente con software de autoedición, como por ejemplo Aldus PageMaker, el cual incluye versiones de Lorem Ipsum."
                },
                new Book{ Editorial=editorial[4],NumberPages="200",Title="El invierno más frío sin ti"
                ,Synopsis=@"Lorem Ipsum es simplemente el texto de relleno de las imprentas y archivos de texto. 
                            Lorem Ipsum ha sido el texto de relleno estándar de las industrias desde el año 1500, 
                            cuando un impresor (N. del T. persona que se dedica a la imprenta) desconocido usó una 
                            galería de textos y los mezcló de tal manera que logró hacer un libro de textos especimen. No sólo sobrevivió 500 años
                          , sino que tambien ingresó como texto de relleno en documentos electrónicos
                          , quedando esencialmente igual al original. 
                            Fue popularizado en los 60s con la creación de las hojas Letraset, las cuales contenian pasajes de Lorem Ipsum
                           , y más recientemente con software de autoedición, como por ejemplo Aldus PageMaker, el cual incluye versiones de Lorem Ipsum."
                }


            };
            
            travelDbContext.Books.AddRange(books);
            travelDbContext.SaveChangesAsync().Wait();
            List<AuthorHasBook> authorHasBooks = new List<AuthorHasBook> {
                new AuthorHasBook{ Author=Autore[0],Book=books[0] },
                new AuthorHasBook{ Author=Autore[1],Book=books[0] },
                new AuthorHasBook{ Author=Autore[1],Book=books[1] },
                new AuthorHasBook{ Author=Autore[2],Book=books[1] },
                new AuthorHasBook{ Author=Autore[2],Book=books[2] },
                new AuthorHasBook{ Author=Autore[3],Book=books[3] },
                new AuthorHasBook{ Author=Autore[4],Book=books[4] },
                new AuthorHasBook{ Author=Autore[5],Book=books[5] },
                new AuthorHasBook{ Author=Autore[0],Book=books[6] },
                new AuthorHasBook{ Author=Autore[1],Book=books[7] },
                new AuthorHasBook{ Author=Autore[2],Book=books[8] },
                new AuthorHasBook{ Author=Autore[3],Book=books[9] },
                new AuthorHasBook{ Author=Autore[4],Book=books[10] },
                new AuthorHasBook{ Author=Autore[5],Book=books[11] },
                new AuthorHasBook{ Author=Autore[0],Book=books[12] },
                new AuthorHasBook{ Author=Autore[1],Book=books[13] },
                new AuthorHasBook{ Author=Autore[2],Book=books[14] },
                new AuthorHasBook{ Author=Autore[3],Book=books[15] },
                new AuthorHasBook{ Author=Autore[4],Book=books[16] },
                new AuthorHasBook{ Author=Autore[5],Book=books[17] },
                new AuthorHasBook{ Author=Autore[0],Book=books[18] },
                new AuthorHasBook{ Author=Autore[1],Book=books[19] },
                new AuthorHasBook{ Author=Autore[2],Book=books[20] },
                new AuthorHasBook{ Author=Autore[3],Book=books[21] },
                new AuthorHasBook{ Author=Autore[4],Book=books[22] },
                new AuthorHasBook{ Author=Autore[5],Book=books[23] },
                new AuthorHasBook{ Author=Autore[5],Book=books[24] },
                new AuthorHasBook{ Author=Autore[5],Book=books[25] },
            };

            travelDbContext.AuthorHasBooks.AddRange(authorHasBooks);
            travelDbContext.SaveChangesAsync().Wait();
        }
    }
}
