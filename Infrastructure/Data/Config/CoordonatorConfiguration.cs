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
    public class CoordonatorConfiguration : IEntityTypeConfiguration<Coordonator>
    {
        public void Configure(EntityTypeBuilder<Coordonator> builder)
        {
            builder.Property(c => c.Nume).IsRequired().HasMaxLength(25);
            builder.Property(c => c.ClientId).IsRequired();
        }
    }
}
