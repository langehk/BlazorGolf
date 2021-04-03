using System.Collections.Generic;
using System.Threading.Tasks;


namespace WebApp.Data
{
    public interface IPlayerService
    {
        Task<List<Player>> GetPlayers();

        Task<Player> CreatePlayer(Player player);
        // Should this have Dto or regular player?

        Task<Player> UpdatePlayer(Player player);

        Task<Player> GetPlayerById(int id);

        Task<bool> DeletePlayer(Player player);
    }
}