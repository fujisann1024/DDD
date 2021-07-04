using DDD.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DDDTest.Tests
{
    [TestClass]
    public class TemperatureTest
    {
        [TestMethod]
        public void 小数点以下2桁で丸めて表示できる()
        {
            //完全コンストラクタ
            var t = new Temperature(12.3f);
            Assert.AreEqual(12.3f, t.Value);
            //画面に表示させる
            Assert.AreEqual("12.30",t.DisplayValue);
            Assert.AreEqual("12.30℃",t.DisplayValueWithUnit);
            Assert.AreEqual("12.30 ℃",t.DisplayValueWithUnitSpace);
        }

        [TestMethod]
        public void 温度Equalsテスト()
        {
            var t1 = new Temperature(12.3f);
            var t2 = new Temperature(12.3f);

            Assert.AreEqual(true, t1.Equals(t2));
            Assert.AreEqual(true, t1 == t2);
            
        }

        [TestMethod]
        public void 値型テスト()
        {
            float t1 = 12.3f;
            float t2 = 12.3f;

            Assert.AreEqual(true, t1.Equals(t2));

        }
    }
}
