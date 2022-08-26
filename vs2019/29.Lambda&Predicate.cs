using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        //문람다 관련...
        delegate double CalcMethod(double a, double b);
        delegate bool IsTeenAger(Student student);
        delegate bool IsAdult(Student student);
        public class Student
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        static void Main(string[] args)
        {//실행 => Ctrl + F5

            //#람다식: Action <T1,T2>, Func <T,TResult>
            var arr = new[] { 3, 34, 6, 34, 7, 8, 24, 3, 675, 8, 23 };

            int n = Count(arr, x => x % 2 == 0);
            Console.WriteLine("짝수의 갯수 : " + n);

            n = Count(arr, x => x % 2 == 1);
            Console.WriteLine("홀수의 갯수 : " + n);

            //#문람다
            Func<int, int> square = x => x * x;
            Console.WriteLine(square(5));

            int[] numbers = { 2, 3, 4, 5 };
            var squaredNumbers = numbers.Select(x => x * x); //Select => using System.Linq;
            Console.WriteLine(string.Join(" ", squaredNumbers));

            Action line = () => Console.WriteLine();
            line();

            CalcMethod add = (a, b) => a + b;
            CalcMethod subtract = (a, b) => a - b;

            Console.WriteLine(add(10, 20));
            Console.WriteLine(subtract(10.5, 20));

            IsTeenAger isTeenAger = delegate (Student s) { return s.Age > 12 && s.Age < 20; };

            Student s1 = new Student() { Name = "John", Age = 18 };
            Console.WriteLine("{0}은 {1}.", s1.Name, isTeenAger(s1) ? "청소년입니다" : "청소년이 아닙니다");

            IsAdult isAdult = (s) => {
                int adultAge = 18;
                return s.Age >= adultAge;
            };

            Student s2 = new Student() { Name = "Robin", Age = 20 };
            Console.WriteLine("{0}은 {1}.", s2.Name, isAdult(s2) ? "성인입니다" : "성인이 아닙니다");

            //#Predicate<T>
            Predicate<int> isEven = n2 => n2 % 2 == 0;
            Console.WriteLine(isEven(6));

            Predicate<string> isLowerCase = s => s.Equals(s.ToLower());
            Console.WriteLine(isLowerCase("This is a lowercase string"));

            //#List<T>
            List<String> myList = new List<String> {"mouse", "cow", "tiger", "rabbit", "dragon", "snake"};
            bool n3 = myList.Exists(s => s.Contains("x"));
            Console.WriteLine("이름에 'x'를 포함하는 동물이 있나요 : " + n3);

            Console.Write("이름이 3글자인 첫번째 동물 : ");
            string name = myList.Find(s => s.Length == 3);
            Console.WriteLine(name);

            Console.Write("6글자 이상의 동물들: ");
            List<string> longName = myList.FindAll(s => s.Length > 5);
            foreach (var item in longName)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.Write("대문자로 변환: ");
            List<string> capList = myList.ConvertAll(s => s.ToUpper());
            foreach (var item in capList)
                Console.Write(item + " ");
            Console.WriteLine();
        }

        //람다식 관련...
        private static int Count(int[] arr, Func<int, bool> testMethod)
        {
            int cnt = 0;
            foreach (var n in arr)
            {
                if (testMethod(n))
                    cnt++;
            }
            return cnt;
        }
        //Predicate<T> 관련...
        static bool IsEven(int n2) => n2 % 2 == 0;
        static bool IsLowerCase(string s) => s.Equals(s.ToLower());
    }
}

/*
짝수의 갯수 : 6
홀수의 갯수 : 5
25
4 9 16 25

30
-9.5
John은 청소년입니다.
Robin은 성인입니다.
True
False
이름에 'x'를 포함하는 동물이 있나요 : False
이름이 3글자인 첫번째 동물 : cow
6글자 이상의 동물들: rabbit dragon
대문자로 변환: MOUSE COW TIGER RABBIT DRAGON SNAKE
계속하려면 아무 키나 누르십시오 . . .
 */
