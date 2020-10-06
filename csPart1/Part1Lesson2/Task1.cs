using System;

namespace AndreyTedeev.Part1Lesson2
{
    /// <summary>
    /// 1. Написать метод, возвращающий минимальное из трёх чисел.
    /// </summary>
    class Task1 : IAbstractTask
    {

        public void Run()
        {
            Console.WriteLine("1. Написать метод, возвращающий минимальное из трёх чисел.");
            int[] data = { 48, 97, 5 };
            int min = FindMinimum(data);
            Console.WriteLine($"Минимальное число из {Util.ToString(data)} = {min}\n");
        }

        /// <summary>
        /// Finds mimimum value in the data array 
        /// </summary>
        /// <param name="data"> Not null and not empty </param>
        /// <returns> Mimimum in the array </returns>
        /// <exception cref="ArgumentException"> if data array is empty or null </exception>
        private int FindMinimum(int[] data)
        {
            if ((data == null) || (data.Length == 0))
                throw new ArgumentException();
            int result = data[0];
            for (int i = 1; i < data.Length; i++)
                if (data[i] < result)
                    result = data[i];
            return result;
        }

    }
}
