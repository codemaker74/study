using System; 

namespace ConsoleApp1
{
    class Program
    {
        enum E { Red, Green, Blue };

        static void Main(string[] args)
        {
            //실행 => Ctrl + F5

            int a = default;
            string s = default;
            Console.WriteLine("a = " + a);
            Console.WriteLine("s = " + s);
            Console.WriteLine("E = " + default(E));
            Console.WriteLine("E = " + (E)0);

            GenericList<int> iList = new GenericList<int>();
            Console.WriteLine("iList : " + iList.GetLast());

            GenericList<string> sList = new GenericList<string>();
            Console.WriteLine("sList : " + sList.GetLast());
        }
    }

    public class GenericList<T>
    {
        private class Node
        {
            public T data;
            public Node next;
        }
        private Node head = default;

        public void AddNode(T t)
        {
            Node newNode = new Node();
            newNode.next = head;
            newNode.data = t;
            head = newNode;
        }

        public void PrintList()
        {
            for (Node ptr = head; ptr != default; ptr = ptr.next)
                Console.Write(ptr.data + " ");
            Console.WriteLine();
        }

        public T GetLast()
        {
            T temp = default(T);

            Node current = head;
            while (current != null)
            {
                temp = current.data;
                current = current.next;
            }
            return temp;
        }
    }
}
