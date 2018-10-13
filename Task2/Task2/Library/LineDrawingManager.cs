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
    class LineDrawingManager
    {
        public ObservableCollection<PolyLine> polyLines;

        public LineDrawingManager()
        {
            polyLines = new ObservableCollection<PolyLine>();

        }

        //public void CreatePL(Polyline line, Color color)
        //{
        //    PolyLine pl = new PolyLine(line, color);
        //    polyLines.Add(pl);
        //}
        //public void CreatePL(Polyline line)
        //{
        //    PolyLine pl = new PolyLine(line);
        //    polyLines.Add(pl);
        //}
    }
}
