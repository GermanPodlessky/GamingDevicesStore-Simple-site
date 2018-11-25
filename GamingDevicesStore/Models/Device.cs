using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GamingDevicesStore.Models;

namespace GamingDevicesStore.Models
{
    public class Device
    {   
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Тип")]
        [Required(ErrorMessage = "Пожалуйста, введите тип устройства")]
        public string Type { get; set; }

        [Display(Name = "Модель")]
        [Required(ErrorMessage = "Пожалуйста, введите модель устройства")]
        public string Model { get; set; }

        [Display(Name = "Бренд")]
        [Required(ErrorMessage = "Пожалуйста, введите бренд устройства")]
        public string Brand { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Описание")]
        [Required(ErrorMessage = "Пожалуйста, введите описание для устройства")]
        public string Description { get; set; }

        [Display(Name = "Категория")]
        [Required(ErrorMessage = "Пожалуйста, укажите категорию для устройства")]
        public string Category { get; set; }

        [Display(Name = "Цена (руб)")]
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Пожалуйста, введите положительное значение для цены")]
        public decimal Price { get; set; }

        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }

    

    public class DeviceContext : DbContext
    {
        public DbSet<Device> Devices { get; set; }
    }

    public class DeviceDbInitializer : DropCreateDatabaseIfModelChanges<DeviceContext>
    {
        protected override void Seed(DeviceContext db)
        {
            db.Devices.AddRange(new Device[]
            {
                new Device
                {
                    Id = 1, Type = "Гарнитура", Brand = "Razer", Model = "Kraken Pro V2 Oval Black",
                    Category = "Наушники", Price = 225, Description = "Благодаря многолетним испытаниям и обратной связи от геймеров" +
                    " и наших профессиональных киберспортсменов, Razer Kraken Pro эволюционировала. Обновленная гарнитура Razer Kraken V2 Oval " +
                    "оснащена двумя 50-миллиметровыми модифицированными динамиками, они большего размера, чем динамики в гарнитурах Kraken предыдущего поколения, и обладают более широким диапазоном частот."
                },
                new Device
                {
                    Id = 2, Type = "Гарнитура", Brand = "Razer", Model = "Thresher Tournament",
                    Category = "Клавиатуры", Price = 245, Description ="Гарнитура Razer Thresher Tournament Edition обеспечивает абсолютный комфорт во время многочасовых игр на консоли и ПК."
                },
                new Device
                {
                    Id = 3, Type = "Гарнитура", Brand = "Razer", Model = "Kraken 7.1 V2 Oval",
                    Category = "Наушники", Price = 249, Description ="Игровая гарнитура Razer Kraken 7.1 V2 с передовой системой формирования виртуального объемного многоканального звука 7.1. Для точного позиционного аудио она оснащена новыми мощными 50 мм динамиками Razer™ с индивидуальной настройкой. "

                },
                new Device
                {
                    Id = 4, Type = "Гарнитура", Brand = "Cougar", Model = "MEGARA",
                    Category = "Наушники", Price = 69, Description ="Легкая компактная игровая гарнитура Cougar MEGARA обеспечит детализированное звучание и превосходную шумоизоляцию."
                },
                new Device
                {
                    Id = 5, Type = "Гарнитура", Brand = "Razer", Model = "Hammerhead Pro V2",
                    Category = "Наушники", Price = 179, Description ="Внешний вид гарнитуры Razer Hammerhead Pro заметно изменился, но прочность остается неизменной. Новый дизайн и плоские кабели порадуют поклонников мобильных игр."
                }
            });
            base.Seed(db);
        }
    }
}