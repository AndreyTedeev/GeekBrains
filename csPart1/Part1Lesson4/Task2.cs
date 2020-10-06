using System;
using System.Collections.Generic;
using System.Text;

namespace AndreyTedeev.Part1Lesson4
{
    /// <summary>
    /// 2. а) Дописать класс для работы с одномерным массивом. 
    /// Реализовать конструктор, создающий массив заданной размерности
    /// и заполняющий массив числами от начального значения с заданным шагом. Создать свойство Sum,
    /// которые возвращают сумму элементов массива, метод Inverse, меняющий знаки у всех элементов массива,
    /// метод Multi, умножающий каждый элемент массива на определенное число, свойство MaxCount,
    /// возвращающее количество максимальных элементов. В Main продемонстрировать работу класса.
    /// б)Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
    /// </summary>
    class Task2 : IAbstractTask
    {
        public void Run()
        {
            Console.WriteLine(" ====== Task 2.\n");

            MyCollection collection = new MyCollection(10, 1, 1);
            collection.Print();
            Console.WriteLine($"Сумма элементов = {collection.Sum()}");
            string fileName = "MyCollection.txt";
            Console.WriteLine($"Записываем в файл '{fileName}'");
            collection.Save(fileName);
            Console.WriteLine("Инвертируем элементы");
            collection.Inverse();
            collection.Print();
            Console.WriteLine();

            Console.WriteLine($"Читаем из файла '{fileName}'");
            collection = new MyCollection(fileName);
            collection.Print();
            Console.WriteLine("Умножаем каждый элемент на два");
            collection.Multi(2);
            collection.Print();
            Console.WriteLine($"Сумма элементов = {collection.Sum()}");
            Console.WriteLine();
        }
    }
}
