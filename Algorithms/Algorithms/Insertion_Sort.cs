using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    /// <summary>
    /// 排序
    /// </summary>
    public class Insertion_Sort
    {
        /// <summary>
        /// 排序插入法
        /// </summary>
        /// <param name="Arr"></param>
        /// <param name="asc"></param>
        /// <returns></returns>
        public static int[] Sort(int[] Arr, bool asc)
        {
            int[] _A = (int[])Arr.Clone();
            if (_A.Length <= 1)
            {
                return _A;
            }
            for (int j = 1; j < _A.Length; j++)
            {
                Print(_A);
                var i = j - 1;
                var key = _A[j];
                if (asc)
                {
                    while (i >= 0 && _A[i] > key)
                    {
                        _A[i + 1] = _A[i];
                        i--;
                    }
                }
                else
                {
                    while (i >= 0 && _A[i] < key)
                    {

                        _A[i + 1] = _A[i];
                        i--;
                    }
                }
                _A[i + 1] = key;
            }
            Print(_A);
            return _A;
        }
        public static int[] Sort2(int[] Arr)
        {
            int[] _A = (int[])Arr.Clone();
            if (_A.Length <= 1)
            {
                return _A;
            }
            for (int j = 1; j < _A.Length; j++)
            {
                Print(_A);
                var i = j - 1;
                var key = _A[j];
                while (i >= 0 && _A[i] > key)
                {

                    _A[i + 1] = _A[i];
                    _A[i] = key;
                    i--;
                }
            }
            Print(_A);
            return _A;
        }
        public static int[] Sort3(int[] Arr)
        {
            int[] _A = new int[Arr.Length];
            Arr.CopyTo(_A, 0);
            if (_A.Length <= 1)
            {
                return _A;
            }
            for (int j = 1; j < _A.Length; j++)
            {
                Print(_A);
                var i = j - 1;
                while (i >= 0)
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
            Print(_A);
            return _A;
        }
        public static void Sort4(int[] Arr, int h, int t)
        {
            if (Arr.Length > 1)
            {
                for (int j = h + 1; j <= t; j++)
                {
                    var i = j - 1;
                    var key = Arr[j];
                    while (i >= h && Arr[i] > key)
                    {
                        Arr[i + 1] = Arr[i];
                        i--;
                    }
                    Arr[i + 1] = key;
                }
            }
        }
        public static void Print(int[] Arr)
        {
            Console.WriteLine("--------------------");
            for (var i = 0; i < Arr.Length; i++)
            {
                Console.Write($"{Arr[i]} ");
            }
            Console.WriteLine("");
        }

        /*
         * 循环不变式
         * 
         * 初始化：循环的第一次迭代之前，它为真
         * 保持：如果荤菜的某次迭代之前它为真，那么下次迭代之前它仍为真。
         * 终止：在循环终止时，不变式为我们提供一个有用的性质，该性质有助于证明算法是正确的。
         */

        public static void Search(int[] Arr, int v)
        {
            int[] _A = new int[Arr.Length];
            Array.Copy(Arr, _A, Arr.Length);
            var i = 0;
            while (i < _A.Length && _A[i] != v)
            {
                i++;
            }
            if (i < _A.Length)
            {
                Console.WriteLine($"第{i + 1}个元素{_A[i]}");
            }
            else
            {
                Console.WriteLine($"v不在A中出现，是特殊值");
            }
        }
        public static void AddTwoArr(int[] A, int[] B)
        {
            Print(A);
            Print(B);
            if (A.Length < 1 || A.Length != B.Length)
            {
                Console.WriteLine("数据不符合条件");
            }
            int[] C = new int[A.Length + 1];
            var i = 0;
            var add = 0;
            while (i < A.Length)
            {
                var r = A[i] + B[i] + add;
                if (r > 1)
                {
                    r = r % 2;
                    add = 1;
                }
                else
                {
                    add = 0;
                }
                C[i] = r;
                i++;
            }
            C[i] = add;
            Console.WriteLine("结果");
            Print(C);
        }

        /// <summary>
        /// 选择排序
        /// </summary>
        /// <param name="Arr"></param>
        /// <returns></returns>
        public static int[] SelectedSort(int[] Arr)
        {
            /*
             * 找到最小的赋值第一个位置
             * 余下中找到最小的赋值第二个位置
             */
            int[] _A = (int[])Arr.Clone();
            Print(_A);
            for (int i = 0; i < _A.Length - 1; i++)   //c1*(n-1)
            {
                var key = _A[i];//c2*(n-1)
                var min = _A[i];//c3*(n-1)
                var minkey = i; //c4*(n-1)
                var j = i;  //c5*(n-1)
                while (j < _A.Length) //c6*（1到n）+****+ c6*(n-1到n)
                {
                    if (_A[j] < min)   //最好  0
                    {
                        min = _A[j];   //最差 c7*（1到n）+****+ c6*(n-1到n)
                        minkey = j;   //c8 *（1到n）+****+c6 * (n - 1到n)
                    }
                    j++;  //c9*（1到n）+****+ c6*(n-1到n)
                }
                _A[i] = min; //c10*(n-1)
                _A[minkey] = key; //c11*(n-1)
                Print(_A);
            }
            /*(c1+c2+c3+c4+c5+c10+c11)*n-(c1+c2+c3+c4+c5)+ (c6+c7+c8+c9)x1*n^2+x2*n-x3
             * 类型  n^2 + n +k;
             * 
             * 等差数列求和公式   Sn=na1+（n*（n-1）/2）*d
             * 
             */
            return _A;
        }


        /*
         * 分治法
         * 
         * 递归遵循分治法的思想，将问题分解为规模较小但类似于原问题，递归的求解子问题。
         * 
         * 步骤：分解   解决   合并
         * 
         * 归并排序法遵循分治模式
         * 
         */

        /// <summary>
        ///  归并 设置哨兵
        /// </summary>
        /// <param name="A"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <param name="r"></param>
        public static void Mergr(int[] A, int p, int q, int r)
        {
            var n1 = q - p + 1;
            var n2 = r - q;
            // int[] _A = new int[A.Length];
            int[] L = new int[n1 + 1];
            int[] R = new int[n2 + 1];
            for (int i = 0; i < n1; i++)
            {
                L[i] = A[p + i];
            }
            for (int j = 0; j < n2; j++)
            {
                R[j] = A[q + j + 1];
            }
            L[n1] = int.MaxValue;
            R[n2] = int.MaxValue;
            var a = 0;
            var b = 0;
            for (int k = p; k <= r; k++)
            {
                if (L[a] <= R[b])
                {
                    A[k] = L[a];
                    a++;
                }
                else
                {
                    A[k] = R[b];
                    b++;
                }
            }
            Print(A);
        }
        /// <summary>
        /// 归并  没有哨兵
        /// </summary>
        /// <param name="A"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <param name="r"></param>
        public static void MergrV2(int[] A, int p, int q, int r)
        {
            var n1 = q - p + 1;
            var n2 = r - q;
            // int[] _A = new int[A.Length];
            int[] L = new int[n1];
            int[] R = new int[n2];
            for (int i = 0; i < n1; i++)
            {
                L[i] = A[p + i];
            }
            for (int j = 0; j < n2; j++)
            {
                R[j] = A[q + j + 1];
            }
            var a = 0;
            var b = 0;
            for (int k = p; k <= r; k++)
            {
                if (a >= n1)
                {
                    A[k] = R[b];
                    b++;
                }
                else if (b >= n2)
                {
                    A[k] = L[a];
                    a++;
                }
                else if (L[a] <= R[b])
                {
                    A[k] = L[a];
                    a++;
                }
                else
                {
                    A[k] = R[b];
                    b++;
                }
            }
            Print(A);
        }
        /// <summary>
        /// 归并  并在小颗粒度上实现插入排序
        /// </summary>
        /// <param name="A"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <param name="r"></param>
        public static void Merge_SortV2(int[] A, int p, int r)
        {
            if (p < r)
            {
                if (r - p > 2)
                {
                    var q = (int)Math.Floor((p + r) / 2M);
                    Console.WriteLine($"p:{p}  r:{r}  q:{q}");
                    Merge_Sort(A, p, q);
                    Merge_Sort(A, q + 1, r);
                    MergrV2(A, p, q, r);
                }
                else
                {
                    Sort4(A, p, r);
                }
            }
        }


        public static void Merge_Sort(int[] A, int p, int r)
        {
            if (p < r)
            {
                var q = (int)Math.Floor((p + r) / 2M);
                Console.WriteLine($"p:{p}  r:{r}  q:{q}");
                Merge_Sort(A, p, q);
                Merge_Sort(A, q + 1, r);
                MergrV2(A, p, q, r);
            }
        }

        /// <summary>
        /// 二分查询
        /// </summary>
        /// <param name="A"></param>
        /// <param name="h"></param>
        /// <param name="t"></param>
        /// <param name="v"></param>
        public static void BinarySearch(int[] A, int h, int t, int v)
        {
            if (h < t)
            {
                var m = (int)Math.Floor((h + t) / 2M);
                if (A[m] == v)
                {
                    Console.WriteLine($"第{m}位是{v}");
                }
                else if (A[m] < v)
                {
                    BinarySearch(A, m + 1, t, v);
                }
                else
                {
                    BinarySearch(A, h, m, v);
                }
            }
            else
            {
                Console.WriteLine($"停止 h:{h} t:{t} 值:{A[h]}  {A[t]}   v:{v}");
            }

        }

        public static int c = 0;
        /// <summary>
        /// 查找逆序对
        /// </summary>
        public static void InversionSearch(int[] A, int p, int r)
        {
            if (p < r)
            {
                var q = (int)Math.Floor((p + r) / 2M);
                Console.WriteLine($"p:{p}  q:{q}   r:{r} ");
                InversionSearch(A, p, q);
                InversionSearch(A, q + 1, r);
                Mergr_InversionS(A, p, q, r);
            }
            Console.WriteLine(c);
            //return c;

        }
        public static void Mergr_InversionS(int[] A, int p, int q, int r)
        {

            var n1 = q - p + 1;
            var n2 = r - q;
            // int[] _A = new int[A.Length];
            int[] L = new int[n1];
            int[] R = new int[n2];
            for (int i = 0; i < n1; i++)
            {
                L[i] = A[p + i];
            }
            for (int j = 0; j < n2; j++)
            {
                R[j] = A[q + j + 1];
            }
            var a = 0;
            var b = 0;
            //Console.WriteLine($"p:{p}->q:{q}  a[{p}]:{A[p]}->a[{q+1}]:{A[q+1]}");
            //if (A[p] > A[q + 1])
            //{
            //    c += q - p + 1;
            //    Console.WriteLine($" c:{c}");
            //}
            for (int k = p; k <= r; k++)
            {
                //Console.WriteLine($"k:{k}->q:{q}  a[{k}]:{A[k]}->a[{q}]:{A[q]}     c:{c}");
                if (a >= n1)
                {
                    A[k] = R[b];
                    b++;
                }
                else if (b >= n2)
                {
                    A[k] = L[a];
                    a++;
                }
                else if (L[a] <= R[b])
                {
                    A[k] = L[a];
                    a++;
                }
                else
                {
                    A[k] = R[b];
                    b++;
                    c++;
                }
            }
        }


        public static Tuple<int, int, int> Find_Max_Crossing_Subarray(int[] A, int low, int mid, int high)
        {
            var left_sum = int.MinValue;
            var sum = 0;
            var max_left = mid;
            for (var i = mid; i >= low; i--)
            {
                sum = sum + A[i];
                if (sum > left_sum)
                {
                    left_sum = sum;
                    max_left = i;
                }
            }
            var right_sum = int.MinValue;
            sum = 0;
            var max_right = mid;
            for (var j = mid + 1; j <= high; j++)
            {
                sum = sum + A[j];
                if (sum > right_sum)
                {
                    right_sum = sum;
                    max_right = j;
                }
            }
            Console.WriteLine($"low{low} mid{mid} high{high} max_left:{max_left} max_right:{max_right} left_sum+right_sum:{left_sum + right_sum}");
            return new Tuple<int, int, int>(max_left, max_right, left_sum + right_sum);
        }

        public static Tuple<int, int, int> Find_MaxiNum_Subarray(int[] A, int low, int high)
        {
            if (high == low)
            {
                return new Tuple<int, int, int>(low, high, A[low]);
            }
            else
            {
                int mid = (int)Math.Floor((low + high) / 2M);
                var rl = Find_MaxiNum_Subarray(A, low, mid);
                int left_low = rl.Item1;
                int left_high = rl.Item2;
                int left_sum = rl.Item3;

                var rr = Find_MaxiNum_Subarray(A, mid + 1, high);
                int right_low = rr.Item1;
                var right_high = rr.Item2;
                var right_sum = rr.Item3;

                var rc = Find_Max_Crossing_Subarray(A, low, mid, high);
                var cross_low = rc.Item1;
                var cross_high = rc.Item2;
                var cross_sum = rc.Item3;

                if (left_sum >= right_sum && left_sum >= cross_sum)
                {
                    return new Tuple<int, int, int>(left_low, left_high, left_sum);
                }
                else if (right_sum >= left_sum && right_sum >= cross_sum)
                {
                    return new Tuple<int, int, int>(right_low, right_high, right_sum);
                }
                else
                {
                    return new Tuple<int, int, int>(cross_low, cross_high, cross_sum);
                }
            }
        }

        public static void Square_Martix_Multiply(int[,] A,int[,]B)
        {
            var n = A.Length;
            var c = new int[n,n];
            for(var i=0;i<n;i++)
            {
                for(var j=0;j<n;j++)
                {
                    c[i, i] = 0;
                    for(var k=0;k<n;k++)
                    {
                        c[i, j] = c[i, j] + A[i, j] * B[i, j];

                    }
                }
            }
        }
    }
}
