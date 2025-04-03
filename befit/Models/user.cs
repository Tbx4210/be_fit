using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_FIT.Models
{
    
    public class UserModel
    {
        public string UserId { get; set; } 
        public string Name { get; set; }   
        public string Email { get; set; }   
        public int Age { get; set; }        
        public string Gender { get; set; }  
        public double Weight { get; set; }
    }
}
