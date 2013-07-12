using MVCSurfaceRTStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSurfaceRTStore.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "De revolutionaire nieuwe tablet van Microsoft, is een technisch hoogstandje en een kunstwerk. Surface heeft een ultralichte en uiterst duurzame magnesiumbehuizing en zal jouw manier van werken en ontspannen veranderen.";

            return View();
        }

        public ActionResult MeerInformatie()
        {
            ViewBag.Message = "Meer Informatie";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
