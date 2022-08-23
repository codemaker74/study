using System;
using System.Globalization;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {//실행 => Ctrl + F5

            //#일반화 메소드
            int[] a1 = { 1, 2, 3 };
            double[] d1 = { 0.1, 0.2, 0.3 };
            string[] s1 = { "tiger", "lion", "zebra" };

            PrintArray<int>(a1);
            PrintArray<double>(d1);
            PrintArray<string>(s1);

            //#일반화 클래스
            MyClass<int> a = new MyClass<int>(10);
            MyClass<string> s = new MyClass<string>(5);

            a.Insert(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
            s.Insert("Tiger", "Lion", "Zebra", "Monkey", "Cow");

            a.Print();
            s.Print();

            Console.WriteLine("a.AddAll() : " + a.AddAll());
            Console.WriteLine("s.AddAll() : " + s.AddAll());

            //#dynamic형
            int[] a3 = { 10, 45, 32, 47, 85, 46, 93, 47, 50, 71 };
            double[] d3 = { 0.1, 5.3, 6.7, 8.5, 4.9, 6.1 };
            float[] f3 = { 1.2f, 5.3f, 7.8f, 6.1f, 3.4f, 8.8f };
            decimal[] c3 = { 123, 783, 456, 234, 456, 748 };

            PrintArray<int>("a3[] :", a3);
            CalcArray<int>(a3);
            PrintArray<double>("d3[] :", d3);
            CalcArray<double>(d3);
            PrintArray<float>("f3[] :", f3);
            CalcArray<float>(f3);
            PrintArray<decimal>("c3[] :", c3);
            CalcArray<decimal>(c3);
        }

        //일반화 메소드 관련...
        private static void PrintArray<T>(T[] a)
        {
            foreach (var item in a)
                Console.Write("{0,8}", item);
            Console.WriteLine();
        }

        //일반화 클래스 관련...
        class MyClass<T>
        {
            private T[] arr;
            private int count = 0;

            public MyClass(int length)
            {
                arr = new T[length];
                count = length;
            }

            public void Insert(params T[] args)
            {
                for (int i = 0; i < args.Length; i++)
                    arr[i] = args[i];
            }

            public void Print()
            {
                foreach (T i in arr)
                    Console.Write(i + " ");
                Console.WriteLine();
            }

            public T AddAll()
            {
                T sum = default(T);
                foreach (T item in arr)
                    sum = sum + (dynamic)item;
                return sum;
            }
        }

        //dynamic형 관련...
        private static void CalcArray<T>(T[] a) where T : struct
        {
            T sum = default(T);
            T avg = default(T);
            T max = default(T);

            foreach (dynamic item in a)
            {
                if (max < item)
                    max = item;
                sum += item;
            }
            avg = (dynamic)sum / a.Length;
            Console.WriteLine("      Sum = {0}, Average = {1}, Max = {2}",
                sum, avg, max);
        }
        private static void PrintArray<T>(string s, T[] a) where T : struct
        {
            Console.Write(s);
            foreach (var item in a)
            {
                Console.Write(" {0}", item);
            }
            Console.WriteLine();
        }

    }
}

/*
       1       2       3
     0.1     0.2     0.3
   tiger    lion   zebra
1 2 3 4 5 6 7 8 9 10
Tiger Lion Zebra Monkey Cow
a.AddAll() : 55
s.AddAll() : TigerLionZebraMonkeyCow
a3[] : 10 45 32 47 85 46 93 47 50 71
      Sum = 526, Average = 52, Max = 93
d3[] : 0.1 5.3 6.7 8.5 4.9 6.1
      Sum = 31.6, Average = 5.26666666666667, Max = 8.5
f3[] : 1.2 5.3 7.8 6.1 3.4 8.8
      Sum = 32.6, Average = 5.433333, Max = 8.8
c3[] : 123 783 456 234 456 748
      Sum = 2800, Average = 466.66666666666666666666666667, Max = 783
계속하려면 아무 키나 누르십시오 . . .

 */
