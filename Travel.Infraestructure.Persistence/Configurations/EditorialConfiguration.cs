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
    public class EditorialConfiguration : IEntityTypeConfiguration<Editorial>
    {
        public void Configure(EntityTypeBuilder<Editorial> builder)
        {
            builder.ToTable("editoriales");

            builder.Property(p => p.Id).HasMaxLength(10).IsRequired().HasColumnName("id");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).HasMaxLength(45).IsRequired().HasColumnName("nombre");
            builder.Property(p => p.Headquarters).HasMaxLength(45).IsRequired().HasColumnName("sede");
            //builder.Property(p => p.Id).HasDefaultValueSql("NEWID()");

        }
    }
}
