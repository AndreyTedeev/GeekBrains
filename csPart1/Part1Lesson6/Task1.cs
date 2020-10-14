using System;
using System.Collections.Generic;
using System.Text;

namespace AndreyTedeev.Part1Lesson6
{
    /// <summary>
    /// 1. Изменить программу вывода функции так, чтобы можно было передавать функции типа double (double,double). 
    /// Продемонстрировать работу на функции с функцией a * x^2 и функцией a * sin(x).
    /// </summary>
    class Task1 : IAbstractTask
    {
        // Описываем делегат. В делегате описывается сигнатура методов, на
        // которые он сможет ссылаться в дальнейшем (хранить в себе)
        public delegate double Fun(double a, double x);

        // Создаем метод, который принимает делегат
        // На практике этот метод сможет принимать любой метод
        // с такой же сигнатурой, как у делегата
        public void Table(Fun F, double a, double x, double b)
        {
            Console.WriteLine("+--- A ----+--- X ----+--- Y ----+");
            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} | {2,8:0.000} |", a, x, F(a, x));
                x += 1;
            }
            Console.WriteLine("+----------+----------+----------+");
        }

        // Создаем методы для передачи его в качестве параметра в Table
        public static double X_3(double a, double x)
        {
            return x * x * x;
        }

        public static double A_X_2(double a, double x)
        {
            return a * x * x;
        }

        public static double A_SIN_X(double a, double x)
        {
            return a * Math.Sin(x);
        }

        public void Run()
        {
            Console.WriteLine(" ====== Task 1.\n");

            Console.WriteLine("Функция x^3.");
            Table(X_3, 3, 0, 3);
            Console.WriteLine("Функция a*x^2.");
            Table(A_X_2, 3, 0, 3);
            Console.WriteLine("Функция a*sin(x).");
            Table(A_SIN_X, 3, 0, 3);
        }
    }
}


