using System;
using System.Collections.Generic;
using System.Text;

namespace AndreyTedeev.Part1Lesson5
{
    class Task2 : IAbstractTask
    {
        /// <summary>
        /// 2. Разработать класс Message, содержащий следующие статические методы для обработки текста:
        /// а) Вывести только те слова сообщения, которые содержат не более n букв.
        /// б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
        /// в) Найти самое длинное слово сообщения.
        /// г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
        /// Продемонстрируйте работу программы на текстовом файле с вашей программой.
        /// </summary>
        public void Run()
        {
            Console.WriteLine(" ====== Task 2.\n");

            string message = "Привет, всем! Это небольшое сообщение для проверки работы методов класса Message. УРА!!!";
            Console.WriteLine($"Потестируем сообщение :\n{message}\n");

            Console.WriteLine("Слова менее 5 букв : ");
            foreach (string word in Message.WordsOfLength(message, 5))
                Console.Write($"{word} ");
            Console.WriteLine();

            Console.WriteLine($"\nДлина самого длинного слова : {Message.LongestWordLength(message)}\n");

            Console.WriteLine("Строка из всех самых длинных слов :");
            Console.WriteLine($"{Message.LongestWords(message)}\n");

            string s = Message.RemoveEndingWith(message, '!');
            Console.WriteLine($"Результат удаления слов заканчивающихся на '!':\n{s}\n");

            
        }
    }
}
