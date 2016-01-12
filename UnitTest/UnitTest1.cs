using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Getken;

namespace UnitTest
{
    [TestClass]
    public class Getken_UnitTest1
    {
        [TestMethod]
        public void TestMethod11()
        {
            CS_Getken getken = new CS_Getken();

            #region 対象：要素１つ
            getken.Clear();
            getken.Wbuf = @"Test";
            getken.Exec();

            Assert.AreEqual(1, getken.Wcnt, "Wcnt[1]");
            Assert.AreEqual("Test", getken.Array[0], "Arry[0] = [Test]");
            #endregion

            #region 対象：要素２つ
            getken.Clear();
            getken.Wbuf = @"Test Sample";
            getken.Exec();

            Assert.AreEqual(2, getken.Wcnt, "Wcnt[2]");
            Assert.AreEqual("Test", getken.Array[0], "Arry[0] = [Test]");
            Assert.AreEqual("Sample", getken.Array[1], "Arry[1] = [Sample]");
            #endregion

            #region 対象："This is a Pen."　その１
            getken.Clear();
            getken.Wbuf = @"This is a Pen.";
            getken.Exec();

            Assert.AreEqual(4, getken.Wcnt, "Wcnt[4]");
            Assert.AreEqual("This", getken.Array[0], "Arry[0] = [This]");
            Assert.AreEqual("is", getken.Array[1], "Arry[1] = [is]");
            Assert.AreEqual("a", getken.Array[2], "Arry[2] = [a]");
            Assert.AreEqual("Pen.", getken.Array[3], "Arry[3] = [Pen.]");
            #endregion

            #region 対象："This is a Pen."　その２
            getken.Clear();
            getken.Exec(@"This is a Pen.");

            Assert.AreEqual(4, getken.Wcnt, "Wcnt[4]");
            Assert.AreEqual("This", getken.Array[0], "Arry[0] = [This]");
            Assert.AreEqual("is", getken.Array[1], "Arry[1] = [is]");
            Assert.AreEqual("a", getken.Array[2], "Arry[2] = [a]");
            Assert.AreEqual("Pen.", getken.Array[3], "Arry[3] = [Pen.]");
            #endregion

            #region 対象："This is a Pen."　区切り”．”　その１
            char[] _trim = { '.' };
            getken.Clear();
            getken.Wbuf = @"This is a Pen.";
            getken.Exec(_trim);

            Assert.AreEqual(2, getken.Wcnt, "Wcnt[2]");
            Assert.AreEqual("This is a Pen", getken.Array[0], "Arry[0] = [This is a Pen]");
            Assert.AreEqual("", getken.Array[1], "Arry[1] = []");
            #endregion

            #region 対象："This is a Pen."　区切り”．”　その２
            getken.Clear();
            getken.Exec(@"This is a Pen.", _trim);

            Assert.AreEqual(2, getken.Wcnt, "Wcnt[2]");
            Assert.AreEqual("This is a Pen", getken.Array[0], "Arry[0] = [This is a Pen]");
            Assert.AreEqual("", getken.Array[1], "Arry[1] = []");
            #endregion
            //  FIXME : Splitを使用すると、区切り情報も要素として見る。
            //          区切り情報単体は排除する処理も追加する。
        }
    }
}
