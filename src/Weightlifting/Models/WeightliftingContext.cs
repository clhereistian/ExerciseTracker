using Microsoft.EntityFrameworkCore;
using Weightlifting.Data;

namespace Weightlifting.Models
{
    public class WeightliftingContext : DbContext
    {
        public WeightliftingContext(DbContextOptions<WeightliftingContext> options) : base(options)
        {
        }

        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Set> Sets { get; set; }
        public DbSet<Workout> Workouts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.RemoveTableNamePlurals();
        }

    }
}
