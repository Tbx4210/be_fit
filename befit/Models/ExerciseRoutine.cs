using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BE_FIT.Models
{
    
    public class ExerciseRoutineModel
    {
        public string ExerciseName { get; set; }  
        public int Sets { get; set; }             
        public int Reps { get; set; }            
        public double Duration { get; set; }      
        public string Difficulty { get; set; }    
        public string Notes { get; set; }         
    }
}
