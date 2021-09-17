using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Domain.Entities;

namespace Travel.Infraestructure.Persistence.Configurations
{
    public class AuthorHasBookConfiguration : IEntityTypeConfiguration<AuthorHasBook>
    {
        public void Configure(EntityTypeBuilder<AuthorHasBook> builder)
        {
            builder.ToTable("autores_has_libros");

            //builder.Property(p=>p.AuthorsId).HasMaxLength(10).IsRequired().HasColumnName("autores_id");
            //builder.Property(p => p.BooksISBNId).HasMaxLength(13).IsRequired().HasColumnName("libros_ISBN");

        }
    }
}
