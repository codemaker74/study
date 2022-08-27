using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Student
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public List<int> Scores { get; set; }
    }

    class Program
    {

        static List<Student> students;

        static void Main(string[] args)
        {//실행 => Ctrl + F5
            //#LINQ사용법
            List<int> data = new List<int> { 123, 45, 12, 89, 456, 1, 4, 74, 46 };
            List<int> lstSortedEven = new List<int>();

            foreach (var item in data)
            {
                if (item % 2 == 0)
                    lstSortedEven.Add(item);
            }
            lstSortedEven.Sort();

            Console.WriteLine("Using foreach: ");
            foreach (var item in lstSortedEven)
                Console.Write(item + " ");
            Console.WriteLine();

            IEnumerable<int> sortedEven = from item in data
                                          where item % 2 == 0
                                          orderby item
                                          select item;

            Console.WriteLine("\nUsing Linq: ");
            foreach (var item in sortedEven)
                Console.Write(item + " ");
            Console.WriteLine();

            //#조건검색, 정렬
            Print("data : ", data);

            var lstEven = from item in data
                          where (item > 20 && item % 2 == 0)
                          orderby item descending
                          select item;

            Print("20보다 큰 짝수 검색 결과 : ", lstEven);

            var lstSorted = from item in lstEven
                            orderby item ascending
                            select item * 2;

            Print("2를 곱해서 오름차순 정렬 : ", lstSorted);

            //#결과를 리스트로
            List<int> lstData = new List<int> { 123, 456, 132, 96, 13, 465, 321 };
            Print2("Data: ", lstData);

            List<int> lstOdd = new List<int>();
            lstOdd = SelectOddAndSort(lstData);
            Print2("Ordered Odd: ", lstOdd);

            int[] arrEven;
            arrEven = SelectEvenAndSort(lstData);
            Print2("Ordered Even: ", arrEven);

            //#컬렉션저장
            students = new List<Student>
              {
                new Student {Name="PjKim", Id=19001001, Scores = new List<int>{86,90,76}},
                new Student {Name="BsKim", Id=19001002, Scores = new List<int>{56,92,93}},
                new Student {Name="YsCho", Id=19001003, Scores = new List<int>{69,85,75}},
                new Student {Name="BiKang", Id=19001004, Scores = new List<int>{88,80,57}},
            };
            Print3(students);
            HighScore(0, 85);
            HighScore(1, 90);
            //HighScore(2, 90);

            //#
            students = new List<Student>
            {
                new Student {Name="PjKim", Id=19001001, Scores = new List<int>{86,90,76}},
                new Student {Name="BsKim", Id=19001002, Scores = new List<int>{56,92,93}},
                new Student {Name="YsCho", Id=19001003, Scores = new List<int>{69,85,75}},
                new Student {Name="BiKang", Id=19001004, Scores = new List<int>{88,80,57}},
            };

            var result = from student in students
                group student by student.Scores.Average() >= 80 into g
                select new
                {
                    key = g.Key == true ? "80점이상" : "80점미만",
                    count = g.Count(), //해당 구간의 학생수
                    avr = g.Average(student => student.Scores.Average()),
                    max = g.Max(student => student.Scores.Average())
                };

            foreach (var item in result)
            {
                Console.WriteLine("{0} : 학생 수 = {1}", item.key, item.count);
                Console.WriteLine("{0} : 평균 점수 = {1:F2}", item.key, item.avr);
                Console.WriteLine("{0} : 최고 점수 = {1:F2}", item.key, item.max);
                Console.WriteLine();
            } 
    }

        //조건검색, 정렬 관련...
        private static void Print(string s, IEnumerable<int> data)
        {
            Console.WriteLine(s);
            foreach (var i in data)
                Console.Write(" " + i);
            Console.WriteLine();
        }
        //결과를 리스트로 관련...
        private static List<int> SelectOddAndSort(List<int> lstData)
        {
            return (from item in lstData
                    where item % 2 == 1
                    orderby item
                    select item).ToList<int>();
        }
        private static int[] SelectEvenAndSort(List<int> lstData)
        {
            return (from item in lstData
                    where item % 2 == 0
                    orderby item
                    select item).ToArray<int>();
        }
        private static void Print2(string s, IEnumerable<int> data)
        {
            Console.WriteLine(s);
            foreach (var i in data)
                Console.Write(" " + i);
            Console.WriteLine();
        }
        //컬렉션저장
        private static void HighScore(int exam, int cut)
        {
            var highScores = from student in students
                             where student.Scores[exam] >= cut
                             select new { Name = student.Name, Score = student.Scores[exam] };

            Console.WriteLine($"{exam + 1}번째 시험에서 {cut} 이상의 점수를 받은 학생");
            foreach (var item in highScores)
            {
                Console.WriteLine($"\t{item.Name,-10}{item.Score}");
            }
        }
        private static void Print3(List<Student> students)
        {
            foreach (var item in students)
            {
                Console.Write($"{item.Id,-10}{item.Name,-10}");
                foreach (var score in item.Scores)
                {
                    Console.Write($"{score,-5}");
                }
                Console.WriteLine(item.Scores.Average().ToString("F2"));
            }
        }
    }
}

/*
Using foreach:
4 12 46 74 456

Using Linq:
4 12 46 74 456
data :
 123 45 12 89 456 1 4 74 46
20보다 큰 짝수 검색 결과 :
 456 74 46
2를 곱해서 오름차순 정렬 :
 92 148 912
Data:
 123 456 132 96 13 465 321
Ordered Odd:
 13 123 321 465
Ordered Even:
 96 132 456
19001001  PjKim     86   90   76   84.00
19001002  BsKim     56   92   93   80.33
19001003  YsCho     69   85   75   76.33
19001004  BiKang    88   80   57   75.00
1번째 시험에서 85 이상의 점수를 받은 학생
        PjKim     86
        BiKang    88
2번째 시험에서 90 이상의 점수를 받은 학생
        PjKim     90
        BsKim     92
80점이상 : 학생 수 = 2
80점이상 : 평균 점수 = 82.17
80점이상 : 최고 점수 = 84.00

80점미만 : 학생 수 = 2
80점미만 : 평균 점수 = 75.67
80점미만 : 최고 점수 = 76.33

계속하려면 아무 키나 누르십시오 . . .

 */
