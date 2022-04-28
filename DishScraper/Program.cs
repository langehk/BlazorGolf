using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using WebApp.Data;
using WebApp.Data.Scraper;
using WebApp.Database;


namespace DishScraper
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();

        static void Main(string[] args)
        {
            var scraper = new DishWebScraper();

            var url = "https://meyers.dk/opskrifter/maaltid/aftensmad/#p=32&ps=12&s=behavior&pg=0&c=IntcIiR0eXBlXCI6XCJMbUZvb2QuQ29tbWVyY2UuUHJvZHVjdEludGVncmF0aW9uLk1leWVyc0Zvb2QuUmVjaXBlUmVxdWVzdE1vZGVsLCBMbUZvb2QuQ29tbWVyY2VcIixcIk1lYWxUeXBlc1wiOltcImFmdGVuc21hZFwiXSxcIlNlYXNvbnNcIjpudWxsLFwiVmVnZXRhcmlhbmlzbVR5cGVzXCI6bnVsbCxcIkN1aXNpbmVzXCI6bnVsbCxcIlByZXBhcmF0aW9uVHlwZXNcIjpudWxsLFwiQWxsZXJnZW5UeXBlc1wiOm51bGwsXCJPY2Nhc2lvbnNcIjpudWxsLFwiSXNRdWlja1NlYXJjaFwiOmZhbHNlLFwiSW5jbHVkZUV4dHJhRmlsdGVyc1wiOm51bGwsXCJFeGNsdWRlUHJvZHVjdHNcIjpudWxsLFwiRXhjbHVkZVZhcmlhbnRzXCI6bnVsbCxcIklnbm9yZUlzUHVibGlzaGVkQ29uc3RyYWludE9uVmFyaWFudFwiOmZhbHNlLFwiT3ZlcnJpZGVIaWVyYXJjaHlJZEluVmFyaWFudExvb2t1cFwiOm51bGx9Ig==";

            var dishes = scraper.GetDishes(url);

                foreach (var dish in dishes)
                {
                    Console.WriteLine(dish.Title, dish.Url);
                
                    var response = client.PostAsJsonAsync("http://localhost:52462/api/dish", dish).Result;
            }
        }
    }
}
