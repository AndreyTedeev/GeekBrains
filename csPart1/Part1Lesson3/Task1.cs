using System;

namespace AndreyTedeev.Part1Lesson3
{

    /// <summary>
    /// 1. а) Дописать структуру Complex, добавив метод вычитания комплексных чисел. 
    ///    Продемонстрировать работу структуры.
    ///    б) Дописать класс Complex, добавив методы вычитания и произведения чисел. Проверить работу класса.
    ///    в) Добавить диалог с использованием switch демонстрирующий работу класса.
    /// </summary>
    class Task1 : IAbstractTask
    {

        public void Run()
        {
            Console.WriteLine("1(а). Демо работы структуры ComplexStruct.");
            StructDemo();
            Console.WriteLine("1(б и в). Демо работы класса ComplexClass.");
            ClassDemo();
        }

        private void ClassDemo()
        {
            ComplexClass x = new ComplexClass(6, 9);
            ComplexClass y = new ComplexClass(4, 6);
            Console.WriteLine($"Дано : x = {x}, y = {y}");
            Console.WriteLine("Выберите операцию");
            Console.WriteLine($"{(int)Operation.Plus}. x + y");
            Console.WriteLine($"{(int)Operation.Minus}. x - y");
            Console.WriteLine($"{(int)Operation.Multi}. x * y");
            Operation op = (Operation)Util.AskIntForever(">>>");
            ComplexClass result = null;
            switch (op) {
                case Operation.Plus: result = x.Plus(y); break;
                case Operation.Minus: result = x.Minus(y); break;
                case Operation.Multi: result = x.Multi(y); break;
                default: break;
            }
            if (result == null)
                Console.WriteLine("Операция не поддерживается.");
            else
                Console.WriteLine($"Результат : x {Util.AsChar(op)} y = {result}");
            Console.WriteLine();
        }

        private void StructDemo()
        {
            ComplexStruct a = new ComplexStruct
            {
                im = 3,
                re = 5
            };
            ComplexStruct b = new ComplexStruct
            {
                im = 1,
                re = 7
            };
            ComplexStruct c = a.Plus(b).Minus(a);
            Console.WriteLine($"Просто напечатаем результат : {c.Multi(a)}");
            Console.WriteLine();
        }
    }
}
