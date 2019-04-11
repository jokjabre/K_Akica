using System;
using System.Collections.Generic;

namespace K_Akica.API.Contracts.Models
{
    public partial class Pooper
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Race { get; set; }
        public string Description { get; set; }

        public virtual FeedItem FeedItem { get; set; }
    }
}