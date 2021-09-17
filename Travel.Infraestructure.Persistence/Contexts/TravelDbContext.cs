using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Travel.Domain.Entities;

namespace Travel.Infraestructure.Persistence.Contexts
{
    public class TravelDbContext:DbContext
    {
        public TravelDbContext()
        {

        }
        public TravelDbContext(DbContextOptions options):base(options)
        {
        }

        //public DbSet<Product> Product { get; set; }
       virtual public DbSet<Author> Authors { get; set; }

       virtual public DbSet<AuthorHasBook> AuthorHasBooks { get; set; }

       virtual public DbSet<Book> Books { get; set; }

       virtual public DbSet<Editorial> Editorials { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                                                       .SelectMany(t=>t.GetProperties())
                                                       .Where(p=>p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.SetColumnType("decimal(18,6)");
            }
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }

    
}
