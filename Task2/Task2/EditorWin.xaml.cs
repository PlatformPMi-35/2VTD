using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using Task2.Library;

namespace Task2
{
    /// <summary>
    /// Логика взаимодействия для EditorWin.xaml
    /// </summary>
    public partial class EditorWin : Window
    {
        bool DataChangedBrush;
        bool DataChangedPoints;

        PolyLine pl;

        public EditorWin(PolyLine p)
        {           
            InitializeComponent();
            pl = p;
            lst.ItemsSource = pl.pc;
            brush.DataContext = pl;
            DataChangedBrush = false;
            DataChangedPoints = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DataChangedBrush && !DataChangedPoints)
                {
                    pl.Brush = (Brush)new BrushConverter().ConvertFromString(brush.Text);
                }
                else if (!DataChangedBrush && DataChangedPoints)
                {
                    PointCollection points = new PointCollection();
                    foreach (var v in lst.Items)
                    {
                        points.Add((Point)v);
                    }
                    pl.pc = points;
                }
                else if (DataChangedBrush && DataChangedPoints)
                {
                    pl.Brush = (Brush)new BrushConverter().ConvertFromString(brush.Text);
                    PointCollection points = new PointCollection();
                    foreach (var v in lst.Items)
                    {
                        points.Add((Point)v);
                    }
                    pl.pc = points;
                }
                Close();
            }
            catch
            {
                MessageBox.Show("Not Valid Data!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           
        }

        private void brush_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(IsLoaded)
                DataChangedBrush = true;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (IsLoaded)
                DataChangedPoints = true;
        }
    }
}
