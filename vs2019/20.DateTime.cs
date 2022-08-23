using System;
using System.Globalization;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {//실행 => Ctrl + F5

            //#DateTime구조체
            DateTime date1 = new DateTime(1992, 7, 4, 8, 44, 0);
            DateTime date2 = new DateTime(1990, 1, 27, 12, 6, 0);
            Console.WriteLine(date1);
            Console.WriteLine(date2);
            Console.WriteLine("{0}과 {1}의 차이는 {2}일입니다",
              date1.ToString("yyyy년 M월 d일"),
              date2.ToString("yyyy년 M월 d일"),
              date1.Subtract(date2).Days);

            Console.WriteLine("\n오늘: {0}", DateTime.Today);

            DateTime y = DateTime.Today.AddDays(-1);  // 어제
            Console.WriteLine("어제: {0}", y.ToShortDateString());

            DateTime t = DateTime.Today.AddDays(1);  // 내일
            Console.WriteLine("내일: {0}", t.ToShortDateString());

            Console.WriteLine("\n2020년은 {0}입니다", DateTime.IsLeapYear(2020) ? "윤년" : "평년");
            Console.WriteLine("2020년 2월은 {0}일입니다.\n", DateTime.DaysInMonth(2020, 2));

            // Parse and TryParse
            string date = "1990-1-27 12:6";
            DateTime aDay = DateTime.Parse(date);
            Console.WriteLine(aDay);

            string input = "1992/7/4 8:44";
            DateTime bDay;
            if (DateTime.TryParse(input, out bDay))
            {
                Console.WriteLine(bDay);
            }
            Console.WriteLine();

            DateTime d1 = DateTime.Now;
            DateTime d2 = DateTime.UtcNow;

            Console.WriteLine(d1);
            Console.WriteLine(d2);

            //#TimeSpan(시간간격)
            DateTime christmas = new DateTime(2018, 12, 25);
            DateTime newYearsDay = new DateTime(2019, 1, 1);
            //TimeSpan span = newYearsDay.Subtract(christmas);

            TimeSpan span = newYearsDay - christmas;
            Console.WriteLine("크리스마스와 1월 1일의 시간 간격");
            Console.WriteLine("{0,14}", span);
            Console.WriteLine("{0,14} days", span.Days);
            Console.WriteLine("{0,14} hours", span.Hours);
            Console.WriteLine("{0,14} minutes", span.Minutes);
            Console.WriteLine("{0,14} seconds", span.Seconds);
            Console.WriteLine("{0,14} milliseconds", span.Milliseconds);
            //Console.WriteLine("{0,14} ticks", span.Ticks);

            Console.WriteLine("\n또는");

            Console.WriteLine("{0,14}", span);
            Console.WriteLine("{0,14} days", span.TotalDays);
            Console.WriteLine("{0,14} hours", span.TotalHours);
            Console.WriteLine("{0,14} minutes", span.TotalMinutes);
            Console.WriteLine("{0,14} seconds", span.TotalSeconds);
            Console.WriteLine("{0,14} milliseconds", span.TotalMilliseconds);
            Console.WriteLine("{0,14} ticks", span.Ticks);

            //#생애 계산기
            Console.Write("생년월일 시분초를 입력하세요: ");
            DateTime date11 = DateTime.Parse( "1974-06-11"/*Console.ReadLine()*/);
            DateTime date22 = DateTime.Now;
            // Calculate the interval between the two dates.
            TimeSpan interval = date22 - date11;
            Console.WriteLine("탄생 시간: {0}", date11);
            Console.WriteLine("현재 시간: {0}", date22);
            Console.WriteLine("생존 시간: {0}", interval.ToString());
            // Display individual properties of the resulting TimeSpan object.
            Console.WriteLine("당신은 지금 이 순간까지 {0}일 {1}시간"
              + " {2}분 {3}초를 살았습니다.",
              interval.Days, interval.Hours,
              interval.Minutes, interval.Seconds);
            Console.WriteLine("   {0,-35} {1,20}", "Value of Days Component:", interval.Days);
            Console.WriteLine("   {0,-35} {1,20}", "Total Number of Days:", interval.TotalDays);
            Console.WriteLine("   {0,-35} {1,20}", "Value of Hours Component:", interval.Hours);
            Console.WriteLine("   {0,-35} {1,20}", "Total Number of Hours:", interval.TotalHours);
            Console.WriteLine("   {0,-35} {1,20}", "Value of Minutes Component:", interval.Minutes);
            Console.WriteLine("   {0,-35} {1,20}", "Total Number of Minutes:", interval.TotalMinutes);
            Console.WriteLine("   {0,-35} {1,20:N0}", "Value of Seconds Component:", interval.Seconds);
            Console.WriteLine("   {0,-35} {1,20:N0}", "Total Number of Seconds:", interval.TotalSeconds);
            Console.WriteLine("   {0,-35} {1,20:N0}", "Value of Milliseconds Component:", interval.Milliseconds);
            Console.WriteLine("   {0,-35} {1,20:N0}", "Total Number of Milliseconds:", interval.TotalMilliseconds);
            Console.WriteLine("   {0,-35} {1,20:N0}", "Ticks:", interval.Ticks);

            //#DateTime 스트링
            DateTime today = DateTime.Now;

            Console.WriteLine(today.ToString("yyyy년 MM월 dd일"));
            Console.WriteLine(string.Format("{0:yyyy년 MM월 dd일}", today));
            Console.WriteLine(today.ToString("MMMM dd, yyyy ddd", CultureInfo.CreateSpecificCulture("en-US")));
            Console.WriteLine(today.ToString("MMMM dd, yyyy ddd", new CultureInfo("en-US")));
            // 오전, 오후
            Console.WriteLine(today.ToString("tt"));
            today = today.AddHours(12);
            Console.WriteLine(today.ToString("tt"));
            today = today.AddHours(-12);
            Console.WriteLine("\n표준 포맷 지정자");
            // d : 축약된 날짜 형식
            Console.WriteLine("d : " + today.ToString("d"));
            Console.WriteLine("d : " + today.ToString("d", new CultureInfo("en-US")));
            // D : 긴 날짜 형식
            Console.WriteLine("D : " + string.Format("{0:D}", today));
            Console.WriteLine("D : " + string.Format(new CultureInfo("en-US"), "{0:D}", today));
            // t : 축약된 시간
            Console.WriteLine("t : " + string.Format("{0:t}", today));
            Console.WriteLine("t : " + string.Format(new CultureInfo("en-US"), "{0:t}", today));
            // T : 긴 시간 형식
            Console.WriteLine("T : " + string.Format("{0:T}", today));
            Console.WriteLine("T : " + string.Format(new CultureInfo("en-US"), "{0:T}", today));
            // g : 일반 날 및 시간 (초 생략)
            Console.WriteLine("g : " + string.Format("{0:g}", today));
            Console.WriteLine("g : " + string.Format(new CultureInfo("en-US"), "{0:g}", today));
            // G : 일반 날짜 및 시간
            Console.WriteLine("G : " + string.Format("{0:G}", today));
            Console.WriteLine("G : " + string.Format(new CultureInfo("en-US"), "{0:G}", today));
            // f : Full 날짜 및 시간 (초 생략)
            Console.WriteLine("f : " + string.Format("{0:f}", today));
            Console.WriteLine("f : " + string.Format(new CultureInfo("en-US"), "{0:f}", today));
            // F : Full 날짜 및 시간
            Console.WriteLine("F : " + string.Format("{0:F}", today));
            Console.WriteLine("F : " + string.Format(new CultureInfo("en-US"), "{0:F}", today));
            // s : ISO 8601 표준
            Console.WriteLine("s : " + string.Format("{0:s}", today));
            //Console.WriteLine("s : " + string.Format(new CultureInfo("en-US"), "{0:s}", today));
            // o : Round-trip 패턴
            Console.WriteLine("o : " + string.Format("{0:o}", today));
            //Console.WriteLine("o : " + string.Format(new CultureInfo("en-US"), "{0:o}", today));
            // r : Round-trip 패턴
            Console.WriteLine("r : " + string.Format("{0:r}", today));
            //Console.WriteLine("r : " + string.Format(new CultureInfo("en-US"), "{0:r}", today));
            // u : 로칼시간을 UTC로 변환하여 출력
            Console.WriteLine("u : " + string.Format("{0:u}", today));
            DateTime utcNow = DateTime.UtcNow;
            DateTime utcTime = DateTime.Now.ToUniversalTime();
            Console.WriteLine("UTC : " + utcNow.ToString("o"));
            Console.WriteLine("UTC : " + utcTime.ToString("o"));
        }
    }
}

