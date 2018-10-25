using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
        
        //public DeviceController() { }

        //public DeviceController(DeviceContext db)
        //{
        //    this.db = db;
        //} 

        public ViewResult Index(int page = 1)
        {
            ViewBag.Devices =  db.Devices.OrderBy(d => d.Id).Skip((page - 1) * pageSize)
                .Take(pageSize);
            return View();
        } 
    } 
}