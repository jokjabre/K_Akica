using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using K_Akica.API.Contracts.Services;
using K_Akica.API.Contracts.Models;
using K_Akica.API.Contracts.Communication;

namespace K_AkicaWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //public async Task<ViewComponentResult> FeedItems(int id, int? pageNum = 1)
        //{
        //    if(!pageNum.HasValue || pageNum == 0) { pageNum = 1; }

        //    var feed = await K_AkicaClient.GetFeedForPooperAsync(id, pageNum.Value);
        //    var model = feed.Select(e => new FeedItemViewModel(e));

        //    return ViewComponent("FeedItemsComponent", new { model, isPlain = pageNum > 1 });
        //}

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
