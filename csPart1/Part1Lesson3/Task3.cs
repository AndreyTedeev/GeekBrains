using System;

namespace AndreyTedeev.Part1Lesson3
{
    /// <summary>
    /// 3. *Описать класс дробей — рациональных чисел, являющихся отношением двух целых чисел. 
    /// Предусмотреть методы сложения, вычитания, умножения и деления дробей.
    /// Написать программу, демонстрирующую все разработанные элементы класса.
    ///
    /// * Добавить свойства типа int для доступа к числителю и знаменателю;
    /// * Добавить свойство типа double только на чтение, чтобы получить десятичную дробь числа;
    /// ** Добавить проверку, чтобы знаменатель не равнялся 0. Выбрасывать исключение ArgumentException("Знаменатель не может быть равен 0");
    /// *** Добавить упрощение дробей.
    /// </summary>
    class Task3 : IAbstractTask
    {

        public void Run()
        {
            Console.WriteLine("3. *Описать класс дробей — рациональных чисел, являющихся отношением двух целых чисел.");
            Console.WriteLine("Написать программу, демонстрирующую все разработанные элементы класса.\n");

            Fraction x = new Fraction(3, 15);
            Fraction y = new Fraction(4, 18);
            TestFraction(x, y, Operation.Plus);

            x = new Fraction(25, 6);
            y = new Fraction(25, 9);
            TestFraction(x, y, Operation.Minus);

            x = new Fraction(1, 3);
            y = new Fraction(1, 5);
            TestFraction(x, y, Operation.Multi);

            x = new Fraction(5, 9);
            y = new Fraction(1, 3);
            TestFraction(x, y, Operation.Divide);
        }

        void TestFraction(Fraction x, Fraction y, Operation op)
        {
            Console.WriteLine($"x = {x}, y = {y}");
            char sign;
            Fraction z;
            switch (op)
            {
                case Operation.Minus: sign = '-'; z = x.Minus(y); break;
                case Operation.Plus: sign = '+'; z = x.Plus(y); break;
                case Operation.Multi: sign = '*'; z = x.Multi(y); break;
                case Operation.Divide: sign = '/'; z = x.Divide(y); break;
                default: throw new ArgumentException("Непонятная операция");
            }
            Console.WriteLine($"x {sign} y = {z}");
            z.Reduce();
            Console.WriteLine($"Сокращенная дробь z = {z}");
            Console.WriteLine();
        }

    }
}
