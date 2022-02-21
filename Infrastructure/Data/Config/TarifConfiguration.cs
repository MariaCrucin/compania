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
    public class TarifConfiguration : IEntityTypeConfiguration<Tarif>
    {
        public void Configure(EntityTypeBuilder<Tarif> builder)
        {
            builder.ToTable("Tarife");
            //builder.HasKey(t => new { t.ClientId, t.ServiciuId });
            builder.Property(t => t.Pret).HasPrecision(10, 2);
            builder.HasIndex(t => new { t.ClientId, t.ServiciuId }).IsUnique();
        }
    }
}
