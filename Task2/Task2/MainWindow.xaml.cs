using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Task2.Library;

namespace Task2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<PolyLine> polylines { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            //LineDrawingManager ldm = new LineDrawingManager();

            polylines = new ObservableCollection<PolyLine>();
            LinesDrawer.ItemsSource = polylines;

            PolyLine l = new PolyLine(new Point[] { new Point(50, 110), new Point(200, 300), new Point(500, 450) });
           
            polylines.Add(l);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
