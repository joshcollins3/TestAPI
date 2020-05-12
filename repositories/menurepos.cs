using System;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using testAPI.model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace testAPI.repositories
{
    
    public class MenuRepository
    {
        private SqlConnection connection = null;
        public MenuRepository(SqlConnection connection){
            this.connection = connection;
        }

        public async Task<MenuItem> GetById(int menuId){
            string sql = @"
                select * 
                from Menu
                where id = @id
            ";
            var result = await connection.QueryAsync<MenuItem>(sql, new {id = menuId});
            return result.FirstOrDefault();
        }

        public async Task<int> Insert(MenuItem item){
            string sql = @"
            insert into menu (
                externalid,
                parentmenuid,
                name,
                menukey,
                url,
                createdby,
                createddate,
                displayorder
                )
            select
                @externalid,
                @parentmenuid,
                @name,
                @menukey,
                @url,
                @createdby,
                @createddate,
                @displayorder

                select SCOPE_IDENTITY()
            ";
            int id = await connection.ExecuteScalarAsync<int>(sql, item);
            return id;
        }
        private const string menuApiUrl = "https://ncte.org/wp-json/menus/v1/menus/global-menu";
        private repositories.MenuRepository repo = null;
        public void UpdateMenu() {
            Console.WriteLine("Enter SQL Password");
            string password = Console.ReadLine();

            string connectionString = $"Server=10.0.0.9;Database=NCTEv2;User Id=sa;Password={password}";

            Console.WriteLine("Getting Menu");
            proxy.MenuProxy proxy = new proxy.MenuProxy();

            var menu = proxy.GetMenu(menuApiUrl).GetAwaiter().GetResult();

            using(System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            using(System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("TRUNCATE TABLE MENU", connection)){
                connection.Open();
                cmd.ExecuteNonQuery();
                repo = new repositories.MenuRepository(connection);
                
                insertMenu(menu);
        }
         void insertMenu(IEnumerable<model.MenuItem> menu, int? parentMenuId = null)
        {
            int id = 0;
            
            foreach(var mi in menu){
                    mi.ParentMenuId = parentMenuId;
                    id = repo.Insert(mi).GetAwaiter().GetResult();

                    Console.WriteLine($"Inserted menuitem id = {id}");
                    
                    if (mi.Children != null)
                    {
                        insertMenu(mi.Children, id);
                    }
        
                }
        }

        
    }
}
}
