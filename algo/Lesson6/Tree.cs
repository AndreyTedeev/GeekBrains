using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson6
{
    public class Tree<T> where T : class, IComparable
    {

        Node<T> _root = null;

        public Node<T> Root { get => _root; }

        public void Add(T value)
        {
            if (_root == null) // если дерево пустое
                _root = new Node<T>(value); // добавляем в корень
            else
            {
                Node<T> node = _root; // начинаем обход с корня
                while (node != null) // пока не дошли до конца
                {
                    if (node.Value.CompareTo(value) <= 0) // идем влево
                    {
                        if (node.Left is null) // если пусто добавляем
                        {
                            node.Left = new Node<T>(value);
                            return;
                        }
                        else // иначе идем дальше по дереву
                        {
                            node = node.Left;
                            continue;
                        }
                    }
                    else // идем вправо
                    {
                        if (node.Right is null) // если пусто добавляем
                        {
                            node.Right = new Node<T>(value);
                            return;
                        }
                        else // иначе идем дальше по дереву
                        {
                            node = node.Right;
                            continue;
                        }
                    }
                    // TODO: нужно ли балансировать дерево ???
                    // если да, то вероятно здесь. 
                    // пока оставлю как есть ...
                }
            }
        }

        public void Add(IEnumerable<T> data)
        {
            foreach (T t in data)
                Add(t);
        }

        public T Find(T template)
        {
            if (Root != null)
            {
                Node<T> node = _root; // начинаем обход с корня
                while (node != null) // пока не дошли до конца
                {
                    if (node.Value.CompareTo(template) < 0) // идем влево
                    {
                        if (node.Left is null) // если пусто то не нашли
                            return null;
                        else // иначе идем дальше по дереву
                        {
                            node = node.Left;
                            continue;
                        }
                    }
                    else if (node.Value.CompareTo(template) > 0) // идем вправо
                    {
                        if (node.Right is null) // если пусто то не нашли
                            return null;
                        else // иначе идем дальше по дереву
                        {
                            node = node.Right;
                            continue;
                        }
                    }
                    else
                        return node.Value;
                }
            }
            return null;
        }
    }
}
