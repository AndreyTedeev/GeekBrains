using System;
using System.Collections.Generic;

namespace Lesson5
{
    /// <summary>
    /// Andrey Tedeev <andrey.tedeev@outlook.com>
    /// "Алгоритмы и структуры данных"
    /// Урок 5
    /// 
    /// 5. ** Реализовать алгоритм перевода из инфиксной записи арифметического выражения в постфиксную.
    /// </summary>
    class Program
    {

        static void Main()
        {
            string infix = "5*8*(2+9)+(7-5+8-9*(5*5)+5)";
            int result = 5 * 8 * (2 + 9) + (7 - 5 + 8 - 9 * (5 * 5) + 5);
            Console.WriteLine($"{infix} = {result}");
            
            string postfix = ToPostfix(infix);
            int calculated = CalcPostfix(postfix);
            Console.WriteLine($"{postfix} = {calculated}");
            Console.WriteLine(result == calculated);
        }

        static string ToPostfix(string input)
        {
            string result = "";
            //Stack<char> stack = new Stack<char>();
            MyStack<char> stack = new MyStack<char>();
            //Queue<char> queue = new Queue<char>();
            MyQueue<char> queue = new MyQueue<char>();
            for (int i = 0; i < input.Length; i++)
            {
                if (isDigit(input[i])) // Если входящий элемент число
                {
                    queue.Enqueue(input[i]); // то добавляем его в очередь
                }
                else if (isOperator(input[i])) // Если входящий элемент оператор (+, -, *, /) то проверяем
                {
                    if ((stack.Count == 0) || (stack.Peek() == '(')) // Если стек пуст или содержит левую скобку в вершине
                    {
                        stack.Push(input[i]); // то добавляем входящий оператор в стек
                    }
                    else if (CompareRank(input[i], stack.Peek()) > 0) // Если входящий оператор имеет более высокий приоритет чем вершина
                    {
                        stack.Push(input[i]); // поместить его в стек
                    }
                    else // Если входящий оператор имеет более низкий или равный приоритет, чем вершина
                    {
                        do
                        {   // выгружаем из стэка в очередь
                            queue.Enqueue(stack.Pop());
                        }   //  пока не увидим оператор с меньшим приоритетом  или левую скобку на вершине 
                        while ((stack.Count > 0) && (stack.Peek() != '(') && (CompareRank(input[i], stack.Peek()) >= 0));
                        stack.Push(input[i]); // затем добавить входящий оператор в стек
                    }
                }
                else if (input[i] == '(') // Если входящий элемент является левой скобкой 
                {
                    stack.Push(input[i]); // поместить его в стек
                }
                else if (input[i] == ')') // Если входящий элемент является правой скобкой 
                {
                    while (stack.Peek() != '(') // то пока не увидим левую скобку
                    {
                        queue.Enqueue(stack.Pop()); // выгружаем стек и добавляем его элементы в очередь
                    }
                    stack.Pop(); // Удалить найденную скобку из стека
                }
            }
            // В конце выражения выгрузить стек в очередь
            while (stack.Count > 0)
                queue.Enqueue(stack.Pop());
            // и очередь в строку
            while (queue.Count > 0)
                result += queue.Dequeue();
            return result;
        }

        private static int CompareRank(char source, char target)
        {
            if (source == target)
                return 0;
            int sourceRank = ((source == '+') || (source == '-')) ? 0 : 1;
            int targetRank = ((target == '+') || (target == '-')) ? 0 : 1;
            return (sourceRank > targetRank) ? 1 : (sourceRank < targetRank) ? -1 : 0;
        }

        private static bool isOperator(char x)
        {
            switch (x)
            {
                case '+': case '-': case '*': case '/': return true;
            }
            return false;
        }

        private static bool isDigit(char x)
        {
            return x >= '0' && x <= '9';
        }

        static int CalcPostfix(string input)
        {
            //Stack<int> stack = new Stack<int>();
            MyStack<int> stack = new MyStack<int>();
            int digit, x, y;
            for (int i = 0; i < input.Length; i++)
            {
                if (int.TryParse(input[i].ToString(), out digit)) // Если входящий элемент является числом, поместите(PUSH) его в стек (STACK)
                    stack.Push(digit);
                else //Если входящий элемент является оператором (*-/+),
                {
                    // необходимо получить(POP) два последних числа из стека(STACK)
                    // и выполнить соответствующую операцию.
                    // Далее поместите (PUSH) полученный результат в стек (STACK).
                    y = stack.Pop();
                    x = stack.Pop();
                    switch (input[i]) {
                        case '+': stack.Push(x + y); break;
                        case '-': stack.Push(x - y); break;
                        case '*': stack.Push(x * y); break;
                        case '/': stack.Push(x / y); break;
                        default: throw new ArgumentException("wrong input");
                    } 
                }
            }
            // Когда выражение закончится, число на вершине (TOP) стека (STACK) является результатом.
            return stack.Pop();
        }
    }
}
