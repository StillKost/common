using System;

namespace Test1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            /*
             Компьютер загадывает число от 1 до n. У пользователя k попыток отгадать.
             После каждой неудачной попытки компьютер сообщает
             меньше или больше загаданное число.
             В конце игры текст с результатом (или “Вы угадали”,
             или “Попытки закончились”).
             */
            Console.WriteLine("Я загадал число от 1 до 100, Ваша задача " +
                "отгадать это число за 10 попыток");
            Random num = new Random();
            var n = num.Next(0, 101);
            for (int i = 0; i < 11; i++)
            {
                int uNum = Convert.ToInt16(Console.ReadLine());
                if (uNum > n)
                {
                    Console.WriteLine($"Меньше!");
                }
                else if (uNum < n)
                {
                    Console.WriteLine($"Больше!");
                }
                else if (uNum == n)
                {
                    Console.WriteLine($"Вы угадали это число ({n}) за {i} попыток!");
                    i = 0;
                    n = num.Next(0, 101);
                }
                else
                {
                    Console.WriteLine($"Вы использовали все {i} попыток, попробуйте еще раз!");
                    i = 0;
                    n = num.Next(0, 101);
                }                
            }
            Console.ReadKey();
        }
    }
}
