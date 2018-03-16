using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Models
{
    public class BaseDescription:BaseEntity
    {


        public virtual string Description(int num)
        {
          
                
            string desc = "blla blla " + num;

            return desc;
        }

        public virtual string Description()
        {

            string desc1 = "This is desc without id";

            return desc1;
        } 
    }
}
