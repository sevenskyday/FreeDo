using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    public class BitTree<T>
    {
        public int key { get; set; }
        public BitTree<T> left { get; set; }
        public BitTree<T> right { get; set; }
        public T Data { get; set; }



        public void RecursiveShow(BitTree<T> bit)
        {
            Console.WriteLine($"key:{bit.key},data:{bit.Data}");
            if (bit.left != null)
            {
                RecursiveShow(bit.left);
            }
            if (bit.right != null)
            {
                RecursiveShow(bit.right);
            }
        }
        public void NonRecursiveShow(BitTree<T> bit)
        {

        }
    }
}
