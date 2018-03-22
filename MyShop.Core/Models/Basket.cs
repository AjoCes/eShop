using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Models
{
    public class Basket : BaseEntity
    {
        public virtual ICollection<BasketItem> BasketItems { get; set; }

        //Lazy loading is a technique which loads the data on demand or when it is required. 
        //It improves efficiency and the performance of the application.
        //Lazy loading Important for entity framework because whenever we want to load the basket from
        //the database it will automatically will load all the basket Items

        public Basket() {
            this.BasketItems = new List<BasketItem>();
        }
    }
}
