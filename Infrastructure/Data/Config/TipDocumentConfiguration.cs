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
    public class TipDocumentConfiguration : IEntityTypeConfiguration<TipDocument>
    {
        public void Configure(EntityTypeBuilder<TipDocument> builder)
        {
            builder.Property(t => t.Den).IsRequired().HasMaxLength(25);
            builder.Property(t => t.Cod).IsRequired().HasMaxLength(2);
        }
    }
}