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
        LineDrawingManager drawingManager;
        public MainWindow()
        {
            InitializeComponent();
            drawingManager = new LineDrawingManager();
            LinesDrawer.ItemsSource = drawingManager.polylines;
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
