namespace Task2
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using Microsoft.Win32;
    using Task2.Library;

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            this.DrawingManager = new LineDrawingManager();
            this.LinesDrawer.ItemsSource = this.DrawingManager.Polylines;
            this.List.ItemsSource = this.DrawingManager.Polylines;
            this.editButton.IsEnabled = false;
            this.doneButton.Visibility = Visibility.Hidden;
            this.CreationModeOn = false;
        }

        public LineDrawingManager DrawingManager { get; set; }

        public bool CreationModeOn { get; set; }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            this.CreationModeOn = false;
            this.doneButton.Visibility = Visibility.Hidden;
            this.editButton.IsEnabled = true;
        }

        private void List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.List.SelectedIndex != -1)
            {
                this.editButton.IsEnabled = true;
            }
            else
            {
                this.editButton.IsEnabled = false;
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.List.SelectedIndex != -1)
            {
                EditorWin editorWin = new EditorWin(this.DrawingManager.Polylines[this.List.SelectedIndex]);
                editorWin.ShowDialog();
                this.List.Items.Refresh();
                this.LinesDrawer.Items.Refresh();
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
                this.DrawingManager.AddPl(pl);
            }
        }

        private void Save_as_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            List<PolyLine> newLines = new List<PolyLine>();
            if (saveFileDialog.ShowDialog() == true)
            {
                PolyLineIOManager.Save(this.DrawingManager.Polylines, saveFileDialog.FileName);
            }
        }

        private void Canvas_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (this.CreationModeOn)
            {
                Point p = Mouse.GetPosition(this);
                if (p != null)
                {
                    this.DrawingManager.Polylines.Last().AddPoint(p);
                }
            }
            else
            {
                PolyLine pl = new PolyLine();
                Point p = Mouse.GetPosition(this);
                if (p != null)
                {
                    pl.AddPoint(p);
                    this.CreationModeOn = true;
                }

                this.DrawingManager.AddPl(pl);
                this.doneButton.Visibility = Visibility.Visible;
                this.editButton.IsEnabled = false;
            }

            this.List.SelectedIndex = this.List.Items.Count - 1;
            this.List.Items.Refresh();
            this.LinesDrawer.Items.Refresh();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.CreationModeOn)
            {
                this.DrawingManager.Polylines.RemoveAt(this.DrawingManager.Polylines.Count - 1);
                this.ButtonAdd_Click(sender, e);
            }
            else if (!this.CreationModeOn && this.List.SelectedIndex != -1)
            {
                this.DrawingManager.Polylines.RemoveAt(this.List.SelectedIndex);
            }

            this.List.Items.Refresh();
            this.LinesDrawer.Items.Refresh();
        }
    }
}
