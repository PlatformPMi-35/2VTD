using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task4.Controllers;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDBConnection()
        {
            Assert.IsTrue(DBUtils.TryConnect());
        }
    }
}
