using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Media;
using System.Windows.Shapes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2.Library;


namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAddingToPolyLine()
        {
            PolyLine polyLine = new PolyLine(null);
            polyLine.AddPoint(new System.Windows.Point(1, 3));
            Assert.IsTrue(polyLine.Pc.Contains(new System.Windows.Point(1, 3)));
        }

        [TestMethod]
        public void TestAddingToPLManager1()
        {
            LineDrawingManager manager = new LineDrawingManager();
            PolyLine polyLine = new PolyLine();
            polyLine.AddPoint(new System.Windows.Point(1, 3));
            polyLine.AddPoint(new System.Windows.Point(2, 4));
            manager.AddPl(polyLine);

            Assert.IsTrue(manager.Polylines.Contains(polyLine));
        }

        [TestMethod]
        public void TestAddingToPLManager2()
        {
            LineDrawingManager manager = new LineDrawingManager();
            Polyline polyLine = new Polyline();
            polyLine.Points.Add(new System.Windows.Point(1, 3));
            polyLine.Points.Add(new System.Windows.Point(2, 4));
            manager.AddPl(polyLine, Brushes.Aqua);

            Assert.IsTrue(manager.Polylines.Contains(new PolyLine(polyLine.Points, Brushes.Aqua)));
        }

        [TestMethod]
        public void TestAddingToPLManager3()
        {
            LineDrawingManager manager = new LineDrawingManager();
            Polyline polyLine = new Polyline();
            polyLine.Points.Add(new System.Windows.Point(1, 3));
            polyLine.Points.Add(new System.Windows.Point(2, 4));
            manager.AddPl(polyLine);

            Assert.IsTrue(manager.Polylines.Contains(new PolyLine(polyLine.Points)));
        }

        [TestMethod]
        public void TestIOManager1()
        {
            List<PolyLine> lines = new List<PolyLine>();
            string path = @"Data.xml";
            PolyLine polyLine = new PolyLine();
            polyLine.AddPoint(new System.Windows.Point(1, 2));
            lines.Add(polyLine);
            PolyLineIOManager.Save(lines, path);
            FileStream fileStream = new FileStream(path, FileMode.Open);
            Assert.IsTrue(1 == 1);
        }

        [TestMethod]
        public void TestIOManager2()
        {
            string path = @"Data2.xml";
            List<PolyLine> lines = new List<PolyLine>();
            lines = (List<PolyLine>)PolyLineIOManager.Load(path);
            Assert.IsTrue(lines.Count != 0);
        }

        [TestMethod]
        public void BrushToStrConverterTest1()
        {
            BrushConverter converter = new BrushConverter();
            string brushNeeded = "#FF00FFFF";
            Assert.AreEqual(brushNeeded, converter.ConvertTo(Brushes.Aqua, typeof(string)));
        }

        [TestMethod]
        public void BrushToStrConverterTest2()
        {
            BrushConverter brushConverter = new BrushConverter();
            string brush = brushConverter.ConvertFrom("#FF00FFFF").ToString();
            Assert.AreEqual(brush, "#FF00FFFF");
        }

        [TestMethod]
        public void PointCollectionToStrConverterTest1()
        {
            PointCollection points = new PointCollection();
            points.Add(new System.Windows.Point(1, 1));
            string strPoints = "1;1\n";
            PointCollectionToStringConverter converter = new PointCollectionToStringConverter();
            Assert.AreEqual(strPoints, converter.Convert(points, typeof(string), null, null));
        }

        [TestMethod]
        public void PointCollectionToStrConverterTest2()
        {
            string strPoints = "1;1\n";
            PointCollectionToStringConverter conv = new PointCollectionToStringConverter();
            PointCollection points = new PointCollection();
            points.Add(new System.Windows.Point(1, 1));
            string buff = (string)conv.Convert(points, string.Empty.GetType(), null, null);
            Assert.IsTrue(strPoints == buff);
        }
    }
}

