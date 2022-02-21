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
    public class ReceptieConfiguration : IEntityTypeConfiguration<Receptie>
    {
        public void Configure(EntityTypeBuilder<Receptie> builder)
        {
            builder.Property(r => r.NrNir).IsRequired();
            builder.Property(r => r.DataNir).IsRequired().HasColumnType("date");
            builder.Property(r => r.TipDocumentId).IsRequired();
            builder.Property(r => r.NrDoc).IsRequired().HasMaxLength(15);
            builder.Property(r => r.DataDoc).IsRequired().HasColumnType("date");
            builder.Property(r => r.Obs).HasMaxLength(10);
            builder.Property(r => r.BazaAch).IsRequired().HasPrecision(12, 2);
            builder.Property(r => r.TvaAch).IsRequired().HasPrecision(12, 2);
            builder.Property(r => r.ValAch).IsRequired().HasPrecision(12, 2);
            builder.Property(r => r.Baza).IsRequired().HasPrecision(12, 2);
            builder.Property(r => r.Tva).IsRequired().HasPrecision(12, 2);
            builder.Property(r => r.Val).IsRequired().HasPrecision(12, 2);
            builder.Property(r => r.FirmaId).IsRequired();
            builder.Property(r => r.FurnizorId).IsRequired();
            builder.HasIndex(r => new { r.FurnizorId, r.DataDoc, r.NrDoc }).IsUnique();
            builder.HasIndex(f => f.NrNir).IsUnique();

            // pt relatie unidirectionala
            //builder
            //    .HasOne(f => f.Furnizor)
            //    .WithMany()
            //    .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(f => f.Furnizor)
                .WithMany(r => r.Receptii)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}