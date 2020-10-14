using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AndreyTedeev.Part1Lesson6
{
    /// <summary>
    /// 2. Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата.
    /// а) Сделайте меню с различными функциями и предоставьте пользователю выбор, 
    /// для какой функции и на каком отрезке находить минимум.
    /// б) Используйте массив(или список) делегатов, в котором хранятся различные функции.
    /// в) * Переделайте функцию Load, чтобы она возвращала массив считанных значений. Пусть она
    /// возвращает минимум через параметр.
    /// </summary>
    class Task2 : IAbstractTask
    {
        public void Run()
        {
            Console.WriteLine(" ====== Task 2.\n");

            Delegate1[] FunDelegates = { F1, F2, F3 };
            int choice, a, b;
            choice = ShowFunctionMenu();
            a = Util.AskIntForever("Введите начало интервала: ");
            b = Util.AskIntForever("Введите конец интервала: ");
            double[] data = FunData(FunDelegates[choice - 1], a, b);

            string fileName = "data.bin";
            Console.WriteLine($"Сохраняем рассчитанные данные в файл {fileName}");
            Save(fileName, data);
            Console.WriteLine($"Загружаем данные из файла {fileName}");
            data = Load(fileName);
            for (int i = 0; i < data.Length; i++)
            {
                Console.Write($"{data[i]} ");
            }
            Console.WriteLine();

            choice = ShowMethodMenu();
            double result = 0;
            switch (choice) 
            {
                case 1: result = Min(Compare, data); break;
                case 2: result = Max(Compare, data); break;
                default: break;
            }
            Console.WriteLine($"Результат : {result}");
            Console.WriteLine("Нажмите Enter для продолжения ");
            Console.ReadLine();
        }

        private int ShowFunctionMenu()
        {
            Console.WriteLine("Выберите функцию для рассчета:");
            Console.WriteLine("[1] y = x * x - 50 * x + 10");
            Console.WriteLine("[2] y = x ^ 2");
            Console.WriteLine("[3] y = x * sin(x)");
            int result;
            while (!int.TryParse(Console.ReadLine(), out result) || result < 1 || result > 3) {
                Console.WriteLine("ОШИБКА! Введите число от 1 до 3.");
            }
            return result;
        }

        private int ShowMethodMenu()
        {
            Console.WriteLine("Выберите метод обработки данных:");
            Console.WriteLine("[1] Найти минимум");
            Console.WriteLine("[2] Найти максимум");
            int result;
            while (!int.TryParse(Console.ReadLine(), out result) || result < 1 || result > 2)
            {
                Console.WriteLine("ОШИБКА! Введите число от 1 до 2.");
            }
            return result;
        }

        public delegate double Delegate1(double x);

        public static double F1(double x) { return x * x - 50 * x + 10; }
        public static double F2(double x) { return x * x; }
        public static double F3(double x) { return x * Math.Sin(x); }

        /// <summary>
        /// Метод рассчитывает значения функции делегата f на интервале от x до b
        /// </summary>
        /// <param name="f">Функция Делегат</param>
        /// <param name="x">Начало интервала</param>
        /// <param name="b">Конец интервала</param>
        /// <returns>Массив значений функции</returns>
        public double[] FunData(Delegate1 f, double x, double b)
        {
            List<double> result = new List<double>();
            while (x <= b)
            {
                result.Add(f(x));
                x++;
            }
            return result.ToArray();
        }

        public delegate double Delegate2(double a, double b);

        /// <summary>
        /// Сравнивает два значения
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns>Возвращает число 
        ///     < 0 если value1 < value2</returns>
        ///     > 0 если value1 > value2</returns>
        ///     0 если значения равны
        public double Compare(double value1, double value2)
        {
            return (value1 - value2);
        }

        /// <summary>
        /// Находит минимум через делегата
        /// </summary>
        /// <param name="f">Метод делегат</param>
        /// <param name="data">Данные</param>
        /// <returns>Минимум</returns>
        public double Min(Delegate2 f, double[] data)
        {
            double min = double.MaxValue;
            for (int i = 0; i < data.Length; i++)
            {
                if (f(data[i], min) < 0)
                    min = data[i];
            }
            return min;
        }

        /// <summary>
        /// Находит максимум через делегата
        /// </summary>
        /// <param name="f">Метод делегат</param>
        /// <param name="data">Данные</param>
        /// <returns>Минимум</returns>
        public double Max(Delegate2 f, double[] data)
        {
            double max = double.MinValue;
            for (int i = 0; i < data.Length; i++)
            {
                if (f(data[i], max) > 0)
                    max = data[i];
            }
            return max;
        }

        /// <summary>
        /// Сохраняет массив данных в файл
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="data"></param>
        public static void Save(string fileName, double[] data)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    for (int i = 0; i < data.Length; i++)
                    {
                        bw.Write(data[i]);
                    }
                }
            };
        }

        /// <summary>
        /// Загружает данные из файла в массив
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static double[] Load(string fileName)
        {
            double[] data;
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader bw = new BinaryReader(fs))
                {
                    data = new double[fs.Length / sizeof(double)];
                    for (int i = 0; i < data.Length; i++)
                    {
                        data[i] = bw.ReadDouble();
                    }
                }
            }
            return data;
        }

    }
}
