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
        public BitTree<T> parent { get; set; }


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
        public BitTree<T> Maxinum(BitTree<T> bit)
        {
            while (bit.right != null)
            {
                bit = bit.right;
            }
            Console.WriteLine($"key:{bit.key},data:{bit.Data}");
            return bit;
        }
        public BitTree<T> Mininum(BitTree<T> bit)
        {
            while (bit.left != null)
            {
                bit = bit.left;
            }
            Console.WriteLine($"key:{bit.key},data:{bit.Data}");
            return bit;

        }
        public BitTree<T> Successor(BitTree<T> bit)
        {
            if (bit.right != null)
            {
                return Mininum(bit.right);
            }
            var y = bit.parent;
            while (y != null && bit == y.right)
            {
                bit = y;
                y = y.parent;
            }
            return y;
        }
        public BitTree<T> insert(BitTree<T> tree, int z)
        {
            //var x = tree.key;
            //var y = new BitTree<T>();
            //while (x != null)
            //{
            //    y = x;
            //    if ()
            //}
            return new BitTree<T>();
        }
    }

}
