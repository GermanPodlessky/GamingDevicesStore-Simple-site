using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace GamingDevicesStore.Models.Concrete
{
    public class EmailSettings
    {
        //public string MailToAddress = "orders@example.com";
        public string MailToAddress = "podlesskiy99@mail.ru";
        public string MailFromAddress = "podlesskiy00@mail.ru";
        public bool UseSsl = true;
        public string Username = "podlesskiy00@mail.ru";
        public string Password = "alla123";
        public string ServerName = "smtp.mail.ru";
        public int ServerPort = 25;
        public bool WriteAsFile = false;
        public string FileLocation = @"D:\learn\GamingDevicesStore\game_devices_store_emails";
    }

    public class EmailOrderProcessor
    {
        private EmailSettings emailSettings;

        public EmailOrderProcessor(EmailSettings emailSettings)
        {
            this.emailSettings = emailSettings;
        }

        public void ProcessOrder(Cart cart, ShippingDetails shippingInfo)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = emailSettings.UseSsl;
                smtpClient.Host = emailSettings.ServerName;
                smtpClient.Port = emailSettings.ServerPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials =
                    new NetworkCredential(emailSettings.Username, emailSettings.Password);

                if (emailSettings.WriteAsFile)
                {
                    smtpClient.DeliveryMethod =
                        SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = emailSettings.FileLocation;
                    smtpClient.EnableSsl = false;
                }

                StringBuilder body = new StringBuilder()
                    .AppendLine("Новый заказ обработан")
                    .AppendLine("****")
                    .AppendLine("Товары:");

                foreach (var line in cart.Lines)
                {
                    var subtotal = line.Device.Price * line.Quantity;
                    body.AppendLine($"{line.Quantity} * {line.Device.Type} {line.Device.Brand} {line.Device.Model}" +
                                    $"{subtotal:0c}");
                }

                body.AppendFormat("Общая стоимость: {0:c}", cart.ComputeTotalValue())
                    .AppendLine("Доставка:")
                    .AppendLine("Фамилия - " + shippingInfo.SecondName)
                    .AppendLine("Имя - "+ shippingInfo.SecondName)
                    .AppendLine("Номер- "+ shippingInfo.Number)
                    .AppendLine("Адрес - " + shippingInfo.Line1)
                    .AppendLine(shippingInfo.Line2 ?? "")
                    .AppendLine("Город " + shippingInfo.City)
                    .AppendLine("Страна" + shippingInfo.Country)
                    .AppendLine("---")
                    .AppendFormat("Самовывоз {0}", shippingInfo.Pickup ? "да" : "нет");

                MailMessage mailMessage = new MailMessage(
                    emailSettings.MailFromAddress,
                    emailSettings.MailToAddress,
                    "Новый заказ отправлен",
                    body.ToString());

                if (emailSettings.WriteAsFile)
                {
                    mailMessage.BodyEncoding = Encoding.UTF8;
                }

                smtpClient.Send(mailMessage);
            }
        }
    }
}