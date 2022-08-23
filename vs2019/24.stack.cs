using System;
using System.Globalization;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {//실행 => Ctrl + F5

            MyStack<int> stack = new MyStack<int>();
            Random r = new Random();

            for (int i = 0; i < 10; i++)
            {
                int val = r.Next(100);
                stack.Push(val);
                Console.WriteLine("Push(" + val + ") ");
                //Console.WriteLine(" top = " + stack.top);
            }

            Console.WriteLine();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Pop() = " + stack.Pop());
            }
        }

    }
}

/*

Push(43)
Push(37)
Push(31)
Push(56)
Push(63)
Push(52)
Push(11)
Push(42)
Push(16)
Push(69)

Pop() = 69
Pop() = 16
Pop() = 42
Pop() = 11
Pop() = 52
Pop() = 63
Pop() = 56
Pop() = 31
Pop() = 37
Pop() = 43
계속하려면 아무 키나 누르십시오 . . .
 */

/////////////////////////////////////////////////////////////////////////////////////////
/*
"MyStack.cs"
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class MyStack<T>
    {
        const int maxSize = 10;
        private T[] arr = new T[maxSize];
        private int top;

        public MyStack()
        {
            top = 0;
        }

        public void Push(T val)
        {
            if (top < maxSize)
            {
                arr[top] = val;
                ++top;
            }
            else
            {
                Console.WriteLine("Stack Full");
                return;
            }
        }

        public T Pop()
        {
            if (top > 0)
            {
                --top;
                return arr[top];
            }
            else
            {
                Console.WriteLine("Stack Empty");
                return default(T);
            }
        }
    }
}
