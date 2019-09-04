using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace K_AkicaWeb.Views.Home.Components.PooperList
{
    public class PooperListComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await K_Akica.API.Contracts.Services.K_AkicaClient.GetAllPoopersAsync();

            return View("PooperListView", model);
        }
    }
}
