using ChainingProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PracticeTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(3,Class1.Add(1,2));
        }

        [TestMethod]
        [ExpectedException(typeof(inputException))]
        public void 例外テスト()
        {
            Assert.AreEqual(3, Class1.Add(-1, 2));
        }

        [TestMethod]
        public void TestMethod2()
        {
            //ISメソッドを使うことで言語的に自然に見やすくかける
            Class1.Add(1, 2).Is(3);

            //戻り値を比較できる
            var ex = AssertEx.Throws<inputException>(() => Class1.Add(-1, 2));
            Assert.AreEqual("マイナス値は入力できない", ex.Message);
        }
    }
}
