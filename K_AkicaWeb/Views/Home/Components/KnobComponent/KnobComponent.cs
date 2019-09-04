using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace K_AkicaWeb.Views.Home.Components.KnobControl
{
    [ViewComponent]
    public class KnobComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string text)
        {
            return View("KnobView", text);
        }
    }
}
