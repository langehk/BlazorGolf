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
    public class CoursesController : ControllerBase
    {

        private readonly dbcontext _ctx;

        public CoursesController(dbcontext ctx)
        {
            _ctx = ctx;
        }


        // GET: api/Courses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            return await _ctx.Courses.AsNoTracking().ToListAsync();
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(int id)
        {
            var course = await _ctx.Courses.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);

            if (course == null)
            {
                return NotFound();
            }

            return course;
        }

        // PUT: api/Courses/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(Course course)
        {

            _ctx.Entry(course).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();

            return Ok();
        }

        // POST: api/Courses
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CourseDto>> PostCourse(Course course)
        {
            _ctx.Courses.Add(course);
            await _ctx.SaveChangesAsync();

            return CreatedAtAction("GetCourse", new { id = course.Id }, course);
        }

        // DELETE: api/Cources/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Course>> DeleteCourse(int id)
        {
            var course = await _ctx.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            _ctx.Courses.Remove(course);
            await _ctx.SaveChangesAsync();

            return course;
        }
    }
}
