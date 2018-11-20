using System;
using System.Windows;
using System.Windows.Input;
using Task3.Controllers;
using Task3.Models;

namespace Task3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            try
            {
                InitializeComponent();
                IOConroller.GenerateRandomOffers();
            }
            catch (Exception)
            {
                MessageBox.Show("Unexpected error occured");
            }
        }

        /// <summary>
        /// Image MouseDown
        /// </summary>
        /// <param name="sender">Just Object</param>
        /// <param name="e">MouseButtonEventArgs e</param>
        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var v = fromCountry.Text;
                fromCountry.Text = toCountry.Text;
                toCountry.Text = v;
            }
            catch (Exception)
            {
                MessageBox.Show("Unexpected error occured");
            }
        }

        /// <summary>
        /// Button Click
        /// </summary>
        /// <param name="sender">Just Object</param>
        /// <param name="e">MouseButtonEventArgs e</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Filter f = new Filter(
                From: fromCountry.Text != string.Empty ? fromCountry.Text : null,
                To: toCountry.Text != string.Empty ? toCountry.Text : null,
                MinDateOfLoading: dateFrom.SelectedDate,
                MaxDateOfLoading: dateTo.SelectedDate,
                Type: (VehicleType?)(expander1.SelectedIndex - 1),
                MinWeight: double.TryParse(weightFrom.Text, out double res1) ? res1 as double? : null,
                MaxWeight: double.TryParse(weightTo.Text, out double res2) ? res2 as double? : null);


                OfferController offerController = new OfferController(IOConroller.LoadOffer(@"../../Resourses/Offres.dat"));

                dataList.ItemsSource = offerController.GetOffers(f);
            }
            catch (Exception)
            {
                MessageBox.Show("Unexpected error occured");
            }
        }
    }
}
