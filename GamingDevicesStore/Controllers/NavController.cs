using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GamingDevicesStore.Models;

namespace GamingDevicesStore.Controllers
{
    public class NavController : Controller
    {
        private DeviceContext db = new DeviceContext();

        public PartialViewResult Menu(string category = null, bool horizontalNav = false)
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = db.Devices
                .Select(d => d.Category)
                .Distinct()
                .OrderBy(x => x);
            string viewName = horizontalNav ? "MenuHorizontal" : "Menu";
            return PartialView(viewName,categories);
        }
    }
}