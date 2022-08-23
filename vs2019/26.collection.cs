using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {//실행 => Ctrl + F5

            //#ArrayList
            ArrayList a = new ArrayList();
            Random r = new Random();

            PrintValues(a);

            for (int i = 0; i < 10; i++)
                a.Add(r.Next(100));

            PrintValues(a);
            a.Sort();
            PrintValues(a);

            a.RemoveAt(3);
            PrintValues(a);
            Console.WriteLine("\n\n");

            //#List<T>
            List<int> a1 = new List<int>(); 

            PrintValues1(a1);

            for (int i = 0; i < 10; i++)
                a1.Add(r.Next(100));

            PrintValues1(a1);
            a1.Sort();
            PrintValues1(a1);

            a1.RemoveAt(3);
            PrintValues1(a1);
        }

        //ArrayList 관련...
        private static void PrintValues(ArrayList a)
        {
            Console.WriteLine("Print Values in ArrayList");
            Console.WriteLine("  Count = {0}", a.Count);
            Console.WriteLine("  Capacity = {0}", a.Capacity);
            foreach (var i in a)
                Console.Write("  {0}", i);
            Console.WriteLine();
        }
        //List<T> 관련...
        private static void PrintValues1(List<int> a)
        {
            Console.WriteLine("Print Values in List<int>");
            Console.WriteLine("  Count = {0}", a.Count);
            Console.WriteLine("  Capacity = {0}", a.Capacity);
            foreach (var i in a)
                Console.Write("  {0}", i);
            Console.WriteLine();
        }

    }
}

/*
Print Values in ArrayList
  Count = 0
  Capacity = 0

Print Values in ArrayList
  Count = 10
  Capacity = 16
  23  19  54  17  58  85  53  82  74  35
Print Values in ArrayList
  Count = 10
  Capacity = 16
  17  19  23  35  53  54  58  74  82  85
Print Values in ArrayList
  Count = 9
  Capacity = 16
  17  19  23  53  54  58  74  82  85



Print Values in List<int>
  Count = 0
  Capacity = 0

Print Values in List<int>
  Count = 10
  Capacity = 16
  43  97  50  7  64  51  14  76  95  22
Print Values in List<int>
  Count = 10
  Capacity = 16
  7  14  22  43  50  51  64  76  95  97
Print Values in List<int>
  Count = 9
  Capacity = 16
  7  14  22  50  51  64  76  95  97
계속하려면 아무 키나 누르십시오 . . .
 */
