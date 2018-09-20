namespace UnitTestProject1
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using FirstTask.Library;
    using System.Linq;
    

    [TestClass]
    public class UnitTest1
    {
        private static string path = @"..\..\..\FirstTask\FirstTask\Data\TextFile.txt";

        [TestMethod]
        public void Task1()
        {
            FirstTask.Library.Menu menu = new FirstTask.Library.Menu();
            SortedList<int, Triangle> SortedTriangles = menu.FirstTask(path);
            IList<Triangle> lst = SortedTriangles.Values;
            Triangle[] triangles = new Triangle[SortedTriangles.Count];
            lst.CopyTo(triangles, 0);
            bool isCorrect = true;
            for (int i=1; i<SortedTriangles.Count; i++)
            {
                isCorrect = triangles[i - 1].GetPerim() < triangles[i].GetPerim();
            }
            Assert.IsTrue(isCorrect);
        }

        [TestMethod]
        public void Task2()
        {
            Dictionary<Color, int> dict = new Dictionary<Color, int>();
            dict.Add(Color.Yelow, 1);
            dict.Add(Color.Green, 2);
            Menu m = new Menu();
            Dictionary<Color, int> testD = m.SecondTask(path);
            Assert.IsTrue(dict.Count == testD.Count && !dict.Except(testD).Any());


        }

        [TestMethod]
        public void Task3()
        {
            FirstTask.Library.Menu menu = new FirstTask.Library.Menu();
            bool isCorrect = true;
            foreach (var v in menu.ThirdTask(path))
            {
                //isCorrect = v.GetSides()[0].Color == v.GetSides()[1].Color && v.GetSides()[0].Color == v.GetSides()[2].Color;
                isCorrect = v.GetSides()[0].Color == v.GetSides()[1].Color;
                isCorrect = v.GetSides()[0].Color == v.GetSides()[2].Color;
            }
            Assert.IsTrue(isCorrect);
        }
    }
}
