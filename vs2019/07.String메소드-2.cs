using System; 

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //실행 => Ctrl + F5

            //#문자열 나누기
            string s = "1,2 3-4";
            int sum = 0;
            char[] delimiters = { ',', ' ', '-' };
            string[] v = s.Split(delimiters);

            foreach (var i in v)
            {
                sum += int.Parse(i);
            }
            Console.WriteLine("결과는 {0}", sum);

            //#문자열 합치기
            string userName = "bikang";
            string date = DateTime.Today.ToShortDateString();

            string strPlus = "Hello " + userName + ". Today is " + date + ".";
            Console.WriteLine(strPlus);

            string strFormat = String.Format("Hello {0}. Today is {1}.", userName, date);
            Console.WriteLine(strFormat);

            string strInterpolation = $"Hello {userName}. Today is {date}.";
            System.Console.WriteLine(strInterpolation);

            string strConcat = String.Concat("Hello ", userName, ". Today is ", date, ".");
            Console.WriteLine(strConcat);

            string[] animals = { "mouse", "cow", "tiger", "rabbit", "dragon" };
            string ss = String.Concat(animals);
            Console.WriteLine(ss);
            ss = String.Join(", ", animals);
            Console.WriteLine(ss);

            //#문자열 검색
            string s1 = "mouse, cow, tiger, rabbit, dragon";
            string s2 = "cow";
            bool b = s1.Contains(s2);
            Console.WriteLine("'{0}' is in the string '{1}': {2}", s2, s1, b);

            if (b)
            {
                int index = s1.IndexOf(s2);
                if (index >= 0)
                    Console.WriteLine("'{0} begins at index {1}", s2, index);
            }

            int i2 = s1.IndexOf(s2, StringComparison.CurrentCultureIgnoreCase);
            if (i2 >= 0)
            {
                Console.WriteLine("'{0}' is in the string '{1}' ", s2, s1);
                Console.WriteLine("at index {0} (case insensitive)", i2);
            }

        }


    }
}
 
