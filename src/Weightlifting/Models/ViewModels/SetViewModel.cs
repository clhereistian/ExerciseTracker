using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weightlifting.Models.ViewModels
{
    public class SetViewModel
    {
        public int Id { get; set; }

        public int ExerciseId { get; set; }

        public int WorkoutId { get; set; }

        public string ExerciseName { get; set; }

        public decimal Weight { get; set; }

        public int Reps { get; set; }
    }
}
