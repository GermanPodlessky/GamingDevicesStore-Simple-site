using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GamingDevicesStore.Models
{
    public class Device
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }

    public class DeviceContext : DbContext
    {
        public DbSet<Device> Devices { get; set; }
    }

    public class DeviceDbInitializer : DropCreateDatabaseAlways<DeviceContext>
    {
        protected override void Seed(DeviceContext db)
        {
            db.Devices.AddRange(new Device[]
            {
                new Device {Id = 1, Brand = "Device 1"},
                new Device {Id = 2, Brand = "Device 2"},
                new Device {Id = 3, Brand = "Device 3"},
                new Device {Id = 4, Brand = "Device 4"},
                new Device {Id = 5, Brand = "Device 5"}
            });
            base.Seed(db);
        }
    }
}