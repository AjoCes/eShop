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

        public virtual ActionResult OffersButton() {          
                Execute execute = new Execute();
                NormalClientOffer normalClientOffer = new NormalClientOffer();
                PreniumClientOffer preniumClientOffer = new PreniumClientOffer();
                Offers offer = new Offers();
            if (offer.Equals("Normal"))
            {
             return execute.viewCaller(normalClientOffer);
            }
            else {
             return execute.viewCaller(preniumClientOffer);
            }         
           // return execute.viewCaller(normalClientOffer); 
            
        }

        
    }

    public class PreniumClientOffer : OffersController {

        public PreniumClientOffer() {
        
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