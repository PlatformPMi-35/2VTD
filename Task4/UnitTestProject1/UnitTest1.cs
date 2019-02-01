using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task4.Controllers;
/// <summary>
/// This class is for testing our program
/// </summary>
namespace UnitTestProject1
{
    [TestClass]
    public class TestDBUtils
    {
        /// <summary>
        /// This Test method testing if the connection was established 
        /// </summary>
        [TestMethod]
        public void TestDBConnection()
        {
            Assert.IsTrue(DBUtils.TryConnect());
        }
        /// <summary>
        /// This Test method testing main functionality of app
        /// </summary>
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
    /// <summary>
    ///  This Test method testing if the data was saved to database
    /// </summary>
    [TestClass]
    public class TestIOController
    {
        [TestMethod]
        public void TestSaveLoad()
        {
            string str1 = "hello";
            string str2 = "word";

            List<string> buff = new List<string>();
            buff.Add(str1);
            buff.Add(str2);

            IOController.SerializeTo(@"../../test.xml", buff);

            List<string> l = IOController.Load(@"../../test.xml");
            Assert.IsTrue(l[0] == str1 && l[1] == str2);
        }
    }
}
