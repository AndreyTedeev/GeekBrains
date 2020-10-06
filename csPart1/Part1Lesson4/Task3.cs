using System;
using System.Collections.Generic;
using System.IO;

namespace AndreyTedeev.Part1Lesson4
{
    /// <summary>
    /// 3. Решить задачу с логинами из предыдущего урока, только логины и пароли считать из файла в массив. 
    /// Создайте структуру Account, содержащую Login и Password.
    /// ------ Ниже сама задача предыдущего урока
    /// Реализовать метод проверки логина и пароля.На вход метода подается логин и пароль.
    /// На выходе истина, если прошел авторизацию, и ложь, если не прошел
    /// (Логин: root, Password: GeekBrains). Используя метод проверки логина и пароля,
    /// написать программу: пользователь вводит логин и пароль, 
    /// программа пропускает его дальше или не пропускает.
    /// С помощью цикла do while ограничить ввод пароля тремя попытками.
    /// </summary>
    class Task3 : IAbstractTask
    {

        public struct Account
        {
            public string userName;
            public string password;
        }

        private Account[] accounts;

        public void Run()
        {
            Console.WriteLine(" ====== Task 3.\n");

            string fileName = "accounts.txt";
            Console.WriteLine($"Инициализируем данные и записываем в файл {fileName}");
            Account[] data = new Account[] {
                new Account { userName = "aaaa", password = "zxncjsdhsd" },
                new Account { userName = "root", password = "GeekBrains" },
                new Account { userName = "user", password = "1234567890" }
            };
            WriteAccounts(fileName, data);

            Console.WriteLine($"Читаем список из файла {fileName}");
            accounts = ReadAccounts(fileName);
            bool success = Login(3);
            Console.WriteLine(success ? "Успешно.\n" : "Доступ запрещен.\n");
        }

        public static Account[] ReadAccounts(string fileName)
        {
            List<Account> result = new List<Account>();
            using (StreamReader reader = new StreamReader(fileName))
            {
                int errors = 0;
                while (!reader.EndOfStream)
                {
                    string[] record = reader.ReadLine().Split(',');
                    if (record.Length != 2)
                    {
                        errors++;
                        Console.WriteLine("Wrong record.");
                    }
                    else
                    {
                        Account account = new Account();
                        account.userName = record[0];
                        account.password = record[1];
                        result.Add(account);
                    }
                }
                Console.WriteLine($"Loaded : {result.Count}, Errors : {errors}");
            }
            return result.ToArray();
        }

        public static void WriteAccounts(string fileName, Account[] data)
        {
            using (StreamWriter writer = new StreamWriter(fileName, false))
            {
                foreach (Account account in data)
                {
                    writer.WriteLine($"{account.userName},{account.password}");
                }
            }
        }

        /// <summary>
        /// Requests user authorization.
        /// </summary>
        /// <param name="numTries">Number of tries</param>
        /// <returns>true if authorized, false otherwise</returns>
        private bool Login(int numTries)
        {
            int count = 0;
            do
            {
                Console.WriteLine($"Пожалуйста авторизуйтесь. Попыток осталось : {numTries - count}");
                if (AutorizeUser())
                    return true;
                count++;
            }
            while (count < numTries);
            return false;
        }

        /// <summary>
        /// Asks for user and passwords
        /// </summary>
        /// <returns> true if match, false otherwise</returns>
        private bool AutorizeUser()
        {
            Console.Write("UserName : ");
            string userName = Console.ReadLine();
            Console.Write("Password : ");
            string password = Console.ReadLine();
            foreach (Account account in accounts)
            {
                if ((userName == "root") && (password == "GeekBrains"))
                    return true;
            }
            return false;
        }

    }
}
