using System; 

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //실행 => Ctrl + F5

            Console.Clear();

            Console.WriteLine("Standard Numeric Format Specifiers");
            Console.WriteLine(
                "(C) Currency: . . . . . . . . {0:C}\n" +
                "(D) Decimal:. . . . . . . . . {0:D}\n" +
                "(E) Scientific: . . . . . . . {1:E}\n" +
                "(F) Fixed point:. . . . . . . {1:F}\n" +
                "(G) General:. . . . . . . . . {0:G}\n" +
                "(N) Number: . . . . . . . . . {0:N}\n" +
                "(P) Percent:. . . . . . . . . {1:P}\n" +
                "(R) Round-trip: . . . . . . . {1:R}\n" +
                "(X) Hexadecimal:. . . . . . . {0:X}\n",
                -12345678, -1234.5678f);


            Console.WriteLine("{0:N2}", 1234.5678);   // 출력: 1,234.57
            Console.WriteLine("{0:D8}", 1234);  // 출력: 00001234      
            Console.WriteLine("{0:F3}", 1234.56);   // 출력: 1234.560
            Console.WriteLine("{0,8}", 1234);   // 출력: ____1234
            Console.WriteLine("{0,-8}", 1234);   // 출력: 1234____

            string s;
            s = string.Format("{0:N2}", 1234.5678);
            Console.WriteLine(s);
            s = string.Format("{0:D8}", 1234);
            Console.WriteLine(s);
            s = string.Format("{0:F3}", 1234.56);
            Console.WriteLine(s);

            Console.WriteLine(1234.5678.ToString("N2"));
            Console.WriteLine(1234.ToString("D8"));
            Console.WriteLine(1234.56.ToString("F3"));

            Console.WriteLine("{0:#.##}", 1234.5678);
            Console.WriteLine("{0:0,0.00}", 1234.5678);
            Console.WriteLine("{0:#,#.##}", 1234.5678);
            Console.WriteLine("{0:000000.00}", 1234.5678);

            Console.WriteLine("{0:#,#.##;(#,#.##);zero}", 1234.567);
            Console.WriteLine("{0:#,#.##;(#,#.##);zero}", -1234.567);
            Console.WriteLine("{0:#,#.##;(#,#.##);zero}", 0);
        }
    }
}
