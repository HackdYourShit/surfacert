using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SurfaceStudent.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Home pagina.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Extra info pagina.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact pagina.";

            return View();
        }

        public ActionResult Order() { 
            ViewBag.Message = "Bestel pagina.";
            return View();
        }
    }
}
