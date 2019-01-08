using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Text.RegularExpressions;




namespace NetTest.Views
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string cond = @"(\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)";
            //string email = @"Bruce_Wayne@gmail.com";

            //if (Regex.IsMatch(email, cond))
            //{
            //    //удовлетворяет условию...
            //}
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // отправитель - устанавливаем адрес и отображаемое в письме имя
            MailAddress from = new MailAddress("hetagurovkost777@mail.ru", "Константин Хетагуров");
            // кому отправляем
            MailAddress to = new MailAddress("hetagurovkost777@mail.ru");
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            m.Subject = "Purshase this!";
            // текст письма
            m.Body = $"<h2>Letter!</h2>";
            m.IsBodyHtml = true;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
            // логин и пароль
            smtp.Credentials = new NetworkCredential("hetagurovkost777@mail.ru", "233217911kot223");
            smtp.EnableSsl = true;
            box.InnerText = "оправлено!";
            smtp.Send(m);
        }
    }
}