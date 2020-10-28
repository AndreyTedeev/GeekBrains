using System;

namespace Lesson2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson2 demo by Andrey Tedeev");
            Console.WriteLine();
            AbstractWorker[] workers = InitData(10);
            Array.Sort(workers);
            Print(workers);
            Console.ReadLine();
        }

        static AbstractWorker[] InitData(int size) {
            AbstractWorker[] data = new AbstractWorker[10];
            Random random = new Random();
            for (int i = 0; i < data.Length; i++)
            {
                string name = $"Worker {i}";
                if (i % 2 == 0)
                    data[i] = new MonthlyWorker(name, random.Next(50_000, 99_999));
                else
                    data[i] = new HourlyWorker(name, random.Next(300, 800));
            }
            return data;
        }

        static void Print(AbstractWorker[] data) 
        {
            foreach (AbstractWorker worker in data)
                worker.Print();
        }
    }
}
