using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson6
{
    public class Node<T> where T : IComparable
    {
        Node<T> _parent = null;
        Node<T> _left = null;
        Node<T> _right = null;

        public Node<T> Parent { get => _parent; }
        public Node<T> Left { get => _left; set { _left = value; _left._parent = this; } }
        public Node<T> Right { get => _right; set { _right = value; _right._parent = this; } }
        public T Value { get; set; }

        public Node(T value)
        {
            Value = value;
        }
    }
}
