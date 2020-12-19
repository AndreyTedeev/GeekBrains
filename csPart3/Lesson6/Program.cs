﻿using System;
using System.Threading.Tasks;

namespace Lesson6
{
    /// <summary>
    /// 1.	Даны 2 двумерных матрицы. Размерность 100х100 каждая. Напишите приложение, 
    /// 	производящее параллельное умножение матриц.Матрицы заполняются случайными целыми числами от 0 до10.
    /// 
    /// [Part1.cs]
    /// 
    /// 2.	*В некой директории лежат файлы.По структуре они содержат 3 числа, разделенные пробелами. 
    /// 
    ///     Первое число — целое, обозначает действие, 1 — умножение и 2 — деление, остальные два — числа с плавающей точкой. 
    /// 
    ///     Написать многопоточное приложение, выполняющее вышеуказанные действия над числами и сохраняющее результат в файл result.dat.
    ///     Количество файлов в директории заведомо много.
    /// 
    /// [Part2.cs]
    /// </summary>
    class Program
    {
        static void Main()
        {
            Console.WriteLine(" --- Part1 --- ");
            Part1.Run();

            Console.WriteLine(" --- Part2 --- ");
            Task.Run(() => Part2.Run());

            Console.ReadLine();
        }
    }
}