using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Models
{
    public class OffersModel : BaseOffer //3 levels of depth in inheritance
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }


}
