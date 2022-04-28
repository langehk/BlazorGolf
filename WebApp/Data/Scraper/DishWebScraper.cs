using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Data.Scraper
{
    public class DishWebScraper
    {

        public List<Dish> GetDishes(string url)
        {
            List<Dish> dishes = new List<Dish>();

            HtmlWeb web = new HtmlWeb();

            HtmlNode nextbutton = null;
            do
            {
                var doc = web.Load(url);
                var nodes = doc.DocumentNode.SelectNodes("//*[@id='product-result-list']/div/a[position()>0]");

                foreach (var node in nodes)
                {
                    var dish = new Dish()
                    {
                        Title = node.ChildNodes[3].InnerText.Trim(),
                        Url = "https://meyers.dk" + node.Attributes["href"].Value,
                    };

                    dishes.Add(dish);
                }

            } while (dishes.Count < 12);
            

            return dishes;
        }
    }
}
