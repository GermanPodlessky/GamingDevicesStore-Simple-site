using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamingDevicesStore.Models
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(Device device, int quanity)
        {
            CartLine line = lineCollection.Where(d => d.Device.Id == device.Id)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine(){Device = device, Quantity = quanity});
            }
            else
            {
                line.Quantity += quanity;
            }
        }

        public void RemoveLine(Device device)
        {
            lineCollection.RemoveAll(l => l.Device.Id == device.Id);
        }

        public void Clear()
        {
            lineCollection.Clear();
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(l => l.Device.Price * l.Quantity);
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }
    }

    public class CartLine
    {
        public Device Device { get; set; }
        public int Quantity { get; set; }
    }
}