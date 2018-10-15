namespace Task2.Library
{
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using System.Windows.Media;

    public class BrushToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return (value as Brush).ToString();
            }
            catch
            {
                return Binding.DoNothing;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return (Brush)new BrushConverter().ConvertFromString(value as string);
            }
            catch
            {
                return Binding.DoNothing;
            }
        }
    }
}
