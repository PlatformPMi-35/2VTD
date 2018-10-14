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
        PolyLine pl;
        public EditorWin(PolyLine p)
        {           
            InitializeComponent();
            pl = p;
            lst.ItemsSource = pl.pc;
            brush.DataContext = pl;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
