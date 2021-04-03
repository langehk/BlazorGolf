using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Database;

namespace WebApp.Data
{
    public class CourseService
    {

        private readonly dbcontext _ctx;

        public CourseService(dbcontext ctx)
        {
            _ctx = ctx;
        }


        // Henter alle Courses
        public async Task<IEnumerable<Course>> GetCoursesAsync()
        {
            return await _ctx.Courses.ToListAsync();
        }

        // Henter specifik Course ud fra Id.
        public async Task<Course> GetCourse(int id)
        {
            Course Course = await _ctx.Courses.FindAsync(id);

            return Course;
        }

        //Sletter en Course
        public async Task<bool> DeleteCourse(Course Course)
        {
            _ctx.Courses.Remove(Course);

            await _ctx.SaveChangesAsync();

            return true;
        }

        // Opdaterer en Course
        public async Task<bool> UpdateCourse(Course Course)
        {
            _ctx.Courses.Update(Course);

            await _ctx.SaveChangesAsync();

            return true;
        }

        // Opretter en Course.
        public async Task<bool> CreateCourse(Course Course)
        {
            await _ctx.Courses.AddAsync(Course);

            await _ctx.SaveChangesAsync();

            return true;
        }


    }
}
