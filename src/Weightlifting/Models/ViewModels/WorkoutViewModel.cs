using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Weightlifting.Models.ViewModels
{
    public class WorkoutViewModel
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public virtual IList<SetViewModel> Sets { get; set; }

        public WorkoutViewModel()
        {
            Sets = new List<SetViewModel>();
            Date = DateTime.Now;
        }
    }
}
