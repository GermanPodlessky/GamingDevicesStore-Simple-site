using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GamingDevicesStore.Models;
using GamingDevicesStore.Models.Concrete;

namespace GamingDevicesStore.Controllers
{
    public class CartController : Controller
    {
        private DeviceContext db = new DeviceContext();
        private EmailOrderProcessor emailOrder = new EmailOrderProcessor(new EmailSettings());
        public ViewResult Index(Cart cart,string returnUrl)
        {
            return View(new CartIndexViewModel()
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToRouteResult AddToCart(Cart cart, int id, string returnUrl)
        {
            Device device = db.Devices.FirstOrDefault(d => d.Id == id);

            if (device != null)
            {
                cart.AddItem(device, 1);
            }

            return RedirectToAction("Index", new {returnUrl});
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int id, string returnUrl)
        {
            Device device = db.Devices.FirstOrDefault(d => d.Id == id);

            if (device != null)
            {
                cart.RemoveLine(device);
            }
            
            return RedirectToAction("Index", new {returnUrl});
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Заказ не может быть обработан, ваша корзина пуста!");
            }

            if (ModelState.IsValid)
            {
                emailOrder.ProcessOrder(cart, shippingDetails);
                cart.Clear();
                return View("Completed");
            }
            else return View("Checkout",new ShippingDetails());
        }
    }
}