using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace K_Akica.API.Contracts.Models
{
    public class K_AkicaContext : DbContext
    {
        public K_AkicaContext()
        {
        }

        public K_AkicaContext(DbContextOptions<K_AkicaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FeedItem> FeedItem { get; set; }
        public virtual DbSet<Pooper> Pooper { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["K_AkicaDb"].ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<FeedItem>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Duration).HasDefaultValueSql("('10:00:00')");

                entity.Property(e => e.Timestamp)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.FeedItem)
                    .HasForeignKey<FeedItem>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Pooper>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Race).HasMaxLength(100);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}