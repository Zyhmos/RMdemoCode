using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //RMA 20/12/20 TFS-[Practice Task] Made index redirect to product page.
            return RedirectToAction("Product", "Product");
        }
    }
}