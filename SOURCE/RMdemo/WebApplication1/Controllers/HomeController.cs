//RMA 20/12/20 TFS-[Practice Task] File Creation

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductModel model = new ProductModel
        {
            Selected = new Product(),
            Products = new List<Product>(),
            Types = new List<Models.Type>(),
            Manager = new ProductManager()
        };

        public ActionResult Index()
        {
            //RMA 20/12/20 TFS-[Practice Task] Made index redirect to product page.
            return RedirectToAction("Product", "Home");
        }

        public ActionResult Product()
        {
            model.Products = model.Manager.GetAllData();
            return View(model);
        }

        public ActionResult ProductNew()
        {
            if (this.Request.RequestType != "POST")
            {
                //If this is a fresh page, fill the Product-Type dropdown list and open a blank page.
                model.Types = model.Manager.GetAllTypeData();
                return View(model);
            }

            //If this is a filled page, refresh the page with appropriate values. This is used for form validation.
            var product = new Product
            {
                ProductID = Convert.ToInt32(Request.Form["Selected.ProductID"]),
                Description = Request.Form["Selected.Description"],
                Code = Request.Form["Selected.Code"],
                TypeID = Convert.ToInt32(Request.Form["ddlType"]),
                Amount = Convert.ToInt32(Request.Form["Selected.Amount"]),
                Price = Convert.ToDouble(Request.Form["Selected.Price"])
            };
            model.Manager.AddNew(product);
            return RedirectToAction("Product", "Home");
        }

        /// <summary>
        /// Open specific products page by product ID parameter in link.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Specific products page.</returns>
        [HttpGet]
        [Route("Home/ProductEdit/{id:int}")]
        public ActionResult ProductEdit(int id)
        {
            //NOTE: I'd usually avoid using the db id, or at least encrypt it, but I don't want to over do it here.
            model.Selected = model.Manager.FindByID(id);
            model.Types = model.Manager.GetAllTypeData();
            return View(model);
        }

        /// <summary>
        /// Product Edit page form validation doesn't need ID
        /// </summary>
        /// <returns></returns>
        public ActionResult ProductEdit()
        {
            var product = new Product
            {
                ProductID = Convert.ToInt32(Request.Form["Selected.ProductID"]),
                Description = Request.Form["Selected.Description"],
                Code = Request.Form["Selected.Code"],
                TypeID = Convert.ToInt32(Request.Form["ddlType"]),
                Amount = Convert.ToInt32(Request.Form["Selected.Amount"]),
                Price = Convert.ToDouble(Request.Form["Selected.Price"])
            };
            model.Manager.Edit(product);
            return RedirectToAction("Product", "Home");
        }

        /// <summary>
        /// Delete product
        /// </summary>
        /// <param name="id">Deleted Product ID</param>
        /// <returns>Product list page</returns>
        [HttpGet]
        [Route("Home/ProductDelete/{id:int}")]
        public ActionResult ProductDelete(int id)
        {
            model.Manager.DeleteByID(id);
            return RedirectToAction("Product", "Home");
        }

    }
}