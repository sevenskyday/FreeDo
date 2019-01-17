using System;
using static Algorithms.Heapify;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //var A = new int[] { 31, 6, 41, 59, 26, 41, 58, 5, 9, 55, 66, 2 };
            //Insertion_Sort.Merge_Sort(A, 0, A.Length - 1);
            //var B = new int[] { 1, 2, 5, 6, 8, 9, 12, 25, 36, 44, 51, 52, 56, 89, 92, 96 };
            //Console.WriteLine("search :3------------");
            //Insertion_Sort.BinarySearch(B, 0, B.Length - 1, 3);
            //Console.WriteLine("search :1------------");
            //Insertion_Sort.BinarySearch(B, 0, B.Length - 1, 1);
            //Console.WriteLine("search :89------------");
            //Insertion_Sort.BinarySearch(B, 0, B.Length - 1, 89);
            //Console.WriteLine("search :95------------");
            //Insertion_Sort.BinarySearch(B, 0, B.Length - 1, 95);
            //var r = Insertion_Sort.Sort(A);
            //Print(r);
            //var r2 = Insertion_Sort.Sort2(A);
            //Print(r2);
            //var C = new int[] { 2, 3, 8, 6, 1, 4, -44, 45, 23, 11, 5, -23, -55, -6, 5, 11 };
            //var D = new Heap() { A = new int[] { 4, 1, 3, 2, 16, 9, 10, 14, 8, 7 }, size = 10 };
            ////Insertion_Sort.InversionSearch(C, 0, C.Length - 1);
            ////Insertion_Sort.Find_MaxiNum_Subarray(C, 0, C.Length - 1);
            ////Heapify.HeapSort(D);
            ////Heapify.Heap_Increase_Key(ref D, 3, 55);
            ////Heapify.HeapSort(D);
            //Build_Max_Heap(D);
            //Build_Max_Heap_s(D);
            //Heapify.Max_Heap_Insert(ref D, 20);
            //Stack<int> stack = new Stack<int>();
            //for(int i=0;i<20; i++)
            //{
            //    stack.Push(i);
            //}
            //while(!stack.IsEmpty())
            //{
            //    var s = stack.Pop();
            //    Console.WriteLine(s);
            //}
            BitTree<int> tree = new BitTree<int>()
            {
                key = 6,
                Data = 18,
                left = new BitTree<int>()
                {
                    key = 1,
                    Data = 12,
                    left = new BitTree<int>() { key = 7, Data = 7 },
                    right = new BitTree<int>()
                    {
                        key = 3,
                        Data = 4,
                        left = new BitTree<int>()
                        {
                            key = 10,
                            Data = 5
                        }
                    }
                },
                right = new BitTree<int>()
                {
                    key = 4,
                    Data = 10,
                    left = new BitTree<int>()
                    {
                        key = 5,
                        Data = 2
                    },
                    right = new BitTree<int>()
                    {
                        key = 9,
                        Data = 21
                    }
                }
            };
            tree.RecursiveShow(tree);
            Console.ReadLine();
        }
        public static void Print(int[] Arr)
        {
            for (var i = 0; i < Arr.Length; i++)
            {
                Console.Write($"{Arr[i]} ");
            }
            Console.WriteLine();
        }
        public int[] Sort(int[] Arr)
        {
            int[] _A = Arr;
            if (_A.Length <= 1)
            {
                return _A;
            }
            for (int j = 2; j < _A.Length; j++)
            {
                var i = j - 1;
                while (i >= 1)
                {
                    if (_A[i] > _A[i + 1])
                    {
                        var temp = _A[i + 1];
                        _A[i + 1] = _A[i];
                        _A[i] = temp;
                    }
                    i--;
                }
            }
            return _A;
        }
    }
}
