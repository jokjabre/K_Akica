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
}