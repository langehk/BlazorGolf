using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data;

namespace WebApp.Database
{
    public class dbcontext : DbContext
    {
        public dbcontext(DbContextOptions<dbcontext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Server=tcp:blazorgolf.database.windows.net,1433;Initial Catalog=WebApp_db;Persist Security Info=False;User ID=langehk;Password=Tigerwoods6!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                optionsBuilder.UseSqlServer("Server=DESKTOP-HFC2M8S;Database=BlazorGolf;Trusted_Connection=True;User ID=Morten;");
            }
        }

        public virtual DbSet<Player> Players { get; set; }

        public virtual DbSet<Score> Scores { get; set; }

        public virtual DbSet<Course> Courses { get; set; }

        public virtual DbSet<Dish> Dishes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
            .HasIndex(a => a.Id)
            .IsUnique();

            modelBuilder.Entity<Player>()
                .HasMany(x => x.Scores);

            modelBuilder.Entity<Score>()
            .HasOne(x => x.Player);
        }
    }
}
