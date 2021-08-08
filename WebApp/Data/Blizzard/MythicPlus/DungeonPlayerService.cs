using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Data.Blizzard.MythicPlus
{
    public class DungeonPlayerService
    {

        public List<BestRuns> GetMythicPlusStatsFromPlayer(string token, string region, string realm, string playerName)
        {
            var client = new RestClient("https://" + region + ".api.blizzard.com/profile/wow/character/" + realm + "/" + playerName + "/mythic-keystone-profile?namespace=profile-eu&locale=en_GB&access_token=" + token);
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("authorization", $"Bearer {token}");
            IRestResponse response = client.Execute(request);

            var mythicPlusPlayerApiResponse = JsonConvert.DeserializeObject<DungeonPlayer>(response.Content);


            var data = mythicPlusPlayerApiResponse.Current_period.Best_runs.ToList();

            foreach (var item in data)
            {

                var formattedDate = DateTimeOffset.FromUnixTimeSeconds((item.Completed_timestamp / 1000));
                var formattedDuration = DateTimeOffset.FromUnixTimeSeconds((item.Duration / 1000));

                item.Formatted_Completed_Timestamp = formattedDate.DateTime.Date;
                item.Formatted_Duration = formattedDuration.DateTime.TimeOfDay;
            }
            return data;
        }



        public List<BestRuns> GetMythicPlusStatsFromPlayerBySeason(string token, string region, string realm, string playerName, string seasonId)
        {
            var client = new RestClient("https://" + region + ".api.blizzard.com/profile/wow/character/" + realm + "/" + playerName + "/mythic-keystone-profile/season/" + seasonId + "?namespace=profile-eu&locale=en_GB&access_token=" + token);
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("authorization", $"Bearer {token}");
            IRestResponse response = client.Execute(request);

            var mythicPlusPlayerApiResponse = JsonConvert.DeserializeObject<DungeonPlayer>(response.Content);


            var data = mythicPlusPlayerApiResponse.Current_period.Best_runs.ToList();

            foreach (var item in data)
            {

                var formattedDate = DateTimeOffset.FromUnixTimeSeconds((item.Completed_timestamp / 1000));
                var formattedDuration = DateTimeOffset.FromUnixTimeSeconds((item.Duration / 1000));

                item.Formatted_Completed_Timestamp = formattedDate.DateTime.Date;
                item.Formatted_Duration = formattedDuration.DateTime.TimeOfDay;
            }
            return data;
        }



    }
}
