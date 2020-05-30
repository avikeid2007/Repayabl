using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace RepayablClient.Shared.Converter
{
    public sealed class EmptyStringToTrueConverter : IValueConverter
    {
        public bool IsInverted { get; set; }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var txt = (string)value;
            return string.IsNullOrEmpty(txt) ^ IsInverted;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
