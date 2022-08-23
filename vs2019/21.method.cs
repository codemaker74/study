using System;
using System.Globalization;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {//실행 => Ctrl + F5

            //#메소드 인수 전달
            int a = 3;
            Sqr(a);
            Console.WriteLine("Value: {0}", a); // 3이 출력됩니다.

            int b = 3;
            Sqr(ref b);
            Console.WriteLine("ref: {0}", b); // 9가 출력됩니다.

            string name;
            int id;
            GetName(out name, out id);
            Console.WriteLine("out: {0} {1}", name, id);

            //#가변길이 매개변수
            PrintIntParams(1, 2, 3, 4);
            PrintObjectParams(1, 1.234, 'a', "test");
            PrintObjectParams();

            int[] myIntArray = { 5, 6, 7, 8, 9 };
            PrintIntParams(myIntArray);

            object[] myObjArray = { 2, 2.345, 'b', "test", "again" };
            PrintObjectParams(myObjArray);

            PrintObjectParams(myIntArray);

            //#선택적&명명된 인수
            Console.WriteLine(MyPower(4, 2));
            Console.WriteLine(MyPower(4));
            Console.WriteLine(MyPower(3, 4));

            Console.WriteLine(Area(w: 5, h: 6));
            Console.WriteLine(Area(h: 6, w: 5));

            //#메소드 오버로딩
            Print(10);
            Print(0.123);
            Print("Sum = ", 123.4);
        }
        //메소드 인수전달 관련...
        static void Sqr(int x)
        {
            x = x * x;
        }
        static void Sqr(ref int x)
        {
            x = x * x;
        }
        static void GetName(out string name, out int id)
        {
            Console.Write("Enter Name: ");
            name = "comtoman"; //Console.ReadLine();
            Console.Write("Enter Id: ");
            id = 9654; //int.Parse(Console.ReadLine());
        }

        //가변길이 매개변수 관련...
        public static void PrintIntParams(params int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
        public static void PrintObjectParams(params object[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }

        //선택적&명명된 인수 관련...
        static int MyPower(int x, int y = 2)
        {
            int result = 1;
            for (int i = 0; i < y; i++)
                result *= x;
            return result;
        }
        static int Area(int h, int w)
        {
            return h * w;
        }

        //메소드 오버로딩 관련...
        private static void Print(double x)
        {
            Console.WriteLine(x);
        }
        private static void Print(string s, double x)
        {
            Console.WriteLine(s + x);
        }
        private static void Print(int x)
        {
            Console.WriteLine(x);
        }

    }
}

/*
Value: 3
ref: 9
Enter Name: Enter Id: out: comtoman 9654
1 2 3 4
1 1.234 a test

5 6 7 8 9
2 2.345 b test again
System.Int32[]
16
16
81
30
30
10
0.123
Sum = 123.4
계속하려면 아무 키나 누르십시오 . . .
 */
