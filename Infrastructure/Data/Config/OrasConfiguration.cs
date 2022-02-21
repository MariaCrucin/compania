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
    public class OrasConfiguration : IEntityTypeConfiguration<Oras>
    {
        public void Configure(EntityTypeBuilder<Oras> builder)
        {
            builder.Property(o => o.Den).IsRequired().HasMaxLength(20);

            builder.HasIndex(o => o.Den).IsUnique();
        }
    }
}
