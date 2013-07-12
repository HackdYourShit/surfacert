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
        private readonly StoreDbContext _storeDb = new StoreDbContext();

        public ActionResult Products()
        {
            var products = _storeDb.Products.ToList();
            return View(products);
        }

        public ActionResult ProductDetails(int id)
        {
            var product = _storeDb.Products.FirstOrDefault(p => p.ProductId == id);
            return View(product);
        }

        public ActionResult Order()
        {
            return View(new OrderModel());
         }

        //
        // POST: /Account/Order

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Order(OrderModel model)
        {
            if (ModelState.IsValid)
            {
                // ChangePassword will throw an exception rather than return false in certain failure scenarios.
                using (StoreDbContext db = new StoreDbContext())
                {
                    Order order = new Order();
                    order.UserId = WebSecurity.CurrentUserId;
                    db.Orders.Add(order);
                    for (int i = 0; i < Convert.ToInt32(model.ModelEen); i++)
                    {
                        db.OrderedProducts.Add(new OrderedProduct
                        {
                            OrderId = db.Orders.Last().OrderId,
                            OrderedProductId = db.Products.ElementAt(0).ProductId,
                            Paid = false,
                            UserId = WebSecurity.CurrentUserId,
                        });
                    }
                    for (int i = 0; i < Convert.ToInt32(model.ModelTwee); i++)
                    {
                        db.OrderedProducts.Add(new OrderedProduct
                        {
                            OrderId = db.Orders.Last().OrderId,
                            OrderedProductId = db.Products.ElementAt(1).ProductId,
                            Paid = false,
                            UserId = WebSecurity.CurrentUserId,
                        });
                    }
                    for (int i = 0; i < Convert.ToInt32(model.ModelEen); i++)
                    {
                        db.OrderedProducts.Add(new OrderedProduct
                        {
                            OrderId = db.Orders.Last().OrderId,
                            OrderedProductId = db.Products.ElementAt(2).ProductId,
                            Paid = false,
                            UserId = WebSecurity.CurrentUserId,
                        });
                    }
                    for (int i = 0; i < Convert.ToInt32(model.ModelEen); i++)
                    {
                        db.OrderedProducts.Add(new OrderedProduct
                        {
                            OrderId = db.Orders.Last().OrderId,
                            OrderedProductId = db.Products.ElementAt(3).ProductId,
                            Paid = false,
                            UserId = WebSecurity.CurrentUserId,
                        });
                    }
                    for (int i = 0; i < Convert.ToInt32(model.ModelEen); i++)
                    {
                        db.OrderedProducts.Add(new OrderedProduct
                        {
                            OrderId = db.Orders.Last().OrderId,
                            OrderedProductId = db.Products.ElementAt(4).ProductId,
                            Paid = false,
                            UserId = WebSecurity.CurrentUserId,
                        });
                    }
                    for (int i = 0; i < Convert.ToInt32(model.ModelEen); i++)
                    {
                        db.OrderedProducts.Add(new OrderedProduct
                        {
                            OrderId = db.Orders.Last().OrderId,
                            OrderedProductId = db.Products.ElementAt(5).ProductId,
                            Paid = false,
                            UserId = WebSecurity.CurrentUserId,
                        });
                    }
                    for (int i = 0; i < Convert.ToInt32(model.ModelEen); i++)
                    {
                        db.OrderedProducts.Add(new OrderedProduct
                        {
                            OrderId = db.Orders.Last().OrderId,
                            OrderedProductId = db.Products.ElementAt(6).ProductId,
                            Paid = false,
                            UserId = WebSecurity.CurrentUserId,
                        });
                    }
                    for (int i = 0; i < Convert.ToInt32(model.ModelEen); i++)
                    {
                        db.OrderedProducts.Add(new OrderedProduct
                        {
                            OrderId = db.Orders.Last().OrderId,
                            OrderedProductId = db.Products.ElementAt(7).ProductId,
                            Paid = false,
                            UserId = WebSecurity.CurrentUserId,
                        });
                    }
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Orders");
        }

        public ActionResult Orders()
        {
            var dictionary = new Dictionary<int, List<OrderedProduct>>();
            if (User.Identity.IsAuthenticated)
            {
                if (!WebSecurity.Initialized)
                    WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", false);
                List<Order> userOrders = _storeDb.Orders.Where(o => o.UserId  == WebSecurity.CurrentUserId).ToList();
                foreach (var userOrder in userOrders)
                {
                    var orders = _storeDb.OrderedProducts.Where(op => op.OrderId == userOrder.OrderId).ToList();
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
                var order = _storeDb.OrderedProducts.Where(p => p.OrderId == id).ToList();
                return View(order);
        }

        public List<OrderedProduct> GetOrderContent(int id)
        {
            return _storeDb.OrderedProducts.Where(p => p.OrderId == id).ToList();
        }
    }
}
