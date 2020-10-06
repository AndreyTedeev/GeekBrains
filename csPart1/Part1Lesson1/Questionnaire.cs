using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Lesson1
{
    public static class Questionnaire
    {

        static float askFloat(string message) {
            do
            {
                Console.Write(message);
                string str = Console.ReadLine();
                if (float.TryParse(str, out float value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("Ошибка конвертации в число!  ");
                    Console.WriteLine("Попробуйте еще раз...");
                }
            }
            while (true);
        }

        /*
         *   Последовательно задаются вопросы (имя, фамилия, возраст, рост, вес). 
         *   returns : Person
         */
        public static Person Run() {
            Person person = new Person();

            Console.WriteLine("Пожалуйста заполните анкету.");
            Console.Write("Имя : ");
            person.FirstName = Console.ReadLine();

            Console.Write("Фамилия : ");
            person.LastName = Console.ReadLine();

            person.Age = askFloat("Возраст : ");
            
            person.Height = askFloat("Рост (в метрах) : ");

            person.Weight = askFloat("Вес (в килограммах) : ");

            return person;
        }

    }
}
