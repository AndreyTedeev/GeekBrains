using System;
using System.Collections.Generic;
using System.Text;

namespace AndreyTedeev.Part1Lesson5
{
    /// <summary>
    /// 3. *Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой. 
    ///    Регистр можно не учитывать:
    ///    а) с использованием методов C#;
    ///    б) * разработав собственный алгоритм.
    ///    Например: badc являются перестановкой abcd.
    /// </summary>
    class Task3 : IAbstractTask
    {
        public void Run()
        {
            Console.WriteLine(" ====== Task 3.\n");

            TestPermutation("bla12bla", "21aabbll");
            TestPermutation("дорога", "города");
            TestPermutation("привет", "припев");
        }

        /// <summary>
        /// Проверка на перестановку с печатью в консоль
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public void TestPermutation(string a, string b)
        {
            bool check = IsPermutation(a, b);
            Console.Write($"Проверяем на перестановку строки '{a}' и '{b}' : {check}\n");
        }

        /// <summary>
        /// Является ли одна строка перестановкой другой
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private bool IsPermutation(string a, string b)
        {
            if (a.Length != b.Length)
                return false;
            Dictionary<char, int> mapA = MapChars(a);
            Dictionary<char, int> mapB = MapChars(b);
            foreach (char key in mapA.Keys)
            {
                if (mapA[key] == mapB[key])
                    mapB.Remove(key);
                else
                    return false;
            }
            if (mapB.Count > 0)
                return false;
            return true;
        }

        /// <summary>
        /// Создает карту количества вхождений каждого символа в строку
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private Dictionary<char, int> MapChars(string s)
        {
            Dictionary<char, int> result = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (result.ContainsKey(c))
                    result[c]++;
                else
                    result.Add(c, 1);
            }
            return result;
        }
    }
}
