using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson5
{

    /// <summary>
    /// Написать приложение, считающее в раздельных потоках:
    /// a.факториал числа N, которое вводится с клавиатуру;
    /// b.сумму целых чисел до N, которое также вводится с клавиатуры.
    /// </summary>
    public class Part1
    {
        static int TOTAL_THREADS = 2;
        static object _Finished = 0; // locker counts finished threads

        public static void Run()
        {
            Menu(out int n);
            if (n == 0) return; // 0 means Exit

            new Thread(FactTask) { IsBackground = true }.Start(n);

            new Thread(SumTask) { IsBackground = true }.Start(n);

            // Main thread waits for other threads to finish
            char[] c = { '―', '|', '\\', '/' };
            int cpos = 0;
            while (true)
            {
                lock (_Finished)
                {
                    if ((int)_Finished == TOTAL_THREADS)
                        break;
                    Console.SetCursorPosition(0, 10);
                    Console.Write($"Подождите... Идет рассчет : {c[cpos++]}");
                }
                if (cpos == c.Length)
                    cpos = 0;
                Thread.Sleep(100);
            }

            Console.SetCursorPosition(0, 10);
            Console.Write("Рассчет окончен. Нажмите ENTER для выхода");
            Console.ReadLine();
        }

        static void FactTask(object param)
        {
            int n = (int)param;
            BigInteger r = 1;
            for (int i = 2; i <= n; ++i)
            {
                r *= i;
                lock (_Finished)
                {
                    Console.SetCursorPosition(0, 5);
                    Console.Write($"N! = {r}");
                }
                Thread.Sleep(100);
            }

            lock (_Finished)
            {
                _Finished = (int)_Finished + 1;
                Console.SetCursorPosition(0, 10);
            }
        }

        static void SumTask(object param)
        {
            int n = (int)param;
            BigInteger r = 1;
            for (int i = 2; i <= n; i++)
            {
                r += i;
                lock (_Finished)
                {
                    Console.SetCursorPosition(0, 8);
                    Console.Write($"∑(1..N) = {r}");
                }
                Thread.Sleep(100);
            }
            lock (_Finished)
            {
                _Finished = (int)_Finished + 1;
                Console.SetCursorPosition(0, 12);
            }
        }

        static void Menu(out int value)
        {
            string s;
            do
            {
                Console.Clear();
                Console.WriteLine("Введите положительное число N для расчета N! и ∑(1..N)");
                Console.WriteLine("или 0 для выхода");
                Console.Write(">> : ");
                s = Console.ReadLine();
            }
            while (!int.TryParse(s, out value) && (value >= 0));
        }
    }
}
