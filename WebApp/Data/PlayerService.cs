using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Database;

namespace WebApp.Data
{
    public class PlayerService
    {
        private readonly dbcontext _ctx;

        // Dependency Injection
        public PlayerService(dbcontext ctx)
        {
            _ctx = ctx;
        }

        public Task<Player> CreatePlayer(Player player)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeletePlayer(Player player)
        {
            _ctx.Players.Remove(player);
            await _ctx.SaveChangesAsync();

            return true;
        }

        public async Task<Player> GetPlayerById(int id)
        {
          Player player = await _ctx.Players.FindAsync(id);

          return player;
        }

        public async Task<List<Player>> GetPlayersAsync()
        {
            return await _ctx.Players.ToListAsync();
        }

        public async Task<Player> UpdatePlayer(Player player)
        {
             _ctx.Players.Update(player);
            await _ctx.SaveChangesAsync();

            return player;
        }

    }
}
