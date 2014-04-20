using System.Web.Mvc;

namespace LemonadeStand.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string id)
        {
            ViewBag.OgDescription = id;
            return View();
        }
    }
}