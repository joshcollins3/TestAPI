using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace testAPI.services
{
   
    public class MenuService{
        private const string menuApiUrl = "https://ncte.org/wp-json/menus/v1/menus/global-menu";
        public static async Task<IEnumerable<model.MenuItem>> Update() {
            var updateGM = await proxy.MenuProxy.GetMenu(menuApiUrl);
            repositories.MenuRepository.UpdateMenu();
            return updateGM;
        }
    }
}