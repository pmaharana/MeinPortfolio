using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;
using MeinPortfolio.Models;


namespace MeinPortfolio.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Email"] = "pranay.maharana@gmail.com";
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Email(EmailFormModel email)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("test", "pranay.maharana@gmail.com"));
            message.To.Add(new MailboxAddress("Pranay", "pranay.maharana@gmail.com"));
            message.Subject = "hi";
            message.Body = new TextPart("plain")
            {
                Text = "will this worku?"
            };

            using (var client = new SmtpClient())
            {
                //client.Connect("smtp.example.com", 587, false);
                //client.AuthenticationMechanisms.Remove("XOAUTH2");

                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect("smtp.gmail.com", 587, false);

                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate("mygoogleusername", "mygooglepassword");

                client.Send(message);
                client.Disconnect(true);
            }



            return RedirectToAction("Index");
        }


    }
}
