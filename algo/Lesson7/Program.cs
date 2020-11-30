using System;
using System.Text;

namespace Lesson7
{
    class Program
    {

        static void Main(string[] args)
        {
            string[] nodes = { "X0", "X1", "X2", "X3", "X4", "X5", "X6", "X7" };
            int m = int.MaxValue;
            
            int[,] matrix = {
                { m, 4, 8, 3, m, m, m, m},
                { 4, m, 1, m, 8, 5, m, m},
                { 8, 1, m, 8, 2, m, m, m},
                { 3, m, 8, m, m, m, 4, m},
                { m, 8, 2, m, m, 2, m, 5},
                { m, 5, m, m, 2, m, m, 3},
                { m, m, m, 4, m, m, m, 2},
                { m, m, m, m, 5, 3, 2, m}
            };

            Dijkstra d = new Dijkstra(nodes, matrix);
            string[] path1 = d.FindPath("X6", "X1");
            Console.WriteLine($"Path from X6 to X1 : {ToString(path1)}");

            string[] path2 = d.FindPath("X1", "X6");
            Console.WriteLine($"Path from X1 to X6 : {ToString(path2)}");
            
            string[] result = (path1.Length < path2.Length) ? path1 : path2;
            Console.WriteLine($"The shortest route is : {ToString(result)}");
        }

        static string ToString(string[] array)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < array.Length; i++)
                sb.Append(array[i] + " ");
            return sb.ToString();
        }
    }
}
