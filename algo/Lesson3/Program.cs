using System;
using System.Diagnostics;

namespace Lesson3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = RandomArray(10000);
            Console.WriteLine("Генерируем исходный массив");
            Print(data, false);
            Console.WriteLine();
            Console.WriteLine($"Простая сортировка пузырьком массива из {data.Length} элементов");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int[] sorted_data = BubbleSort<int>(data, out int total_circles, out int total_swaps);
            sw.Stop();
            Print(sorted_data, false);
            Console.WriteLine($"ellapsed: {sw.ElapsedMilliseconds}, circles: {total_circles}, swaps: {total_swaps}");
            Console.WriteLine();

            Console.WriteLine($"Оптимизированная сортировка пузырьком массива из {data.Length} элементов");
            sw.Reset();
            sw.Start();
            sorted_data = BubbleSortOptimized<int>(data, out total_circles, out total_swaps);
            sw.Stop();
            Print(sorted_data, false);
            Console.WriteLine($"ellapsed: {sw.ElapsedMilliseconds}, circles: {total_circles}, swaps: {total_swaps}");
            Console.WriteLine();

            Console.WriteLine($"Шейкерная сортировка массива из {data.Length} элементов");
            sw.Reset();
            sw.Start();
            sorted_data = ShakerSort<int>(data, out total_circles, out total_swaps);
            sw.Stop();
            Print(sorted_data, false);
            Console.WriteLine($"ellapsed: {sw.ElapsedMilliseconds}, circles: {total_circles}, swaps: {total_swaps}");
            Console.WriteLine();

            Console.WriteLine($"Поиск числа {data[0]} в отсортированном массиве из {sorted_data.Length} элементов");
            sw.Reset();
            sw.Start();
            int index = BinarySearch<int>(sorted_data, data[0], out total_circles);
            sw.Stop();
            Console.WriteLine($"ellapsed: {sw.ElapsedMilliseconds}, circles: {total_circles}, index: {index}, value: {sorted_data[index]}");
            Console.WriteLine();
        }

        private static int[] RandomArray(int size)
        {
            Random random = new Random();
            int[] result = new int[size];
            for (int i = 0; i < size; i++)
                result[i] = random.Next(0, size);
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

        /// <summary>
        /// Simple bubble sort implementation
        /// </summary>
        /// <typeparam name="T">IComparable</typeparam>
        /// <param name="source">given array to sort</param>
        /// <returns>sorted copy of given array</returns>
        static T[] BubbleSort<T>(T[] source, out int total_circles, out int total_swaps) where T : IComparable
        {
            T[] result = new T[source.Length];
            Array.Copy(source, result, source.Length);

            total_swaps = 0;
            total_circles = 0;

            for (int j = 0; j < source.Length; j++)
            {
                for (int i = 0; i < result.Length - 1; i++)
                {
                    if (result[i].CompareTo(result[i + 1]) > 0)
                    {
                        (result[i], result[i + 1]) = (result[i + 1], result[i]); // swap
                        total_swaps++;
                    }
                }
                total_circles++;
            }
            return result;
        }

        /// <summary>
        /// Optimized bubble sort implementation
        /// </summary>
        /// <typeparam name="T">IComparable</typeparam>
        /// <param name="source">given array to sort</param>
        /// <returns>sorted copy of given array</returns>
        static T[] BubbleSortOptimized<T>(T[] source, out int total_circles, out int total_swaps) where T : IComparable
        {
            T[] result = new T[source.Length];
            Array.Copy(source, result, source.Length);

            total_swaps = 0;
            total_circles = 0;
            int circle_swaps;
            do // circles
            {
                circle_swaps = 0;
                for (int i = 0; i < result.Length - 1; i++)
                {
                    if (result[i].CompareTo(result[i + 1]) > 0)
                    {
                        (result[i], result[i + 1]) = (result[i + 1], result[i]); // swap
                        circle_swaps++;
                    }
                }
                total_circles++;
                total_swaps += circle_swaps;
            }
            while (circle_swaps > 0);
            return result;
        }

        /// <summary>
        /// Shaker sort implementation
        /// </summary>
        /// <typeparam name="T">IComparable</typeparam>
        /// <param name="source">given array to sort</param>
        /// <returns>sorted copy of given array</returns>
        static T[] ShakerSort<T>(T[] source, out int total_circles, out int total_swaps) where T : IComparable
        {
            T[] result = new T[source.Length];
            Array.Copy(source, result, source.Length);

            total_swaps = 0;
            total_circles = 0;
            int circle_swaps;
            int left = 0, right = result.Length - 1;

            while (left < right)
            {
                circle_swaps = 0;
                for (int i = left; i < right; i++)
                {
                    if (result[i].CompareTo(result[i + 1]) > 0)
                    {
                        (result[i], result[i + 1]) = (result[i + 1], result[i]); // swap
                        circle_swaps++;
                    }
                }
                right--;
                total_circles++;
                total_swaps += circle_swaps;
                if (circle_swaps == 0)
                    break;

                circle_swaps = 0;
                for (int i = right; i > left; i--)
                {
                    if (result[i - 1].CompareTo(result[i]) > 0)
                    {
                        (result[i], result[i - 1]) = (result[i - 1], result[i]); // swap
                        circle_swaps++;
                    }
                }
                left++;
                total_circles++;
                total_swaps += circle_swaps;
                if (circle_swaps == 0)
                    break;

            }
            return result;
        }

        /// <summary>
        /// Binary search of element in array
        /// </summary>
        /// <typeparam name="T">IComparable</typeparam>
        /// <param name="source">given array for search</param>
        /// <param name="value">index of found element or -1 if not found </param>
        /// <returns></returns>
        static int BinarySearch<T>(T[] source, T value, out int total_circles) where T : IComparable
        {
            int left = 0, right = source.Length - 1;
            total_circles = 0;
            while (left <= right)
            {
                total_circles++;
                int middle = (left + right) / 2;
                if (source[middle].CompareTo(value) == 0)
                {
                    return middle;
                }
                else if (source[middle].CompareTo(value) > 0)
                {
                    right = middle - 1;
                }
                else
                {
                    left = middle + 1;
                }
            }
            return -1; // not found
        }
    }
}
