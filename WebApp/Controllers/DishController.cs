using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data;
using WebApp.Database;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishController : ControllerBase
    {

        private readonly dbcontext _ctx;

        public DishController(dbcontext ctx)
        {
            _ctx = ctx;
        }


        // GET: api/Dishes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dish>>> GetDishes()
        {
            return await _ctx.Dishes.AsNoTracking().ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Dish>> PostDish(Dish dish)
        {
            _ctx.Dishes.Add(dish);
            await _ctx.SaveChangesAsync();

            return CreatedAtAction("GetDishes", new { id = dish.Id }, dish);
        }

    }
}
