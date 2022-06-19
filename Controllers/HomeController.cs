using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompetitionManager.Controllers
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
        public ActionResult Cld()
        {
            ViewBag.Message = "Your class diagram page.";
            return View();
        }
        public ActionResult Ad()
        {
            ViewBag.Message = "Your activity diagram page.";
            return View();
        }
    }
}