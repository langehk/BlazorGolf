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

        //https://open.faceit.com/data/v4/players/18c2e4f9-e536-4363-8c85-0750645c191c/history?game=csgo&offset=0&limit=10
        // Hent sidste 10 games
        // Match ID

        // Find stats 
        // https://open.faceit.com/data/v4/matches/1-ef4c5115-0246-4d09-a803-5b5f16cd6f81/stats

        // Find spilleren ud fra playerId
        // Kills
        // Deaths
        // K/R Ratio
        // K/D Ratio
        // MVPs

        /*
         *  Method that returns historic match data in csgo, based on PlayerID and numberOfMatches.
         */
        public async Task<MatchHistory> GetMatchHistoryAsync(string playerID, int numberOfMatches)
        {

            var client = new RestClient("https://open.faceit.com/data/v4/players/" + playerID + "/history?game=csgo&offset=0&limit=" + numberOfMatches + "");
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("authorization", "Bearer 1ef71530-ae91-487a-8720-d43c9094ba4f");
            request.AddHeader("accept", "application/json");
            IRestResponse response = client.Execute(request);

            var data = JsonConvert.DeserializeObject<MatchHistory>(response.Content);

            return data;
        }

        public async Task<MatchStats> GetMatchStatsAsync(string matchID)
        {

            var client = new RestClient("https://open.faceit.com/data/v4/matches/" + matchID + "/stats");
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("authorization", "Bearer 1ef71530-ae91-487a-8720-d43c9094ba4f");
            request.AddHeader("accept", "application/json");
            IRestResponse response = client.Execute(request);

            var data = JsonConvert.DeserializeObject<MatchStats>(response.Content);

            return data;
        }
    }
}
