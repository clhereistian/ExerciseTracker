namespace Weightlifting.Models
{
    public class Set
    {
        public int Id { get; set; }

        public int ExerciseId { get; set; }

        public int WorkoutId { get; set; }

        public decimal Weight { get; set; }

        public int Reps { get; set; }

        public virtual Exercise Exercise { get; set;  }

        public virtual Workout Workout { get; set; }
    }
}
