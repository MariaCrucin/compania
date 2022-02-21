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
    public class FurnizorConfiguration : IEntityTypeConfiguration<Furnizor>
    {
        public void Configure(EntityTypeBuilder<Furnizor> builder)
        {
            builder.Property(f => f.AtCif).HasMaxLength(2);
            builder.Property(f => f.NrCif).IsRequired().HasMaxLength(13);
            builder.Property(f => f.PrefixDen).HasMaxLength(3);
            builder.Property(f => f.Den).IsRequired().HasMaxLength(50);

            builder.HasIndex(f => f.NrCif).IsUnique();
        }
    }
}
