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
                    if (!WebSecurity.Initialized)
                        WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", false);
                    Order order = new Order();
                    order.User = db.UserProfiles.FirstOrDefault(u => u.UserId == WebSecurity.CurrentUserId);
                    db.Orders.Add(order);
                    var productOne = db.Products.FirstOrDefault(p => p.ProductId == 1);
                    var productTwo = db.Products.FirstOrDefault(p => p.ProductId == 2);
                    var productThree = db.Products.FirstOrDefault(p => p.ProductId == 4);
                    var productFour = db.Products.FirstOrDefault(p => p.ProductId == 5);
                    var productFive = db.Products.FirstOrDefault(p => p.ProductId == 6);
                    var productSix = db.Products.FirstOrDefault(p => p.ProductId == 7);
                    var productSeven = db.Products.FirstOrDefault(p => p.ProductId == 8);
                    var productEight = db.Products.FirstOrDefault(p => p.ProductId == 9);
                    for (int i = 0; i < Convert.ToInt32(model.ModelEen); i++)
                    {
                        db.OrderedProducts.Add(new OrderedProduct
                        {
                            Order = order,
                            Product = productOne,
                            Paid = false,
                            UserId = WebSecurity.CurrentUserId,
                        });
                    }
                    for (int i = 0; i < Convert.ToInt32(model.ModelTwee); i++)
                    {
                        db.OrderedProducts.Add(new OrderedProduct
                        {
                            Order = order,
                            Product = productTwo,
                            Paid = false,
                            UserId = WebSecurity.CurrentUserId,
                        });
                    }
                    for (int i = 0; i < Convert.ToInt32(model.ModelDrie); i++)
                    {
                        db.OrderedProducts.Add(new OrderedProduct
                        {
                            Order = order,
                            Product = productThree,
                            Paid = false,
                            UserId = WebSecurity.CurrentUserId,
                        });
                    }
                    for (int i = 0; i < Convert.ToInt32(model.ModelVier); i++)
                    {
                        db.OrderedProducts.Add(new OrderedProduct
                        {
                            Order = order,
                            Product = productFour,
                            Paid = false,
                            UserId = WebSecurity.CurrentUserId,
                        });
                    }
                    for (int i = 0; i < Convert.ToInt32(model.ModelVijf); i++)
                    {
                        db.OrderedProducts.Add(new OrderedProduct
                        {
                            Order = order,
                            Product = productFive,
                            Paid = false,
                            UserId = WebSecurity.CurrentUserId,
                        });
                    }
                    for (int i = 0; i < Convert.ToInt32(model.AccessoireEen); i++)
                    {
                        db.OrderedProducts.Add(new OrderedProduct
                        {
                            Order = order,
                            Product = productSix,
                            Paid = false,
                            UserId = WebSecurity.CurrentUserId,
                        });
                    }
                    for (int i = 0; i < Convert.ToInt32(model.AccessoireTwee); i++)
                    {
                        db.OrderedProducts.Add(new OrderedProduct
                        {
                            Order = order,
                            Product = productSeven,
                            Paid = false,
                            UserId = WebSecurity.CurrentUserId,
                        });
                    }
                    for (int i = 0; i < Convert.ToInt32(model.AccessoireDrie); i++)
                    {
                        db.OrderedProducts.Add(new OrderedProduct
                        {
                            Order = order,
                            Product = productEight,
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
