using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using Martec.Domain.Models;
using Martec.Domain.Interfaces.Utility;
using System.Configuration;
using System.Web;
using System.Security.Principal;

namespace Martec.Infrastruture.Utilities
{
    //public class EmailNotification : IEmailNotification
    //{
    //    public bool SendEmail(params UserModel[] models)
    //    {
    //        try
    //        {
    //            WindowsIdentity wi = System.Security.Principal.WindowsIdentity.GetCurrent();



    //            string user = wi.User.ToString();


    //            var message = new MailMessage();

    //            foreach (var model in models)
    //            {
    //                message.To.Add(new MailAddress(model.Email));
    //            }

    //            message.From = new MailAddress("Everebukz@gmail.com");
    //            message.Subject = "A message was sent to you";
    //            message.Body = "Did u see that message";
    //            message.IsBodyHtml = true;
    //            message.BodyEncoding = Encoding.UTF8;

    //            using (var smtp = new SmtpClient())
    //            {

    //                smtp.Timeout = 100000;
    //                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
    //                smtp.UseDefaultCredentials = false;
    //                var credential = new NetworkCredential()
    //                {
    //                    UserName = "Everebukz@gmail.com",
    //                    Password = "united4ever",
    //                    Domain = HttpContext.Current.Request.Url.Host




    //                };
    //                smtp.Credentials = credential;
    //                smtp.Host = "smtp-mail.outlook.com";
    //                smtp.Port = 587;
    //                smtp.EnableSsl = true;
    //                smtp.Send(message);



    //            }
    //            return true;
    //        }
    //        catch (Exception ex)
    //        {

    //            Console.WriteLine(ex);
    //            Console.ReadLine();
    //        }
    //        return false;

    //    }
    //}
}