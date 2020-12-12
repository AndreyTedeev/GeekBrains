using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Lesson6
{
    /// <summary>
    /// 1.	Даны 2 двумерных матрицы. Размерность 100х100 каждая. Напишите приложение, 
    /// 	производящее параллельное умножение матриц.Матрицы заполняются случайными целыми числами от 0 до10.
    /// </summary>
    public class Part1
    {

        public static void Run()
        {
            Console.WriteLine("Generate two Matrix(100,100) with random values (0,10)");
            Matrix m1 = new Matrix(100, 100);
            m1.Randomize(0, 10);

            Matrix m2 = new Matrix(100, 100);
            m2.Randomize(0, 10);
            Console.WriteLine();

            Console.Write("Process in main thread   : ");
            Stopwatch sw = Stopwatch.StartNew();
            Matrix result1 = m1 * m2;
            sw.Stop();
            Console.WriteLine($"{sw.ElapsedMilliseconds} ms");
            Console.WriteLine("This calculated Matrix will be our reference result");
            Console.WriteLine();

            Console.Write("Process with Parallel    : ");
            sw.Reset();
            sw.Start();
            Matrix result2 = m1.MulParallel(m2);
            sw.Stop();
            Console.WriteLine($"{sw.ElapsedMilliseconds} ms");
            Console.WriteLine($"Is result equal to reference : {result1.Equals(result2)}");
            Console.WriteLine();

            Console.Write("Process with Task        : ");
            sw.Reset();
            sw.Start();
            Matrix result3 = m1.MulTask(m2);
            sw.Stop();
            Console.WriteLine($"{sw.ElapsedMilliseconds} ms");
            Console.WriteLine($"Is result equal to reference : {result1.Equals(result3)}");
            Console.WriteLine();

            Console.Write("Process with Async/Await : ");
            sw.Reset();
            sw.Start();
            Task<Matrix> task = Task.Factory.StartNew(() => m1.MulAsync(m2)).Result;
            Matrix result4 = task.Result;
            sw.Stop();
            Console.WriteLine($"{sw.ElapsedMilliseconds} ms");
            Console.WriteLine($"Is result equal to reference : {result1.Equals(result4)}");
            Console.WriteLine();
        }

    }
}
