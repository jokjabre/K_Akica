using System;
using System.Collections.Generic;

namespace K_Akica.API.Contracts.Models
{
    public partial class FeedItem
    {
        public int Id { get; set; }
        public int PooperId { get; set; }
        public string Description { get; set; }
        public DateTime Timestamp { get; set; }
        public bool Poop { get; set; }
        public bool Wizz { get; set; }
        public TimeSpan Duration { get; set; }

        public virtual Pooper IdNavigation { get; set; }
    }
}