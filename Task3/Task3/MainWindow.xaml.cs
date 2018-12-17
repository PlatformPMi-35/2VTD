namespace Task3
{
    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Input;
    using Task3.Controllers;
    using Task3.Models;

    /// <summary>
    /// Interaction logic for <see cref="MainWindow.xaml"/>.
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
                this.InitializeComponent();
                //// DbController.GenerateRandomDB();
            }
            catch (Exception)
            {
                MessageBox.Show("Unexpected error occured");
            }
        }

        /// <summary>
        /// Image MouseDown.
        /// </summary>
        /// <param name="sender">Just Object.</param>
        /// <param name="e">MouseButtonEventArgs e.</param>
        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var v = this.fromCountry.Text;
                this.fromCountry.Text = this.toCountry.Text;
                this.toCountry.Text = v;
            }
            catch (Exception)
            {
                MessageBox.Show("Unexpected error occured");
            }
        }

        /// <summary>
        /// Button Click.
        /// </summary>
        /// <param name="sender">Just Object.</param>
        /// <param name="e">MouseButtonEventArgs e.</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Filter f = new Filter(
                from: this.fromCountry.Text != string.Empty ? this.fromCountry.Text : null,
                to: this.toCountry.Text != string.Empty ? this.toCountry.Text : null,
                minDateOfLoading: this.dateFrom.SelectedDate,
                maxDateOfLoading: this.dateTo.SelectedDate,
                type: (VehicleType?)(this.expander1.SelectedIndex - 1),
                minWeight: double.TryParse(this.weightFrom.Text, out double res1) ? res1 as double? : null,
                maxWeight: double.TryParse(this.weightTo.Text, out double res2) ? res2 as double? : null);
                
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    OfferController offerController = new OfferController(new List<Offer>(unitOfWork.Offers.GetAll()));
                    this.dataList.ItemsSource = offerController.GetOffers(f);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unexpected error occured");
            }
        }
    }
}
