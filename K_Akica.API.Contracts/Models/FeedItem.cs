using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace K_Akica.API.Contracts.Models
{
    public class FeedItem
    {
        public int Id { get; set; }

        [Required]
        [JsonIgnore]
        public virtual Pooper Pooper { get; set; }

        [NotMapped]
        public int RefPooperId { get => Pooper.Id; }

        public string Description { get; set; }
        public DateTime Timestamp { get; set; }
        public bool Poop { get; set; }
        public bool Wizz { get; set; }
        public TimeSpan Duration { get; set; }
    }

    public class FeedItemsConfiguration : IEntityTypeConfiguration<FeedItem>
    {
        public void Configure(EntityTypeBuilder<FeedItem> builder)
        {
            // Set configuration for entity
            builder.ToTable("FeedItems", "dbo");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(e => e.Duration).HasDefaultValueSql("('10:00:00')");

            builder.Property(e => e.Timestamp)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");
        }
    }
}