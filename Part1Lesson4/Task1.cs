using System;
using System.Collections.Generic;
using System.Text;

namespace AndreyTedeev.Part1Lesson4
{
    /// <summary>
    /// 1. Дан целочисленный массив из 20 элементов. Элементы массива могут принимать целые значения 
    /// от –10 000 до 10 000 включительно.Написать программу, позволяющую найти и вывести количество
    /// пар элементов массива, в которых хотя бы одно число делится на 3. 
    /// В данной задаче под парой подразумевается два подряд идущих элемента массива.
    /// Например, для массива из пяти элементов: 6; 2; 9; –3; 6 – ответ: 4.
    /// </summary>
    class Task1 : IAbstractTask
    {

        static readonly int MIN = -10_000;
        static readonly int MAX = +10_000;
        int[] data = new int[20];

        public void Run()
        {
            Console.WriteLine(" ====== Task 1.\n");

            int result = 0;

            // fill data array with random values and print it
            Random random = new Random();
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = random.Next(MIN, MAX);
                Console.Write($"{data[i]} ");
            }
            Console.WriteLine("");

            // test pairs of values
            for (int i = 0; i < data.Length-1; i++)
            {
                if (TestPair(data[i], data[i + 1]))
                    result++;
            }

            Console.WriteLine($"Количество пар в которых хотя бы одно число делится на три: {result}\n");
        }

        /// <summary>
        /// Тестирует пару элементов в которых хотя бы одно число делится на 3.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>
        /// true - если условие выполняется, false - если нет</returns>
        bool TestPair(int a, int b)
        {
            return (a % 3) == 0 || (b % 3) == 0;
        }

    }
}
