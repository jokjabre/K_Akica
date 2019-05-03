using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace K_AkicaWeb.Views.Home.Components.AddFeed
{
    public class NewFeedItemComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("NewFeedItemView");
        }
    }
}
