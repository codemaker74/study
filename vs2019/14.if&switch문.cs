using System; 

namespace ConsoleApp1
{
    class Program
    { 

        static void Main(string[] args)
        {
            //실행 => Ctrl + F5

            //#if문
            for (int year = 2015; year <= 2020; year += 1)
            {
                if (year % 4 == 0 && year % 100 != 0 || year % 400 == 0)
                    Console.WriteLine("{0}년은 윤년", year);
                else
                    Console.WriteLine("{0}년은 평년", year);

                if (DateTime.IsLeapYear(year))
                    Console.WriteLine("{0}년은 윤년", year);
                else
                    Console.WriteLine("{0}년은 평년", year);
            }

            //#switch문
            //Console.Write("점수를 입력하세요: ");
            int score = int.Parse( "97" );

            string grade = null;

            if (score >= 90)
                grade = "A";
            else if (score >= 80)
                grade = "B";
            else if (score >= 70)
                grade = "C";
            else if (score >= 60)
                grade = "D";
            else
                grade = "F";
            Console.WriteLine("학점은 {0}", grade);

            switch (score / 10)
            {
                case 10:
                case 9:
                    grade = "A";
                    break;
                case 8:
                    grade = "B";
                    break;
                case 7:
                    grade = "C";
                    break;
                case 6:
                    grade = "D";
                    break;
                default:
                    grade = "F";
                    break;
            }
            Console.WriteLine("학점은 {0}", grade);


            Console.Write("키를 입력하세요(cm) : ");
            double height = double.Parse(Console.ReadLine());
            height /= 100;  // m 단위

            Console.Write("체중을 입력하세요(kg) : ");
            double weight = double.Parse(Console.ReadLine());
            double bmi = weight / (height * height);

            /*
              BMI < 20, 저체중
              20 <= BMI < 25, 정상체중
              25 <= BMI < 30, 경도비만
              30 <= BMI < 40, 비만
              BMI >= 40, 고도비만
            */
            string comment = null;
            if (bmi < 20)
                comment = "저체중";
            else if (bmi < 25)
                comment = "정상체중";
            else if (bmi < 30)
                comment = "경도비만";
            else if (bmi < 40)
                comment = "비만";
            else
                comment = "고도비만";

            Console.WriteLine("BMI={0:F1}, \"{1}\"입니다", bmi, comment);
        }
    }
}
