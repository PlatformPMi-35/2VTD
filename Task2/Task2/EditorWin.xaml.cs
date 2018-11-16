namespace Task2
{
    using System;
    using System.Windows;
    using Task2.Library;

    /// <summary>
    /// Логика взаимодействия для EditorWin.xaml.
    /// </summary>
    public partial class EditorWin : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EditorWin"/> class.
        /// </summary>
        /// <param name="p"><see cref="PolyLine"/> to edit.</param>
        public EditorWin(PolyLine p)
        {
            try
            {
                this.InitializeComponent();
                this.Pl = p;

                textBl.DataContext = this.Pl;
                brush.DataContext = this.Pl;
            }
            catch (Exception ex)
            {
                if (ex.Message == "Invalid Brush Argument")
                {
                    MessageBox.Show("Invalid Color Argument");
                }
                else
                {
                    MessageBox.Show("Unexpected error occured");
                }

                throw;
            }
        }

        /// <summary>
        /// Gets or sets <see cref="PolyLine"/> to edit.
        /// </summary>
        /// <value><see cref="PolyLine"/> to edit.</value>
        public PolyLine Pl { get; set; }

        /// <summary>
        /// Click on button.
        /// </summary>
        /// <param name="sender">Just an Object.</param>
        /// <param name="e">RoutedEventArgs e.</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
