using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Task2.Library
{
    public class PolyLine
    {
        public List<Point> points;
        public Color color;
        
        public PolyLine(IEnumerable<Point> points, Color color)
        {
            this.points = new List<Point>(points);
            this.color = color;
        }

        public PolyLine(IEnumerable<Point> points) : this(points, Color.FromRgb(255, 255, 255)) { }
        public PolyLine() : this(null, Color.FromRgb(255, 255, 255)) { }

    }
}
