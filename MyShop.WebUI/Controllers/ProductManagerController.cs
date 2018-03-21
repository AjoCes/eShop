using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyShop.Core.Models;
using MyShop.DataAccess.InMemory;
using MyShop.Core.ViewModels;
using MyShop.Core.Contracts;
using System.IO;

namespace MyShop.WebUI.Controllers
{
    //Controllers process incoming requests, 
    //handle user input and interactions, and execute appropriate application logic

    public class ProductManagerController : Controller
    {
        IRepository<Product> context;
        IRepository<ProductCategory> productCategories;
        IOffers<ProductOffer> productOffers;
        IOffers<OffersModel> offersModel;

        public ProductManagerController(IRepository<Product> productContext, IRepository<ProductCategory> productCategoryContext, IOffers<ProductOffer> productOfferContext, IOffers<OffersModel> productOffersContext) {
       
            context = productContext;
            productCategories = productCategoryContext;
            productOffers = productOfferContext;
            offersModel = productOffersContext;
        }

        // GET: ProductManager
        /*In ASP.NET applications that do not use the MVC framework, 
         * user interaction is organized around pages, and around raising and handling events
         * from the page and from controls on the page. 
         * In contrast, user interaction with ASP.NET MVC applications is organized around controllers 
         * and action methods. The controller defines action methods. 
         * Controllers can include as many action methods as needed.
         */

        public ActionResult Index()
        {
            List<Product> products = context.Collection().ToList();
             
            return View(products);
        }

        public ActionResult Create() {
            ProductManagerViewModel viewModel = new ProductManagerViewModel();

            viewModel.Product = new Product();
            viewModel.ProductCategories = productCategories.Collection();
            viewModel.ProductOffers = productOffers.Collection();
            viewModel.OffersModel = offersModel.Collection();
            return View(viewModel);
        }

        //Polimorfizmi
        [HttpPost]
        public ActionResult Create(Product product, HttpPostedFileBase file) {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            else {

                if (file != null) {
                    product.Image = product.Id + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Content//ProductImages//") + product.Image);
                }

                context.Insert(product);
                context.Commit();

                return RedirectToAction("Index");
            }

        }

        public ActionResult Edit(string Id) {
            Product product = context.Find(Id);
            if (product == null)
            {
                return HttpNotFound();
            }
            else {
                ProductManagerViewModel viewModel = new ProductManagerViewModel();
                viewModel.Product = product;
                viewModel.ProductCategories = productCategories.Collection();
                viewModel.ProductOffers = productOffers.Collection();
                viewModel.OffersModel = offersModel.Collection();

                return View(viewModel);
            }
        }
        //Polimorfizmi
        [HttpPost]
        public ActionResult Edit(Product product, string Id, HttpPostedFileBase file) {
            Product productToEdit = context.Find(Id);

            if(String.IsNullOrEmpty(product.Description))
            {
                return HttpNotFound();
            }

            if (productToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid) {
                    return View(product);
                }

                if (file != null) {
                    productToEdit.Image = product.Id + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Content//ProductImages//") + productToEdit.Image);
                }

                productToEdit.Category = product.Category;
                productToEdit.Description = product.Description;
                productToEdit.Name = product.Name;
                productToEdit.Price = product.Price;
                productToEdit.Offer = product.Offer;

                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string Id)
        {
            Product productToDelete = context.Find(Id);

            if (productToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id) {
            Product productToDelete = context.Find(Id);

            if (productToDelete == null)
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
 