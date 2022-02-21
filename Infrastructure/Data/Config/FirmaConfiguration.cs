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
    public class FirmaConfiguration : IEntityTypeConfiguration<Firma>
    {
        public void Configure(EntityTypeBuilder<Firma> builder)
        {
            builder.Property(f => f.Den)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(f => f.Sediu1)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(f => f.Sediu2).HasMaxLength(50);

            builder.Property(f => f.CodJudJ).HasMaxLength(2);

            builder.Property(f => f.NrOrdJ).HasMaxLength(5);

            builder.Property(f => f.AnJ).HasMaxLength(4);

            builder.Property(f => f.AtCif).HasMaxLength(2);

            builder.Property(f => f.NrCif)
                .IsRequired()
                .HasMaxLength(13);

            builder.Property(f => f.SeriaFact).HasMaxLength(5);

            builder.Property(f => f.NumeOperator).HasMaxLength(30);

            builder.Property(f => f.Telefon).HasMaxLength(12);

            builder.Property("SiglaUrl").HasMaxLength(25);

            builder.HasIndex(f => f.NrCif).IsUnique();
        }
    }
}
