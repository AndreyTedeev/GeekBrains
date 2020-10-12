using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AndreyTedeev.Part1Lesson6
{
    /// <summary>
    /// 3. Переделать программу «Пример использования коллекций» для решения следующих задач:
    /// а) Подсчитать количество студентов учащихся на 5 и 6 курсах;
    /// б) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся(частотный массив);
    /// в) отсортировать список по возрасту студента;
    /// г) * отсортировать список по курсу и возрасту студента;
    /// д) разработать единый метод подсчета количества студентов по различным параметрам
    /// выбора с помощью делегата и методов предикатов.
    /// </summary>
    class Task3 : IAbstractTask
    {
        /// <summary>
        /// в класс добавлена возможность хранить null.
        /// Это нужно для шаблонов поиска
        /// </summary>
        class Student
        {
            public string LastName { get; set; }
            public string FirstName { get; set; }
            public string University { get; set; }
            public string Faculty { get; set; }
            public int? Course { get; set; }
            public string Department { get; set; }
            public int? Group { get; set; }
            public string City { get; set; }
            public int? Age { get; set; }

            public static List<Student> Load(string fileName)
            {
                List<Student> result = new List<Student>();
                using (StreamReader sr = new StreamReader(fileName))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] row = sr.ReadLine().Split(';');
                        Student student = new Student
                        {
                            FirstName = row[0],
                            LastName = row[1],
                            University = row[2],
                            Faculty = row[3],
                            Department = row[4],
                            Age = int.Parse(row[5]),
                            Course = int.Parse(row[6]),
                            Group = int.Parse(row[7]),
                            City = row[8]
                        };
                        result.Add(student);
                    }
                    return result;
                }
            }
        }

        public void Run()
        {
            Console.WriteLine(" ====== Task 3.\n");

            string fileName = @"..\..\..\students.csv";
            Console.WriteLine($"загружаем данные из файла {fileName}");
            List<Student> data = Student.Load(fileName);
            foreach (Student s in data)
            {
                Console.WriteLine($"{s.Age}, {s.Course}, {s.FirstName} {s.LastName}");
            }
            Console.WriteLine("--------------------------------------");
            Part1(ref data);
            Console.WriteLine("--------------------------------------");
            Part2(ref data);
            Console.WriteLine("--------------------------------------");
            Part3(ref data);
            Console.WriteLine("--------------------------------------");
            Part4(ref data);
            Console.WriteLine("--------------------------------------");
            Part5(ref data);
        }

        #region Part1
        bool FindByCourse(Student match)
        {
            return (match.Course == 5) || (match.Course == 6);
        }

        /// <summary>
        /// а) Подсчитать количество студентов учащихся на 5 и 6 курсах;
        /// </summary>
        /// <param name="data"></param>
        void Part1(ref List<Student> data) {
            int count = data.FindAll(new Predicate<Student>(FindByCourse)).Count;
            Console.WriteLine($"Количество студентов учащихся на 5 и 6 курсах : {count}");
            // или так
            data.FindAll(new Predicate<Student>(
                (Student s) =>
                {
                    return (s.Course == 5) || (s.Course == 6);
                }
            ));
        }

        #endregion

        #region Part2

        /// <summary>
        /// б) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся(частотный массив);
        /// </summary>
        /// <param name="data">Исходные данные</param>
        void Part2(ref List<Student> data) {
            Console.WriteLine("Количество студентов от 18 до 20 лет на каждом курсе");
            Console.WriteLine("+ Курс + Кол-во +");
            for (int i = 1; i < 7; i++)
            {
                int count = data.FindAll(new Predicate<Student>(
                    (Student s) =>
                    {
                        return (s.Age >= 18) && (s.Age <= 20) && (s.Course == i);
                    }
                )).Count;
                Console.WriteLine("| {0,4:0} | {1,6:0} |", i, count);
            }
        }

        #endregion

        #region Part3

        int CompareByAge(Student st1, Student st2)
        {
            return (int)st1.Age - (int)st2.Age;
        }

        /// <summary>
        /// в) отсортировать список по возрасту студента;
        /// </summary>
        /// <param name="data"></param>
        void Part3(ref List<Student> data) {
            Console.WriteLine("Сортировка списка по возрасту");
            data.Sort(new Comparison<Student>(CompareByAge));
            foreach (Student s in data) {
                Console.WriteLine($"{s.Age}, {s.FirstName} {s.LastName}");
            }
        }

        #endregion

        #region Part4

        int CompareByCourseAndAge(Student st1, Student st2)
        {
            if (st1.Course == st2.Course)
                return (int)st1.Age - (int)st2.Age;
            else
                return (int)st1.Course - (int)st2.Course;
        }

        /// <summary>
        /// г) * отсортировать список по курсу и возрасту студента;
        /// </summary>
        /// <param name="data"></param>
        void Part4(ref List<Student> data)
        {
            Console.WriteLine("Сортировка списка по курсу и возрасту");
            data.Sort(new Comparison<Student>(CompareByCourseAndAge));
            foreach (Student s in data)
            {
                Console.WriteLine($"{s.Course}, {s.Age}, {s.FirstName} {s.LastName}");
            }
        }

        #endregion

        #region Part5

        delegate bool ByTemplate<in T>(T match, T template);

        bool MatchAllFields(Student match, Student template)
        {
            bool result = true;
            if (template.LastName != null)
                result &= (template.LastName.Equals(match.LastName));
            if (template.FirstName != null)
                result &= (template.FirstName.Equals(match.FirstName));
            if (template.University != null)
                result &= (template.University.Equals(match.University));
            if (template.Faculty != null)
                result &= (template.Faculty.Equals(match.Faculty));
            if (template.Course != null)
                result &= (template.Course.Equals(match.Course));
            if (template.Department != null)
                result &= (template.Department.Equals(match.Department));
            if (template.Group != null)
                result &= (template.Group.Equals(match.Group));
            if (template.City != null)
                result &= (template.City.Equals(match.City));
            if (template.Age != null)
                result &= (template.Age.Equals(match.Age));
            return result;
        }

        List<T> FindByTemplate<T>(ByTemplate<T> f, T template, ref List<T> data)
        {
            List<T> result = new List<T>();
            foreach (T t in data)
            {
                if (f(t, template))
                    result.Add(t);
            }
            return result;
        }
        /// <summary>
        /// д) разработать единый метод подсчета количества студентов по различным параметрам
        /// выбора с помощью делегата и методов предикатов.
        /// </summary>
        /// <param name="data"></param>
        void Part5(ref List<Student> data)
        {
            Console.WriteLine("Поиск по шаблону. Найти всех кому 18 лет.");
            Student template = new Student
            {
                LastName = null,
                FirstName = null,
                University = null,
                Faculty = null,
                Course = null,
                Department = null,
                Group = null,
                City = null,
                Age = 18
            };
            List<Student> found = FindByTemplate<Student>(MatchAllFields, template, ref data);
            foreach (Student s in found)
            {
                Console.WriteLine($"{s.Age}, {s.FirstName} {s.LastName}");
            }
        }
        #endregion

    }
}
