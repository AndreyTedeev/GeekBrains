using System;

namespace Lesson1
{
    /// <summary>
    /// Андрей Тедеев andrey.tedeev@gmail.com
    /// Алгоритмы и структуры данных. Урок 1.
    /// 
    /// 12. Написать функцию нахождения максимального из трех чисел.
    /// 13. * Написать функцию, генерирующую случайное число от 1 до 100.
    ///     а) с использованием стандартной функции rand()
    ///     б) без использования стандартной функции rand()
    /// 14. * Автоморфные числа.Натуральное число называется автоморфным, 
    /// если оно равно последним цифрам своего квадрата.Например, 252 = 625. 
    /// Напишите программу, которая вводит натуральное число N и выводит 
    /// на экран все автоморфные числа, не превосходящие N.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int menu;
            do
            {
                menu = Menu();
                if (menu == 1)
                    Task12();
                else if (menu == 2)
                    Task13();
                else if (menu == 3)
                    Task14();
            }
            while (menu > 0);
        }

        private static void Task12()
        {
            Console.WriteLine("Задание 12");
            Random random = new Random();
            int[] data = new int[3];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = random.Next(0, 1000);
            }
            int max = Max(ref data);
            Console.WriteLine($"Максимум из трех чисел [{data[0]}, {data[1]}, {data[2]}] = {max}");
            Console.ReadLine();
        }

        private static int Max(ref int[] data)
        {
            if (data.Length == 0)
                throw new ArgumentException();
            int result = data[0];
            for (int i = 1; i < data.Length; i++)
            {
                if (data[i] > result)
                    result = data[i];
            }
            return result;
        }

        private static void Task13()
        {
            Console.WriteLine("Задание 13");
            Random random = new Random();
            Console.WriteLine($"Случайное число от 1 до 100");
            Console.WriteLine($"Встроенный Random  : {random.Next(1, 100)}");
            Console.WriteLine($"Собственный Random : {Random(1, 100)}");
            Console.ReadLine();
        }


        private static object Random(int min, int max)
        {
            int x, a, b, m;
            m = max;
            b = 34564564;
            a = 1289456;
            x = (int)DateTime.Now.Ticks;
            do
            {
                x = (a * x + b) % m;
                // Console.WriteLine($"{a} {b} {x}");
            }
            while ((x < min) || (x > max));
            return x;
        }

        private static void Task14()
        {
            Console.WriteLine("Задание 14");
            Console.WriteLine("Автоморфные числа на интервале от 0 до 10000");
            int n = 10_000;
            int d = 1;
            for (int i = 0; i < n; i++)
            {
                // Поскольку Math было запрещено пользоваться ))))
                // то можно
                // d = Power10(CountNumerals(i));
                // но эффективнее
                if (i < 10) d = 10;
                else if (i < 100) d = 100;
                else if (i < 1000) d = 1000;
                else if (i < 10000) d = 10000;
                if ((i * i) % d == i)
                    Console.WriteLine(i);
            }
            Console.ReadLine();
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

        private static int Power10(int power)
        {
            if (power == 0)
                return 1;
            else if (power == 1)
                return 10;
            else 
                return 10 * Power10(power - 1);
        }

        static int Menu()
        {
            int value;
            do
            {
                Console.Clear();
                Console.WriteLine("Выберите задание: ");
                Console.WriteLine("1: Задание 12");
                Console.WriteLine($"\tНаписать функцию нахождения максимального из трех чисел.");
                Console.WriteLine("2: Задание 13");
                Console.WriteLine($"\tНаписать функцию, генерирующую случайное число от 1 до 100.");
                Console.WriteLine("3: Задание 14");
                Console.WriteLine($"\tНапишите программу, которая вводит натуральное число N и выводит");
                Console.WriteLine($"\tна экран все автоморфные числа, не превосходящие N.");
                Console.WriteLine("0: Выход");
                Console.WriteLine();
                Console.Write(">> ");

            }
            while (!int.TryParse(Console.ReadLine(), out value) && (value >= 0) && (value < 4));
            return value;
        }
    }
}
