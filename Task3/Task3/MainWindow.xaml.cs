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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Task3.Controllers;
using Task3.Models;

namespace Task3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var v = fromCountry.Text;
            fromCountry.Text = toCountry.Text;
            toCountry.Text = v;

            v = fromCity.Text;
            fromCity.Text = toCity.Text;
            toCity.Text = v;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Filter f = new Filter(
                From:               fromCountry.Text != string.Empty ? fromCountry.Text : null,
                To:                 toCountry.Text != string.Empty ? toCountry.Text : null,
                MinDateOfLoading:   dateFrom.SelectedDate,
                MaxDateOfLoading:   dateTo.SelectedDate,
                Type:               (VehicleType?)(expander1.SelectedIndex - 1),
                MinWeight:          double.TryParse(weightFrom.Text, out double res1) ? res1 as double? : null,
                MaxWeight:          double.TryParse(weightTo.Text, out double res2) ? res2 as double? : null);
            

            OfferController offerController = new OfferController(IOConroller.LoadOffer(@"../../Resourses/Offres.dat"));

            dataList.ItemsSource = offerController.GetOffers(f);
        }
    }
}
