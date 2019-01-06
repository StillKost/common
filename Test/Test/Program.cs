using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    #region Clases
    public class coinA 
    {
        public double nominal, weight;
        public coinA()
        {
            nominal = 12.14;
            weight = 10.21;
        }
    }
    public class coinB 
    {
        public double nominal, weight;
        public coinB()
        {
            nominal = 11.17;
            weight = 9.29;
        }
    }
    public class coinC 
    {
        public double nominal, weight;
        public coinC()
        {
            nominal = 10.0145;
            weight = 10.29;
        }
    }
    #endregion

    class Program
    {

        static void Main(string[] args)
        {
            void Print(int[] arr)
            {
                Console.WriteLine("Array:");
                foreach (var a in arr)
                    Console.Write(a + "  ");
                Console.WriteLine("\r\n");
            }
            void PrintD(int[,] arr, int n, int m)
            {
                Console.WriteLine("Array:");
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                        Console.Write(arr[i, j] + "  ");
                    Console.WriteLine();
                }
            }
            
            int[] Test1()
            {
                int[] arr = new int[10];
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[0] = 1;
                    arr[arr.Length - 1] = 1;
                    for (int j = i + 1; j < arr.Length - 1; j++)
                    {
                        arr[j] += 0;
                    }
                }
                return arr;
            }
            var test1 = Test1();
            Print(test1);

            int[] Test2()
            {
                int[] arr = new int[10];
                for(int i = 0; i < arr.Length; i++)
                {
                    if (i % 2 == 0)
                        arr[i] = 0;
                    else
                        arr[i] = 1;
                }
                return arr;
            }
            var test2 = Test2();
            Print(test2);

            int[,] Test3()
            {
                Random r = new Random();
                int[,] a = new int[10, 10];
                int[,] arr = new int[10, 10];
                //initialisation
                for (int i = 0; i < 10; i++)
                    for (int j = 0; j < 10; j++)
                    {
                        //a[i, j] = (i + j) % 10 + 1;
                        a[i, j] = r.Next(0, 10);
                    }
                //rull
                for (int i = 0; i < 10; i++)
                    for (int j = 0; j < 10; j++)
                    {
                        if (i + 1 < 10 && j + 1 < 10)
                        {
                            arr[i, j] = a[i, j] * a[i + 1, j + 1];
                        }                        
                    }
                return arr;
            }
            var test3 = Test3();
            PrintD(test3, 10, 10);
            Console.WriteLine();            
            #region Interval
            int[] Sort(int[] arr)
            {
                int temp = 0;
                for(int i = 0; i < arr.Length; i++)
                    for (int j = i + 1; j < arr.Length; j++)
                    {
                        if (arr[i] > arr[j])
                        {
                            temp = arr[i];
                            arr[i] = arr[j];
                            arr[j] = temp;
                        }
                    }
                return arr;
            }
            bool Interval(int[] arr, int[] arr2)
            {
                bool isInterval;
                arr = Sort(arr);
                arr2 = Sort(arr2);
                //for (int i = 0; i < arr.Length; i++)
                //    for (int j = 0; j < arr2.Length; j++)
                //    {

                //    }
                if (arr[arr.Length - 1] >= arr2[0] && arr[0] < arr2[0])
                    isInterval = true;
                else
                    isInterval = false;
                return isInterval;
            }
            int[] x = new int[3] { 1, 10, 3 };
            int[] y = new int[3] { 10, 15, 55 };
            var q = Interval(x, y);
            Console.WriteLine("First array: ");
            for (int i = 0; i < x.Length; i++)
                Console.Write(x[i] + "  ");
            Console.WriteLine();
            Console.WriteLine("Second array: ");
            for (int i = 0; i < y.Length; i++)
                Console.Write(y[i] + "  ");
            Console.WriteLine();
            Console.WriteLine("Forms an interval: " + q);
            #endregion
            #region Coins
            double[] Coins(int a, int b, int c)
            {
                double nominalSumA = 0; double nominalSumB = 0; double nominalSumC = 0;
                double weightSumA = 0; double weightSumB = 0; double weightSumC = 0;
                List<coinA> coinsA = new List<coinA>();
                List<coinB> coinsB = new List<coinB>();
                List<coinC> coinsC = new List<coinC>();
                for (int i = 0; i < a; i++)
                {
                    coinsA.Add(new coinA());
                    nominalSumA += coinsA[i].nominal;
                    weightSumA += coinsA[i].weight;
                }
                for (int i = 0; i < b; i++)
                {
                    coinsB.Add(new coinB());
                    nominalSumB += coinsB[i].nominal;
                    weightSumB += coinsB[i].weight;
                }
                for (int i = 0; i < c; i++)
                {
                    coinsC.Add(new coinC());
                    nominalSumC += coinsC[i].nominal;
                    weightSumC += coinsC[i].weight;
                }
                double TotalNominalSum = nominalSumA + nominalSumB + nominalSumC;
                double TotalWeight = weightSumC + weightSumA + weightSumB;
                double[] TotalInfo = new double[2];
                TotalInfo[0] = TotalNominalSum;
                TotalInfo[1] = TotalWeight;
                return TotalInfo;
            }
            Console.WriteLine();
            Console.WriteLine("Enter coins count:");
            int aa = Convert.ToInt32(Console.ReadLine());
            int bb = Convert.ToInt32(Console.ReadLine());
            int cc = Convert.ToInt32(Console.ReadLine());
            var res = Coins(aa, bb, cc);
            Console.WriteLine("Total Nominal: " + res[0] + " conventional units");
            Console.WriteLine("Total Weight: " + res[1] + " conventional units");
            #endregion
            Console.ReadKey();
        }
    }
}
