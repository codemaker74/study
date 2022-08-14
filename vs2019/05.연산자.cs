using System; 

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //실행 => Ctrl + F5

            //#산술 연산자
            Console.WriteLine("정수의 계산");
            Console.WriteLine(123 + 45);
            Console.WriteLine(123 - 45);
            Console.WriteLine(123 * 45);
            Console.WriteLine(123 / 45);
            Console.WriteLine(123 % 45);

            Console.WriteLine("\n실수의 계산");
            Console.WriteLine(123.45 + 67.89);
            Console.WriteLine(123.45 - 67.89);
            Console.WriteLine(123.45 * 67.89);
            Console.WriteLine(123.45 / 67.89);
            Console.WriteLine(123.45 % 67.89);

            //#Divide By Zero Exception
            int x1 = 10, y1 = 0;
            try
            {
                Console.WriteLine(x1 / y1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); //=> 0으로 나누려 했습니다.
            }
            //#Overflow Exception
            int x = int.MaxValue, y = 0;
            checked
            {
                try
                {
                    y = x + 10;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.WriteLine("int.MaxVlaue + 10 = {0}", y);
            //Console.Read();

            //#관계 연산자
            bool result;
            int first = 10, second = 20;

            result = (first == second);
            Console.WriteLine("{0} == {1} : {2}", first, second, result);

            result = (first > second);
            Console.WriteLine("{0} > {1} : {2}", first, second, result);

            result = (first < second);
            Console.WriteLine("{0} < {1} : {2}", first, second, result);

            result = (first >= second);
            Console.WriteLine("{0} >= {1} : {2}", first, second, result);

            result = (first <= second);
            Console.WriteLine("{0} <= {1} : {2}", first, second, result);

            result = (first != second);
            Console.WriteLine("{0} != {1} : {2}", first, second, result);

            //#논리 연산자
            result = (first == second) || (first > 5);
            Console.WriteLine("{0} || {1} : {2}", first == second, first > 5, result);

            result = (first == second) && (first > 5);
            Console.WriteLine("{0} && {1} : {2}", first == second, first > 5, result);

            result = true ^ false;
            Console.WriteLine("{0} ^ {1} : {2}", true, false, result);

            result = !(first > second);
            Console.WriteLine("!{0} : {1}", first > second, result);

            int year = 2018;
            bool isLeapYear = year % 4 == 0 && (year % 100 != 0 || year % 400 == 0);
            Console.WriteLine("{0}년은 윤년이다 : {1}", year, isLeapYear);

            //#비트 연산자
            int x2 = 14, y2 = 11, result2;

            result2 = x2 | y2;
            Console.WriteLine("{0} | {1} = {2}", x2, y2, result2);

            result2 = x2 & y2;
            Console.WriteLine("{0} & {1} = {2}", x2, y2, result2);

            result2 = x2 ^ y2;
            Console.WriteLine("{0} ^ {1} = {2}", x2, y2, result2);

            result2 = ~x2;
            Console.WriteLine("~{0} = {1}", x2, result2);

            result2 = x2 << 2;
            Console.WriteLine("{0} << 2 = {1}", x2, result2);

            result2 = y2 >> 1;
            Console.WriteLine("{0} >> 1 = {1}", y2, result2);

            //#조건 연산자
            int input = Convert.ToInt32(Console.ReadLine());

            string result3 = (input > 0) ? "양수입니다." : "음수입니다.";
            Console.WriteLine("{0}는 {1}", input, result3);
            Console.WriteLine("{0}는 {1}", input, (input % 2 == 0) ? "짝수입니다." : "홀수입니다.");

            for (int i = 1; i <= 50; i++)
            {
                Console.Write("{0,3}{1}", i, i % 10 != 0 ? "" : "\n");
            }

            //#증가/감소 연산자
            int x3 = 10;

            Console.WriteLine(x3 += 2);
            Console.WriteLine(x3 -= 8);
            Console.WriteLine(x3 *= 3);
            Console.WriteLine(x3 /= 2);
            Console.WriteLine(x3++);
            Console.WriteLine(--x3);

        }
    
    }
}
