using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2.Library;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Shapes;

namespace UnitTests
{
    [TestClass]
    public class PolyLineTests
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

        }

        [TestMethod]
        public void TestIOManager2()
        {

        }

        [TestMethod]
        public void BrushToStrConverterTest()
        {

        }

        [TestMethod]
        public void PointCollectionToStrConverterTest()
        {

        }
    }
}
