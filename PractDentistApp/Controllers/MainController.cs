using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Net;

namespace PractDentistApp.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendData(string message)
        {
            MailAddress from = new MailAddress("sikirovtemirlan@mail.ru", "Tom");
            // кому отправляем
            MailAddress to = new MailAddress("sikirovtemirlan@mail.ru");
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            m.Subject = "Тест";
            // текст письма
            m.Body = "<h2>Письмо-тест работы smtp-клиента</h2>";
            // письмо представляет код html
            m.IsBodyHtml = true;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            // логин и пароль
            smtp.Credentials = new NetworkCredential("ukionna08@gmail.com", "");
            smtp.EnableSsl = true;
            smtp.Send(m);

            return View("index");
        }
    }
}