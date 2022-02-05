using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moment_2_MVC.Models
{
    public class List
    {

        
        public static List<string> Items;    
        
        public static List<string> Item
    {
        get
        {
 
            return Items;
        }
        set
        {
               
                Items = value;
        }
    }

    }

}
