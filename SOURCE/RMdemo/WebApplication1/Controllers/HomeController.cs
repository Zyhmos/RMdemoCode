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

        public ActionResult Index()
        {
            return RedirectToAction("Product", "Home");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Product()
        {
            var productManager = new ProductSQL();
            var model = productManager.GetAllData();
            return View(model);
        }

        [HttpGet]
        [Route("Home/ProductEdit/{id:int}")]
        public ActionResult ProductEdit(int id)
        {
            var productManager = new ProductSQL();
            var model = productManager.FindByID(id);
            return View(model);
        }

        [HttpGet]
        [Route("Home/ProductDelete/{id:int}")]
        public ActionResult ProductDelete(int id)
        {
            var productManager = new ProductSQL();
            productManager.DeleteByID(id);
            return RedirectToAction("Product", "Home");
        }

        public ActionResult ProductNew()
        {
            return View();
        }

        public ActionResult ProductSave()
        {
            var productManager = new ProductSQL();
            var product = new Product
            {
                ProductID = Convert.ToInt32(Request.Form["hdid"]),
                Description = Request.Form["tbDescription"],
                Code = Request.Form["tbCode"],
                Type = Convert.ToInt32(Request.Form["tbType"]),
                Amount = Convert.ToInt32(Request.Form["tbAmount"]),
                Price = Convert.ToDouble(Request.Form["tbPrice"])
            };

            if (product.ProductID > 0) {
                productManager.Edit(product);}
            else {
                productManager.AddNew(product);
            }

            return RedirectToAction("Product", "Home");
        }

    }
}