using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContozooMVC.Models
{
    public class AnimalModels
    {
        #region Properties  
        ///<summary>  
        ///get and set the  College ID  
        ///</summary>         
        public int AnimalID { get; set; }
       
        public string Animal { get; set; }
       
        public int Number { get; set; }
        
        public string Location { get; set; }
         
        public string ActiveHours { get; set; }
       
        public string Notes { get; set; }
    
    }
}
