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
            Manager = new ProductSQL()
        };

        public ActionResult Producter()
        {
            return View();
        }

        public ActionResult Index()
        {
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
                model.Types = model.Manager.GetAllTypeData();
                return View(model);
            }

            var product = new Product
            {
                ProductID = Convert.ToInt32(Request.Form["Selected.ProductID"]),
                Description = Request.Form["Selected.Description"],
                Code = Request.Form["Selected.Code"],
                TypeID = Convert.ToInt32(Request.Form["Selected.TypeID"]),
                Amount = Convert.ToInt32(Request.Form["Selected.Amount"]),
                Price = Convert.ToDouble(Request.Form["Selected.Price"])
            };
            model.Manager.AddNew(product);
            return RedirectToAction("Product", "Home");

        }

        [HttpGet]
        [Route("Home/ProductEdit/{id:int}")]
        public ActionResult ProductEdit(int id)
        {
            model.Selected = model.Manager.FindByID(id);
            model.Types = model.Manager.GetAllTypeData();
            return View(model);
        }

        public ActionResult ProductEdit()
        {
            var product = new Product
            {
                ProductID = Convert.ToInt32(Request.Form["Selected.ProductID"]),
                Description = Request.Form["Selected.Description"],
                Code = Request.Form["Selected.Code"],
                TypeID = Convert.ToInt32(Request.Form["Selected.TypeID"]),
                Amount = Convert.ToInt32(Request.Form["Selected.Amount"]),
                Price = Convert.ToDouble(Request.Form["Selected.Price"])
            };
            model.Manager.Edit(product);
            return RedirectToAction("Product", "Home");
        }

        [HttpGet]
        [Route("Home/ProductDelete/{id:int}")]
        public ActionResult ProductDelete(int id)
        {
            model.Manager.DeleteByID(id);
            return RedirectToAction("Product", "Home");
        }

        public ActionResult ProductSave()
        {
            var product = new Product
            {
                ProductID = Convert.ToInt32(Request.Form["Selected.ProductID"]),
                Description = Request.Form["Selected.Description"],
                Code = Request.Form["Selected.Code"],
                TypeID = Convert.ToInt32(Request.Form["Selected.TypeID"]),
                Amount = Convert.ToInt32(Request.Form["Selected.Amount"]),
                Price = Convert.ToDouble(Request.Form["Selected.Price"])
            };

            if (product.ProductID > 0)
            {
                model.Manager.Edit(product);
            }
            else
            {
                model.Manager.AddNew(product);
            }
            return RedirectToAction("Product", "Home");
        }

    }
}