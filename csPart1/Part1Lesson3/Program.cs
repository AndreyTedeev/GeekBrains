using System;

namespace AndreyTedeev.Part1Lesson3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Andrey Tedeev <andrey.tedeev@outlook.com>");
            Console.WriteLine("Домашнее задание 'Основы языка C#, Урок 3'\n");

            IAbstractTask[] tasks = {
                new Task1(),
                new Task2(),
                new Task3()
            };

            foreach (IAbstractTask task in tasks)
                task.Run();
        }
    }
}
