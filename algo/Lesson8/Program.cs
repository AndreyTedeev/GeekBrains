using System;
using System.Diagnostics;

namespace Lesson8
{
    /// <summary>
    /// Andrey Tedeev <andrey.tedeev@outlook.com>
    /// "Алгоритмы и структуры данных"
    /// Урок 8
    /// 
    /// 1. Реализовать сортировку подсчетом.
    /// 2. Реализовать быструю сортировку.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Генерируем исходный массив");
            int MIN = 1;
            int MAX = 99;
            int[] data = RandomArray(10000, MIN, MAX);
            Print(data, false);
            Console.WriteLine();

            Console.WriteLine($"QuickSort массива из {data.Length} элементов");

            int[] q_data = new int[data.Length];
            Array.Copy(data, q_data, data.Length);

            Stopwatch sw = new Stopwatch();
            sw.Start();
            QuickSort<int>(q_data);
            sw.Stop();

            Print(q_data, false);
            Console.WriteLine($"ellapsed: {sw.ElapsedMilliseconds}");
            Console.WriteLine();

            Console.WriteLine($"CountSort массива из {data.Length} элементов");

            int[] c_data = new int[data.Length];
            Array.Copy(data, c_data, data.Length);

            sw.Start();
            CountSort(c_data, MIN, MAX);
            sw.Stop();

            Print(c_data, false);
            Console.WriteLine($"ellapsed: {sw.ElapsedMilliseconds}");
            Console.WriteLine();
        }

        public static void CountSort(int[] data, int min, int max)
        {
            if (min == int.MinValue)
                throw new ArgumentException("The int.MIN value is reserved.");
            if (max - min < 2)
                throw new ArgumentException("It makes sense to sort if we have at least two different elements.");
            if (max - min > 100)
                throw new ArgumentException("It makes sense to use another sort method.");
            // prepare counts
            int[] counts = new int[max - min + 1];
            for (int i = 0; i < counts.Length; i++)
                counts[i] = int.MinValue;
            // process counts
            for (int i = 0; i < data.Length; i++)
            {
                int pos = data[i] - min;
                counts[pos] = (counts[pos] == int.MinValue) ? 1 : counts[pos] + 1;
            }
            int c = 0;
            for (int i = 0; i < counts.Length; i++)
            {
                int value = i + min;
                for (int j = 0; j < counts[i]; j++) 
                {
                    data[c] = value;
                    c++;
                }
            }
        }

        public static void QuickSort<T>(T[] data) where T : IComparable<T>
        {
            QuickSort(data, 0, data.Length - 1);
        }

        private static void QuickSort<T>(T[] data, int left, int right) where T : IComparable<T>
        {
            if (right <= left) return;

            int middle = Partition(data, left, right);

            QuickSort(data, left, middle - 1);
            QuickSort(data, middle + 1, right);
        }

        private static int Partition<T>(T[] data, int left, int right) where T : IComparable<T>
        {
            int i = left;
            int j = right + 1;

            while (true)
            {
                while (data[++i].CompareTo(data[left]) < 0)
                {
                    if (i == right) break;
                }

                while (data[--j].CompareTo(data[left]) > 0)
                {
                    if (j == left) break;
                }

                if (i >= j)
                {
                    break;
                }

                (data[i], data[j]) = (data[j], data[i]);
            }
            (data[left], data[j]) = (data[j], data[left]);
            return j;
        }

        private static int[] RandomArray(int size, int min, int max)
        {
            Random random = new Random();
            int[] result = new int[size];
            for (int i = 0; i < size; i++)
                result[i] = random.Next(min, max);
            return result;
        }

        private static void Print(int[] data, bool full)
        {
            if (full)
                foreach (int i in data)
                    Console.Write($"{i} ");
            else
                Console.WriteLine($"[{data[0]}..{data[data.Length - 1]}]");
        }
    }
}
