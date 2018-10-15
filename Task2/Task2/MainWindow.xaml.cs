using Microsoft.Win32;
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
        bool creationModeOn = false;

        public MainWindow()
        {
            InitializeComponent();
            drawingManager = new LineDrawingManager();        
            LinesDrawer.ItemsSource = drawingManager.polylines;
            List.ItemsSource = drawingManager.polylines;
            editButton.IsEnabled = false;
            doneButton.Visibility = Visibility.Hidden;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            creationModeOn = false;
            doneButton.Visibility = Visibility.Hidden;
            editButton.IsEnabled = true;
        }

        private void List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (List.SelectedIndex != -1)
            {
                editButton.IsEnabled = true;
            }
            else
            {
                editButton.IsEnabled = false;
            }
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            if (List.SelectedIndex != -1)
            {
                EditorWin editorWin = new EditorWin(drawingManager.polylines[List.SelectedIndex]);
                editorWin.ShowDialog();
                List.Items.Refresh();
                LinesDrawer.Items.Refresh();
            }
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            List<PolyLine> newLines = new List<PolyLine>();
            if (openFileDialog.ShowDialog() == true)
            {
                newLines = PolyLineIOManager.Load(openFileDialog.FileName).ToList();
            }

            foreach (PolyLine pl in newLines)
            {
                drawingManager.AddPl(pl);
            }
        }

        private void Save_as_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            List<PolyLine> newLines = new List<PolyLine>();
            if (saveFileDialog.ShowDialog() == true)
            {
                PolyLineIOManager.Save(drawingManager.polylines, saveFileDialog.FileName);
            }
        }

        private void Canvas_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (creationModeOn)
            {         
                Point p = Mouse.GetPosition(this);
                if (p != null)
                    drawingManager.polylines.Last().AddPoint(p);
            }
            else
            {
                PolyLine pl = new PolyLine();                
                Point p = Mouse.GetPosition(this);
                if (p != null)
                {
                    pl.AddPoint(p);
                    creationModeOn = true;
                }
                drawingManager.AddPl(pl);
                doneButton.Visibility = Visibility.Visible;
                editButton.IsEnabled = false;
            }
            List.SelectedIndex = List.Items.Count-1;
            List.Items.Refresh();
            LinesDrawer.Items.Refresh();
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            if(creationModeOn)
            {
                drawingManager.polylines.RemoveAt(drawingManager.polylines.Count - 1);
                ButtonAdd_Click(sender, e);
            }
            else if(!creationModeOn && List.SelectedIndex!=-1)
            {
                drawingManager.polylines.RemoveAt(List.SelectedIndex);
            }            
            List.Items.Refresh();
            LinesDrawer.Items.Refresh();
        }
    }
}
