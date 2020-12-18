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
            return View();
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
            ViewBag.Message = "Products";
            var model = new List<Product>
            {
                new Product { ProductID = 1, Description = "TEST", Code = "TEST", Type = 1, Amount = 5, Price = 10.45 },
                new Product { ProductID = 1, Description = "TEST", Code = "TEST", Type = 1, Amount = 5, Price = 10.45 },
                new Product { ProductID = 1, Description = "TEST", Code = "TEST", Type = 1, Amount = 5, Price = 10.45 },
                new Product { ProductID = 1, Description = "TEST", Code = "TEST", Type = 1, Amount = 5, Price = 10.45 },
                new Product { ProductID = 1, Description = "TEST", Code = "TEST", Type = 1, Amount = 5, Price = 10.45 }
            };
            return View(model);
        }

        public ActionResult ProductAdd()
        {
            return View();
        }

        public ActionResult ProductEdit()
        {
            return View();
        }
    }
}