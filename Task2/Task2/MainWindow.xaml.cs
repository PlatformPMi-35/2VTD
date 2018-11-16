namespace Task2
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Shapes;
    using Microsoft.Win32;
    using Task2.Library;

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool editModeOn = false;
        private Point trigerPoint;
        private PointCollection tpc;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
            //тут вказуєм до чого прив'язуємся  
            this.DrawingManager = new LineDrawingManager();
            this.LinesDrawer.ItemsSource = this.DrawingManager.Polylines;//тут ми вказуємо звідки будемо відображати ламані(з this.DrawingManager.Polylines)
            this.List.ItemsSource = this.DrawingManager.Polylines;
            this.editButton.IsEnabled = false;
            this.doneButton.Visibility = Visibility.Hidden;
            this.CreationModeOn = false;
        }

        /// <summary>
        /// Gets or sets <see cref="LineDrawingManager"/>.
        /// </summary>
        /// <value><see cref="LineDrawingManager"/>.</value>
        public LineDrawingManager DrawingManager { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether <see cref="CreationModeOn"/>.
        /// </summary>
        /// <value><see cref="bool"/>.</value>
        public bool CreationModeOn { get; set; }

        /// <summary>
        /// Click on button.
        /// </summary>
        /// <param name="sender">Just Object.</param>
        /// <param name="e">RoutedEventArgs e.</param>
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Click to stop adding <see cref="Point"/> to <see cref="PolyLine"/>.
        /// </summary>
        /// <param name="sender">Just Object.</param>
        /// <param name="e">RoutedEventArgs e.</param>
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            this.CreationModeOn = false;
            this.doneButton.Visibility = Visibility.Hidden;
            this.editButton.IsEnabled = true;
        }

        /// <summary>
        /// On List index chaged.
        /// </summary>
        /// <param name="sender">Just Object.</param>
        /// <param name="e">SelectionChangedEventArgs e.</param>
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

        /// <summary>
        /// EditButton Click.
        /// </summary>
        /// <param name="sender">Just Object.</param>
        /// <param name="e">RoutedEventArgs e.</param>
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

        /// <summary>
        /// Open Click.
        /// </summary>
        /// <param name="sender">Just Object.</param>
        /// <param name="e">RoutedEventArgs e.</param>
        private void Open_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "XML file|*.xml";

                List<PolyLine> newLines = new List<PolyLine>();
                if (openFileDialog.ShowDialog() == true)
                {
                    newLines = PolyLineIOManager.Load(openFileDialog.FileName).ToList();
                }

                this.DrawingManager.Polylines.Clear();
                foreach (PolyLine pl in newLines)
                {
                    this.DrawingManager.AddPl(pl);
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("File Not Found");
            }
            catch (Exception)
            {
                MessageBox.Show("Open File Error");
            }
        }

        /// <summary>
        /// Save as Click.
        /// </summary>
        /// <param name="sender">Just Object.</param>
        /// <param name="e">RoutedEventArgs e.</param>
        private void Save_as_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "XML file|*.xml";
                List<PolyLine> newLines = this.DrawingManager.Polylines.ToList();
                if (saveFileDialog.ShowDialog() == true)
                {
                    PolyLineIOManager.Save(newLines, saveFileDialog.FileName);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Save File Error");
            }
        }

        // додавання нових точок
        /// <summary>
        /// Canvas MouseRightButtonDown.
        /// </summary>
        /// <param name="sender">Just Object.</param>
        /// <param name="e">MouseButtonEventArgs e.</param>
        private void Canvas_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
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
            catch (Exception)
            {
                MessageBox.Show("Unexpected error occured");
            }
        }

        /// <summary>
        /// ClearButton Click.
        /// </summary>
        /// <param name="sender">Just Object.</param>
        /// <param name="e">RoutedEventArgs e.</param>
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            try
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
            catch (Exception)
            {
                MessageBox.Show("Save File Error");
            }
        }

        // пересування ламаних
        /// <summary>
        /// Polyline MouseDown.
        /// </summary>
        /// <param name="sender">Just Object.</param>
        /// <param name="e">MouseButtonEventArgs e.</param>
        private void Polyline_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.editModeOn = true;
                Polyline trigerLine = sender as Polyline;
                if (trigerLine == null)
                {
                    throw new Exception();
                }

                foreach (var item in this.DrawingManager.Polylines)
                {
                    if (item.Pc == trigerLine.Points)
                    {
                        this.tpc = item.Pc;
                        break;
                    }
                }

                Point p = Mouse.GetPosition(this);
                if (p != null)
                {
                    this.trigerPoint = p;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unexpected error occured");
            }
        }

        /// <summary>
        /// Window MouseLeftButtonUp.
        /// </summary>
        /// <param name="sender">Just Object.</param>
        /// <param name="e">MouseButtonEventArgs e.</param>
        private void Window_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.editModeOn = false;
        }

        /// <summary>
        /// Window MouseMove.
        /// </summary>
        /// <param name="sender">Just Object.</param>
        /// <param name="e">MouseEventArgs e.</param>
        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.editModeOn)
                {
                    Point p = Mouse.GetPosition(this);
                    double dx = p.X - this.trigerPoint.X;
                    double dy = p.Y - this.trigerPoint.Y;
                    for (int i = 0; i < this.tpc.Count; i++)
                    {
                        this.tpc[i] = new Point(this.tpc[i].X + dx, this.tpc[i].Y + dy);
                    }

                    this.trigerPoint.X = p.X;
                    this.trigerPoint.Y = p.Y;
                    this.LinesDrawer.Items.Refresh();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unexpected error occured");
            }
        }

        /// <summary>
        /// Polyline MouseUp.
        /// </summary>
        /// <param name="sender">Just Object.</param>
        /// <param name="e">MouseButtonEventArgs e.</param>
        private void Polyline_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.editModeOn = false;
        }

        //викликається коли наводимся мишкою
        /// <summary>
        /// Polyline MouseEnter.
        /// </summary>
        /// <param name="sender">Just Object.</param>
        /// <param name="e">MouseEventArgs e.</param>
        private void Polyline_MouseEnter(object sender, MouseEventArgs e)
        {
            try
            {
                Polyline trigerLine = sender as Polyline;
                if (trigerLine == null)
                {
                    throw new Exception();
                }

                trigerLine.StrokeThickness = 6;
            }
            catch (Exception)
            {
                MessageBox.Show("Unexpected error occured");
            }
        }

        //викликається коли забираємо мишку

        /// <summary>
        /// Polyline MouseLeave.
        /// </summary>
        /// <param name="sender">Just Object.</param>
        /// <param name="e">MouseEventArgs e.</param>
        private void Polyline_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                Polyline trigerLine = sender as Polyline;
                if (trigerLine == null)
                {
                    throw new Exception();
                }

                trigerLine.StrokeThickness = 3;
            }
            catch (Exception)
            {
                MessageBox.Show("Unexpected error occured");
            }
        }
    }
}
