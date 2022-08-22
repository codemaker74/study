using System; 

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        { //실행 => Ctrl + F5
            Console.Write("Hello ");
            Console.WriteLine("World!");
            Console.Write("이름을 입력하세요: ");

            string name = Console.ReadLine();
            Console.Write("안녕하세요, ");
            Console.Write(name);
            Console.WriteLine("님!");
        }
    }
}
