using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebApp.Data
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Handicap { get; set; }

        [JsonIgnore]
        public List<Score> Scores { get; set; }
    }
}
