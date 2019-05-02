using K_AkicaWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace K_AkicaWeb.Views.Home.Components.TimelineItem
{
    [ViewComponent]
    public class TimelineItem : ViewComponent
    {
        public IViewComponentResult Invoke(FeedItemViewModel model)
        {
            return View("TimelineItemView", model);
        }
    }
}
