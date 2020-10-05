using System;
using System.Collections.Generic;
using System.Text;

namespace AndreyTedeev.Part1Lesson4
{
    /// <summary>
    /// 4. *а) Реализовать класс для работы с двумерным массивом. Реализовать конструктор, заполняющий массив 
    /// случайными числами.Создать методы, которые возвращают сумму всех элементов массива,
    /// сумму всех элементов массива больше заданного, свойство, возвращающее минимальный элемент массива,
    /// свойство, возвращающее максимальный элемент массива, метод, возвращающий номер максимального элемента
    /// массива(через параметры, используя модификатор ref или out)
    /// * б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
    /// Дополнительные задачи
    /// в) Обработать возможные исключительные ситуации при работе с файлами.
    /// </summary>
    class Task4 : IAbstractTask
    {

        public void Run()
        {
            Console.WriteLine(" ====== Task 4.\n");

            MyGrid grid = new MyGrid(5, 5, true);
            grid.Print();
            Console.WriteLine($"Сумма всех элементов = {grid.Sum()}");
            Console.WriteLine($"Сумма элементов > 7 = {grid.Sum(7)}");
            Console.WriteLine($"Минимальный элемент = {grid.Min}");
            Console.WriteLine($"Максимальный элемент = {grid.Max}");
            int row, col, max;
            max = grid.MaxIndex(out row, out col);
            Console.WriteLine($"Максимальный элемент = {max} и его индекс [{row}, {col}]");
            string fileName = "MyGrid.txt";
            try
            {
                Console.WriteLine($"Записываем в файл '{fileName}'");
                grid.Save(fileName);
                Console.WriteLine($"Читаем из файла '{fileName}'");
                grid = new MyGrid(fileName);
                grid.Print();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка! {ex.Message}");
            }
        }

    }
}
