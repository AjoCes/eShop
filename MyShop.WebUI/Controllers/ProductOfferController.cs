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

        public ActionResult Details(string id) 
            // Ne qeet klase duhet me u impleentu polimorfizmi 
        {
            ProductOffer OfferDescription = context.Find(id);

            if (OfferDescription == null)
            {

                return HttpNotFound();
            }
            else {

                //qitu duhet me qene me funksionu polimorfizmi
                OfferDescription.Descr.Description();
                OfferDescription.Descr.Description(1);

               return View (OfferDescription);

               
            }

            
        }

    public ActionResult Create()
        {

            ProductOffer productOffer = new ProductOffer();
            return View(productOffer);

        }

        [HttpPost]
        public ActionResult Create(ProductOffer productOffer)
        {

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
        [HttpPost]
        public ActionResult Edit(ProductOffer offer, string Id)
        {

            //Load the id offer which will be edited 
            ProductOffer productOfferToEdit = context.Find(Id);

            if (productOfferToEdit == null)
            {

                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {

                    return View(offer);
                }

                productOfferToEdit.Offer = offer.Offer;

                context.Commit();

                return RedirectToAction("Index");
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