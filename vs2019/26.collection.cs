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

            //#Array와 비교
            List<string> lstNames = new List<string>();
            lstNames.Add("dog");
            lstNames.Add("cow");
            lstNames.Add("rabbit");
            lstNames.Add("goat");
            lstNames.Add("sheep");
            lstNames.Sort();
            foreach (string s in lstNames)
                Console.Write(s + " ");
            Console.WriteLine();

            //Array arrNames = new Array(100);
            string[] arrNames = new string[100];
            arrNames[0] = "dog";
            arrNames[1] = "cow";
            arrNames[2] = "rabbit";
            arrNames[3] = "goat";
            arrNames[4] = "sheep";
            Array.Sort(arrNames);
            foreach (string s in lstNames)
                Console.Write(s + " ");
            Console.WriteLine();
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
  62  32  37  42  85  77  15  4  19  75
Print Values in ArrayList
  Count = 10
  Capacity = 16
  4  15  19  32  37  42  62  75  77  85
Print Values in ArrayList
  Count = 9
  Capacity = 16
  4  15  19  37  42  62  75  77  85



Print Values in List<int>
  Count = 0
  Capacity = 0

Print Values in List<int>
  Count = 10
  Capacity = 16
  35  66  38  37  37  87  55  15  76  85
Print Values in List<int>
  Count = 10
  Capacity = 16
  15  35  37  37  38  55  66  76  85  87
Print Values in List<int>
  Count = 9
  Capacity = 16
  15  35  37  38  55  66  76  85  87
cow dog goat rabbit sheep
cow dog goat rabbit sheep
계속하려면 아무 키나 누르십시오 . . .
 */
