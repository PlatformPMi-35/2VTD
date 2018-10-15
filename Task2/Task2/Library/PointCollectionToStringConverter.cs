namespace Task2.Library
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Media;

    public class PointCollectionToStringConverter : IValueConverter
    {
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
                    catch
                    {                        
                    }
                }
            }

            return points;
        }
    }
}
