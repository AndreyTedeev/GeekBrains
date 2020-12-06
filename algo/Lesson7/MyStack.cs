using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson5
{
    public class MyStack<T>
    {
        private static int SIZE = 4;

        private T[] _data = new T[SIZE];
        private int _head = -1;

        private void Grow()
        {
            Array.Resize(ref _data, _data.Length + SIZE);
        }

        public int Count
        {
            get => _head + 1;
        }

        public void Push(T t)
        {
            if (Count == _data.Length)
                Grow();
            _data[++_head] = t;
            // eq
            //_head++;
            //_data[_head] = t;
        }

        public T Peek()
        {
            if (Count > 0)
                return _data[_head];
            else
                throw new Exception("Stack is Empty");
        }

        public T Pop()
        {
            if (Count > 0)
                return _data[_head--];
            //{ eq
            //    T t = _data[_head];
            //    _head--;
            //    return t;
            //}
            else
                throw new Exception("Stack is Empty");
        }

    }
}
