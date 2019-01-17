using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    public class Stack<T>
    {
        private int top { get; set; }
        private int length { get; set; }
        private T[] arr { get; set; }

        public Stack()
        {
            arr = Array.Empty<T>();
            top = -1;
            length = 0;
        }
        public bool IsEmpty()
        {
            return top == -1;
        }
        public void Push(T item)
        {
            ++length;
            Resize();
            arr[++top] = item;
         
        }
        public T Pop()
        {
            var item = arr[top--];
            --length;
            return item;
        }
        public void Clear()
        {
            arr = Array.Empty<T>();
            top = -1;
            length = 0;
        }
        private void Resize()
        {
            var newarr = arr;
            Array.Resize(ref newarr, length);
            arr = newarr;
        }
    }
}
