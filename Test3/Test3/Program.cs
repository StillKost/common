using System;
using System.Linq;
namespace Test3
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             Найти количество вхождений подстроки в строку и вывести количество вхождений             
             */
            Console.WriteLine("Enter text!");
            string test = Console.ReadLine();
            Console.WriteLine("Enter text!");
            string inSearch = Console.ReadLine();
            int Search(string str, string item)
            {
                //форматирование входящей строки 
                string[] strArr;
                str = str.Trim();
                str = str.Replace('!', ' ').Replace('?', ' ')
                        .Replace(',', ' ').Replace('.', ' ')
                        .Replace("  ", " ");
                str = str.Trim();
                //создание из строки массива строк
                strArr = str.Split(' ');
                //поиск вхождений элемента
                int count = 0;
                for (int i = 0; i < strArr.Length; i++)
                {
                    if(strArr[i].ToLower() == item.ToLower())
                        count++;
                }
                return count;
            }

            var s = Search(test, inSearch);
            Console.WriteLine($"Words count is {s}");
            Console.ReadKey();
        }
    }
}
