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
    public class DistantaConfiguration : IEntityTypeConfiguration<Distanta>
    {
        public void Configure(EntityTypeBuilder<Distanta> builder)
        {
            builder.Property(d => d.Km).IsRequired();

            builder.HasIndex(d => new { d.PlecareId, d.SosireId }).IsUnique();

            // pt relatie unidirectionala
            builder
                .HasOne(d => d.Plecare)
                .WithMany()
                .HasForeignKey(d => d.PlecareId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(d => d.Sosire)
                .WithMany()
                .HasForeignKey(d => d.SosireId)
                .OnDelete(DeleteBehavior.Restrict);

            // pt relatie biidirectionala
            //builder
            //    .HasOne(d => d.Plecare)
            //    .WithMany(o => o.Plecari)
            //    .HasForeignKey(d => d.PlecareId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //builder
            //    .HasOne(d => d.Sosire)
            //    .WithMany(o => o.Sosiri)
            //    .HasForeignKey(d => d.SosireId)
            //    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
