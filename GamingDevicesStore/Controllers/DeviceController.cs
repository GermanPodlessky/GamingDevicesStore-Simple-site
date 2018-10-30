using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GamingDevicesStore.HtmlHelpers;
using GamingDevicesStore.Models;

namespace GamingDevicesStore.Controllers
{
    public interface IDeviceRepository
    {
        IEnumerable<Device> Devices { get; }
    }

    public class DeviceController : Controller
    {
        private DeviceContext db = new DeviceContext();
        public int pageSize = 1;

        public ViewResult List(string category, int page = 1)
        {
            HtmlHelper myHelper = null;

            ViewBag.Devices = db.Devices.Where(p => category == null || p.Category == category)
                .OrderBy(d => d.Id).Skip((page - 1) * pageSize)
                .Take(pageSize);

            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = page,
                TotalItems = category == null?
                    db.Devices.Count() : 
                    db.Devices.Where(d => d.Category == category).Count(),
                ItemsPerPage = pageSize
            };

            Func<int, string> pageUrlDelegate = i => category == null ? "Page" + i :
                $"/{category}/Page{i}";
            MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);

            ViewBag.PagingInfo = pagingInfo;
            ViewBag.Result = result;
            ViewBag.Category = category;
            return View();
        } 
    } 
}