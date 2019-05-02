using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace K_AkicaWeb.Views.Components.Toggle
{
    [ViewComponent]
    public class Toggle : ViewComponent
    {
        public IViewComponentResult Invoke(string text)
        {
            return View("ToggleView", text);
        }
    }
}
