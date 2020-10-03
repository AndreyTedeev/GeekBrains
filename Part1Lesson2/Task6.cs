using System;

namespace AndreyTedeev.Part1Lesson2
{
    /// <summary>
    /// 6. * Написать программу подсчета количества «хороших» чисел в диапазоне от 1 до 1 000 000 000.
    /// «Хорошим» называется число, которое делится на сумму своих цифр.
    /// Реализовать подсчёт времени выполнения программы, используя структуру DateTime.
    /// </summary>
    class Task6 : IAbstractTask
    {
        public void Run()
        {
            int count;
            Console.WriteLine("6. Подсчет количества «хороших» чисел двумя способами с оценкой времени.");

            Console.WriteLine("Расчет в цикле.");
            DateTime t1 = DateTime.Now;
            count = CountGoodNumbers(1, 1_000_000_000, false);
            DateTime t2 = DateTime.Now;
            TimeSpan time1 = t2 - t1;
            Console.WriteLine($"Количество чисел = {count:# ### ### ###}. Затрачено {time1}\n");

            Console.WriteLine("Расчет рекурсивно.");
            t1 = DateTime.Now;
            count = CountGoodNumbers(1, 1_000_000_000, true);
            t2 = DateTime.Now;
            TimeSpan time2 = t2 - t1;
            Console.WriteLine($"Количество чисел = {count:# ### ### ###}. Затрачено {time2}\n");

            if (time1 == time2)
                Console.WriteLine("Методы показали одинаковый результат.\n");
            else
                Console.WriteLine("Рекурсивный метод " + ((time1 > time2) ? "быстрее" : "медленнее") + ".\n");
        }

        /// <summary>
        /// Подсчитывает количество чисел в диапазоне,
        /// которые делятся на сумму своих цифр
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="recursive"></param>
        /// <returns></returns>
        private static int CountGoodNumbers(int min, int max, bool recursive)
        {
            int result = 0;
            for (int i = min; i <= max; i++)
            {
                result += IsGoodNumber(i, recursive) ? 1 : 0;
            }
            return result;
        }

        /// <summary>
        /// Проверяет если число делится на сумму своих цифр
        /// </summary>
        /// <param name="digit"></param>
        /// <param name="recursive"></param>
        /// <returns></returns>
        private static bool IsGoodNumber(int digit, bool recursive)
        {
            int div = SumNumerals(digit, recursive);
            return (digit % div == 0);
        }

        /// <summary>
        /// Sum of numerals of digit
        /// </summary>
        /// <param name="digit"></param>
        /// <param name="recursive"></param>
        /// <returns></returns>
        private static int SumNumerals(int digit, bool recursive)
        {
            if (recursive)
            {
                if (digit == 0)
                    return 0;
                else
                    return SumNumerals(digit / 10, recursive) + digit % 10;
            }
            else
            {
                int result = 0;
                while (digit > 0)
                {
                    result += digit % 10;
                    digit /= 10;
                }
                return result;
            }
        }

    }
}
