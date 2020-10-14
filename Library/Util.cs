using System;
using System.Text;

namespace AndreyTedeev
{
    public class Util
    {

        public static char AsChar(Operation op) {
            switch (op) {
                case Operation.Minus: return '-';
                case Operation.Plus: return '+';
                case Operation.Multi: return '*';
                case Operation.Divide: return '/';
                default: throw new ArgumentException("Неизвестная операция");
            }
        }

        /// <summary>
        /// Decorates int[] to string
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string ToString(int[] data)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[ ");
            for (int i = 0; i < data.Length; i++)
            {
                if (i > 0)
                    sb.Append(", ");
                sb.Append(data[i]);
            }
            sb.Append(" ]");
            return sb.ToString();
        }

        /// <summary>
        /// Алгоритм Евклида, нахождение НОД
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int NOD(int a, int b)
        {
            if (a < b)
            {
                // swap a  и  b
                (a, b) = (b, a);
            }

            while (b > 0)
            {
                a %= b;
                // swap a  и  b
                (a, b) = (b, a);
            }

            return a;
        }

        /// <summary>
        /// Наименьшее общее кратное
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int NOK(int a, int b) 
        { 
            return a / NOD(a, b) * b;
        }

        public static int AskIntForever(string message)
        {
            Console.WriteLine(message);
            int result;
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("ОШИБКА! Введите число.");
            }
            return result;
        }

        public static double AskDoubleForever(string message)
        {
            bool success;
            double result;
            do
            {
                Console.Write(message);
                success = double.TryParse(Console.ReadLine(), out result);
                if (!success)
                    Console.WriteLine("Неверные данные. Попробуйте еще раз...");
            }
            while (!success);
            return result;
        }

    }
}
