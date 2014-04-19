using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using LemonadeStand.Common;
using LemonadeStand.Common.Commands;
using LemonadeStand.Common.Persistence;

namespace LemonadeStand.Web.Controllers
{
    public class GameController : Controller
    {
        private GameApplicationRepository repo;

        public GameController()
        {
            repo = new GameApplicationRepository();
        }

        //
        // GET: /Game/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateGame(CreateGame createGame)
        {
            var cmd = new CreateGameCommand(repo);
            var result = cmd.Execute(createGame);
            return Json(result);
        }

        public ActionResult NextDay(GameId gameId)
        {
            var cmd = new NextDayCommand(repo);
            var result = cmd.Execute(gameId);
            return Json(result);
        }

        public ActionResult FinishDay(AddChoices addChoices)
        {
            var addChoicesCommand = new AddChoicesCommand(repo);
            var finishDayCommand = new FinishDayCommand(repo);

            addChoicesCommand.Execute(addChoices);
            var result = finishDayCommand.Execute(addChoices);
            
            return Json(result);
        }

        public ActionResult Urls()
        {
            return Json(new
            {
                views = new
                {
                    createGame = Url.Action("CreateGame", "GameViews"),
                    welcome = Url.Action("Welcome", "GameViews"),
                    weatherForecast = Url.Action("WeatherForecast", "GameViews"),
                    input = Url.Action("Input", "GameViews"),
                    financialReport = Url.Action("FinancialReport", "GameViews")
                },
                actions = new 
                {
                    createGame = Url.Action("CreateGame"),
                    nextDay = Url.Action("NextDay"),
                    finishDay = Url.Action("FinishDay")
                }
            }, JsonRequestBehavior.AllowGet);
        }
    }

    public class GameApplicationRepository : IRepository<Game>
    {
        private static readonly object LockObj = new object();
        private static readonly List<Game> Items = new List<Game>();

        public void Insert(Game entity)
        {
            lock (LockObj)
            {
                Items.Add(entity);
            }
        }

        public void Delete(Game entity)
        {
            lock (LockObj)
            {
                Items.Remove(entity);
            }
        }

        public IQueryable<Game> Query()
        {
            return Items.AsQueryable();
        }

        public Game Get(Expression<Func<Game, bool>> predicate)
        {
            return Query().FirstOrDefault(predicate);
        }
    }
}