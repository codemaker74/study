using System; 

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {//실행 => Ctrl + F5

            //#배열의 초기화
            int[] a = { 1, 2, 3 };      
            Console.Write("a[]: ");
            foreach (var value in a)
                Console.Write(value + " ");

            int[] b = new int[] { 1, 2, 3 };
            Console.Write("\nb[]: ");
            for (int i = 0; i < 3; i++)
                Console.Write(b[i] + " ");

            int[] c = new int[3] { 1, 2, 3 };
            Console.Write("\nc[]: ");
            for (int i = 0; i < b.Length; i++)
                Console.Write(b[i] + " ");

            int[] d = new int[3];
            d[0] = 1;
            d[1] = d[0] + 1;
            d[2] = d[1] + 1;
            Console.Write("\nd[]: ");
            foreach (int value in d)
                Console.Write(value + " ");
            Console.WriteLine();

            //#ArrayClass - 복제,정렬,초기화
            int[] a1 = { 5, 25, 75, 35, 15 };
            PrintArray(a1);

            int[] b1;
            b1 = (int[])a1.Clone();
            PrintArray(b1);

            int[] c1 = new int[10];
            Array.Copy(a1, 0, c1, 1, 3);
            PrintArray(c1);

            a1.CopyTo(c1, 3);
            PrintArray(c1);
                        
            Array.Sort(a1);     //오름차순
            PrintArray(a1);
                        
            Array.Reverse(a1);  //내림차순
            PrintArray(a1);
                        
            Array.Clear(a1, 0, a1.Length);
            PrintArray(a1);

            //#다차원배열            
            Console.WriteLine("2차원 배열: arr1[2, 3]");
            int[,] arrA = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                    Console.Write("{0,5}", arrA[i, j]);
                Console.WriteLine();
            }
            Console.WriteLine("Length={0} GetLength(0)={1} GetLength(1)={2}",
              arrA.Length, arrA.GetLength(0), arrA.GetLength(1));
            Array.Clear(arrA, 0, arrA.Length);
                        
            Console.WriteLine("2차원 배열: arrB[2][3]");
            int[][] arrB = new int[2][]; //가변배열(jagged array)
            arrB[0] = new int[] { 1, 2 };
            arrB[1] = new int[] { 3, 4, 5 };
            for (int i = 0; i < 2; i++)
            {
                Console.Write("arrB[{0}] : ", i);
                for (int j = 0; j < arrB[i].Length; j++)
                    Console.Write("{0}  ", arrB[i][j]);
                Console.WriteLine();
            }

            //#알파벳순으로 정렬
            string[] name = { "Mouse", "Cow", "Tiger", "Rabiit", "Dragon", "Snake", "Horse" };
            PrintArrayStr("Before Sort: ", name);

            Array.Reverse(name);
            PrintArrayStr("After Reverse: ", name);

            Array.Sort(name);
            PrintArrayStr("After Sort: ", name);

            Array.Reverse(name);
            PrintArrayStr("After Reverse: ", name);
        }
        private static void PrintArray(int[] a)
        {
            foreach (var i in a)
                Console.Write("{0,5}", i);
            Console.WriteLine();
        }
        private static void PrintArrayStr(string s, string[] name)
        {
            Console.WriteLine(s);
            foreach (var n in name)
                Console.Write("{0} ", n);
            Console.WriteLine();
        }
    }
}
