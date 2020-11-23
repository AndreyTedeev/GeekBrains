using System;
using System.Diagnostics;

namespace Lesson4
{
    /// <summary>
    /// Andrey Tedeev <andrey.tedeev@outlook.com>
    /// "Алгоритмы и структуры данных"
    /// Урок 4
    /// 
    /// 3. *** Требуется обойти конем шахматную доску размером NxM,
    ///      пройдя через все поля доски по одному разу.
    ///      Здесь алгоритм решения такой же, как в задаче о 8 ферзях.
    ///      Разница только в проверке положения коня.
    /// </summary>
    class Program
    {

        static void Main(string[] args)
        {
            KnightSelector k1 = new KnightSelector(8);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            k1.MoveKnight();
            sw.Stop();
            long tm1 = sw.ElapsedMilliseconds;

            KnightWarnsdorff k2 = new KnightWarnsdorff(30);
            sw.Reset();
            sw.Start();
            k2.MoveKnight();
            sw.Stop();
            long tm2 = sw.ElapsedMilliseconds;

            Console.WriteLine($"Метод перебора с возвратом [8,8] занял: {tm1}");
            Console.WriteLine($"Метод Варнсдорфа [20,20] занял: {tm2}");

            Console.WriteLine("Press 1 to see moves on board.");
            ConsoleKeyInfo k = Console.ReadKey();
            if (k.KeyChar == '1')
            {
                k1.PrintBoard();
                k2.PrintBoard();
            }
        }
    }

}
