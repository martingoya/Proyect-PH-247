using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using OhlalaPH.Models;
using System.Text;

namespace OhlalaPH.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactModels c)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    MailMessage msg = new MailMessage();
                    SmtpClient smtp = new SmtpClient();
                    MailAddress from = new MailAddress(c.Email.ToString());
                    StringBuilder sb = new StringBuilder();
                    msg.To.Add("tincho_592@hotmail.com");
                    msg.Subject = "Contacto";
                    msg.IsBodyHtml = false;
                    smtp.Host = "mail.yourdomain.com";
                    smtp.Port = 25;
                    sb.Append("Nombre: " + c.Name);
                    sb.Append(Environment.NewLine);
                    sb.Append("Mail: " + c.Email);
                    sb.Append(Environment.NewLine);
                    sb.Append("Teléfono: " + c.Tel);
                    sb.Append(Environment.NewLine);
                    sb.Append("Consulta: " + c.Comment);
                    msg.Body = sb.ToString();
                    smtp.Send(msg);
                    msg.Dispose();
                    return View("Success");
                }
                catch (Exception)
                {
                    return View("Error");
                }
            }
            return View();
        }
    }
}
