using System;
using System.Collections.Generic;
using System.Text;

namespace AndreyTedeev.Part1Lesson5
{
    /// <summary>
    /// 2. Разработать класс Message, содержащий следующие статические методы для обработки текста:
    /// а) Вывести только те слова сообщения, которые содержат не более n букв.
    /// б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
    /// в) Найти самое длинное слово сообщения.
    /// г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
    /// </summary>
    class Message
    {
        /// <summary>
        /// Возвращает только те слова сообщения, которые содержат не более max_len букв.
        /// </summary>
        /// <param name="message">Сообщение</param>
        /// <param name="max_len">максимальная длина слова</param>
        /// <returns></returns>
        public static string[] WordsOfLength(string message, int max_len)
        {
            List<string> result = new List<string>();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < message.Length; i++)
            {
                if (message[i] == ' ')
                {
                    if (sb.Length > 0 && sb.Length < max_len)
                        result.Add(sb.ToString());
                    sb.Clear();
                }
                else 
                {
                    sb.Append(message[i]);
                }
            }
            return result.ToArray();
        }

        /// <summary>
        /// Удаляет из сообщения все слова, которые заканчиваются на заданный символ.
        /// </summary>
        /// <param name="message">Сообщение</param>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public static string RemoveEndingWith(string message, char symbol)
        {
            StringBuilder result = new StringBuilder();
            StringBuilder word = new StringBuilder();
            for (int i = 0; i < message.Length; i++)
            {
                if (message[i] == ' ')
                {
                    if (word.Length > 0)
                    {
                        if (word[word.Length-1] != symbol)
                            result.Append(word);
                        word.Clear();
                    }
                    result.Append(message[i]);
                }
                else word.Append(message[i]);
            }
            return result.ToString();
        }

        /// <summary>
        /// Возвращает длину самого длинного слова сообщения
        /// </summary>
        /// <param name="message">Сообщение</param>
        /// <returns>Длина самого длинного слова сообщения</returns>
        public static int LongestWordLength(string message) 
        {
            int result = 0;
            string[] words = Parse(message);
            foreach (string s in words)
            {
                if (s.Length > result)
                    return result = s.Length;
            }
            return result;
        }

        /// <summary>
        /// Возвращает самые длинные слова сообщения
        /// </summary>
        /// <param name="message">Сообщение</param>
        /// <returns>Строка слов</returns>
        public static string LongestWords(string message)
        {
            StringBuilder result = new StringBuilder();
            string[] words = Parse(message);
            int longestLength = 0;
            foreach (string s in words)
            {
                if (s.Length > longestLength)
                    longestLength = s.Length;
            }
            foreach (string s in words)
            {
                if (s.Length == longestLength)
                    result.Append(s).Append(' ');
            }
            return result.ToString();
        }

        /// <summary>
        /// Разбивает сообщение на слова
        /// </summary>
        /// <param name="message">Сообщение</param>
        /// <param name="delimiter">Разделитель по умолчанию пробел</param>
        /// <returns>массив слов сообщения</returns>
        public static string[] Parse(string message, char delimiter = ' ')
        {
            List<string> result = new List<string>();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < message.Length; i++)
            {
                if (message[i] == delimiter)
                {
                    if (sb.Length > 0)
                        result.Add(sb.ToString());
                    sb.Clear();
                }
                else
                {
                    sb.Append(message[i]);
                }
            }
            return result.ToArray();
        }
    }
}
