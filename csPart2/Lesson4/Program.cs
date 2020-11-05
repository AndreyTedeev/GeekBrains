using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lesson4
{
    /// <summary>
    /// Альтернавтивное задание на коллекции.
    /// 1) Сравнить с помощью класса HashSet<string> несколько песен своей любимой группы.
    /// Найти слова, которые встречаются во всех песнях группы.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Top 10 most used words in Led Zeppelin I album (1969)");
            string text = File.ReadAllText("lyrics.txt");
            text = text.ToLower();
            text = Regex.Replace(text, "[\r\n]", " ");
            text = Regex.Replace(text, "  ", " ");
            text = Regex.Replace(text, "[.,;:!?]", "");
            string[] words = text.Split(" ");
            Dictionary<string, int> dict = new Dictionary<string, int>();
            foreach (string word in words) {
                if (dict.Keys.Contains(word))
                    dict[word]++;
                else
                    dict[word] = 1;
            }
            foreach (var item in dict.OrderByDescending(i => i.Value).Take(10))
                Console.WriteLine($"{item.Key}\t\t{item.Value}");

        }
    }
}
