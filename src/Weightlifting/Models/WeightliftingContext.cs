using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Weightlifting.Data;

namespace Weightlifting.Models
{
    public class WeightliftingContext : IdentityDbContext<ApplicationUser>
    {
        public WeightliftingContext(DbContextOptions<WeightliftingContext> options) : base(options)
        {
        }

        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Set> Sets { get; set; }
        public DbSet<Workout> Workouts { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.RemoveTableNamePlurals();
        }

    }
}
