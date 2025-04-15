using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace befit.Models
{
    
    public class WorkoutHistoryModel
    {
        public string UserId { get; set; }       
        public string ExerciseName { get; set; } 
        public int Sets { get; set; }            
        public int Reps { get; set; }            
        public DateTime Date { get; set; }      
        public double CaloriesBurned { get; set; } 

        
    }
}
