using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Data
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Handicap { get; set; }
        public ICollection<Score> Scores { get; set; }

    }
}
