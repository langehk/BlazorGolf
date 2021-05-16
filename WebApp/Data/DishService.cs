using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Database;

namespace WebApp.Data
{
    public class DishService
    {

        private readonly dbcontext _ctx;

        public DishService(dbcontext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<Dish>> GetDishesAsync()
        {
            return await _ctx.Dishes.ToListAsync();
        }

        
        public async Task<bool> CreateDish(Dish dish)
        {
            await _ctx.Dishes.AddAsync(dish);

            await _ctx.SaveChangesAsync();

            return true;
        }


    }
}
