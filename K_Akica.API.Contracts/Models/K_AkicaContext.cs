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

        public virtual DbSet<FeedItem> FeedItems { get; set; }
        public virtual DbSet<Pooper> Poopers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Trsa\\source\\repos\\K_Akica\\K_Akica.API.Contracts\\k_akica.mdf;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.ApplyConfiguration(new FeedItemsConfiguration());
            modelBuilder.ApplyConfiguration(new PoopersConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}