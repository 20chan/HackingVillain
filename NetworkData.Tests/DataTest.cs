using System;
using System.Linq;
using System.Collections.Generic;
using NetworkData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NetworkData.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSplit()
        {
            byte[] meanless = new byte[1024];
            Array.Copy(meanless, Enumerable.Range(0, 1024).ToArray(), 1024);

            Assert.IsTrue(Enumerable.SequenceEqual(meanless, Data.Combine(Data.SplitToDatas(meanless, 0))));
        }

        [TestMethod]
        public void TestCombine()
        {
            byte[] meanless = new byte[10000];
            Array.Copy(meanless, Enumerable.Range(0, 1000).ToArray(), 10000);

            Assert.IsTrue(Enumerable.SequenceEqual(meanless, Data.Combine(Data.SplitToDatas(meanless, 0))));
        }
    }
}
