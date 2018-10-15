namespace Task2.Library
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Windows;
    using System.Windows.Media;
   
    /// <summary>
    /// Class represents Polyline with Color.
    /// </summary>
    [DataContract]
    public class PolyLine
    {
        /// <summary>
        /// Color of the Line.
        /// </summary>
        private Brush brush;

        /// <summary>
        /// Initializes a new instance of the <see cref="PolyLine" /> class.
        /// </summary>
        /// <param name="points"><see cref="IEnumerable{T}"/> of <see cref="Point"/>.</param>
        /// <param name="brush"><see cref="System.Windows.Media.Brush"/> (Color) of <see cref="PolyLine"/>.</param>
        public PolyLine(IEnumerable<Point> points, Brush brush = null) : this(brush)
        {
            try
            {
                this.Pc = this.Pc ?? new PointCollection();
                foreach (var p in points)
                {
                    this.Pc.Add(p);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PolyLine" /> class.
        /// </summary>
        /// <param name="brush"><see cref="System.Windows.Media.Brush"/> (Color) of <see cref="PolyLine"/>.</param>
        public PolyLine(Brush brush = null)
        {
            try
            {
                this.Pc = this.Pc ?? new PointCollection();
                this.Brush = brush;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets or sets <see cref="PointCollection"/> for <see cref="PolyLine"/>.
        /// </summary>
        /// <value><see cref="PointCollection"/> for <see cref="PolyLine"/>.</value>
        [DataMember]
        public PointCollection Pc { get; set; }

        /// <summary>
        /// Gets or sets <see cref="System.Windows.Media.Brush"/> for <see cref="PolyLine"/>.
        /// </summary>
        /// <value><see cref="System.Windows.Media.Brush"/> for <see cref="PolyLine"/>.
        /// </value>
        [DataMember]
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

        /// <summary>
        /// Add <see cref="Point"/> to <see cref="PolyLine"/>.
        /// </summary>
        /// <param name="p"><see cref="Point"/> for <see cref="PolyLine"/>.</param>
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

        /// <summary>
        /// Gets <see cref="String"/> version of <see cref="System.Windows.Media.Brush"/>
        /// </summary>
        /// <returns><see cref="String"/> version of <see cref="System.Windows.Media.Brush"/></returns>
        public override string ToString()
        {
            return this.Brush.ToString();
        }

        /// <summary>
        /// Checks if <see cref="PolyLine"/>s are Equal.
        /// </summary>
        /// <param name="obj"><see cref="PolyLine"/> to check with.</param>
        /// <returns>Are <see cref="PolyLine"/>s Equal.</returns>
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
