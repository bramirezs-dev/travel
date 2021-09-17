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
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("libros");

            builder.Property(p => p.ISBNId).HasMaxLength(13).IsRequired().HasColumnName("ISBN");
            builder.HasKey(p => p.ISBNId);
            builder.Property(p => p.Title).HasMaxLength(45).IsRequired().HasColumnName("titulo");
            builder.Property(p => p.Synopsis).IsRequired().HasColumnName("sinopsis");
            builder.Property(p => p.NumberPages).HasMaxLength(45).IsRequired().HasColumnName("n_paginas");
            
            



            //builder.Property(p => p.Id).HasDefaultValueSql("NEWID()");

        }
    }
}
