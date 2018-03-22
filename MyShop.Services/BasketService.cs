using MyShop.Core.Contracts;
using MyShop.Core.Models;
using MyShop.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MyShop.Services
{
    // We could all this class include within Basket Controller
    //but since controller is for conjuction between UI and the 
    //Model we use this layer to encasulate The business logic

    // Try to read a cookie from the user with HTTPContext that contains info such as IP Adress

    public class BasketService : IBasketService
    {
        //getting acces to underlined data
        IRepository<Product> productContext;
        IRepository<Basket> basketContext;//load basket and basketItems

        public const string BasketSessionName = "eCommerceBasket"; //use string to reference a cookie

        public BasketService(IRepository<Product> ProductContext, IRepository<Basket> BasketContext) {
            this.basketContext = BasketContext;
            this.productContext = ProductContext;
        }

        //Private method because we only will use id internally within BasketSevice Class

        private Basket GetBasket(HttpContextBase httpContext, bool createIfNull) {
            //Attempt to read the cookie
            HttpCookie cookie = httpContext.Request.Cookies.Get(BasketSessionName);

            //create new basket
            Basket basket = new Basket();

            //Check if the cookie actualy exists, if the users has visited before, 
            //method will read that cookie, if not, cookie will simply be null 

            if (cookie != null)
            {
                string basketId = cookie.Value;
                //further check if the value red from the cookie is not null

                if (!string.IsNullOrEmpty(basketId))
                {
                    //load from the basketContext
                    basket = basketContext.Find(basketId);
                }
                // If basket is null
                else
                {
                    if (createIfNull)
                    {
                        basket = CreateNewBasket(httpContext);
                    }
                }
            }
            //if cookie is null
            else {
                if (createIfNull)
                {
                    basket = CreateNewBasket(httpContext);
                }
            }

            return basket;
           
        }

        private Basket CreateNewBasket(HttpContextBase httpContext) {
            
            //create new basket
            Basket basket = new Basket();

            //insert to the database
            basketContext.Insert(basket);
            basketContext.Commit();

            //Write a cookie to the users machine 

            //Create a cookie first

            HttpCookie cookie = new HttpCookie(BasketSessionName);
            cookie.Value = basket.Id;

            //set expiration of the cookie 
            cookie.Expires = DateTime.Now.AddDays(1);

            //send cookie back to the user
            httpContext.Response.Cookies.Add(cookie);


            return basket;
        }

        //Method where we actually want to add a basket Item
        public void AddToBasket(HttpContextBase httpContext, string productId) {
            Basket basket = GetBasket(httpContext, true);
            BasketItem item = basket.BasketItems.FirstOrDefault(i => i.ProductId == productId);

            //Does that item exits in the basket?

            if (item == null)
            {
                //create new item
                item = new BasketItem()
                {
                    
                    BasketId = basket.Id,
                    ProductId = productId,
                    Quanity = 1
                };

                basket.BasketItems.Add(item);
            }
            else {
                item.Quanity = item.Quanity + 1;
            }

            basketContext.Commit();
        }

        public void RemoveFromBasket(HttpContextBase httpContext, string itemId) {
            Basket basket = GetBasket(httpContext, true);
            BasketItem item = basket.BasketItems.FirstOrDefault(i => i.Id == itemId);

            if (item != null) {
                basket.BasketItems.Remove(item);
                basketContext.Commit();
            }
        }

        public List<BasketItemViewModel> GetBasketItems(HttpContextBase httpContext) {

            //instead of this id there is no items in basket we just return an empty inMemory basket 

            Basket basket = GetBasket(httpContext, false);

            //Query a product table if we retreive the basket

            if (basket != null)
            {
                var results = (from b in basket.BasketItems
                               join p in productContext.Collection() on b.ProductId equals p.Id
                               select new BasketItemViewModel()
                               {
                                   Id = b.Id,
                                   Quanity = b.Quanity,
                                   ProductName = p.Name,
                                   Image = p.Image,
                                   Price = p.Price,
                                   Offer = p.Offer
                               }
                              ).ToList();

                return results;
            }
            else {
                return new List<BasketItemViewModel>();
            }
        }

        public BasketSummaryViewModel GetBasketSummary(HttpContextBase httpContext) {
            Basket basket = GetBasket(httpContext, false);
            BasketSummaryViewModel model = new BasketSummaryViewModel(0, 0);
            if (basket != null)
            {
                int? basketCount = (from item in basket.BasketItems
                                    select item.Quanity).Sum();

                decimal? basketTotal = (from item in basket.BasketItems
                                        join p in productContext.Collection() on item.ProductId equals p.Id
                                        select item.Quanity * p.Price).Sum(); //here we can choose to calculate the discount

                model.BasketCount = basketCount ?? 0;
                model.BasketTotal = basketTotal ?? decimal.Zero;

                return model;
            }
            else {
                return model;
            }
        }
    }
}
