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
