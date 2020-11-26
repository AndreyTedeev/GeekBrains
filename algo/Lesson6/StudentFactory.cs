using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Lesson6
{
    public class StudentFactory
    {
        static string[] MF = { "Andrey", "Sergey", "Igor", "Vasily", "Petr", "Slava", "John" };
        static string[] ML = { "Petrov", "Ivanov", "Sidorov", "Lennon", "Lenin", "Sharapov", "Rasputin" };
        static string[] FF = { "Anna", "Ekaterina", "Irina", "Alla", "Maria", "Svetlana", "Olga" };
        static string[] FL = { "Petrova", "Ivanova", "Sidorova", "Katz", "Pugacheva", "Sharapova", "Rasputina" };
        static Random RANDOM = new Random();

        public static List<Student> Generate(int quantity = 30)
        {
            List<Student> result = new List<Student>();
            for (int i = 0; i < quantity; i++)
            {
                Gender gender = (RANDOM.Next(2, 200) % 2 == 0) ? Gender.Male : Gender.Female;
                string[] fNames = (gender == Gender.Male) ? MF : FF;
                string[] lNames = (gender == Gender.Male) ? ML : FL;
                result.Add(new Student
                {
                    Id = i,
                    FirstName = fNames[RANDOM.Next(0, 7)],
                    LastName = lNames[RANDOM.Next(0, 7)],
                    Age = RANDOM.Next(18, 60),
                    Gender = gender
                });
            }
            return result;
        }

        public static void Write(string fileName, List<Student> data)
        {
            string jsonString = JsonSerializer.Serialize(data);
            File.WriteAllText(fileName, jsonString);
        }

        public static List<Student> Read(string fileName)
        {
            string jsonString;
            if (File.Exists(fileName))
            {
                jsonString = File.ReadAllText(fileName);
                return JsonSerializer.Deserialize<List<Student>>(jsonString);
            }
            return new List<Student>();
        }
    }
}
