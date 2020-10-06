using System;

namespace Lesson1
{

    class Program
    {

        static void Main(string[] args)
        {
            Console.Clear();
            string[] messages = {
                "Здравствуйте!",
                " Я Тедеев Андрей из г.Томск",
                "Представляю решения домашнего задания к уроку 1",
                "Этот экран и есть решение заданий 5 и 6",
                "Нажмите ENTER для продолжения"
            };
            ConsoleHelper.PrintCentered(messages);
            Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Задания 1 и 2");
            Person person = Questionnaire.Run();
            person.Print();
            ConsoleHelper.Pause();

            Console.WriteLine("\nЗадание 3");
            Point a = new Point(1, 1);
            Point b = new Point(100, 100);
            Line line = new Line(a, b);
            line.Print();
            ConsoleHelper.Pause();

            Console.WriteLine("\nЗадание 4");
            swap();
            ConsoleHelper.Pause();

            Console.WriteLine("\nСпасибо за внимание!\n");
            ConsoleHelper.Pause();
        }

        static void swap()
        {
            Console.WriteLine("Меняем местами две переменные (swap)");
            int x = 1, y = 9, temp;
            Console.WriteLine($"Исходные данные: x={x}, y={y}");

            Console.WriteLine($"Первый способ: ");
            temp = x;
            x = y;
            y = temp;
            Console.WriteLine($"x={x}, y={y}");

            Console.WriteLine($"Второй способ вернет переменные в исходное положение:");
            x ^= y;
            y ^= x;
            x ^= y;
            Console.WriteLine($"x={x}, y={y}");

            Console.WriteLine($"Третий способ работает только с С# 7");
            (x, y) = (y, x);
            Console.WriteLine($"x={x}, y={y}");
        }
    }
}
