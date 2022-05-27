using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Data.Faceit
{
    public interface IFaceitService
    {
        Task<FaceitData> GetPlayerDetailsByName(string playerName);
        Task<MatchHistory> GetMatchHistoryAsync(string playerID, int numberOfMatches);
        Task<MatchStats> GetMatchStatsAsync(string matchID);
    }
}
