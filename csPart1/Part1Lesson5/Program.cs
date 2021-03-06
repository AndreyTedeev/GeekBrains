﻿using AndreyTedeev;
using System;

namespace AndreyTedeev.Part1Lesson5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Andrey Tedeev <andrey.tedeev@outlook.com>");
            Console.WriteLine("Домашнее задание 'Основы языка C#, Урок 5'\n");

            IAbstractTask[] tasks = {
                new Task1(),
                new Task2(),
                new Task3(),
                new Task4(),
                new Task5()
            };

            foreach (IAbstractTask task in tasks)
                task.Run();
        }

    }
}
