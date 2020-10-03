using System;

namespace AndreyTedeev.Part1Lesson3
{
    /// <summary>
    /// 2. а)  С клавиатуры вводятся числа, пока не будет введён 0 (каждое число в новой строке). 
    /// Требуется подсчитать сумму всех нечётных положительных чисел.
    /// Сами числа и сумму вывести на экран, используя tryParse.
    /// </summary>
    class Task2 : IAbstractTask
    {

        public void Run()
        {
            Console.WriteLine("3. С клавиатуры вводятся числа, пока не будет введен 0.");
            Console.WriteLine("Подсчитать сумму всех нечетных положительных чисел.");
            int result = 0;
            int input;
            do
            {
                // AndreyTedeev.Util.AskIntForever в библиотеке Library
                input = AndreyTedeev.Util.AskIntForever("Введите целое число. [ 0 - Выход ] : ");
                if ((input > 0) && (input % 2 != 0))
                    result += input;
            }
            while (input != 0);
            Console.WriteLine($"Сумма всех нечетных положительных чисел = {result}\n");
        }

    }
}
