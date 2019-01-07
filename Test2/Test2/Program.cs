using System;
using System.Linq;

namespace Test2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            /*
             Дан массив. Перемешать его элементы случайным образом так,
             чтобы каждый элемент оказался на новом месте                     
             */
            int[] Mix(int[] arr)
            {
                //временной массив неповтояющихся чисел
                var r = new Random(DateTime.Now.Millisecond);
                //лямбда сортировка по возрастанию случайно
                //сгенерированных чисел в массиве random
                arr = arr.OrderBy(x => r.Next()).ToArray();
                return arr;
            }
            int[] nums = new int[10] { 1,4,6,7,5,2,89,0,45,12 };
            nums = Mix(nums);
            foreach (int a in nums)
            {
                Console.Write(a + "  ");
            }
            Console.ReadKey();
        }
    }
}
