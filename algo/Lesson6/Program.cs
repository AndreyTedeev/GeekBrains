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

        static void Main(string[] args)
        {
            // генерируем три файла
            List<Student> students;
            for (int i = 0; i < 3; i++)
                StudentFactory.Write($"students{i + 1}.json", StudentFactory.Generate(30));

            // делаем список файлов и печатаем меню
            string[] fileNames = Directory.GetFiles(".", "students*.json");
            Console.WriteLine("Выберите файл данных:");
            Menu(fileNames, out int option);

            // выход
            if (option == 0)
                return;

            // читаем файл
            Console.Clear();
            Console.WriteLine($"Loading file {fileNames[option - 1]}");
            students = StudentFactory.Read(fileNames[option - 1]);

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
                Console.WriteLine($"Finally... This Student HASH is {found.Hash()}");
            }
        }

        static void Menu(string[] options, out int option) {
            do
            {
                option = 0;
                foreach (string f in options)
                {
                    option++;
                    Console.WriteLine($"{option} : {f}");
                }
                Console.WriteLine();
                Console.WriteLine("0 : Выход");
            }
            while (!int.TryParse(Console.ReadLine(), out option) && (option >= 0) && (option < options.Length));
        }

    }

}