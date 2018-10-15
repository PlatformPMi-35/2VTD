namespace Task2
{
    using System.Windows;
    using Task2.Library;

    /// <summary>
    /// Логика взаимодействия для EditorWin.xaml
    /// </summary>
    public partial class EditorWin : Window
    {
        public EditorWin(PolyLine p)
        {
            this.InitializeComponent();           
            this.Pl = p;

            textBl.DataContext = this.Pl;
            brush.DataContext = this.Pl;      
        }

        public PolyLine Pl { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {                       
            this.Close();          
        }
    }
}
