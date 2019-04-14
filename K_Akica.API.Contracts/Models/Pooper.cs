using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace K_Akica.API.Contracts.Models
{
    public class Pooper
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Race { get; set; }
        public string Description { get; set; }

        [JsonIgnore]
        public virtual ICollection<FeedItem> FeedItems { get; set; } = new List<FeedItem>();

        [NotMapped]
        public List<int> FeedItemIds { get => FeedItems.Select(i => i.Id).ToList(); }
    }


    public class PoopersConfiguration : IEntityTypeConfiguration<Pooper>
    {
        public void Configure(EntityTypeBuilder<Pooper> builder)
        {
            // Set configuration for entity
            builder.ToTable("Poopers", "dbo");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

            builder.Property(e => e.Race).HasMaxLength(100);

            builder.HasMany(e => e.FeedItems)
                .WithOne(e => e.Pooper);
        }
    }
}