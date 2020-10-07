using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AndreyTedeev.Part1Lesson5
{
    /// <summary>
    ///  5. **Написать игру «Верю. Не верю». 
    ///  В файле хранятся вопрос и ответ, правда это или нет.
    ///  Например: «Шариковую ручку изобрели в древнем Египте», «Да». 
    ///  Компьютер загружает эти данные, случайным образом выбирает 5 вопросов и задаёт их игроку.
    ///  Игрок отвечает Да или Нет на каждый вопрос и набирает баллы за каждый правильный ответ.
    ///  Список вопросов ищите во вложении или воспользуйтесь интернетом.
    /// </summary>
    class Task5 : IAbstractTask
    {

        public void Run()
        {
            Console.WriteLine(" ====== Task 5.\n");

            Console.WriteLine("Загрузка данных.\n");
            FileRecord[] data = LoadData("..\\..\\..\\task5data.txt");
            if (data.Length < 5)
            {
                Console.WriteLine("Спрашивать нечего. Вопросов меньше пяти.\n");
                return;
            }

            Console.WriteLine($"Начнем игру...\nБудет 5 вопросов на которые нжно ответить {StaticQuestion}\n");
            Random random = new Random();
            int count = 5, total = 0, randomQuestion;
            for (int i = 0; i < count; i++)
            {
                randomQuestion = random.Next(1, data.Length);
                total += AskQuestion(data[randomQuestion]);
            }
            Console.WriteLine($"\nВы набрали {total} баллов.\n");
        }

        private static readonly string StaticQuestion = "[Д]а или[Н]ет";

        /// <summary>
        /// Запись вопроса в файле
        /// </summary>
        private struct FileRecord
        {
            public string Question;
            public bool RightAnswer;
        }

        /// <summary>
        /// Задает вопрос и сравнивает ответ с правильным ответом
        /// </summary>
        /// <param name="rec">Вопрос и Правильный ответ</param>
        /// <returns>Количество баллов за ответ (1 или 0)</returns>
        private int AskQuestion(FileRecord rec)
        {
            Console.WriteLine($"{rec.Question}");
            while (true)
            {
                Console.Write($"{StaticQuestion} : ");
                char c = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if ((c == 'Д') || (c == 'д'))
                    return (rec.RightAnswer == true) ? 1 : 0;
                else if ((c == 'Н') || (c == 'н'))
                    return (rec.RightAnswer == false) ? 1 : 0;
            }
        }

        /// <summary>
        /// Загружает данные из файла
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private FileRecord[] LoadData(string fileName)
        {
            List<FileRecord> result = new List<FileRecord>();
            using (StreamReader sr = new StreamReader(fileName))
            {
                string[] fields;
                while (!sr.EndOfStream)
                {
                    try
                    {
                        fields = sr.ReadLine().Split('|');
                        FileRecord rec = new FileRecord();
                        rec.Question = fields[0];
                        rec.RightAnswer = bool.Parse(fields[1]);
                        result.Add(rec);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"ОШИБКА! {ex.Message}");
                    }
                }
            }
            return result.ToArray();
        }
    }
}
