using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    /// <summary>
    /// 堆排序
    /// </summary>
    public class Heapify
    {
        public static void Build_Max_Heap(Heap A)
        {
            A.size = A.A.Length;
            var max = (int)Math.Floor(A.size / 2M);
            Console.WriteLine($"length:{A.size}   max:{max}");
            for (var i = max; i > 0; i--)
            {
                //Min_Heapify(A, i - 1);
                Max_Heapify(A, i - 1);
            }
            Insertion_Sort.Print(A.A);
        }
        public static void Build_Max_Heap_s(Heap A)
        {
            A.size = 1;
            var max = (int)Math.Floor(A.size / 2M);
            Console.WriteLine($"length:{A.size}   max:{max}");
            for (var i = 2; i < A.A.Length; i++)
            {
                //Min_Heapify(A, i - 1);
                Max_Heap_Insert(ref A, i - 1);
            }
            Insertion_Sort.Print(A.A);
        }
        /// <summary>
        /// 构造最大堆
        /// </summary>
        /// <param name="A"></param>
        /// <param name="i"></param>
        public static void Max_Heapify(Heap A, int i)
        {
            var l = Left(i);
            var r = Right(i);
            var h = A.size - 1;
            var largest = i;
            if (l <= h && A.A[l] > A.A[i])
                largest = l;
            else largest = i;

            if (r <= h && A.A[r] > A.A[largest])
                largest = r;
            if (largest != i)
            {
                var temp = A.A[i];
                A.A[i] = A.A[largest];
                A.A[largest] = temp;
                Max_Heapify(A, largest);
            }
            Insertion_Sort.Print(A.A);
        }
        /// <summary>
        /// 构造最小堆
        /// </summary>
        /// <param name="A"></param>
        /// <param name="i"></param>
        public static void Min_Heapify(Heap A, int i)
        {
            var l = Left(i);
            var r = Right(i);
            var h = A.size - 1;
            var min = i;
            if (l <= h && A.A[l] < A.A[i])
                min = l;
            else min = i;

            if (r <= h && A.A[r] < A.A[min])
                min = r;
            if (min != i)
            {
                var temp = A.A[i];
                A.A[i] = A.A[min];
                A.A[min] = temp;

                Min_Heapify(A, min);
            }
        }


        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="A"></param>
        public static void HeapSort(Heap A)
        {
            Build_Max_Heap(A);
            for (int i = A.A.Length - 1; i >= 1; i--)
            {
                Console.WriteLine($"change: A[{i}]:{A.A[i]};A[0]:{ A.A[0]}");
                var temp = A.A[0];
                A.A[0] = A.A[i];
                A.A[i] = temp;
                A.size = A.size - 1;
                Max_Heapify(A, 0);
            }
            Insertion_Sort.Print(A.A);
        }

        public static int Heap_Maxinum(Heap A)
        {
            return A.A[0];
        }

        public static int Heap_Extract_Max(Heap A)
        {
            if (A.size < 0)
                throw new Exception("heap underfalow");
            var max = A.A[0];
            A.A[0] = A.A[A.size - 1];
            A.size = A.size - 1;
            Max_Heapify(A, 0);
            return max;
        }

        public static void Heap_Increase_Key(ref Heap A, int i, int key)
        {
            if (key < A.A[i])
                throw new Exception("new key is smaller than current key");
            A.A[i] = key;
            while (i > 0 && A.A[Parent(i)] < A.A[i])
            {
                var temp = A.A[i];
                A.A[i] = A.A[Parent(i)];
                A.A[Parent(i)] = temp;
                i = Parent(i);
            }
        }

        public static void Max_Heap_Insert(ref Heap A, int key)
        {
            A.size = A.size + 1;
            // Array.Resize(ref A.A, A.A.Length + 1);
            int[] temp = new int[A.A.Length + 1];
            Array.Copy(A.A, temp, A.A.Length);
            //把临时数组赋值给原数组，这时原数组已经扩容
            A.A = temp;
            //给扩容后原数组的最后一个位置赋值
            A.A[A.A.Length - 1] = int.MinValue;
            Insertion_Sort.Print(A.A);
            Console.WriteLine($"size{A.size}");
            Heap_Increase_Key(ref A, A.size - 1, key);
        }

        public static int Left(int i)
        {
            //Console.WriteLine($"i:{i};Left:{2 * i + 1}");
            return 2 * i + 1;
        }
        public static int Right(int i)
        {

            //Console.WriteLine($"i:{i};Right:{2 * i + 2}");
            return 2 * i + 2;
        }
        public static int Parent(int i)
        {
            return (int)Math.Ceiling(i / 2M) - 1;
        }

        public class Heap
        {
            public int[] A { get; set; }
            public int size { get; set; }
        }

    }
}
