using System;
using System.Collections.Generic;

namespace Weightlifting.Models
{
    public class Workout
    {
        public int Id { get; set; }
        
        public DateTime Date { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }

        public virtual IList<Set> Sets { get; set; }

        public Workout()
        {            
            Sets = new List<Set>();
        }
    }
}
