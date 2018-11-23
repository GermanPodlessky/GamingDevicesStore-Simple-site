using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;
using Newtonsoft.Json;

namespace GamingDevicesStore.Models
{
    public class ShippingDetails
    {
        public string[] Name = {"Номер","Строка 1", "Строка 2", "Город", "Страна"};

        [Required(ErrorMessage = "Укажите фамилию")]
        public string SecondName { get; set; }

        [Required(ErrorMessage = "Укажите имя")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Укажите мобильный телефон")]
        public string Number { get; set; }
        
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