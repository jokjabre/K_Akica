using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using K_Akica.API.Contracts.Services;
using K_Akica.API.Contracts.Models;
using K_Akica.API.Contracts.Communication;
using K_AkicaReact.Models;

namespace K_AkicaReact.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public async Task<IEnumerable<FeedItemViewModel>> FeedItems(int id, int? pageNum = 1)
        {
            if (!pageNum.HasValue || pageNum == 0) { pageNum = 1; }

            var feed = await K_AkicaClient.GetFeedForPooperAsync(id, pageNum.Value);
            return feed.Select(e => new FeedItemViewModel(e));
}

        public async Task<bool> AddFeed(FeedItemRequest item)
        {           
            return await K_AkicaClient.AddFeedItemAsync(item);
        }

        [HttpGet]
        public async Task<IEnumerable<Pooper>> Poopers()
        {
            return await K_AkicaClient.GetAllPoopersAsync();
        }

    }
}
