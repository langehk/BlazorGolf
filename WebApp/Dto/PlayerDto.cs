using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data;

namespace WebApp.Model
{
    public class PlayerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Handicap { get; set; }
    }
}
