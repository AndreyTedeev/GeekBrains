using System;
using System.IO;
using System.Text;

namespace AndreyTedeev.Part1Lesson4
{
    /// <summary>
    /// Рaбота с 2D массивом
    /// </summary>
    class MyGrid
    {
        private int[,] storage;

        private int nextRow;

        private int nextCol;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="rows">количество строк</param>
        /// <param name="cols">количество столбцов</param>
        /// <param name="fill">true = заполнить рандомно</param>
        public MyGrid(int rows, int cols, bool fill)
        {
            nextRow = 0;
            nextCol = 0;
            storage = new int[rows, cols];
            if (fill)
            {
                Random rnd = new Random();
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        storage[i, j] = rnd.Next(1, 9);
                        nextCol++;
                    }
                    nextCol = 0;
                    nextRow++;
                }
            }
        }

        /// <summary>
        /// Конструктор загружающий данные из файла
        /// </summary>
        /// <param name="fileName">имя файла</param>
        public MyGrid(string fileName)
        {
            bool isInitialized = false;
            string[] data;
            using (StreamReader sr = new StreamReader(fileName))
            {
                while (!sr.EndOfStream)
                {
                    if (!isInitialized) // first row expected with size
                    {
                        data = sr.ReadLine().Split(',');
                        nextRow = 0;
                        nextCol = 0;
                        storage = new int[
                            int.Parse(data[0]), int.Parse(data[1])];
                        isInitialized = true;
                    }
                    else // read rows
                    {
                        data = sr.ReadLine().Split(',');
                        foreach (string s in data)
                        {
                            storage[nextRow,nextCol] = int.Parse(s);
                            nextCol++;
                        }
                        nextCol = 0;
                        nextRow++;
                    }
                }
            }
        }

        /// <summary>
        /// Записывает данные в файл (всегда перезаписывает файл)
        /// </summary>
        /// <param name="fileName"></param>
        public void Save(string fileName)
        {
            StringBuilder s = new StringBuilder();
            s.Append(storage.GetLength(0)).Append(',').Append(storage.GetLength(1)).Append('\n');
            for (int i = 0; i < storage.GetLength(0); i++)
            {
                for (int j = 0; j < storage.GetLength(1) - 1; j++)
                {
                    s.Append(storage[i, j]).Append(',');
                }
                s.Append(storage[i, storage.GetLength(1) - 1]).Append('\n');
            }
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
            for (int i = 0; i < storage.GetLength(0); i++)
            {
                for (int j = 0; j < storage.GetLength(1); j++)
                {
                    Console.Write($"{storage[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Возвращают сумму элементов массива
        /// Проверки на переполнение int не реализовано
        /// </summary>
        /// <returns>Сумма элементов массива</returns>
        public int Sum()
        {
            int result = 0;
            for (int i = 0; i < storage.GetLength(0); i++)
            {
                for (int j = 0; j < storage.GetLength(1); j++)
                {
                    result += storage[i, j];
                }
            }
            return result;
        }

        /// <summary>
        /// Возвращают сумму элементов массива больше заданного
        /// Проверки на переполнение int не реализовано
        /// </summary>
        /// <param name="x"></param>
        /// <returns>Сумма элементов массива</returns>
        public int Sum(int x)
        {
            int result = 0;
            int value;
            for (int i = 0; i < storage.GetLength(0); i++)
            {
                for (int j = 0; j < storage.GetLength(1); j++)
                {
                    value = storage[i, j];
                    result += (value > x) ? value : 0;
                }
            }
            return result;
        }

        /// <summary>
        /// Возвращает минимальный элемент
        /// </summary>
        /// <returns>минимальный элемент</returns>
        public int Min
        {
            get
            {
                int result = int.MaxValue;
                int value;
                for (int i = 0; i < storage.GetLength(0); i++)
                {
                    for (int j = 0; j < storage.GetLength(1); j++)
                    {
                        value = storage[i, j];
                        if (value < result)
                            result = value;
                    }
                }
                return result;
            }
        }

        /// <summary>
        /// Возвращает максимальный элемент
        /// </summary>
        /// <returns>максимальный элемент</returns>
        public int Max
        {
            get
            {
                int result = int.MinValue;
                int value;
                for (int i = 0; i < storage.GetLength(0); i++)
                {
                    for (int j = 0; j < storage.GetLength(1); j++)
                    {
                        value = storage[i, j];
                        if (value > result)
                            result = value;
                    }
                }
                return result;
            }
        }

        /// <summary>
        /// Возвращает индекс максимального элемента
        /// </summary>
        /// <param name="row">строка</param>
        /// <param name="col">столбец</param>
        /// <returns>максимальный элемент</returns>
        public int MaxIndex(out int row, out int col)
        {
            int result = int.MinValue;
            row = 0; col = 0;
            int value;
            for (int i = 0; i < storage.GetLength(0); i++)
            {
                for (int j = 0; j < storage.GetLength(1); j++)
                {
                    value = storage[i, j];
                    if (value > result)
                    {
                        result = value;
                        row = i;
                        col = j;
                    }
                }
            }
            return result;
        }

    }
}
