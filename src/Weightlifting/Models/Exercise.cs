using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Weightlifting.Models
{
    public class Exercise
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public virtual IList<Set> Sets { get; set; }

        public Exercise()
        {
            Sets = new List<Set>();
        }
    }
}
