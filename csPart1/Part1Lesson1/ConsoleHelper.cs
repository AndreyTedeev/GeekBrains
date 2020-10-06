using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson1
{
    public static class ConsoleHelper
    {

        public static void Pause()
        {
            Console.Write("\nНажмите ENTER для продолжения");
            Console.ReadLine();
            Console.Clear();
        }

        public static void Print(string message, int x, int y) 
        {
            Console.SetCursorPosition(x, y);
            Console.Write(message);
        }

        public static void PrintCentered(string[] messages)
        {
            for (int i = 0; i < messages.Length; i++)
            {
                int centerX = (Console.WindowWidth / 2) - (messages[i].Length / 2);
                int centerY = (Console.WindowHeight / 2) + i - (messages.Length / 2);
                ConsoleHelper.Print(messages[i], centerX, centerY);
            }
        }

    }

}
