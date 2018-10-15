namespace Task2.Library
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Media;

    public class PolyLine
    {
        private Brush brush;

        public PolyLine(IEnumerable<Point> points, Brush brush = null) : this(brush)
        {
            this.Pc = this.Pc ?? new PointCollection();
            foreach (var p in points)
            {
                this.Pc.Add(p);
            }
        }

        public PolyLine(Brush brush = null)
        {
            this.Pc = this.Pc ?? new PointCollection();
            this.Brush = brush;
        }

        public PointCollection Pc { get; set; }

        public Brush Brush
        {
            get
            {
                return this.brush ?? Brushes.Black;
            }

            set
            {
                try
                {
                    this.brush = value;
                }
                catch
                {
                    throw new ArgumentException("Invalid Brush Argument");
                }
            }
        }

        public void AddPoint(Point p)
        {
            try
            {
                this.Pc.Add(p);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override string ToString()
        {
            return this.Brush.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj is PolyLine)
            {
                bool isCorrect = true;
                PolyLine pl = obj as PolyLine;
                isCorrect = pl.Brush == this.Brush;
                for (int i = 0; i < this.Pc.Count() && i < pl.Pc.Count(); i++)
                {
                    isCorrect = this.Pc[i] == pl.Pc[i];
                }

                return true;
            }
            else
            {
                return base.Equals(obj);
            }
        }
    }
}
