using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Net.Mail;

namespace SendPost
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello post!");
            // отправитель - устанавливаем адрес и отображаемое в письме имя
            MailAddress from = new MailAddress("hetagurovkost777@mail.ru", "Kost");
            // кому отправляем
            MailAddress to = new MailAddress("hetagurovkost777@mail.ru");
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            m.Subject = "Тест";
            // текст письма
            m.Body = "<h2>Hello, my first C# post!</h2>";
            // письмо представляет код html
            m.IsBodyHtml = true;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
            // логин и пароль
            smtp.Credentials = new NetworkCredential("hetagurovkost777@mail.ru", "233217911kot223");
            smtp.EnableSsl = true;
            smtp.Send(m);
            Console.Read();

        }
    }
}
