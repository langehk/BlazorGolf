using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MudBlazor.Colors;

namespace WebApp.Data.Blizzard.MythicPlus
{
    public class DungeonService
    {
        public List<Dungeon> GetDungeons(string token, string region)
        {
            
            var client = new RestClient("https://" + region + ".api.blizzard.com/data/wow/mythic-keystone/dungeon/index?namespace=dynamic-us&locale=en_US&access_token=" + token);
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("authorization", $"Bearer {token}");
            IRestResponse response = client.Execute(request);

            var auctionApiResponse = JsonConvert.DeserializeObject<DungeonApiResponse>(response.Content);
            var dungeonData = auctionApiResponse.Dungeons.ToList();
            return dungeonData;
        }

    }
}
