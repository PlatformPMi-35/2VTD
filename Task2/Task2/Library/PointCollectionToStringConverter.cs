namespace Task2.Library
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Media;

    /// <summary>
    /// Class to convert <see cref="Point"/> to <see cref="string"/> and back.
    /// </summary>
    public class PointCollectionToStringConverter : IValueConverter
    {
        /// <summary>
        /// Converts <see cref="Point"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="value"><see cref="Point"/> to convert.</param>
        /// <param name="targetType">Type to which convert (<see cref="string"/>).</param>
        /// <param name="parameter">Not using parameter.</param>
        /// <param name="culture"><see cref="CultureInfo"/> of region.</param>
        /// <returns>Converted to <see cref="string"/> <see cref="Point"/>.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                string arr = string.Empty;
                foreach (var v in value as PointCollection)
                {
                    arr += v.ToString() + '\n';
                }

                return arr;
            }
            catch
            {
                return Binding.DoNothing;
            }
        }

        /// <summary>
        /// Converts <see cref="string"/> to <see cref="Point"/>.
        /// </summary>
        /// <param name="value"><see cref="string"/> to convert.</param>
        /// <param name="targetType">Type to which convert (<see cref="Point"/>).</param>
        /// <param name="parameter">Not using parameter.</param>
        /// <param name="culture"><see cref="CultureInfo"/> of region.</param>
        /// <returns>Converted to <see cref="Point"/> <see cref="string"/>.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            PointCollection points = new PointCollection();
            foreach (var v in (value as string).Split('\n'))
            {
                if (v != string.Empty && v != null)
                {
                    try
                    {
                        string[] temp = v.Split(';');
                        points.Add(new Point(System.Convert.ToDouble(temp[0]), System.Convert.ToDouble(temp[1])));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Invalid Input");
                    }
                }
            }

            return points;
        }
    }
}
