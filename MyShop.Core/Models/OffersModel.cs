using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Models
{
    public class OffersModel : BaseEntity
    {
        public Offers Offers { get; set; }
    }

    public enum Offers
    {
        Offer1,
        Offer2
    }
}
