using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GamingDevicesStore.Models;

namespace GamingDevicesStore.Controllers
{
    public class AdminController : Controller
    {
        private DeviceContext db = new DeviceContext();

        public ActionResult Index()
        {
            ViewBag.Devices = db.Devices;
            return View();
        }

        
        public ViewResult Edit(int id)
        {
            Device device = db.Devices.FirstOrDefault(d => d.Id == id);
            return View(device);
        }

        [HttpPost]
        public ActionResult Edit(Device device)
        {
            if (ModelState.IsValid)
            {
                SaveDevice(device);
                TempData["message"] =
                    string.Format($"Изменения в устройстве \"{device.Model} {device.Brand}\" были сохранены");
                return RedirectToAction("Index");
            }
            else
            {
                return View(device);
            }
        }

        private void SaveDevice(Device device)
        {
            if (device.Id == 0)
            {
                db.Devices.Add(device);
            }
            else
            {
                Device dbDevice = db.Devices.Find(device.Id);
                if (dbDevice != null)
                {
                    dbDevice.Type = device.Type;
                    dbDevice.Model = device.Model;
                    dbDevice.Brand = device.Brand;
                    dbDevice.Description = device.Description;
                    dbDevice.Price = device.Price;
                    dbDevice.Category = device.Category;
                }
            }
            db.SaveChanges();
        }
    }
}