using System;
using System.Collections.Generic;
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

        [TestMethod]
        public void TestExecute()
        {
            string request = "SELECT FirstName, LastName FROM Northwind.dbo.Employees WHERE BirthDate = (SELECT MIN(BirthDate) FROM Northwind.dbo.Employees)";
            string[] buff = { "FirstName;LastName;", "Margaret;Peacock;" };
            List<string> reqRes = new List<string>(buff);
            List<string> reqRes1 = DBUtils.Execute(request);

            if(reqRes.Count != reqRes1.Count)
            {
                Assert.Fail();
            }
            for (int i = 0; i < reqRes.Count; i++)
            {
                if (reqRes[i] != reqRes1[i])
                {
                    Assert.Fail();
                }
            }
            Assert.IsTrue(true);
        }
    }
}
