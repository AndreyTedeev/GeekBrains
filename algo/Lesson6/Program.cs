using System;
using System.Collections.Generic;
using System.IO;

namespace Lesson6
{
    /// <summary>
    /// 1. Реализовать простейшую хеш-функцию. На вход функции подается строка, на выходе сумма кодов символов.
    /// 2. Переписать программу, реализующую двоичное дерево поиска.
    /// а) Добавить в него обход дерева различными способами;
    /// б) Реализовать поиск в двоичном дереве поиска;
    /// в) * Добавить в программу обработку командной строки, с помощью которой можно указывать, 
    /// из какого файла считывать данные, каким образом обходить дерево.
    /// 3. *Разработать базу данных студентов из полей «Имя», «Возраст», «Табельный номер», 
    /// в которой использовать все знания, полученные на уроках.
    /// Считайте данные в двоичное дерево поиска.
    /// Реализуйте поиск по какому-нибудь полю базы данных (возраст, вес).
    /// </summary>
    class Program
    {

        public class Node<T> where T : IComparable
        {
            Node<T> _parent = null;
            Node<T> _left = null;
            Node<T> _right = null;

            public Node<T> Parent { get => _parent; }
            public Node<T> Left { get => _left; set { _left = value; _left._parent = this; } }
            public Node<T> Right { get => _right; set { _right = value; _right._parent = this; } }
            public T Value { get; set; }

            public Node(T value)
            {
                Value = value;
            }
        }

        public class Tree<T> where T : class, IComparable
        {

            Node<T> _root = null;

            public Node<T> Root { get => _root; }

            public void Add(T value)
            {
                if (_root == null) // если дерево пустое
                    _root = new Node<T>(value); // добавляем в корень
                else
                {
                    Node<T> node = _root; // начинаем обход с корня
                    while (node != null) // пока не дошли до конца
                    {
                        if (node.Value.CompareTo(value) <= 0) // идем влево
                        {
                            if (node.Left is null) // если пусто добавляем
                            {
                                node.Left = new Node<T>(value);
                                return;
                            }
                            else // иначе идем дальше по дереву
                            {
                                node = node.Left;
                                continue;
                            }
                        }
                        else // идем вправо
                        {
                            if (node.Right is null) // если пусто добавляем
                            {
                                node.Right = new Node<T>(value);
                                return;
                            }
                            else // иначе идем дальше по дереву
                            {
                                node = node.Right;
                                continue;
                            }
                        }
                        // TODO: нужно ли балансировать дерево ???
                        // если да, то вероятно здесь. 
                        // пока оставлю как есть ...
                    }
                }
            }

            public void Add(IEnumerable<T> data)
            {
                foreach (T t in data)
                    Add(t);
            }

            public T Find(T template)
            {
                if (Root != null) 
                {
                    Node<T> node = _root; // начинаем обход с корня
                    while (node != null) // пока не дошли до конца
                    {
                        if (node.Value.CompareTo(template) < 0) // идем влево
                        {
                            if (node.Left is null) // если пусто то не нашли
                                return null;
                            else // иначе идем дальше по дереву
                            {
                                node = node.Left;
                                continue;
                            }
                        }
                        else if (node.Value.CompareTo(template) > 0) // идем вправо
                        {
                            if (node.Right is null) // если пусто то не нашли
                                return null;
                            else // иначе идем дальше по дереву
                            {
                                node = node.Right;
                                continue;
                            }
                        }
                        else
                            return node.Value;
                    }
                }
                return null;
            }
        }

        static void Main(string[] args)
        {
            // генерируем три файла
            List<Student> students;
            for (int i = 0; i < 3; i++)
                Student.Write($"students{i + 1}.json", Student.GenerateStudents(30));

            // делаем список файлов и печатаем меню
            string[] fileNames = Directory.GetFiles(".", "students*.json");
            Console.WriteLine("Выберите файл данных:");
            int option;
            do
            {
                option = 0;
                foreach (string f in fileNames)
                {
                    option++;
                    Console.WriteLine($"{option} : {f}");
                }
                Console.WriteLine();
                Console.WriteLine("0 : Выход");
            }
            while (!int.TryParse(Console.ReadLine(), out option) && (option >= 0) && (option < fileNames.Length));

            // выход
            if (option == 0)
                return;

            // читаем файл
            Console.Clear();
            Console.WriteLine($"Loading file {fileNames[option - 1]}");
            students = Student.Read(fileNames[option - 1]);

            // будем в дереве искать какого нибудь студента по Age.
            // другие поля нас не интересуют потому, что 
            // Student.CompareTo реализован только для Age
            Student search = new Student
            {
                Age = students[students.Count/2].Age
            };

            // строим дерево
            Console.WriteLine($"Building tree of {students.Count} items");
            Tree<Student> tree = new Tree<Student>();
            tree.Add(students);

            Console.WriteLine($"Performing tree search of Student.Age = {search.Age}");
            Student found = tree.Find(search);
            if (found == null)
                Console.WriteLine("Not found. But it has to be one! Error.");
            else
            {
                Console.WriteLine($"Success! {found}");
                Console.WriteLine($"Finally... This Student HASH is {Hash(found.ToString())}");
            }
        }

        /// <summary>
        /// Simple Hash implementation
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static long Hash(string input)
        {
            long result = 0;
            for (int i = 0; i < input.Length - 1; i++)
            {
                result += input[i] * input[i + 1];
            }
            return result;
        }

    }

}