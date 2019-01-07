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
            MailAddress from = new MailAddress("hetagurovkost777@mail.ru", "Константин Хетагуров");
            // кому отправляем
            Console.WriteLine("Введите адрессата письма: ");
            string adress = Console.ReadLine();
            MailAddress to = new MailAddress(adress);
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            Console.WriteLine("Введите тему письма: ");
            string tema = Console.ReadLine();
            m.Subject = tema;
            // текст письма
            Console.WriteLine("Введите текст письма: ");
            string text = Console.ReadLine();
            m.Body = $"<h2>{text}</h2>";
            m.IsBodyHtml = true;
            Console.WriteLine($"Ваше письмо на адрес {adress}: \r\nТема:\r\n{tema}\r\nТекст\r\n{text}");
            Console.WriteLine("Нажмите любую клавишу");
            Console.ReadKey();
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
            // логин и пароль
            smtp.Credentials = new NetworkCredential("hetagurovkost777@mail.ru", "233217911kot223");
            smtp.EnableSsl = true;
            smtp.Send(m);
            Console.WriteLine($"Письмо успешно отправлено!");

            Console.ReadKey();

        }
    }
}
