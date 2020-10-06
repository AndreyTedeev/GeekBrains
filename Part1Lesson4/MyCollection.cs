using System;
using System.IO;
using System.Text;

namespace AndreyTedeev.Part1Lesson4
{
    /// <summary>
    /// Рaбота с массивом по новому
    /// </summary>
    class MyCollection
    {
        private int[] storage;

        private int nextIndex;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="size">количество элементов</param>
        public MyCollection(int size)
        {
            nextIndex = 0;
            storage = new int[size];
        }

        /// <summary>
        /// Конструктор, создающий массив заданной размерности
        /// и заполняющий массив числами от начального значения с заданным шагом.
        /// Проверки на переполнение int не реализовано
        /// </summary>
        /// <param name="size">количество элементов</param>
        /// <param name="initValue">начальное значение</param>
        /// <param name="stepValue">шаг изменения</param>
        public MyCollection(int size, int initValue, int stepValue) : this(size)
        {
            storage[0] = initValue;
            nextIndex++;
            for (int i = 1; i < size; i++)
            {
                storage[i] = storage[i - 1] + stepValue;
                nextIndex++;
            }
        }

        /// <summary>
        /// Конструктор загружающий данные из файла
        /// </summary>
        /// <param name="fileName">имя файла</param>
        public MyCollection(string fileName)
        {
            int errors = 0;
            using (StreamReader sr = new StreamReader(fileName))
            {
                string[] data = sr.ReadToEnd().Split(',');
                nextIndex = 0;
                storage = new int[data.Length];
                int element;
                foreach (string s in data)
                {
                    if (int.TryParse(s, out element))
                    {
                        Add(element);
                    }
                    else
                    {
                        errors++;
                        Console.WriteLine($"Couldn't convert element to int : '{s}'");
                    }
                }
            }
            Console.WriteLine($"Loaded : {nextIndex}, Errors : {errors}");
        }

        /// <summary>
        /// Записывает данные в файл (всегда перезаписывает файл)
        /// </summary>
        /// <param name="fileName"></param>
        public void Save(string fileName)
        {
            StringBuilder s = new StringBuilder();
            for (int i = 0; i < nextIndex-1; i++)
            {
                s.Append(storage[i]).Append(',');
            }
            s.Append(storage[nextIndex - 1]);
            using (StreamWriter sw = new StreamWriter(fileName, false))
            {
                sw.Write(s);
            }
        }

        /// <summary>
        /// печатает элементы в консоли
        /// </summary>
        public void Print()
        {
            for (int i = 0; i < nextIndex; i++)
            {
                Console.Write($"{storage[i]} ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Возвращает количество максимальных элементов
        /// </summary>
        public int MaxCount
        {
            get
            {
                return int.MaxValue;
            }
        }

        /// <summary>
        /// Возвращают сумму элементов массива
        /// Проверки на переполнение int не реализовано
        /// </summary>
        /// <returns>Сумма элементов массива</returns>
        public int Sum()
        {
            int result = 0;
            for (int i = 0; i < nextIndex; i++)
            {
                result += storage[i];
            }
            return result;
        }

        /// <summary>
        /// Меняет знаки у всех элементов массива
        /// </summary>
        public void Inverse()
        {
            for (int i = 0; i < nextIndex; i++)
            {
                storage[i] = -storage[i];
            }
        }

        /// <summary>
        /// Умножает каждый элемент массива на определенное число
        /// Проверки на переполнение int не реализовано
        /// </summary>
        public void Multi(int value)
        {
            for (int i = 0; i < nextIndex; i++)
            {
                storage[i] *= value;
            }
        }

        /// <summary>
        /// Добавление ...
        /// </summary>
        /// <param name="item">Элемент</param>
        public void Add(int item)
        {
            if (nextIndex >= storage.Length) Array.Resize(ref storage, storage.Length * 2);
            storage[nextIndex] = item;
            nextIndex++;
        }

        /// <summary>
        /// Индексатор
        /// </summary>
        /// <param name="indexElement">индекс эдемента</param>
        /// <returns></returns>
        public int this[int indexElement]
        {
            get
            {
                return storage[indexElement];
            }

            set
            {
                storage[indexElement] = value;
            }
        }

        public int GetElement(int index)
        {
            return storage[index];
        }

    }
}
