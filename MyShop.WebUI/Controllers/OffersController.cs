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

        public ActionResult Delete(string Id)
        {

            OffersModel productOfferToDelete = context.Find(Id);

            if (productOfferToDelete == null)
            {

                return HttpNotFound();
            }
            else
            {
                return View(productOfferToDelete);

            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            OffersModel offerToDelete = context.Find(Id);

            if (offerToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {

                context.Delete(Id);
                context.Commit();
                return RedirectToAction("Index");

            }
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