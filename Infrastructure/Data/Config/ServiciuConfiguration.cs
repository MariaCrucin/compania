using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Config
{
    public class ServiciuConfiguration : IEntityTypeConfiguration<Serviciu>

    {
        public void Configure(EntityTypeBuilder<Serviciu> builder)
        {
            builder.Property(s => s.Cod).IsRequired().HasMaxLength(3);
            builder.Property(s => s.Den).IsRequired().HasMaxLength(50);
            builder.Property(s => s.Um).HasMaxLength(3);
            builder.HasIndex(s => s.Cod).IsUnique();
        }
    }
}
