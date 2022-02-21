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
    public class MagazinConfiguration : IEntityTypeConfiguration<Magazin>
    {
        public void Configure(EntityTypeBuilder<Magazin> builder)
        {
            builder.Property(m => m.Den).IsRequired().HasMaxLength(50);
            builder.Property(m => m.Numar).IsRequired();
            builder.Property(m => m.ComandaCadru).HasMaxLength(10);
            builder.HasIndex(m => new { m.ClientId, m.Numar }).IsUnique();
        }
    }
}
