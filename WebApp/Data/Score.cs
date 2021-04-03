using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Data
{
    public class Score
    {
        public int Id { get; set; }
        [Required]
        public int PlayerId { get; set; }
        [Required]
        public int CourseId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int Point { get; set; }
        public Player Player { get; set; }
        public Course Course { get; set; }

    }
}
