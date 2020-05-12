using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using testAPI.model;
using Newtonsoft.Json.Linq;

namespace testAPI.proxy
{
  
    public class MenuProxy{
         public async Task<IEnumerable<MenuItem>> GetMenu(string apiUrl){
           var fullMenu = new List<MenuItem>();
           using(System.Net.Http.HttpClient client = new HttpClient()){
               var response = await client.GetStringAsync(apiUrl);
                JObject globalMenu = JObject.Parse(response);
                JArray parentItems = JArray.Parse(globalMenu["items"].ToString());

                for(int i=0; i<parentItems.Count; i++){
                    var menuItem = (JObject)parentItems[i];
                    var mi = loadMenuItem(menuItem);
                    fullMenu.Add(mi);
                }
           }

           return fullMenu;
       }

       private MenuItem loadMenuItem(JObject item){
           var m = new MenuItem();
           m.ExternalId = int.Parse(item["ID"].ToString());
           m.Url = item["url"].ToString();
           m.MenuKey = item["post_name"].ToString();
           m.ParentMenuId = null;
           m.DisplayOrder = 0;
           m.CreatedBy = 0;
           m.CreatedDate = DateTime.Now;
           m.Name = item["title"].ToString();

            if(item["child_items"]!= null){
                var children = (JArray) item["child_items"];
                var childlist = new List<MenuItem>();
                foreach(JObject child in children){
                    var childMenu = loadMenuItem(child);
                    childlist.Add(childMenu);
                }
                m.Children = childlist;

            }

           return m;
    }

    }
}