/*
1992-07-04 오전 8:44:00
1990-01-27 오후 12:06:00
1992년 7월 4일과 1990년 1월 27일의 차이는 888일입니다

오늘: 2022-08-24 오전 12:00:00
어제: 2022-08-23
내일: 2022-08-25

2020년은 윤년입니다
2020년 2월은 29일입니다.

1990-01-27 오후 12:06:00
1992-07-04 오전 8:44:00

2022-08-24 오전 3:51:46
2022-08-23 오후 6:51:46
크리스마스와 1월 1일의 시간 간격
    7.00:00:00
             7 days
             0 hours
             0 minutes
             0 seconds
             0 milliseconds

또는
    7.00:00:00
             7 days
           168 hours
         10080 minutes
        604800 seconds
     604800000 milliseconds
 6048000000000 ticks
생년월일 시분초를 입력하세요: 탄생 시간: 1974-06-11 오전 12:00:00
현재 시간: 2022-08-24 오전 3:51:46
생존 시간: 17606.03:51:46.3817299
당신은 지금 이 순간까지 17606일 3시간 51분 46초를 살았습니다.
   Value of Days Component:                           17606
   Total Number of Days:                   17606.1609534922
   Value of Hours Component:                              3
   Total Number of Hours:                  422547.862883814
   Value of Minutes Component:                           51
   Total Number of Minutes:                25352871.7730288
   Value of Seconds Component:                           46
   Total Number of Seconds:                   1,521,172,306
   Value of Milliseconds Component:                     381
   Total Number of Milliseconds:          1,521,172,306,382
   Ticks:                              15,211,723,063,817,299
2022년 08월 24일
2022년 08월 24일
August 24, 2022 Wed
August 24, 2022 Wed
오전
오후

표준 포맷 지정자
d : 2022-08-24
d : 8/24/2022
D : 2022년 8월 24일 수요일
D : Wednesday, August 24, 2022
t : 오전 3:51
t : 3:51 AM
T : 오전 3:51:46
T : 3:51:46 AM
g : 2022-08-24 오전 3:51
g : 8/24/2022 3:51 AM
G : 2022-08-24 오전 3:51:46
G : 8/24/2022 3:51:46 AM
f : 2022년 8월 24일 수요일 오전 3:51
f : Wednesday, August 24, 2022 3:51 AM
F : 2022년 8월 24일 수요일 오전 3:51:46
F : Wednesday, August 24, 2022 3:51:46 AM
s : 2022-08-24T03:51:46
o : 2022-08-24T03:51:46.3967228+09:00
r : Wed, 24 Aug 2022 03:51:46 GMT
u : 2022-08-24 03:51:46Z
UTC : 2022-08-23T18:51:46.4656850Z
UTC : 2022-08-23T18:51:46.4656850Z
계속하려면 아무 키나 누르십시오 . . .
 */
