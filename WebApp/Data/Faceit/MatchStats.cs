using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Data.Faceit
{
    public class MatchStats
    {

        public List<RoundData> Rounds { get; set; }
    }

    public class RoundData
    {
        public RoundStats Round_Stats { get; set; }
        public IList<TeamsData> Teams { get; set; }
    }

    public class RoundStats
    {
        public string Map { get; set; } // dd2, mirage osv.
        public string Score { get; set; } // Formatted "16 / 12" 
    }

    public class TeamsData
    {
        public string Team_id { get; set; }
        public IList<PlayerStatsData> Players { get; set; }
    }

    public class PlayerStatsData
    {
        public string Player_id { get; set; }
        public string Nickname { get; set; }
        public PlayerStats Player_Stats { get; set; }
    }

    public class PlayerStats
    {
        [JsonProperty("K/R Ratio")]
        public string KRRatio { get; set; }
        [JsonProperty("K/D Ratio")]
        public string KDRatio { get; set; }
        public string Kills { get; set; }
        public string Deaths { get; set; }
        public string MVPs { get; set; }
    }
}
