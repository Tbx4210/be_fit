using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace befit.Models
{
    
    public class UserModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; } // in kg
        public double Height { get; set; } // in cm
        public string FitnessGoal { get; set; }
    }
}
