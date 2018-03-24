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
        public virtual ActionResult Index()
        {
            return View();
        }

    }

    public class PreniumClientOffer : OffersController
    {

        BaseOffer baseoffer;

        public PreniumClientOffer(BaseOffer baseOffer)
        {

            this.baseoffer = baseOffer;
        }

        public override ActionResult Index()
        {
            if (baseoffer.Equals(2))
            {
                return PartialView("IndexPrenium");
            }
            return View();
        }

    }


    public class NormalClientOffer : OffersController
    {

        BaseOffer baseoffer;

        public NormalClientOffer(BaseOffer baseOffer)
        {

            this.baseoffer = baseOffer;
        }

        public override ActionResult Index()
        {
            if (baseoffer.Equals(1))
            {
                return PartialView("IndexNormal");
            }
            return View();
        }

    }

    public class Execute
    {
        //OffersController offersController;

        public static void Main(OffersController offersController)
        {

            offersController.Index();

        }
    }
}