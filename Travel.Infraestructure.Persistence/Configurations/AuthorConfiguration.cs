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
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("autores");

            builder.Property(p => p.Id).HasMaxLength(10).IsRequired().HasColumnName("id");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).HasMaxLength(45).IsRequired().HasColumnName("nombre");
            builder.Property(p => p.SureName).HasMaxLength(45).IsRequired().HasColumnName("apellidos");
            
            //builder.Property(p => p.Id).HasDefaultValueSql("NEWID()");
        }
    }
}
