using Kutse_App.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Kutse_App.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string pidu = "";
            if (DateTime.Now.Month == 1)
            {
                pidu = "Head uut aastat";
            }
            else if (DateTime.Now.Month == 2)
            {
                pidu = "Iseseisvuspäeva";
            }
            else if (DateTime.Now.Month == 3)
            {
                pidu = "head rahvusvahelist naistepäeva";
            }
            else if (DateTime.Now.Month == 4)
            {
                pidu = "head kosmonautikapäeva";
            }
            else if (DateTime.Now.Month == 5)
            {
                pidu = "head võidupäeva";
            }
            else if (DateTime.Now.Month == 6)
            {
                pidu = "Head ülemaailmset vanemate päeva";
            }
            else if (DateTime.Now.Month == 7)
            {
                pidu = "head Kanada päeva";
            }
            else if (DateTime.Now.Month == 8)
            {
                pidu = "Head arbuusipäeva";
            }
            else if (DateTime.Now.Month == 9)
            {
                pidu = "Еeadmiste päev";
            }
            else if (DateTime.Now.Month == 10)
            {
                pidu = "Rahvusvahelise muusikapäevaga!";
            }
            else if (DateTime.Now.Month == 11)
            {
                pidu = "Head rahvusliku ühtsuse päeva!";
            }
            ViewBag.Message = "Ootan sind oma peole!" + pidu + "Palun tule kindlasti!";
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 && hour > 4 ? "Tere hommikust!" : "Tere päevast";
            ViewBag.Greeting = hour > 16 && hour < 20 ? "Tere õhtust!" : "Head ööd";
            ViewBag.Greeting = hour < 16 && hour > 12 ? "Tere päevast!" : "Head õhtust";
            ViewBag.Greeting = hour > 20 && hour < 4 ? "Tere ööd!" : "Head hommikust";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Teie rakenduse kirjeldusleht.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Tittle = "Kutse kõik";

            return View();
        }
        [HttpGet]
        public ViewResult Ankeet()
        {
            return View();
        }
        [HttpPost]
        public ViewResult Ankeet(Guest guest)
        {
            E_mail(guest);
            E_mailGuest(guest);
            if (ModelState.IsValid)
            {
                ViewBag.Greeting = guest.Email;
                return View("Thanks", guest);
            }
            else
            {
                return View();
            }
        }

        public void E_mail(Guest guest)
        {

            try
            {
                WebMail.SmtpServer = "smtp.gmail.com";
                WebMail.SmtpPort = 587;
                WebMail.EnableSsl = true;
                WebMail.UserName = "programmeeriminetthk2@gmail.com";
                WebMail.Password = "2.kuursus tarpv20";
                WebMail.From = "programmeeriminetthk2@gmail.com";
                WebMail.Send("programmeeriminetthk2@gmail.com", "Vastus kutsele",guest.Name + " vastas " + ((guest.WillAttend ?? false) ?
                    "tuleb peole " : "ei tule peole"));
                ViewBag.Message = "Kiri on saatnud!";
            }
            catch (Exception)
            {
                ViewBag.Message = "Mul on kahjul! Ei saa kirja saada!!!";
            }
        }

        MailMessage message = new MailMessage();
        public void E_mailGuest(Guest guest)
        {
            string komu = guest.Email;
            message.To.Add(new MailAddress(komu));
            message.From = new MailAddress(komu);
            message.Subject = "Ostetud piletid";
            message.Body = guest.Name + "Ne zabud pridit v 01.05.2022";
            string email = "programmeeriminetthk2@gmail.com";
            string password = "2.kuursus tarpv20";
            SmtpClient client = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(email, password),
                EnableSsl = true,
            };
            /*try
            {
                client.Send(message);
                Environment.Exit(0);
            }
            catch (Exception ex)
            {}*/
        }

        
        

    }
}