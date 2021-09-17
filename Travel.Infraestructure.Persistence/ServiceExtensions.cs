using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Travel.Application.Interfaces;
using Travel.Application.Interfaces.AuthorHasBook;
using Travel.Application.Interfaces.Book;
using Travel.Infraestructure.Persistence.Contexts;
using Travel.Infraestructure.Persistence.Repositories;

namespace Travel.Infraestructure.Persistence
{
    public static class ServiceExtensions
    {
        public static void AddPersistenceInfraestructure(this IServiceCollection service, IConfiguration configuration)
        {

            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                service.AddDbContext<TravelDbContext>(options =>
                    options.UseInMemoryDatabase("TravelConnection"));
            }
            else
            {

                service.AddDbContext<TravelDbContext>(options =>
               options.UseSqlServer(
                   configuration.GetConnectionString("TravelConnection"),
                   b => b.MigrationsAssembly(typeof(TravelDbContext).Assembly.FullName)));
            }

            //service.AddDbContext<TravelDbContext>(options => options.UseSqlServer(configuration
            //                                                                            .GetConnectionString("TravelConnection")
            //                                                                            ,b=>b.MigrationsAssembly(typeof(TravelDbContext).Assembly.FullName)));

            service.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            service.AddTransient<IAuthorHasBookRepositoryAsync, AuthorHasBookRepositoryAsync>();
            service.AddTransient<IBookRepositoryAsync, BookRepositoryAsync>();

        }
    }
}
