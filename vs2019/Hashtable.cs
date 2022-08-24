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

            //#Hashtable
            Dictionary<string, string> colorTable = new Dictionary<string, string>();

            colorTable.Add("Red", "빨간색");
            colorTable.Add("Green", "초록색");
            colorTable.Add("Blue", "파란색");

            foreach (var v in colorTable)
                Console.WriteLine("colorTable[{0}] = {1}", v.Key, v.Value);
            Console.WriteLine();

            try
            {
                colorTable.Add("Red", "빨강");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                Console.WriteLine("Yellow => {0}", colorTable["Yellow"]);
            }
            catch (KeyNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("\n" + colorTable["Red"]);
            Console.WriteLine(colorTable["Green"]);
            Console.WriteLine(colorTable["Blue"]);

            //#SortedList
            SortedList<int, string> s1 = new SortedList<int, string>();
            s1.Add(3, "Three");
            s1.Add(4, "Four");
            s1.Add(1, "One");
            s1.Add(2, "Two");

            for (int i = 0; i < s1.Count; i++)
                Console.Write("k: {0}, v: {1} / ", s1.Keys[i], s1.Values[i]);
            Console.WriteLine();

            foreach (var kvp in s1)
                Console.Write("{0, -10} ", kvp);
            Console.WriteLine();

            SortedList<string, int> s2 = new SortedList<string, int>();
            s2.Add("one", 1);
            s2.Add("two", 2);
            s2.Add("three", 3);
            s2.Add("four", 4);
            Console.WriteLine(s2["two"]);

            foreach (var kvp in s2)
                Console.Write("{0, -10} ", kvp);
            Console.WriteLine();

            for (int i = 0; i < s2.Count; i++)
                Console.Write("k: {0}, v: {1}", s2.Keys[i], s2.Values[i]);

            int val;

            if (s2.TryGetValue("ten", out val))
                Console.WriteLine("key: ten, value: {0}", val);
            else
                Console.WriteLine("[ten] : Key is not valid.");

            if (s2.TryGetValue("one", out val))
                Console.WriteLine("key: one, value: {0}", val);

            Console.WriteLine(s2.ContainsKey("one"));
            Console.WriteLine(s2.ContainsKey("ten"));
            Console.WriteLine(s2.ContainsValue(2));
            Console.WriteLine(s2.ContainsValue(6));

            s2.Remove("one");// 키가 'one' 요소 삭제
            s2.RemoveAt(0);  // 첫번째 요소 삭제

            foreach (KeyValuePair<string, int> kvp in s2)
                Console.Write("{0, -10} ", kvp);
            Console.WriteLine();

            //#Indexer
            var myString = new MyCollection<string>();
            myString[0] = "Hello, World!";
            myString[1] = "Hello, C#";
            myString[2] = "Hello, Indexer!";
            for (int i = 0; i < 3; i++)
                Console.WriteLine(myString[i]);
        }

        //Indexer 관련...
        class MyCollection<T>
        {
            private T[] array = new T[100];

            public T this[int i]
            {
                get { return array[i]; }
                set { array[i] = value; }
            }
        }
    }
}

/*
colorTable[Red] = 빨간색
colorTable[Green] = 초록색
colorTable[Blue] = 파란색

동일한 키를 사용하는 항목이 이미 추가되었습니다.
지정한 키가 사전에 없습니다.

빨간색
초록색
파란색
k: 1, v: One / k: 2, v: Two / k: 3, v: Three / k: 4, v: Four /
[1, One]   [2, Two]   [3, Three] [4, Four]
2
[four, 4]  [one, 1]   [three, 3] [two, 2]
k: four, v: 4k: one, v: 1k: three, v: 3k: two, v: 2[ten] : Key is not valid.
key: one, value: 1
True
False
True
False
[three, 3] [two, 2]
Hello, World!
Hello, C#
Hello, Indexer!
계속하려면 아무 키나 누르십시오 . . .
 */
