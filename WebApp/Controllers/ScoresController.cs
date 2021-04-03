using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data;
using WebApp.Database;
using WebApp.Dto;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoresController : ControllerBase
    {
        private readonly dbcontext _ctx;

        public ScoresController(dbcontext ctx)
        {
            _ctx = ctx;
        }


        // GET: api/Scores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Score>>> GetScores()
        {
            return await _ctx.Scores.AsNoTracking().Include(x => x.Player).ToListAsync();
        }

        // GET: api/Scores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Score>> GetScore(int id)
        {
            var score = await _ctx.Scores.AsNoTracking().Include(x => x.Player).SingleOrDefaultAsync(x => x.Id == id);

            if (score == null)
            {
                return NotFound();
            }

            return score;
        }

        // PUT: api/Scores/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScore(Score score)
        {
            
            _ctx.Entry(score).State = EntityState.Modified;
           await _ctx.SaveChangesAsync();

            return Ok();
        }

        // POST: api/Scores
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ScoreDto>> PostScore(Score score)
        {
            _ctx.Scores.Add(score);
            await _ctx.SaveChangesAsync();

            return CreatedAtAction("GetScore", new { id = score.Id }, score);
        }

        // DELETE: api/Scores/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Score>> DeleteScore(int id)
        {
            var score = await _ctx.Scores.FindAsync(id);
            if (score == null)
            {
                return NotFound();
            }

            _ctx.Scores.Remove(score);
            await _ctx.SaveChangesAsync();

            return score;
        }

        private bool ScoreExists(int id)
        {
            return _ctx.Scores.Any(e => e.Id == id);
        }
}
}
