using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GamingDevicesStore.Models
{
    public class ShippingDetails
    {
        public string[] Name = {"Строка 1", "Строка 2", "Город", "Страна"}; 

        [Required(ErrorMessage = "Укажите фамилию")]
        public string SecondName { get; set; }

        [Required(ErrorMessage = "Укажите Имя")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Вставьте первый адрес доставки")]
        public string Line1 { get; set; }
        public string Line2 { get; set; }

        [Required(ErrorMessage = "Укажите город")]
        public string City { get; set; }

        [Required(ErrorMessage = "Укажите страну")]
        public string Country { get; set; }

        public bool Pickup { get; set; }
    }
}