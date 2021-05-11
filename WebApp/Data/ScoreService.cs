using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Database;

namespace WebApp.Data
{
    public class ScoreService
    {

        private readonly dbcontext _ctx;

        public ScoreService(dbcontext ctx)
        {
            _ctx = ctx;
        }

        // Henter alle scores
        public async Task<List<Score>> GetScoresAsync()
        {
            return await _ctx.Scores
                .Include(y => y.Course)
                .ToListAsync();
        }

        // Henter specifik score ud fra Id.
        public async Task<Score> GetScore(int id)
        {
            Score score = await _ctx.Scores.FindAsync(id);

            return score;
        }

        //Sletter en score
        public async Task<bool> DeleteScore(Score score)
        {
            _ctx.Scores.Remove(score);

            await _ctx.SaveChangesAsync();

            return true;
        }

        // Opdaterer en Score
        public async Task<bool> UpdateScore(Score score)
        {
            _ctx.Scores.Update(score);

            await _ctx.SaveChangesAsync();

            return true;
        }

        // Opretter en score.
        public async Task<bool> CreateScore(Score score)
        {
            await _ctx.Scores.AddAsync(score);

            await _ctx.SaveChangesAsync();

            return true;
        }

    }
}
