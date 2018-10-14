using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;


namespace Task2.Library
{
    public class LineDrawingManager
    {
        public ObservableCollection<PolyLine> polylines { get; set; }

        public LineDrawingManager()
        {
            polylines = new ObservableCollection<PolyLine>();
            PolyLine l = new PolyLine(new Point[] { new Point(50, 110), new Point(200, 300), new Point(500, 450) }, Brushes.Cyan);
            PolyLine b = new PolyLine(new Point[] { new Point(500, 110), new Point(200, 300), new Point(50, 450) }, Brushes.Black);
            polylines.Add(l);
            polylines.Add(b);
        }

        public void AddPl(Polyline line, Brush color)
        {
            PolyLine pl = new PolyLine(line.Points, color);
            polylines.Add(pl);
        }
        public void AddPl(Polyline line)
        {
            PolyLine pl = new PolyLine(line.Points);
            polylines.Add(pl);
        }
        public void AddPl(PolyLine line)
        {
            polylines.Add(line);
        }
    }
}
