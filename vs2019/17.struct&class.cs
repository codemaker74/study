using System; 

namespace ConsoleApp1
{
    struct DateStruct2
    {
    public int year, month, day;
    }

    class DateClass
    {
    public int year, month, day;
    }
    class Program
    {
        static void Main(string[] args)
        {//실행 => Ctrl + F5

            DateStruct2 sDay;
            sDay.year = 2018;
            sDay.month = 11;
            sDay.day = 22;
            Console.WriteLine("sDay: {0}/{1}/{2}", sDay.year, sDay.month, sDay.day);

            DateClass cDay = new DateClass();
            cDay.year = 2018;
            cDay.month = 11;
            cDay.day = 22;
            Console.WriteLine("cDay: {0}/{1}/{2}", cDay.year, cDay.month, cDay.day);

            DateStruct2 sDay2 = new DateStruct2();
            Console.WriteLine("sDay2: {0}/{1}/{2}", sDay2.year, sDay2.month, sDay2.day);
            DateClass cDay2 = new DateClass();
            Console.WriteLine("cDay2: {0}/{1}/{2}", cDay2.year, cDay2.month, cDay2.day);

            DateStruct2 s = sDay;
            DateClass c = cDay;

            s.year = 2000;
            c.year = 2000;

            Console.WriteLine("s: {0}/{1}/{2}", s.year, s.month, s.day);
            Console.WriteLine("c: {0}/{1}/{2}", c.year, c.month, c.day);
            Console.WriteLine("sDay: {0}/{1}/{2}", sDay.year, sDay.month, sDay.day);
            Console.WriteLine("cDay: {0}/{1}/{2}", cDay.year, cDay.month, cDay.day);

        }

    }
}

/*
- 구조체&클래스는 class와 struct 키워드만 빼고 구문 동일.
- 구조체는 값형이고 클래스는 참조형.
- 구조체는 메모리 스택영역에 공간 할당.
- 클래스는 스택에 참조만 위치.
- 클래스는 반드시 new 키워드를 사용해서 객체 생성.
*/

/*
sDay: 2018/11/22
cDay: 2018/11/22
sDay2: 0/0/0
cDay2: 0/0/0
s: 2000/11/22
c: 2000/11/22
sDay: 2018/11/22
cDay: 2000/11/22
계속하려면 아무 키나 누르십시오 . . .
 */
