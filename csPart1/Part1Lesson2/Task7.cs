using System;

namespace AndreyTedeev.Part1Lesson2
{
    /// <summary>
    /// 7. a) Разработать рекурсивный метод, который выводит на экран числа от a до b(a < b).
    ///	   б) *Разработать рекурсивный метод, который считает сумму чисел от a до b.
    /// </summary>
    class Task7 : IAbstractTask
    {

        public void Run()
        {
            Console.WriteLine("7. a) Разработать рекурсивный метод, который выводит на экран числа от a до b(a < b).");
            Console.Write("Числа от 1 до 20 : ");  
            SequencePrint(1, 20);
            Console.WriteLine();

            Console.WriteLine("7. б) *Разработать рекурсивный метод, который считает сумму чисел от a до b.");
            
            Console.WriteLine("Расчет в цикле.");
            int result = SequenceSum(500, 1000, false);
            Console.WriteLine($"Сумма чисел от 500 до 1 000 равна {result}.\n");

            Console.WriteLine("Расчет рекурсивно.");
            result = SequenceSum(500, 1000, true);
            Console.WriteLine($"Сумма чисел от 500 до 1 000 равна {result}.\n");
        }

        /// <summary>
        /// считает сумму чисел от a до b. 
        /// поддерживает два варианта в цикле и рекурсивно.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="recursive"></param>
        /// <returns></returns>
        private int SequenceSum(int a, int b, bool recursive)
        {
            if (recursive)
            {
                // from b to a
                if (b <= a)
                    return b;
                return b + SequenceSum(a, b - 1, true);
                
                // from a to b
                //if (a == b - 1)
                //    return a + b;
                //return a + SequenceSum(a + 1, b, true);
            }
            else
            {
                int result = 0;
                for (int i = a; i <= b; i++)
                {
                    result += i;
                }
                return result;
            }
        }

        /// <summary>
        /// выводит на экран числа от a до b(a < b)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        private void SequencePrint(int a, int b)
        {
            if (a < b)
            {
                Console.Write($"{a}");
                Console.Write((a < b - 1) ? "," : "\n");
                SequencePrint(a + 1, b);
            }

        }

    }
}
