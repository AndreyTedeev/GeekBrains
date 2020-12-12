using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson5
{
    /// <summary>
    /// Написать приложение, выполняющее парсинг CSV-файла произвольной структуры 
    /// и сохраняющее его в обычный TXT-файл.Все операции проходят в потоках.
    /// CSV-файл заведомо имеет большой объём.
    /// </summary>
    public class Part2
    {

        private struct Rec
        {
            public int Code;
            public double Price;
            public override string ToString() => $"{Code};{Price}";
        }

        private const int TOTAL_THREADS = 2;
        private static readonly List<Rec> _data = new List<Rec>(); // locker with data
        private static int _finished = 0;

        public static void Run()
        {
            new Thread(ReadTask) { IsBackground = true }.Start("price.csv");

            new Thread(WriteTask) { IsBackground = true }.Start("price.txt");

            // Main thread waits for other threads to finish
            char[] c = { '―', '|', '\\', '/' };
            int cpos = 0;
            while (true)
            {
                lock (_data)
                {
                    if (_finished == TOTAL_THREADS)
                        break;
                    Console.SetCursorPosition(0, 10);
                    Console.Write($"Подождите... {c[cpos++]}");
                }
                if (cpos == c.Length)
                    cpos = 0;
                Thread.Sleep(100);
            }

            Console.SetCursorPosition(0, 10);
            Console.Write("Нажмите ENTER для выхода");
            Console.ReadLine();
        }

        /// <summary>
        /// Reads records from CSV file, converts to Rec, filters by Price > 5000
        /// </summary>
        /// <param name="fname"></param>
        static void ReadTask(object fname)
        {
            using (var reader = File.OpenText(fname.ToString()))
            {
                int count = 0;
                while (!reader.EndOfStream)
                {
                    var csv = reader.ReadLine().Split(';');
                    if (csv.Length != 15)
                        break;
                    if (!int.TryParse(csv[0], out int code))
                        continue;
                    if (!double.TryParse(csv[13], out double price))
                        continue;
                    count++;
                    lock (_data)
                    {
                        if (price > 5000)
                            _data.Add(new Rec { Code = code, Price = price });
                        Console.SetCursorPosition(0, 5);
                        Console.Write($"Reading record from '{fname}' : {count}");
                    }
                    //Thread.Sleep(1);
                }
            }
            lock (_data)
            {
                _finished = 1;
            }
        }

        /// <summary>
        /// Monitors _data and if it has records, writes it to the file then removes records.
        /// Exits when _finished is set to 1, indicating reading process is finished;
        /// </summary>
        /// <param name="fname"></param>
        static void WriteTask(object fname)
        {
            using (var writer = File.CreateText(fname.ToString()))
            {
                int count = 0;
                while (true)
                {
                    lock (_data)
                    {
                        foreach (Rec rec in _data)
                        {
                            writer.WriteLine(rec.ToString());
                            count++;
                            Console.SetCursorPosition(0, 7);
                            Console.Write($"Writing record to '{fname}' : {count}");
                        }
                        _data.Clear();
                        lock (_data)
                        {
                            if (_finished == 1) {
                                _finished = 2;
                                break;
                            }
                        }
                    }
                    //Thread.Sleep(1);
                }
            }
        }

    }
}
