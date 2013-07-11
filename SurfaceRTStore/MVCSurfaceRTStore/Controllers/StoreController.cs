using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCSurfaceRTStore.Models;
using System.Web.Security;
using WebMatrix.WebData;

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

        public ActionResult ProductDetails(int id)
        {
            var product = storeDB.Products.FirstOrDefault(p => p.ProductId == id);
            return View(product);
        }

        public ActionResult Order()
        {
            var products = storeDB.Products.ToList();
            return View(products);
        }

        public ActionResult Orders()
        {
            var dictionary = new Dictionary<int, List<OrderedProduct>>();
            if (User.Identity.IsAuthenticated)
            {
                if (!WebSecurity.Initialized)
                    WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", false);
                List<Order> userOrders = storeDB.Orders.Where(o => o.UserId  == WebSecurity.CurrentUserId).ToList();
                foreach (var userOrder in userOrders)
                {
                    var orders = storeDB.OrderedProducts.Where(op => op.OrderId == userOrder.OrderId).ToList();
                    foreach (var order in orders)
                    {
                        if (order.OrderId != null)
                        {
                            if (!dictionary.ContainsKey((int)order.OrderId))
                                dictionary.Add((int)order.OrderId, new List<OrderedProduct>());
                            dictionary[(int)order.OrderId].Add(order);
                        }
                    }   
                }
            }
            return View(dictionary);
        }

        public ActionResult OrderDetails(int id)
        {
                var order = storeDB.OrderedProducts.Where(p => p.OrderId == id).ToList();
                return View(order);
        }

        public List<OrderedProduct> GetOrderContent(int id)
        {
            return storeDB.OrderedProducts.Where(p => p.OrderId == id).ToList();
        }
    }
}
