using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Data.Faceit
{
    public class FaceitData
    {
        public Guid Player_id { get; set; }
        public string Nickname { get; set; }
        public string Country { get; set; }

        public Dictionary<string, GameData> Games { get; set; }

    }
}
