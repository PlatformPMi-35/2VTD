namespace Task2
{
    using System;
    using System.Windows;
    using Task2.Library;

    /// <summary>
    /// Логика взаимодействия для EditorWin.xaml
    /// </summary>
    public partial class EditorWin : Window
    {
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
                if(ex.Message == "Invalid Brush Argument")
                {
                    throw new Exception("Invalid Color Argument");
                }
                else
                {
                    throw new Exception("Unexpected error occured");
                }
                throw;
            }
            
        }

        public PolyLine Pl { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {                       
            this.Close();          
        }
    }
}
