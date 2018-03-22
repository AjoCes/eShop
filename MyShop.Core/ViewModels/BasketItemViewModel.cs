using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.ViewModels
{
    //this class Brings together a number of properties of two classes Products and BasketItem Classes
    public class BasketItemViewModel 
    {
        //Id of BasketItem
        public string Id { get; set; }
        public int Quanity { get; set; } // Quantity from Basket

        //from Product table we have properties below
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Offer { get; set; }
        public string Image { get; set; }
    }
}
