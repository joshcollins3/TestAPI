using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace testAPI.services
{
   
    public class MenuService{
        public static async Task<string> Update() {
            var updateGM = await proxy.MenuProxy.GetMenu("https://ncte.org/wp-json/menus/v1/menus/global-menu");
            return updateGM.ToString();
        }
    }

}