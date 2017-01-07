using System.Collections.Generic;

namespace Weightlifting.Models.ViewModels
{
    public class ExerciseViewModel
    {
        public int Id { get; set; }
      
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual IList<Set> Sets { get; set; }
    }
}
