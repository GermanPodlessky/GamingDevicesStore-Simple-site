using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GamingDevicesStore.Models;

namespace GamingDevicesStore.Controllers
{
    public class CartController : Controller
    {
        private DeviceContext db = new DeviceContext();

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
    }
}