using System.Collections.Generic;

namespace Weightlifting.Models.ViewModels
{
    public class WorkoutDetailsViewModel
    {
        public WorkoutViewModel Workout { get; set; }

        public IList<ExerciseViewModel> Exercises { get; set; }     
    }
}
