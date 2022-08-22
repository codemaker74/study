using System; 

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {//실행 => Ctrl + F5

            //#랜덤함수
            Random r = new Random();

            Console.Write("{0,-16}", "Random Bytes : ");
            Byte[] b = new byte[5];
            r.NextBytes(b);                // 한번 호출로 배열을 랜덤값으로 채움

            foreach (var x in b)
                Console.Write("{0,12}", x); // 12자리로 출력
            Console.WriteLine();

            Console.Write("{0,-16}", "Random Double : ");
            double[] d = new double[5];

            for (int i = 0; i < 5; i++)    // 5개 double 랜덤값 생성 저장
                d[i] = r.NextDouble();

            foreach (var x in d)
                Console.Write("{0,12:F8}", x); // 12자리, 소수점 아래 8자리로 출력
            Console.WriteLine();

            Console.Write("{0,-16}", "Random Int32 : ");
            int[] a = new int[5];

            for (int i = 0; i < 5; i++)    // 5개 int 랜덤값 생성 저장
                a[i] = r.Next();
            PrintArray(a);

            Console.Write("{0,-16}", "Random 0~99 :");
            int[] v = new int[5];

            for (int i = 0; i < 5; i++)    // 5개 0~99의 랜덤값 생성 저장
                v[i] = r.Next(100);
            PrintArray(v);

            //#최소,최대,평균계산
            //Console.WriteLine("Random Int32(0~99)");
            int[] v1 = new int[20];

            for (int i = 0; i < v1.Length; i++)  // 5개 0~99의 랜덤값 저장
                v1[i] = r.Next(100);
            PrintArray1(v1);
                        
            int max = v1[0];
            for (int i = 1; i < v1.Length; i++)
                if (v1[i] > max)
                    max = v1[i];
            Console.WriteLine("최대값: {0}", max);
                        
            int min = v1[0];
            for (int i = 1; i < v1.Length; i++)
                if (v1[i] < min)
                    min = v1[i];
            Console.WriteLine("최소값: {0}", min);
                       
            int sum = 0;
            for (int i = 0; i < v1.Length; i++)
                sum += v1[i];
            Console.WriteLine("합계: {0}\n평균: {1:F2}", sum,
               (double)sum / v1.Length);

            //#정렬
            int[] v2 = new int[30];

            for (int i = 0; i < 30; i++)
                v2[i] = r.Next(1000);
            PrintArray2("정렬 전", v2);

            Array.Sort(v2);
            PrintArray2("정렬 후", v2);

            Console.Write("=> 검색할 숫자를 입력하세요: ");
            int key = 567;//int.Parse(Console.ReadLine());
            int count = 0;  // 비교횟수  

            //#선형탐색
            for (int i = 0; i < v2.Length - 1; i++)
            {
                count++;
                if (v2[i] == key)
                {
                    Console.WriteLine("v2[{0}] = {1}", i, key);
                    Console.WriteLine("선형탐색의 비교횟수는 {0}회 입니다.", count);
                    break;
                }
            }

            //#이진탐색      
            count = 0;
            int low = 0;
            int high = v2.Length - 1;
            while (low <= high)
            {
                count++;
                int mid = (low + high) / 2;
                if (key == v2[mid])
                {
                    Console.WriteLine("v2[{0}] = {1}", mid, key);
                    Console.WriteLine("이진탐색의 비교횟수는 {0}회 입니다.", count);
                    break;
                }
                else if (key > v2[mid])
                    low = mid + 1;
                else
                    high = mid - 1;
            }

            //#버블정렬
            int[] v3 = { 3, 5, 2, 7, 1 };
            PrintArray3(v3);

            for (int i = 4; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                    if (v3[j] > v3[j + 1])
                    {
                        int t = v3[j];
                        v3[j] = v3[j + 1];
                        v3[j + 1] = t;
                    }
                PrintArray3(v3);
            }
        }
        private static void PrintArray(int[] v)
        {
            foreach (var value in v)
                Console.Write("{0,12}", value);
            Console.WriteLine();
        }
        private static void PrintArray1(int[] v1)
        {
            for (int i = 0; i < v1.Length; i++)
                Console.Write("{0,5}{1}", v1[i], (i % 10 == 9) ? "\n" : "");
        }
        private static void PrintArray2(string s, int[] v2)
        {
            Console.WriteLine(s);
            for (int i = 0; i < v2.Length; i++)
                Console.Write("{0,5}{1}", v2[i], (i % 10 == 9) ? "\n" : "");
        }
        private static void PrintArray3(int[] v3)
        {
            foreach (var i in v3)
                Console.Write("{0, 5}", i);
            Console.WriteLine();
        }
    }
}
