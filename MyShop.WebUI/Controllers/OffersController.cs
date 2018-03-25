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

    public class PreniumClientOffer : OffersController {

        BaseOffer baseoffer;

        public PreniumClientOffer(BaseOffer baseOffer) {

            this.baseoffer = baseOffer;
        }

        public override ActionResult Index()
        {         
            return PartialView("IndexPrenium");

        }

    }


    public class NormalClientOffer : OffersController
    {

        public NormalClientOffer(){
            
        }

        public override ActionResult Index()
        { 
            return PartialView("IndexNormal");
           
        }

    }

    public class Execute
    {
        //OffersController offersController;

        public ActionResult viewCaller(OffersController offersController) {
            return offersController.Index();
        }
    }
}