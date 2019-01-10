using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            double F(double x)
            {
                return 1 / (Math.Sqrt((x * x) + x) - x);
            }
            Console.WriteLine("Hello World!");
            Console.WriteLine("Enter number!");
            for (int i = 0; ; i++)
            {
                #region programm
                string str = Console.ReadLine();
                double arg;
                if (str.Contains('.'))
                {
                    str = str.Replace('.', ',');
                }
                if (double.TryParse(str, out arg))
                {
                    arg = Convert.ToDouble(str);
                    if (arg == 0)
                    {
                        arg = 0.1;
                        Console.WriteLine("Your argument must be > 0! (0.1)");
                    }
                    var res = F(arg);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Result:\t" + res);
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Input error! Format exception!");
                    Console.ResetColor();
                    str = Console.ReadLine();
                }
                #endregion
                Console.ReadKey();
            }
        }
    }
}
