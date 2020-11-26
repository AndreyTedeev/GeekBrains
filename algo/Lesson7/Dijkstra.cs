using System;
using Lesson5;

namespace Lesson7
{
    public class Dijkstra
    {
        string[] _nodes;
        int[,] _matrix;

        public Dijkstra(string[] nodes, int[,] matrix)
        {
            if (nodes.Length != matrix.GetUpperBound(0) + 1)
                throw new ArgumentException("Count of Nodes must match size of Matrix");
            _nodes = nodes;
            _matrix = matrix;
        }

        private int IndexByName(string name)
        {
            for (int i = 0; i < _nodes.Length; i++)
                if (_nodes[i].Equals(name))
                    return i;
            return -1;
        }

        public string[] FindPath(string from, string to)
        {
            int start = IndexByName(from);
            if (start < 0)
                throw new ArgumentException("from: Unknown Node name");
            if (from.Equals(to))
                return new string[] { from };
            int end = IndexByName(to);
            if (end < 0)
                throw new ArgumentException("to: Unknown Node name");

            return Build( Walk(start), end );
        }

        private int[] Walk(int start)
        {
            // init stat array
            int[] stat = new int[_nodes.Length];
            for (int i = 0; i < _nodes.Length; i++)
                stat[i] = int.MaxValue;

            //  begin at the FROM point
            MyQueue<int> queue = new MyQueue<int>();
            int node = start;
            queue.Enqueue(node);
            stat[node] = 0;

            // walk the graph
            while (queue.Count > 0)
            {
                node = queue.Dequeue();
                for (int j = 0; j < _matrix.GetUpperBound(0) + 1; j++)
                {
                    int temp = ((stat[node] == int.MaxValue) || (_matrix[node, j] == int.MaxValue))
                        ? int.MaxValue
                        : stat[node] + _matrix[node, j];
                    if (stat[j] > temp)
                    {
                        stat[j] = temp;
                        queue.Enqueue(j);
                    }
                }
            }
            return stat;
        }

        private string[] Build(int[] stat, int end)
        {
            int node = end;
            MyStack<int> stack = new MyStack<int>();
            stack.Push(node);
            int x = stat[node];
            while (x > 0)
            {
                for (int j = 0; j < _matrix.GetUpperBound(0) + 1; j++)
                {
                    if (stat[j] == x - _matrix[node, j])
                    {
                        stack.Push(j);
                        x = stat[j];
                        node = j;
                        break; // for
                    }
                }
            }
            string[] result = new string[stack.Count];
            int index = 0;
            while (stack.Count > 0)
            {
                result[index++] = _nodes[stack.Pop()];
            }
            return result;
        }
    }
}
