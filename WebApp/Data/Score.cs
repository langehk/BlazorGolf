using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Data
{
    public class Score
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int CourseId { get; set; }
        public DateTime Date { get; set; }
        public int Point { get; set; }
        public Player Player { get; set; }
    }
}
