using System;
using System.Threading;

namespace ThreadTest
{
    class Program
    {
        public static Value value = new Value();

        static void Main(string[] args)
        {

            Worker worker = new Worker();
            for (int i = 0; i < 10; i++)
            {
                new Thread(worker.Do)
                {
                    Name = i.ToString()
                }
                .Start();
                Thread.Sleep(1000);
            }
        }
    }

    class Value
    {
        public int Int { get; set; }

        public static Value operator +(Value v1, Value v2)
        {
            return new Value() { Int = v1.Int + v2.Int };
        }

        public static Value operator ++(Value v1)
        {
            return new Value() { Int = v1.Int + 1 };
        }

        public static Value operator +(Value v1, int v2)
        {
            return new Value() { Int = v1.Int + v2 };
        }
    }

    class Worker
    {

        public void Do()
        {
            int hash = Thread.CurrentThread.GetHashCode();
            string name = Thread.CurrentThread.Name;
            int val = 0;
            while (true)
            {
                lock (Program.value)
                {
                    val = ++Program.value.Int;
                }
                if (val < 100)
                {
                    Console.WriteLine($"hash: {hash}, name: {name}, value = {val}");
                    Thread.Sleep(1000);
                }
                else
                    break;
            }
        }

    }
}
