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
    public class FaceitController : ControllerBase
    {

        // GET: api/Dishes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetPlayerByName(string name)
        {
            return null;
        }
    }
}
