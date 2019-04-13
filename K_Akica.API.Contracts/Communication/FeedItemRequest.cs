using K_Akica.API.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace K_Akica.API.Contracts.Communication
{
    public class FeedItemRequest
    {
        public int Id { get; set; }

        public int PooperId { get; set; }
        public string Description { get; set; }
        //public DateTime Timestamp { get; set; }
        public bool Poop { get; set; }
        public bool Wizz { get; set; }
        public TimeSpan Duration { get; set; }
    }

    public static class FeedItemCommunicationExtensions
    {
        public static FeedItem AsFeedItem(this FeedItemRequest request, Pooper pooper)
        {
            return new FeedItem
            {
                Pooper = pooper,
                Duration = request.Duration,
                Description = request.Description,
                Poop = request.Poop,
                Wizz = request.Wizz
            };
        }

        public static FeedItemRequest AsResponce(this FeedItem item)
        {
            return new FeedItemRequest
            {
                PooperId = item.Pooper.Id,
                Duration = item.Duration,
                Description = item.Description,
                Poop = item.Poop,
                Wizz = item.Wizz
            };
        }

        public static void UpdateFromRequest(this FeedItem item, FeedItemRequest request, Pooper pooper)
        {
            item.Pooper = pooper;
            item.Duration = request.Duration;
            item.Description = request.Description;
            item.Poop = request.Poop;
            item.Wizz = request.Wizz;
        }
    }
}
