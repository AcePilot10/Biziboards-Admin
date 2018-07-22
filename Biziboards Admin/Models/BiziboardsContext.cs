using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Biziboards_Admin.Models
{
    public partial class BiziboardsContext : DbContext
    {
        public BiziboardsContext()
        {
        }

        public BiziboardsContext(DbContextOptions<BiziboardsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Merchants> Merchants { get; set; }
        public virtual DbSet<Offers> Offers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=biziboards.database.windows.net;Initial Catalog=Biziboards;Integrated Security=False;User ID=AcePilot10;Password=Airplane10;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Merchants>(entity =>
            {
                entity.Property(e => e.LogoUrl).HasColumnName("LogoURL");
            });
        }
    }
}