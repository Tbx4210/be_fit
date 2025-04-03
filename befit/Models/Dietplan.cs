using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace BE_FIT.Models
{
   
    public class DietPlanModel
    {
        public string MealName { get; set; }      
        public string MealType { get; set; }     
        public double Calories { get; set; }     
        public double Protein { get; set; }       
        public double Carbohydrates { get; set; } 
        public double Fat { get; set; }           

        
    }
}

