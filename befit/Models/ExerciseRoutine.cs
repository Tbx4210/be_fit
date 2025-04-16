using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using befit; 


namespace befit.Models
{
    
    public class ExerciseRoutineModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string ExerciseName { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public int Duration { get; set; }
        public string Difficulty { get; set; }
        public string MuscleGroup { get; set; } // New
        public bool IsCustom { get; set; } // New
        public bool IsFavorite { get; set; } // New     
    }
}
