using System;
using System.Text.RegularExpressions;

namespace AndreyTedeev.Part1Lesson5
{
    class Task1 : IAbstractTask
    {
        /// <summary>
        /// 1. Создать программу, которая будет проверять корректность ввода логина. 
        /// Корректным логином будет строка от 2 до 10 символов, содержащая только
        /// буквы латинского алфавита или цифры, при этом цифра не может быть первой:
        /// а) без использования регулярных выражений;
        /// б) с использованием регулярных выражений.
        /// </summary>
        public void Run()
        {
            Console.WriteLine(" ====== Task 1.\n");
            
            Console.WriteLine("Введите имя пользователя");
            string s = Console.ReadLine();
            Console.WriteLine($"Результат проверки без RegEx: {CheckLogin(s)}");
            
            Regex regex = new Regex("^[a-zA-Z][a-zA-Z0-9]{1,9}$");
            Console.WriteLine($"Результат проверки c RegEx: {regex.IsMatch(s)}\n");
        }

        /// <summary>
        /// Проверяет логин на корректность
        /// </summary>
        /// <param name="login">Логин</param>
        /// <returns>true если корректный</returns>
        public bool CheckLogin(string login) 
        {
            if (login.Length < 2 || login.Length > 10)
                return false; // Корректным логином будет строка от 2 до 10 символов
            char c;
            for (int i = 0; i < login.Length; i++)
            {
                c = login[i];
                if (i == 0 && char.IsDigit(c))
                    return false; // цифра не может быть первой
                if ((c < 'a' || c > 'z') && (c < 'A' || c > 'Z') && (c < '0' || c > '9'))
                    return false; // содержащая только буквы латинского алфавита или цифры
            }
            return true;
        }

    }
}
