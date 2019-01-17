using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    public class LinkedList<T>
    {
        private Node<T> head { get; set; }
        private Node<T> list { get; set; }

        public void Init()
        {
            list = new Node<T>();
        }


        public Node<T> List_Search(int key)
        {
            var x = head;
            while (x != null && x.Key != key)
            {
                x = x.Next;
            }
            return x;
        }
        public void List_Insert(Node<T> x)
        {
            x.Next = head;
            if(head != null)
            {
                head.Prev = x;
            }
            head = x;
            x.Prev = null;
        }
        public void List_Delete(Node<T> x)
        {
            if(x.Prev!=null)
            {
                x.Prev.Next = x.Next;
            }
            else
            {
                head = x.Next;
            }
            if(x.Next!=null)
            {
                x.Next.Prev = x.Prev;
            }
        }

    }
    public class Node<T>
    {
        public Node<T> Prev { get; set; }
        public Node<T> Next { get; set; }
        public T Data { get; set; }
        public int Key { get; set; }
    }
}
