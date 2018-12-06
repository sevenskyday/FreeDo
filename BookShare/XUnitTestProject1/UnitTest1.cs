using System;
using System.Diagnostics;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Debug.WriteLine("look here!");
            Console.WriteLine("look here!");
            Assert.True(false);
        }
    }
}
