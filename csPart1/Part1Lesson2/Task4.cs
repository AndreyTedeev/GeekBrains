using System;

namespace AndreyTedeev.Part1Lesson2
{
    /// <summary>
    /// 4.Реализовать метод проверки логина и пароля.На вход метода подается логин и пароль.
    /// На выходе истина, если прошел авторизацию, и ложь, если не прошел
    /// (Логин: root, Password: GeekBrains). Используя метод проверки логина и пароля,
    /// написать программу: пользователь вводит логин и пароль, 
    /// программа пропускает его дальше или не пропускает.
    /// С помощью цикла do while ограничить ввод пароля тремя попытками.
    /// </summary>
    class Task4 : IAbstractTask
    {

        public void Run()
        {
            Console.WriteLine("4. Реализовать метод проверки логина и пароля.");
            bool success = Login(3);
            Console.WriteLine(success ? "Успешно.\n" : "Доступ запрещен.\n");
        }

        /// <summary>
        /// Requests user authorization.
        /// </summary>
        /// <param name="numTries">Number of tries</param>
        /// <returns>true if authorized, false otherwise</returns>
        private static bool Login(int numTries)
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
        private static bool AutorizeUser()
        {
            Console.Write("UserName : ");
            string userName = Console.ReadLine();
            Console.Write("Password : ");
            string password = Console.ReadLine();
            return (userName == "root") && (password == "GeekBrains");
        }

    }
}
