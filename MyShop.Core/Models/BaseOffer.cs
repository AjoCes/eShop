using MyShop.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Models
{
    public abstract class BaseOffer : BaseEntity   {
        public Offers Offers { get; set; }

    }

    public enum Offers
    {
        Offer1,
        Offer2,
        Offer3,
        Offer4
    }
}
