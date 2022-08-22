using System; 

namespace ConsoleApp1
{
    class Program
    {

        static int[] f = new int[50];

        static void Main(string[] args)
        {//실행 => Ctrl + F5

            Console.Write("피보나치 수열의 n항까지를 구합니다. n를 입력하세요: ");
            int n = 30; // int.Parse(Console.ReadLine());
            Console.WriteLine(n);

            var watch = System.Diagnostics.Stopwatch.StartNew();
            f[1] = f[2] = 1;
            for (int i = 3; i <= n; i++)
                f[i] = f[i - 1] + f[i - 2];
            for (int i = 1; i <= n; i++)
                Console.Write("{0} ", f[i]);
            Console.WriteLine();
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("실행시간은 {0}ms\n", elapsedMs);

            watch = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 1; i <= n; i++)
                Console.Write("{0} ", FiboRecursive(i));
            Console.WriteLine();
            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("실행시간은 {0}ms", elapsedMs);
        }

        private static int FiboRecursive(int n)
        {
            if (n == 1 || n == 2)
                return 1;
            else
                return FiboRecursive(n - 1) + FiboRecursive(n - 2);
        }
    }
}

/*
피보나치 수열의 n항까지를 구합니다. n를 입력하세요: 30
1 1 2 3 5 8 13 21 34 55 89 144 233 377 610 987 1597 2584 4181 6765 10946 17711 28657 46368 75025 121393 196418 317811 514229 832040
실행시간은 1ms

1 1 2 3 5 8 13 21 34 55 89 144 233 377 610 987 1597 2584 4181 6765 10946 17711 28657 46368 75025 121393 196418 317811 514229 832040
실행시간은 20ms
계속하려면 아무 키나 누르십시오 . . .
 */
