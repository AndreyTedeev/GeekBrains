using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AndreyTedeev.Part1Lesson5
{
    /// <summary>
    /// 4. Задача ЕГЭ. 
    ///    * На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов некоторой средней
    ///    школы. В первой строке сообщается количество учеников N, которое не меньше 10, но не
    ///    превосходит 100, каждая из следующих N строк имеет следующий формат:
    ///    <Фамилия> <Имя> <оценки>,
    ///    где<Фамилия> — строка, состоящая не более чем из 20 символов, <Имя> — строка, состоящая не
    ///    более чем из 15 символов, <оценки> — через пробел три целых числа, соответствующие оценкам по
    ///    пятибалльной системе. <Фамилия> и<Имя>, а также<Имя> и<оценки> разделены одним пробелом.
    ///  
    ///    Пример входной строки:
    ///  
    ///    Иванов Петр 4 5 3
    ///  
    ///    Требуется написать как можно более эффективную программу, которая будет выводить на экран
    ///    фамилии и имена трёх худших по среднему баллу учеников. Если среди остальных есть ученики,
    ///    набравшие тот же средний балл, что и один из трёх худших, следует вывести и их фамилии и имена.
    /// </summary>
    class Task4 : IAbstractTask
    {

        public void Run()
        {
            Console.WriteLine(" ====== Task 4.\n");

            Student[] data = ReadData("..\\..\\..\\task4data.txt");
            ShowWorstStudents(data);
            Console.WriteLine();
        }

        /// <summary>
        /// Запись студента в файле
        /// </summary>
        private struct Student : IComparable
        {
            public string FirstName;
            public string LastName;
            public byte Grade1;
            public byte Grade2;
            public byte Grade3;

            /// <summary>
            /// Пробует преобразовать строку в объест класса Person.
            /// Throws exception если не получится
            /// </summary>
            /// <param name="s">Строка</param>
            /// <param name="delimiter">Разделитель, по умолчанию ' '</param>
            /// <returns></returns>
            public static Student Parse(string s, char delimiter = ' ')
            {
                string[] fields = s.Split(delimiter);
                if (fields.Length != 5)
                    throw new Exception("Не верное количество полей в записи.");
                Student result = new Student();
                result.LastName = fields[0];
                result.FirstName = fields[1];
                result.Grade1 = byte.Parse(fields[2]);
                result.Grade2 = byte.Parse(fields[3]);
                result.Grade3 = byte.Parse(fields[4]);
                if (result.LastName.Length > 20)
                    throw new Exception("Фамилия длиннее 20 символов.");
                if (result.FirstName.Length > 15)
                    throw new Exception("Имя длиннее 15 символов.");
                if ((result.Grade1 < 1) && (result.Grade1 > 5) ||
                    (result.Grade2 < 1) && (result.Grade2 > 5) ||
                    (result.Grade3 < 1) && (result.Grade3 > 5))
                    throw new Exception("Оценка должна быть числом от 1 до 5.");
                return result;
            }

            /// <summary>
            /// Средний балл
            /// </summary>
            /// <returns></returns>
            public double AverageGrade() {
                return (Grade1 + Grade2 + Grade3) / 3D;
            }

            /// <summary>
            /// Перекрываем метод для преобразования в строку для вывода
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                return string.Format($"{LastName} {FirstName} : {AverageGrade():#.##}");
            }

            /// <summary>
            /// Имплементация интерфейса IComparable для сортировки
            /// </summary>
            /// <param name="obj">must be of type Student</param>
            /// <returns></returns>
            public int CompareTo(object obj)
            {
                if (obj is Student)
                    return this.AverageGrade().CompareTo(((Student)obj).AverageGrade());
                else
                    throw new ArgumentException("object is not Student");
            }
        }
        
        /// <summary>
        /// Читаем данные соостветсвующие условию
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private Student[] ReadData(string fileName)
        {
            List<Student> result = new List<Student>();
            using (StreamReader sr = new StreamReader(fileName))
            {
                int count = int.Parse(sr.ReadLine());
                if ((count < 10) || (count > 100))
                    throw new Exception("Неверное количество записей в файле.");
                string s;
                while (!sr.EndOfStream)
                {
                    s = sr.ReadLine();
                    if (s.Length == 0) 
                        continue;
                    result.Add(Student.Parse(s));
                }
            };
            return result.ToArray();
        }

        /// <summary>
        /// Выводит на экран фамилии и имена трёх худших по среднему баллу учеников. 
        /// Если среди остальных есть ученики, набравшие тот же средний балл, 
        /// что и один из трёх худших, следует вывести и их фамилии и имена.
        /// </summary>
        /// <param name="students"></param>
        private void ShowWorstStudents(Student[] students) 
        {
            Array.Sort(students);
            int count = 0;
            double lastAverage = 0D;
            double currentAverage = 0D;
            foreach (Student student in students)
            {
                currentAverage = student.AverageGrade();
                if ( currentAverage != lastAverage) {
                    lastAverage = currentAverage;
                    count++;
                }
                if (count < 4)
                {
                    Console.WriteLine(student);
                }
                else
                    break;
            }
        }

    }
}
