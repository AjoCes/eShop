using MyShop.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Models
{
    public abstract class BaseOffer : BaseEntity 
   
    // we can never create instance for an abstract class we can only create classes that implements it 

    {
        public Offers Offers { get; set; }

    }

    public enum Offers
    {
        Normal,
        Pernium
     }

}
