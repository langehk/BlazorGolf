using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Data.Faceit
{
    public class FaceitService : IFaceitService
    {
        public async Task<FaceitData> GetPlayerDetailsByName(string playerName)
        {
            var client = new RestClient("https://open.faceit.com/data/v4/players?nickname=" + playerName + "&game=csgo");

            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("authorization", "Bearer 1ef71530-ae91-487a-8720-d43c9094ba4f");
            request.AddHeader("accept", "application/json");
            IRestResponse response = client.Execute(request);


            var data = JsonConvert.DeserializeObject<FaceitData>(response.Content);

            return data;
        }
    }
}
