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
        private IDeviceRepository repository;
        public int pageSize = 3;

        public ViewResult List(int page = 1)
        {
            HtmlHelper myHelper = null;

            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = page,
                TotalItems = db.Devices.Count(),
                ItemsPerPage = pageSize
            };

            Func<int, string> pageUrlDelegate = i => "Page" + i;
            MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);
            
            ViewBag.Devices =  db.Devices.OrderBy(d => d.Id).Skip((page - 1) * pageSize)
                .Take(pageSize);
            ViewBag.Result = result;
            return View();
        } 
    } 
}