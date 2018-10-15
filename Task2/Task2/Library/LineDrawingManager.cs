namespace Task2.Library
{
    using System.Collections.ObjectModel;
    using System.Windows.Media;
    using System.Windows.Shapes;

    public class LineDrawingManager
    {
        public LineDrawingManager()
        {
            this.Polylines = new ObservableCollection<PolyLine>();           
        }

        public ObservableCollection<PolyLine> Polylines { get; set; }

        public void AddPl(Polyline line, Brush color)
        {
            PolyLine pl = new PolyLine(line.Points, color);
            this.Polylines.Add(pl);
        }

        public void AddPl(Polyline line)
        {
            PolyLine pl = new PolyLine(line.Points);
            this.Polylines.Add(pl);
        }

        public void AddPl(PolyLine line)
        {
            this.Polylines.Add(line);
        }
    }
}
