using System;
using System.Linq;
using System.Collections.Generic;
using NetworkData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NetworkData.Tests
{
    [TestClass]
    public class DataTest
    {
        [TestMethod]
        public void TestSplit()
        {
            byte[] meanless = (from i in Enumerable.Range(0, 1024)
                               select (byte)i).ToArray();
            Assert.IsTrue(Enumerable.SequenceEqual(meanless, Data.Combine(Data.SplitToDatas(meanless, 0))));
        }

        [TestMethod]
        public void TestCombine()
        {
            byte[] meanless = (from i in Enumerable.Range(0, 5000)
                               select (byte)i).ToArray();
            var datas = Data.SplitToDatas(meanless, 0);
            var combined = Data.Combine(datas);
            Assert.IsTrue(Enumerable.SequenceEqual(meanless, combined));
        }
    }
}
