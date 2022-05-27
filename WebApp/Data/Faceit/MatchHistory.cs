using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Data.Faceit
{
    public class MatchHistory
    {
        public IList<MatchHistoryData> Items { get; set; }
    }

    public class MatchHistoryData
    {
        public string Match_id { get; set; }

        public TeamData Teams { get; set; }
    }

    public class TeamData
    {
        public string Team_id { get; set; }
        public FactionData faction1 { get; set; }
        public FactionData faction2 { get; set; }
    }

    public class FactionData
    {
        public string Team_id { get; set; }
        public IList<PlayerData> Players { get; set; }
    }

    public class PlayerData
    {
        public string Player_id { get; set; }
        public string Nickname { get; set; }
    }
}
