using K_AkicaWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace K_AkicaWeb.Views.Home.Components.FeedItems
{
    public class FeedItemsComponent : ViewComponent
    {
        public IViewComponentResult Invoke(IEnumerable<FeedItemViewModel> model, bool isPlain)
        {
            return isPlain ?
                View("PlainFeedItemsView", model) :
                View("FeedItemsView", model);
        }
    }
}
