using AutoMapper;
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
        protected readonly IMapper _mapper;

        public ScoresController(dbcontext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }



        // GET: api/Scores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Score>>> GetScores()
        {
            return await _ctx.Scores.AsNoTracking()
                .Include(x => x.Player)
                .Include(y => y.Course)
                .ToListAsync();
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
        public async Task<ActionResult> PutScore(int id, [FromBody] ScoreDto score)
        {

            var _score = await _ctx.Set<Score>().FindAsync(id);

            if (_score == null) return BadRequest("Object not found");

            _score = _mapper.Map(score, _score);
            _score.Id = id;

            _ctx.Update(_score);

            await _ctx.SaveChangesAsync();

            return Ok(_score);
        }

        /*// POST: api/Scores
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Score>> PostScore(int id, [FromBody] ScoreDto score)
        {

            var _score = await _ctx.Scores.FindAsync(id);


            if (_score == null) return BadRequest("Object not found");



            //_ctx.Scores.Add(score);
            //await _ctx.SaveChangesAsync();

            return Ok();
        }*/

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
}
}
