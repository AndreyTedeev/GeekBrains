using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson2
{
    /// <summary>
    /// Andrey Tedeev <andrey.tedeev@gmail.com>
    /// "Алгоритмы и структуры данных"
    /// 
    /// 1. Реализовать функцию перевода из десятичной системы в двоичную, используя рекурсию.
    /// 
    /// 2. Реализовать функцию возведения числа a в степень b:
    /// a.без рекурсии;
    /// b.рекурсивно;
    /// c. * рекурсивно, используя свойство четности степени.
    /// 
    /// 3. Исполнитель Калькулятор преобразует целое число, записанное на экране.
    /// У исполнителя две команды, каждой команде присвоен номер:
    /// Прибавь 1
    /// Умножь на 2
    /// Первая команда увеличивает число на экране на 1, вторая увеличивает это число в 2 раза.
    /// Сколько существует программ, которые число 3 преобразуют в число 20?
    /// а) с использованием массива;
    /// б) с использованием рекурсии.
    /// Реализовать меню с выбором способа заполнения массива: из файла, случайными числами, с клавиатуры.
    /// </summary>
    class Program
    {

        static Random random = new Random();

        static void Main(string[] args)
        {
            int menu;
            do
            {
                menu = Menu();
                if (menu == 1)
                    Task1();
                else if (menu == 2)
                    Task2();
                else if (menu == 3)
                    Task3();
            }
            while (menu > 0);
        }

        static char[] op = { '+', '*' };
        static List<string> variants = new List<string>();
        /// <summary>
        /// 3. Исполнитель Калькулятор преобразует целое число, записанное на экране.
        /// У исполнителя две команды, каждой команде присвоен номер:
        /// Прибавь 1
        /// Умножь на 2
        /// Первая команда увеличивает число на экране на 1, вторая увеличивает это число в 2 раза.
        /// Сколько существует программ, которые число 3 преобразуют в число 20?
        /// а) с использованием массива;
        /// б) с использованием рекурсии.
        /// </summary>
        private static void Task3()
        {
            Console.Clear();
            int start = 3;
            int end = 20;
            calc("", start, end);
            Console.WriteLine("List использован ТОЛЬКО для наглядного хранения вариантов.");
            Console.WriteLine("Можно было просто использовать counter вариантов.");
            Console.WriteLine($"Все {variants.Count} вариантов ниже:");
            foreach (string variant in variants)
                Console.WriteLine(variant);
            Console.ReadLine();
        }

        static void calc(string variant, int start, int end)
        {
            if (start == end)
                variants.Add(variant);
            for (int i = 0; i < op.Length; i++)
            {
                if ((op[i] == '+') && (start < end))
                    calc(variant + op[i], start + 1, end);
                else if ((op[i] == '*') && start <= (int)(end / 2))
                    calc(variant + op[i], start * 2, end);
            }
        }

        /// <summary>
        /// 2. Реализовать функцию возведения числа a в степень b:
        ///     a.без рекурсии;
        ///     b.рекурсивно;
        ///     c. * рекурсивно, используя свойство четности степени.
        /// </summary>
        private static void Task2()
        {
            Console.Clear();
            long a = random.Next(1, 30);
            long b = random.Next(1, 30);
            Console.WriteLine($"Без рекурсии : {a} ^ {b} = {Power(a, b):# ### ### ### ### ### ##0}");
            Console.WriteLine($"С рекурсией  : {a} ^ {b} = {PowerRecursive(a, b):# ### ### ### ### ### ##0}");
            Console.WriteLine($"С рекурсией 2: {a} ^ {b} = {PowerRecursive2(a, b):# ### ### ### ### ### ##0}");
            Console.ReadLine();
        }

        private static long Power(long a, long b)
        {
            if (b <= 0)
                throw new ArgumentException();
            long result = a;
            for (long i = 1; i < b; i++)
            {
                result *= a;
            }
            return result;
        }

        private static long PowerRecursive(long a, long b)
        {
            if (b <= 0)
                throw new ArgumentException();
            else if (b == 1)
                return a;
            else
                return a * PowerRecursive(a, b - 1);
        }

        private static long PowerRecursive2(long a, long b)
        {
            if (b <= 0)
                throw new ArgumentException();
            else if (b == 1)
                return a;
            else if (b % 2 == 0)
                return a * a * PowerRecursive(a, b - 2);
            else
                return a * PowerRecursive(a, b - 1);
        }

        /// <summary>
        /// 1. Реализовать функцию перевода из десятичной системы в двоичную, используя рекурсию.
        /// </summary>
        private static void Task1()
        {
            Console.Clear();
            int x10 = random.Next(1, 100);
            string x2 = Convert10To2(x10);
            Console.WriteLine($"Число '{x10}' в десятичной системе = '{x2}' в двоичной.");
            Console.ReadLine();
        }

        private static string Convert10To2(int src)
        {
            if (src > 0)
            {
                return Convert10To2((int)(src / 2)) + (src % 2).ToString();
            }
            return "";
        }

        static int Menu()
        {
            int value;
            do
            {
                Console.Clear();
                Console.WriteLine("Выберите задание: ");
                Console.WriteLine("1: Реализовать функцию перевода из десятичной системы в двоичную, используя рекурсию.");
                Console.WriteLine();
                Console.WriteLine("2: Реализовать функцию возведения числа a в степень b:");
                Console.WriteLine();
                Console.WriteLine("3: Задание 3");
                Console.WriteLine($"\tСколько существует программ, которые число 3 преобразуют в число 20?");
                Console.WriteLine($"\tС помощью двух команд +1 и *2");
                Console.WriteLine();
                Console.WriteLine("0: Выход");
                Console.WriteLine();
                Console.Write(">> ");

            }
            while (!int.TryParse(Console.ReadLine(), out value) && (value >= 0) && (value < 4));
            return value;
        }
    }
}
