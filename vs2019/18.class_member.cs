using System; 

namespace ConsoleApp1
{
    //필드관련
    class Product
    {
        public string name;
        public int price;
    }
    class MyMath
    {
        public static double PI = 3.14;
    }
    class MyCalendar
    {
        public const int months = 12;
        public const int weeks = 52;
        public const int days = 365;

        public const double daysPerWeek = (double)days / (double)weeks;
        public const double daysPerMonth = (double)days / (double)months;
    }
    //메소드관련
    struct Date
    {
        public int year, month, day;

        public static bool IsLeapYear(int year)
        {
            return year % 4 == 0 && (year % 100 != 0 || year % 400 == 0);
        }

        static int[] days = { 0, 31, 69, 90, 120, 151, 181, 212, 243, 273, 304, 334 };
        public int DayOfYear()
        {
            return days[month - 1] + day +
              (month > 2 && IsLeapYear(year) ? 1 : 0);
        }
    }
    //생성자관련
    class Date2
    {
        private int year, month, day;

        public Date2()
        {
            year  = 1;
            month = 1;
            day   = 1;
        }

        public Date2(int y, int m, int d)
        {
            year  = y;
            month = m;
            day   = d;
        }

        public void PrintDate()
        {
            Console.WriteLine("{0}/{1}/{2}", year, month, day);
        }
    }
    //속성관련 ("propfull"입력후, 탭키 두번 => 기본코드 자동생성)
    class RectWithPropFull
    {
        private double width;

        public double Width
        {
            get { return width; }
            set { if (value > 0) width = value; }
        }

        private double height;
        public double Height
        {
            get { return height; }
            set { if (value >= 0) height = value; }
        }
    }

    class Program
    {
        //정적메소드관련
        static int[] days = { 0, 31, 69, 90, 120, 151, 181, 212, 243, 273, 304, 334 }; // 평년
        public static int DayOfYear(int year, int month, int day)
        {
            return days[month - 1] + day +
              (month > 2 && IsLeapYear(year) ? 1 : 0);
        }
        private static bool IsLeapYear(int year)
        {
            return year % 4 == 0 && (year % 100 != 0 || year % 400 == 0);
        }

        static void Main(string[] args)
        {//실행 => Ctrl + F5

            //#필드
            Product p = new Product();

            p.name = "시계";
            p.price = 100000;

            Console.WriteLine("{0} : {1:C}", p.name, p.price);
            Console.WriteLine("원주율 : {0}", MyMath.PI);
            Console.WriteLine("한달은 평균 {0:F3}일", MyCalendar.daysPerMonth);

            //#메소드
            Date xmas = new Date();

            xmas.year = 2018;
            xmas.month = 12;
            xmas.day = 25;

            Console.WriteLine("xmas: {0}/{1}/{2}는 {3}일째 되는 날입니다", xmas.year, xmas.month, xmas.day, xmas.DayOfYear());

            if (Date.IsLeapYear(2018) == true)
                Console.WriteLine("2018년은 윤년입니다");
            else
                Console.WriteLine("2018년은 평년입니다");

            //#생성자
            Date2 birthday = new Date2(2000, 11, 22);
            Date2 christmas = new Date2(2018, 12, 25);
            Date2 theDay = new Date2();

            birthday.PrintDate();
            christmas.PrintDate();
            theDay.PrintDate();

            //#속성
            RectWithPropFull r2 = new RectWithPropFull();
            r2.Width = 10.0;
            r2.Height = 10.0;
            Console.WriteLine("r2의 면적은 {0}", r2.Width * r2.Height);

            RectWithPropFull r3 = new RectWithPropFull();
            r2.Width = 10.0;
            r2.Height = -10.0;
            Console.WriteLine("r3의 면적은 {0}", r3.Width * r3.Height);

            //#정적 메소드

            Console.Write("생일을 입력하세요(yyyy/mm/dd) : ");
            string birth = "1974/06/11"; //Console.ReadLine();
            Console.WriteLine(birth);
            string[] bArr = birth.Split('/');
            int bYear = int.Parse(bArr[0]);
            int bMonth = int.Parse(bArr[1]);
            int bDay = int.Parse(bArr[2]);

            int tYear = DateTime.Today.Year;
            int tMonth = DateTime.Today.Month;
            int tDay = DateTime.Today.Day;

            int totalDays = 0;
            for (int year = bYear + 1; year < tYear; year++)
            {
                if (IsLeapYear(year))
                    totalDays += 366;
                else
                    totalDays += 365;
            }

            // 올해의 1월 1일부터 오늘까지의 날짜 수
            totalDays += DayOfYear(tYear, tMonth, tDay);

            // 생년의 생일부터 마지막날까지의 날짜 수 = 365(366) - DayOfYear(bYear, bMonth, bDay)
            int yearDays = IsLeapYear(bYear) ? 366 : 365;
            totalDays += yearDays - DayOfYear(bYear, bMonth, bDay);

            Console.WriteLine("total days from birth day : {0}일", totalDays);
        }

    }
}

/*
* CLASS MEMBER *
* 
- 필드: 클래스 또는 구조체에서 직접 선언되는 모든 형식의 변수.
 => 인스턴스(객체)필드: 객체이름과 함께사용, [접근제한자][자료형][필드명]
 => 정적필드(클래스필드): 클래스 이름과 함께 사용, [클래스명][필드명]
- 상수: 값이 컴파일시에 설정되는 변경할수 없는 필드나 속성.
- 속성: 필드처럼 액세스되는 클래스의 메소드.
 => getter와 setter를 쉽게 만들수있는 방법.
- 메소드: 클래스나 구조체안에 정의된 함수, 스태틱메소드는 객체 만들지 않고 바로 사용가능.
 => 재귀메소드(recursive method)
- 이벤트: 성공적인 메소드 완료등의 사건이 발생했을때 알림을 다른 책체에 제공.
- 연산자
- 인덱서
- 생성자: 객체가 만들어지면서 수행해야 하는 작업, 클래스이름과 동일, 리턴없음, 중복가능.
- 소멸자
*/

/*
시계 : \100,000
원주율 : 3.14
한달은 평균 30.417일
xmas: 2018/12/25는 359일째 되는 날입니다
2018년은 평년입니다
2000/11/22
2018/12/25
1/1/1
r2의 면적은 100
r3의 면적은 0
생일을 입력하세요(yyyy/mm/dd) : 1974/06/11
total days from birth day : 17605일
계속하려면 아무 키나 누르십시오 . . .
 */
