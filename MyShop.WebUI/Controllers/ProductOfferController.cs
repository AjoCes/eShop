using MyShop.Core.Contracts;
using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShop.WebUI.Controllers
{
    public class ProductOfferController : Controller
    {
        IOffers<ProductOffer> context;

        public ProductOfferController(IOffers<ProductOffer> context)
        {

            this.context = context;

        }

        public ProductOfferController()
        {

        }

        // GET: ProductOffer
        public ActionResult Index()
        {
            List<ProductOffer> productOffers = context.Collection().ToList();

            return View(productOffers);
        }


        public ActionResult Create()
        {
            //static polymorphism overloading
            System.Diagnostics.Debug.WriteLine("without parameters");
            ProductOffer productOffer = new ProductOffer();
            return View(productOffer);

        }

        [HttpPost]
        public ActionResult Create(ProductOffer productOffer)
        {
            if (string.IsNullOrEmpty(productOffer.Offer))
            {
                ModelState.AddModelError("Offer", "Offer field is required");
            }
            //static polymorphism overloading
            System.Diagnostics.Debug.WriteLine("with parameters");
            if (!ModelState.IsValid)
            {

                return View(productOffer);
            }
            else
            {

                context.Insert(productOffer);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {

            ProductOffer productOffer = context.Find(Id);          
            if (productOffer == null)
            {

                return HttpNotFound();
            }
            else
            {

                return View(productOffer);
            }
        }
       

        public ActionResult Delete(string Id)
        {

            ProductOffer productOfferToDelete = context.Find(Id);

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
            ProductOffer offerToDelete = context.Find(Id);

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
    }
}