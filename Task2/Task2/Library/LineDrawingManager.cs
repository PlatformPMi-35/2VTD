namespace Task2.Library
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Media;
    using System.Windows.Shapes;

    /// <summary>
    /// Represents Model_View part of pattern.
    /// </summary>
    public class LineDrawingManager
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LineDrawingManager"/> class.
        /// </summary>
        public LineDrawingManager()
        {
            this.Polylines = new ObservableCollection<PolyLine>();           
        }

        /// <summary>
        /// Gets or sets <see cref="ObservableCollection"/> .
        /// </summary>
        /// <value><see cref="ObservableCollection{T}"/> of <see cref="PolyLine"/>s.</value>
        public ObservableCollection<PolyLine> Polylines { get; set; }

        /// <summary>
        /// Adds <see cref="PolyLine"/> to <see cref="ObservableCollection{PolyLine}"/>
        /// </summary>
        /// <param name="line"><see cref="Polyline"/> to add.</param>
        /// <param name="color"><see cref="Brush"/>(Color) to draw.</param>
        public void AddPl(Polyline line, Brush color)
        {
            PolyLine pl = new PolyLine(line.Points, color);
            this.Polylines.Add(pl);
        }

        /// <summary>
        /// Creates and Adds <see cref="PolyLine"/> to <see cref="ObservableCollection{PolyLine}"/>.
        /// </summary>
        /// <param name="line"><see cref="Polyline"/> to add.</param>
        public void AddPl(Polyline line)
        {
            PolyLine pl = new PolyLine(line.Points);
            this.Polylines.Add(pl);
        }

        /// <summary>
        /// Add <see cref="PolyLine"/> to <see cref="ObservableCollection{PolyLine}"/>
        /// </summary>
        /// <param name="line"><see cref="PolyLine"/> to add.</param>
        public void AddPl(PolyLine line)
        {
            this.Polylines.Add(line);
        }
    }
}
