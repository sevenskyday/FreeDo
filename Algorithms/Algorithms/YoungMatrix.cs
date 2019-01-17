using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    public class YoungMatrix
    {
        private int m { get; set; }
        private int n { get; set; }
        private int?[,] mtrix { get; set; }
        public void Create(int M, int N)
        {
            m = M;
            n = N;
            mtrix = new int?[m, n];
        }
        public bool IsNull()
        {
            if (m >= 1 && n >= 1)
            {
                if (mtrix[1, 1] == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        public bool IsFull()
        {
            if (m >= 1 && n >= 1)
            {
                if (mtrix[m, n] != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public int? Extract_Min()
        {
            if (IsNull())
            {
                return null;
            }

            return 0;
        }
        public int? Extract_Max()
        {
            return 0;
        }
    }
}
