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
    public class ContConfiguration : IEntityTypeConfiguration<Cont>
    {
        public void Configure(EntityTypeBuilder<Cont> builder)
        {
            builder.Property(c => c.Valuta).IsRequired().HasMaxLength(10);
            builder.Property(c => c.NrCont).IsRequired().HasMaxLength(24);
            builder.Property(c => c.Banca).IsRequired().HasMaxLength(50);
        }
    }
}
