using K_Akica.API.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace K_AkicaWeb.Models
{
    public class FeedItemViewModel
    {
        public string Date { get; set; }
        public string Time { get; set; }
        public double Duration { get; set; }

        public string[] Description { get; set; }

        public bool Poop { get; set; }
        public bool Wizz { get; set; }

        public string ContentClass { get; set; }
        public string DurationIcon { get; set; }

        public FeedItemViewModel(FeedItem item)
        {
            Date = item.Timestamp.ToString("dd/MM/yyyy");
            Time = item.Timestamp.ToString("HH:mm");
            Duration = item.Duration.TotalMinutes;

            Description = item.Description?.Split(Environment.NewLine) ?? new string[] { };

            Poop = item.Poop;
            Wizz = item.Wizz;

            ContentClass = string.IsNullOrWhiteSpace(item.Description) ? "empty-content" : string.Empty;

            int[] vals = new int[] { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60 };
            DurationIcon = vals.FirstOrDefault(v => item.Duration.TotalMinutes <= v).ToString();
        }
    }
}
