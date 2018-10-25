using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Mvc;
using GamingDevicesStore.Controllers;
using GamingDevicesStore.Models;

namespace GamingDevices.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            DeviceContext db = new DeviceContext();
            db.Devices.AddRange(new Device[]
            {
                new Device {Id = 1, Brand = "Device 1"},
                new Device {Id = 2, Brand = "Device 2"},
                new Device {Id = 3, Brand = "Device 3"},
                new Device {Id = 4, Brand = "Device 4"},
                new Device {Id = 5, Brand = "Device 5"}
            });
            db.SaveChanges();
            DeviceController controller = new DeviceController();
            controller.pageSize = 3;

           
        }
    }
}
