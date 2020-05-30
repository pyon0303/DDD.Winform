using System;
using DDD.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DDDTest.Tests
{
    [TestClass]
    public class TemparatureTest
    {
        [TestMethod]
        public void 小数点以下2桁でまるめて表示できる()
        {
            var t = new Temparature(12.3f);
            Assert.AreEqual(12,3f, t.Value);
            Assert.AreEqual("12.30 ℃", t.DisplayValueWithUnit);

        }

        [TestMethod]
        public void 温度Equals()
        {
            var t1 = new Temparature(12.3f);
            var t2 = new Temparature(12.3f);
            Assert.AreEqual(true, t1.Equals(t2));
        }

        [TestMethod]
        public void 温度EqualEqual()
        {
            var t1 = new Temparature(12.3f);
            var t2 = new Temparature(12.3f);
            Assert.AreEqual(true, t1 == t2);
        }
    }
}
