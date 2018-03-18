using MyShop.Core.Contracts;
using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShop.WebUI.Controllers
{
    public class OffersController : Controller
    {
        IOffers<OffersModel> context;

        public OffersController(IOffers<OffersModel> context)
        {

            this.context = context;

        }

        public OffersController()
        {

        }

        // GET: Offers
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult LoadOffer() {
            return Content("LoadOffer");
        }
        [ActionName("LoadOffersByName")]
        public ActionResult LoadOffer(string str) {
            return Content("LoadOffer with string");
        }
    }
}