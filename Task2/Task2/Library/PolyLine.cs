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
        private Brush brush;
        public PointCollection pc { get; private set; }
        public Brush Brush
        {
            get
            {
                return brush ?? Brushes.Black;
            }
            set
            {
                try
                {
                    brush = value;
                }
                catch
                {
                    throw new ArgumentException("Invalid Brush Argument");
                }
            }
        }

        public PolyLine(IEnumerable<Point> points, Brush brush)
        {
            this.pc = new PointCollection();
            foreach (var p in points)
            {
                this.pc.Add(p);
            }
            this.Brush = brush;
                      
        }
        public PolyLine(IEnumerable<Point> points) : this(points, null) { }

        
        public void AddPoint(Point p)
        {
            try
            {
                pc.Add(p);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
