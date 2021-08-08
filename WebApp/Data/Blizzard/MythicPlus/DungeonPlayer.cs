using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Data.Blizzard.MythicPlus
{
    public class DungeonPlayer
    {
        public Current_period Current_period { get; set; }
    }

    public class Current_period
    {
        public List<BestRuns> Best_runs { get; set; }
    }
    public class BestRuns
    {
        public int Keystone_level { get; set; }
        public long Completed_timestamp { get; set; }
        public long Duration { get; set; }
        public bool Is_completed_within_time { get; set; }

        public CompletedRating Mythic_rating { get; set; }

        public Dungeon Dungeon { get; set; }
        public DateTime Formatted_Completed_Timestamp { get; set; }
        public TimeSpan Formatted_Duration { get; set; }
    }


    public class CompletedRating
    {
        public int Rating { get; set; }
    }


    public class SearchPlayer
    {
        public string Name { get; set; }

        public string Realm { get; set; }

        public Season Season { get; set; }
    }


    public class Season
    {
        public bool Season1 { get; set; }
        public bool Season2 { get; set; }
        public bool Options => Season1 || Season2;
    }

}
