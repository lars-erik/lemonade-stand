using System.Web.Mvc;

namespace LemonadeStand.Web.Controllers
{
    public class GameViewsController : Controller
    {
        public ActionResult CreateGame()
        {
            return PartialView();
        }

        public ActionResult Welcome()
        {
            return PartialView();
        }

        public ActionResult WeatherForecast()
        {
            return PartialView();
        }

        public ActionResult Input()
        {
            return PartialView();
        }

        public ActionResult FinancialReport()
        {
            return PartialView();
        }
    }
}