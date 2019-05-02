using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace K_AkicaWeb.Views.Home.Components.Range
{
    public class Range : ViewComponent
    {
        public IViewComponentResult Invoke(string name)
        {
            return View("TimelineItemView", name);
        }
    }
}
