using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class CompContext : DbContext
    {
        public CompContext(DbContextOptions<CompContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands{ get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Firma> Firme { get; set; }
        public DbSet<Cont> Conturi { get; set; }
        public DbSet<Client> Clienti { get; set; }
        public DbSet<Pozitia> Pozitii { get; set; }
        public DbSet<Magazin> Magazine { get; set; }
        public DbSet<Furnizor> Furnizori { get; set; }
        public DbSet<Receptie> Receptii { get; set; }
        public DbSet<UnitateDeMasura> UnitatiDeMasura { get; set; }
        public DbSet<Material> Materiale { get; set; }
        public DbSet<TipDocument> TipuriDocument { get; set; }
        public DbSet<Coordonator> Coordonatori { get; set; }
        public DbSet<Serviciu> Servicii { get; set; }
        public DbSet<Oras> Orase { get; set; }
        public DbSet<Distanta> Distante { get; set; }

        // suprascriem aceasta metoda ca sa fie luate in seama configurarile noastre din Data>Config
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
