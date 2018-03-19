using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.ViewModels
{

    //Structure is a value type data type whereas classes are reference types.
    //Structures are used to represent a record. 
    //Structure can not inherit from another classes or other structures.
    // In memory it is treated differentely from classes
    //It should be used in those records that are imutable and not big in size
    //runtime deals with the two in different ways.  When a value-type instance is created, 
    //a single space in memory is allocated to store the value
    //With reference types, however, an object is created in memory, 
    //and then handled through a separate reference

    public struct ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<ProductCategory> ProductCategories { get; set; }
        public IEnumerable<ProductOffer> ProductOffers { get; set; }
        public IEnumerable<OffersModel> OffersModel { get; set; }
    }
}
