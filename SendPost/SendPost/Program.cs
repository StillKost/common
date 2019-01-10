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
            string[] validUser(string _name, string _email, string _password)
            {
                string _valid = "";
                //отправитель
                if (_name == "" || _name == " ") _name = "Отправитель";

                for (int i = 0; ; i++)
                {
                    _valid = Console.ReadLine();
                    if (_valid.ToUpper() == "ДА")
                        break;
                    else if (_valid.ToUpper() == "НЕТ")
                    {
                        _name = Console.ReadLine();
                        Console.WriteLine("Введите Ваш адресс електронной почты (например: example@example.ru/com): ");
                        _email = Console.ReadLine();
                        Console.WriteLine("Введите пароль от Вашей електронной почты: ");
                        _password = Console.ReadLine();
                        for (int j = 0; ; j++)
                        {
                            if (_password == "" || _password == " ")
                            {
                                Console.WriteLine("Введите пароль от Вашей електронной почты: ");
                                _password = Console.ReadLine();
                            }
                            else
                                break;
                        }
                        Console.WriteLine($"Убедитесь в правильности введенных Вами данных:\r\n" +
                            $"Вы ввели: имя: {_name}, адресс почты: {_email}, пароль: {_password}\r\n" +
                            $"Вы подтверждаете эти данные? ДА или НЕТ");
                        _valid = Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Введите ДА или НЕТ...");
                        _valid = Console.ReadLine();
                    }
                }
                string[] user = new string[] { _name, _email, _password };
                return user;
            }
            string[] validAdrr(string _name, string _email)
            {
                string _valid = "";
                // кому отправляем
                for (int i = 0; ; i++)
                {
                    if (_email == "" || _email == " ")
                    {
                        Console.WriteLine("Введите email адрессата письма: ");
                        _email = Console.ReadLine();
                    }
                    else
                        break;
                }
                if (_name == "" || _name == " ") _name = "Адрессат";
                //проверка данных получателя
                Console.WriteLine($"Убедитесь в правильности введенных Вами данных:\r\n" +
                    $"Вы ввели: имя: {_name}, адресс почты: {_email}");
                for (int i = 0; ; i++)
                {
                    _valid = Console.ReadLine();
                    if (_valid.ToUpper() == "ДА")
                        break;
                    else if (_valid.ToUpper() == "НЕТ")
                    {
                        // кому отправляем
                        Console.WriteLine("Введите email адрессата письма: ");
                        _email = Console.ReadLine();
                        for (int j = 0; ; j++)
                        {
                            if (_email == "" || _email == " ")
                            {
                                Console.WriteLine("Введите адрессата письма: ");
                                _email = Console.ReadLine();
                            }
                            else
                                break;
                        }
                        Console.WriteLine("Введите Имя адрессата письма: ");
                        _name = Console.ReadLine();
                        if (_name == "" || _name == " ") _name = "Адрессат";
                        _valid = Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Введите ДА или НЕТ...");
                        _valid = Console.ReadLine();
                    }
                }
                string[] user = new string[] {_name, _email };
                return user;
            }

            Console.WriteLine("<<<<<<<<Local post>>>>>>>>>");
            //отправитель
            string Name = "", Mail = "", Pword = "";
            var iam = validUser(Name, Mail, Pword);
            Console.WriteLine("Введите Ваше имя (например: Иван Иванов): ");
            Name = Console.ReadLine();
            Console.WriteLine("Введите Ваш адресс електронной почты (например: example@example.ru/com): ");
            Mail = Console.ReadLine();
            Console.WriteLine("Введите пароль от Вашей електронной почты: ");
            Pword = Console.ReadLine();
            MailAddress from = new MailAddress($"{iam[1]}", $"{iam[0]}");
            // кому отправляем
            string AdrName = "", AdrMail = "";
            var addr = validAdrr(AdrName, AdrMail);
            Console.WriteLine("Введите Имя адрессата письма: ");
            AdrName = Console.ReadLine();
            Console.WriteLine("Введите email адрессата письма: ");
            AdrMail = Console.ReadLine();

            MailAddress to = new MailAddress(addr[1]);

            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            Console.WriteLine("Введите тему письма: ");
            string tema = Console.ReadLine();
            if (tema == "" || tema == " ") tema = "Здравствуйте!";
            m.Subject = tema;
            // текст письма
            Console.WriteLine("Введите текст письма: ");
            string text = Console.ReadLine();
            if (text == "" || text == " ") text = "Некий текст этого маленького, но крутого письма!";
            #region Letter
            m.Body = $"<table align=\"center\" border=\"0\" width=\"80%\" style=\"font-family: CENTURY GOTHIC;border: 1px solid;background: #e1efff; line-height: 23px\">" +
                    $"<tr>" +
                        $"<td colspan=\"2\" style=\"padding: 15px\">" +
                            $"{iam[0]}, {iam[1]}" +
                        $"</td>" +
                    $"</tr>" +
                    $"<tr>" +
                        $"<td colspan=\"2\" style=\"padding: 15px\">" +
                            $"{addr[0]}, здравствуйте!" +
                        $"</td>" +
                    $"</tr>" +
                    $"<tr>" +
                          $"<td colspan=\"2\" style=\"padding: 15px\">" +
                              $"{text}" +
                          $"</td>" +
                      $"</tr>" +
                      $"<tr>" +
                          $"<td colspan=\"2\" style=\"text-align: right; padding: 15px\">" +
                              $"Спасибо за уделенное внимание,<br>" +
                              $"с уважением, {iam[0]}!" +
                          $"</td>" +
                      $"</tr>" +
                  $"</table>";
            #endregion
            m.IsBodyHtml = true;
            Console.WriteLine("Нажмите любую клавишу");
            Console.ReadKey();
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
            // логин и пароль
            smtp.Credentials = new NetworkCredential($"{iam[1]}", $"{iam[2]}");
            smtp.EnableSsl = true;
            try
            {
                smtp.Send(m);
            }
            catch (System.Net.Mail.SmtpException)
            {
                Console.WriteLine("Возникли ошибки во время отправки письма!\r\n" +
                    "Возможно Вы неверно ввели свой пароль, адресс или(и) адресс получателя.\r\n" +
                    "Попрубуйте еще раз!\r\n");
                //отправитель
                iam = validUser(Name, Mail, Pword);
                Console.WriteLine("Введите Ваше имя (например: Иван Иванов): ");
                Name = Console.ReadLine();
                Console.WriteLine("Введите Ваш адресс електронной почты (например: example@example.ru/com): ");
                Mail = Console.ReadLine();
                Console.WriteLine("Введите пароль от Вашей електронной почты: ");
                Pword = Console.ReadLine();
                from = new MailAddress($"{iam[1]}", $"{iam[0]}");
                // кому отправляем
                addr = validAdrr(AdrName, AdrMail);
                Console.WriteLine("Введите Имя адрессата письма: ");
                AdrName = Console.ReadLine();
                Console.WriteLine("Введите email адрессата письма: ");
                AdrMail = Console.ReadLine();
                to = new MailAddress(addr[1]);
                from = new MailAddress($"{iam[1]}", $"{iam[0]}");
                m = new MailMessage(from, to);
                smtp.Credentials = new NetworkCredential($"{iam[1]}", $"{iam[2]}");
                smtp.EnableSsl = true;
                #region Letter
                m.Body = $"<table align=\"center\" border=\"0\" width=\"80%\" style=\"font-family: CENTURY GOTHIC;border: 1px solid;background: #e1efff; line-height: 23px\">" +
                        $"<tr>" +
                            $"<td colspan=\"2\" style=\"padding: 15px\">" +
                                $"{iam[0]}, {iam[1]}" +
                            $"</td>" +
                        $"</tr>" +
                        $"<tr>" +
                            $"<td colspan=\"2\" style=\"padding: 15px\">" +
                                $"{addr[0]}, здравствуйте!" +
                            $"</td>" +
                        $"</tr>" +
                        $"<tr>" +
                              $"<td colspan=\"2\" style=\"padding: 15px\">" +
                                  $"{text}" +
                              $"</td>" +
                          $"</tr>" +
                          $"<tr>" +
                              $"<td colspan=\"2\" style=\"text-align: right; padding: 15px\">" +
                                  $"Спасибо за уделенное внимание,<br>" +
                                  $"с уважением, {iam[0]}!" +
                              $"</td>" +
                          $"</tr>" +
                      $"</table>";
                #endregion
                m.Subject = tema;
                m.IsBodyHtml = true;
                smtp.Send(m);
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Возникли ошибки во время отправки письма!\r\n" +
                    "Возможно Вы неверно ввели свой пароль, адресс или(и) адресс получателя.\r\n" +
                    "Попрубуйте еще раз!\r\n");
                //отправитель
                iam = validUser(Name, Mail, Pword);
                Console.WriteLine("Введите Ваше имя (например: Иван Иванов): ");
                Name = Console.ReadLine();
                Console.WriteLine("Введите Ваш адресс електронной почты (например: example@example.ru/com): ");
                Mail = Console.ReadLine();
                Console.WriteLine("Введите пароль от Вашей електронной почты: ");
                Pword = Console.ReadLine();
                from = new MailAddress($"{iam[1]}", $"{iam[0]}");
                // кому отправляем
                addr = validAdrr(AdrName, AdrMail);
                Console.WriteLine("Введите Имя адрессата письма: ");
                AdrName = Console.ReadLine();
                Console.WriteLine("Введите email адрессата письма: ");
                AdrMail = Console.ReadLine();
                to = new MailAddress(addr[1]);
                from = new MailAddress($"{iam[1]}", $"{iam[0]}");
                m = new MailMessage(from, to);
                smtp.Credentials = new NetworkCredential($"{iam[1]}", $"{iam[2]}");
                smtp.EnableSsl = true;
                #region Letter
                m.Body = $"<table align=\"center\" border=\"0\" width=\"80%\" style=\"font-family: CENTURY GOTHIC;border: 1px solid;background: #e1efff; line-height: 23px\">" +
                        $"<tr>" +
                            $"<td colspan=\"2\" style=\"padding: 15px\">" +
                                $"{iam[0]}, {iam[1]}" +
                            $"</td>" +
                        $"</tr>" +
                        $"<tr>" +
                            $"<td colspan=\"2\" style=\"padding: 15px\">" +
                                $"{addr[0]}, здравствуйте!" +
                            $"</td>" +
                        $"</tr>" +
                        $"<tr>" +
                              $"<td colspan=\"2\" style=\"padding: 15px\">" +
                                  $"{text}" +
                              $"</td>" +
                          $"</tr>" +
                          $"<tr>" +
                              $"<td colspan=\"2\" style=\"text-align: right; padding: 15px\">" +
                                  $"Спасибо за уделенное внимание,<br>" +
                                  $"с уважением, {iam[0]}!" +
                              $"</td>" +
                          $"</tr>" +
                      $"</table>";
                #endregion
                m.Subject = tema;
                m.IsBodyHtml = true;
                smtp.Send(m);
            }
            //smtp.Send(m);
            Console.WriteLine($"Письмо успешно отправлено!");

            Console.ReadKey();

        }
    }
}