using System;

namespace AndreyTedeev.Part1Lesson2
{
    /// <summary>
    /// 3. С клавиатуры вводятся числа, пока не будет введен 0.
    /// Подсчитать сумму всех нечетных положительных чисел.
    /// </summary>
    class Task3 : IAbstractTask
    {

        public void Run()
        {
            Console.WriteLine("3. С клавиатуры вводятся числа, пока не будет введен 0.");
            Console.WriteLine("Подсчитать сумму всех нечетных положительных чисел.");
            int result = 0;
            int input = -1;
            do
            {
                Console.Write("Введите целое число. [ 0 - Выход ] : ");
                try
                {
                    input = int.Parse(Console.ReadLine());
                    if ((input > 0) && (input % 2 != 0))
                        result += input;
                }
                catch (Exception ex)
                {
                    Console.Write($"ОШИБКА. {ex.Message}. [ Enter - Продолжить ]");
                    Console.ReadLine();
                    continue;
                }
            }
            while (input != 0);
            Console.WriteLine($"Сумма всех нечетных положительных чисел = {result}\n");
        }

     }
}
