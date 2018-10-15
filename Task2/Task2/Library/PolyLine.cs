using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Task2.Library
{
    [DataContract]
    public class PolyLine
    {       
        private Brush brush;
        [DataMember]
        public PointCollection pc { get; set; }
        [DataMember]
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

        public PolyLine(IEnumerable<Point> points, Brush brush = null) : this(brush)
        {
            this.pc = pc ?? new PointCollection();
            foreach (var p in points)
            {
                this.pc.Add(p);
            }
        }
        //public PolyLine(IEnumerable<Point> points) : this(points, null) { }
        public PolyLine(Brush brush = null)
        {
            this.pc= pc ?? new PointCollection();
            this.Brush = brush;
        }

        public void AddPoint(Point p)
        {
            try
            {
                this.pc.Add(p);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override string ToString()
        {
            return Brush.ToString();
        }

        public override bool Equals(object obj)
        {
            if(obj is PolyLine)
            {
                bool isCorrect = true;
                PolyLine pl = obj as PolyLine;
                isCorrect = pl.Brush == Brush;
                for (int i = 0; i < pc.Count() && i < pl.pc.Count(); i++)
                {
                    isCorrect = pc[i] == pl.pc[i];
                }

                return true;
            }
            else
            return base.Equals(obj);
        }

      
    }
}
