using System;

namespace AndreyTedeev.Part1Lesson2
{
    /// <summary>
    /// 2. Написать метод подсчета количества цифр числа.
    /// </summary>
    class Task2 : IAbstractTask
    {

        public void Run()
        {
            Console.WriteLine("2. Написать метод подсчета количества цифр числа.");
            int randomDigit = new Random().Next(0, Int32.MaxValue);
            int count = CountNumerals(randomDigit);
            Console.WriteLine($"Количество цифр числа {randomDigit:### ### ### ###} = {count}\n");
        }

        /// <summary>
        /// Counts numerals in the given digit
        /// </summary>
        /// <param name="digit"></param>
        /// <returns>Count of numerals</returns>
        private static int CountNumerals(int digit)
        {
            if (digit == 0)
                return 0;
            else
                return CountNumerals(digit / 10) + 1;
        }

    }
}
