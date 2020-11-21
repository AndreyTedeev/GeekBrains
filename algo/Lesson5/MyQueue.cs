using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson5
{
    class MyQueue<T>
    {
        private static int SIZE = 4; 

        private T[] _data = new T[SIZE];
        private int _head = -1;
        private int _tail = -1;

        private void Grow()
        {
            Array.Resize(ref _data, _data.Length + SIZE);
        }

        public int Count
        {
            get => _head - _tail;
        }

        public void Enqueue(T t)
        {
            if (Count == _data.Length)
                Grow();
            _data[++_head] = t;
            // eq
            //_head++;
            //_data[_head] = t;
        }

        public T Dequeue()
        {
            if (Count > 0)
                return _data[++_tail];
            //{ eq
            //    _tail++;
            //    T t = _data[_tail];
            //    return t;
            //}
            else
                throw new Exception("Queue is Empty");
        }
    }
}
