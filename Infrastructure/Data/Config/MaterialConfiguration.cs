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
    public class MaterialConfiguration : IEntityTypeConfiguration<Material>
    {
        public void Configure(EntityTypeBuilder<Material> builder)
        {
            builder.Property(m => m.NrPozDoc).IsRequired();
            builder.Property(m => m.Den).IsRequired().HasMaxLength(50);
            builder.Property(m => m.Cant).IsRequired().HasPrecision(12, 4);
            builder.Property(m => m.Um).IsRequired().HasMaxLength(3);
            builder.Property(m => m.CotaTvaAch).IsRequired();
            builder.Property(m => m.PretAch).IsRequired().HasPrecision(12, 4);
            builder.Property(m => m.BazaAch).IsRequired().HasPrecision(12, 2);
            builder.Property(m => m.TvaAch).IsRequired().HasPrecision(12, 2);
            builder.Property(m => m.ValAch).IsRequired().HasPrecision(12, 2);
            builder.Property(m => m.CotaTva).IsRequired();
            builder.Property(m => m.AdaosProc).IsRequired();
            builder.Property(m => m.Pret).IsRequired().HasPrecision(12, 4);
            builder.Property(m => m.Baza).IsRequired().HasPrecision(12, 2);
            builder.Property(m => m.Tva).IsRequired().HasPrecision(12, 2);
            builder.Property(m => m.Val).IsRequired().HasPrecision(12, 2);
            builder.Property(m => m.CantUtilizata).IsRequired().HasPrecision(12, 4);
            builder.Property(m => m.CantRamasa).IsRequired().HasPrecision(12, 4);
        }
    }
}