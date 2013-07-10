using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCSurfaceRTStore.Models;

namespace MVCSurfaceRTStore.Controllers
{
    public class StoreController : Controller
    {
        StoreDbContext storeDB = new StoreDbContext();

        public ActionResult Products()
        {

            var products = storeDB.Products.ToList();
            
            return View(products);

        }

        public ActionResult Details(int id)
        {
            var product = new Product { ProductName = "RT" +  id};

            return View(product);
        }
    }
}
