using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Models
{
    public class ProductOffer : BaseEntity
    {
        public string Offer { get; set; }
        public BaseDescription Descr { get; set; }
        
    }

}
