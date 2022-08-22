using System; 

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        { //실행 => Ctrl + F5
            string a = "hello";
            string b = "h";

            b += "ello";
            Console.WriteLine(a == b);
            Console.WriteLine("b = " + b);

            int x = 10;
            string c = b + '!' + " " + x;
            Console.WriteLine("c = " + c);
        }
    }
}
