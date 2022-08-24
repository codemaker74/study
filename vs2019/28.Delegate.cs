using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

namespace ConsoleApp1
{
    class Program
    {
        delegate bool MemberTest(int a);

        static void Main(string[] args)
        {//실행 => Ctrl + F5

            //#Delegate 기본
            int[] arr = new int[] { 3, 5, 4, 2, 6, 4, 6, 8, 54, 23, 4, 6, 4 };

            Console.WriteLine(Count(4));
            Console.WriteLine(Count(arr, 4));
            Console.WriteLine("짝수의 갯수: " + EvenCount(arr));
            Console.WriteLine("홀수의 갯수: " + OddCount(arr));

            Console.WriteLine("짝수의 갯수: " + Count(arr, IsEven));
            Console.WriteLine("홀수의 갯수: " + Count(arr, IsOdd));
            Console.WriteLine("\n\n\n");

            //#이름 없는 델리게이트
            var arr1 = new[] { 3, 34, 6, 34, 7, 8, 24, 3, 675, 8, 23 };

            int n = Count1(arr1, delegate (int x) { return x % 2 == 0; });
            Console.WriteLine("짝수의 갯수 : " + n);

            n = Count1(arr1, delegate (int x) { return x % 2 != 0; });
            Console.WriteLine("홀수의 갯수 : " + n);
            Console.WriteLine("\n\n\n");

            //#선언필요없음
            var arr2 = new[] { 3, 34, 6, 34, 7, 8, 24, 3, 675, 8, 23 };

            int n2 = Count2(arr2, delegate (int x) { return x % 2 == 0; });
            Console.WriteLine("짝수의 갯수 : " + n2);

            n2 = Count2(arr2, delegate (int x) { return x % 2 != 0; });
            Console.WriteLine("홀수의 갯수 : " + n2);
        }

        //Delegate 기본 관련...
        static int EvenCount(int[] a)
        {
            int cnt = 0;
            foreach (var n in a)
            {
                if (n % 2 == 0)
                    cnt++;
            }
            return cnt;
        }

        static int OddCount(int[] a)
        {
            int cnt = 0;
            foreach (var n in a)
            {
                if (n % 2 == 1)
                    cnt++;
            }
            return cnt;
        }

        static int Count(int[] a, MemberTest testMethod)
        {
            int cnt = 0;
            foreach (var n in a)
            {
                if (testMethod(n) == true)
                    cnt++;
            }
            return cnt;
        }

        static public bool IsOdd(int n) { return n % 2 != 0; }
        static public bool IsEven(int n) { return n % 2 == 0; }

        private static int Count(int v)
        {
            var nums = new[] { 3, 5, 4, 2, 6, 4, 6, 8, 54, 23, 4, 6, 4 };
            int cnt = 0;
            foreach (var n in nums)
            {
                if (n == v)
                    cnt++;
            }
            return cnt;
        }

        private static int Count(int[] nums, int v)
        {
            int cnt = 0;
            foreach (var n in nums)
            {
                if (n == v)
                    cnt++;
            }
            return cnt;
        }

        //이름 없는 델리게이트 관련...
        private static int Count1(int[] arr1, MemberTest testMethod)
        {
            int cnt = 0;
            foreach (var n in arr1)
            {
                if (testMethod(n))
                    cnt++;
            }
            return cnt;
        }

        //선언필요없음 관련...
        private static int Count2(int[] arr2, Func<int, bool> testMethod)
        {
            int cnt = 0;
            foreach (var n in arr2)
            {
                if (testMethod(n))
                    cnt++;
            }
            return cnt;
        }
    }
}

/*
4
4
짝수의 갯수: 10
홀수의 갯수: 3
짝수의 갯수: 10
홀수의 갯수: 3




짝수의 갯수 : 6
홀수의 갯수 : 5




짝수의 갯수 : 6
홀수의 갯수 : 5
계속하려면 아무 키나 누르십시오 . . .
 */
