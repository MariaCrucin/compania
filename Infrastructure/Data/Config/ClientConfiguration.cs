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
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.Property(f => f.Den)
               .IsRequired()
               .HasMaxLength(50);

            builder.Property(f => f.Sediu1)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(f => f.Sediu2).HasMaxLength(50);

            builder.Property(c => c.NrCont).HasMaxLength(24);

            builder.Property(c => c.Banca).HasMaxLength(50);

            builder.Property(f => f.CodJudJ).HasMaxLength(2);

            builder.Property(f => f.NrOrdJ).HasMaxLength(5);

            builder.Property(f => f.AnJ).HasMaxLength(4);

            builder.Property(f => f.AtCif).HasMaxLength(2);

            builder.Property(f => f.NrCif)
                .IsRequired()
                .HasMaxLength(13);

            builder.Property(c => c.NumarContract).HasMaxLength(10);

            builder.Property(c => c.DataContract).HasColumnType("date");

            builder.Property(c => c.Tara).HasMaxLength(50);

            builder.Property(c => c.NrTva).HasMaxLength(10);

            builder.HasIndex(c => new { c.FirmaId, c.NrCif }).IsUnique();

        }
    }
}
