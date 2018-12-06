using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Debug.WriteLine("look there!");
            Console.WriteLine("look here!");
        }
        #region queens
        [TestMethod]
        public void TestQueenMethod()
        {
            //皇后
            var queens = new List<Queen>();
            var chass = new List<Pos>();
            //棋盘大小
            var size = 8;
            //皇后个数
            var count = 4;
            //初始化棋盘
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    chass.Add(new Pos() { x = i, y = j, isSafe = true });
                }
            }
            for (int i = 0; i < size; i++)
            {
                queens.Add(new Queen() { x = i, y = 0 });
                chass = ResetBoard(chass, queens);
                while (queens.Count < size && chass.Any(x => x.isSafe))
                {
                    var f = chass.FirstOrDefault(x => x.isSafe);
                    queens.Add(new Queen() { x = f.x, y = f.y });
                    chass = ResetBoard(chass, queens);
                }
                if (queens.Count == size)
                {
                    print(queens, size);
                }
                queens.Clear();
                foreach (var item in chass)
                {
                    item.isQueen = false;
                    item.isSafe = true;
                }
            }

        }

        private void print(List<Queen> qs, int size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (qs.Any(x => x.x == i && x.y == j))
                    {
                        Console.Write("Q   ");
                    }
                    else
                    {
                        Console.Write("*   ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("--------------------------------------");
        }
        private List<Pos> ResetBoard(List<Pos> ps, List<Queen> qs)
        {
            foreach (var q in qs)
            {
                foreach (var p in ps)
                {
                    if (q.x == p.x || q.y == p.y || Math.Abs(q.x - p.x) == Math.Abs(q.y - p.y))
                    {
                        p.isSafe = false;
                    }
                    if (q.x == p.x && q.y == p.y)
                    {
                        p.isQueen = true;
                    }
                }
            }
            return ps;
        }
        private void place(List<Queen> qs, int size)
        {
            if (qs.Count < size)
            {
                for (var i = 0; i < size; i++)
                {
                    if (qs.Count == 0)
                    {
                        qs.Add(new Queen() { x = i, y = 0 });
                    }
                    else
                    {
                        foreach (var a in qs)
                        {

                        }
                    }
                }
            }
        }
        private bool IsAttack(Queen a, int x, int y)
        {
            if (a.x == x)
            {
                //同一水平位置
                return true;
            }
            else if (Math.Abs(a.x - x) == Math.Abs(a.y - y))
            {
                return true;
            }
            return false;
        }
        public class Queen
        {
            public int x { get; set; }
            public int y { get; set; }
        }
        public class Pos
        {
            public int x { get; set; }
            public int y { get; set; }
            public bool isSafe { get; set; }
            public bool isQueen { get; set; }
        }

        #endregion

        #region  insertion-sort
        [TestMethod]
        public void TestMethod2()
        {
            var x = new int[6] { 31, 41, 59, 26, 41, 58 };
            var list = insertion_sort(x);
            printInt(list);
        }
        private int[] insertion_sort(int[] A)
        {
            for (var i = 1; i < A.Length; i++)
            {
                var v = A[i];
                var j = i - 1;
                while (j > 0 && A[j] > v)
                {
                    A[j + 1] = A[j];
                    j = i - 1;
                    A[j + 1] = v;
                }  
            }
            return A;
        }
        private void printInt(int[] A)
        {
            foreach(var i in A)
            {
                Console.WriteLine(i);
            }
        }
        #endregion
    }
}
