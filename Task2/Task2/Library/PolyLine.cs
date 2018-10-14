using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Task2.Library
{
    public class PolyLine
    {
        public Polyline line;
        public Color color { get; set; }
        public PointCollection pc { get; set; }



        public PolyLine(IEnumerable<Point> points, Color color)
        {
            this.line = new Polyline();
            this.pc = new PointCollection();
            foreach (var p in points)
            {
                this.pc.Add(p);
            }
            this.color = color;
        }
        public PolyLine(IEnumerable<Point> points) : this(points, (Color)ColorConverter.ConvertFromString("Black")) { }

        
        public void AddPoint(Point p)
        {
            try
            {
                line.Points.Add(p);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
