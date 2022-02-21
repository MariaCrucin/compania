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
    public class UnitateDeMasuraConfiguration : IEntityTypeConfiguration<UnitateDeMasura>
    {
        public void Configure(EntityTypeBuilder<UnitateDeMasura> builder)
        {
            builder.Property(u => u.Um).IsRequired().HasMaxLength(3);
        }
    }
}
