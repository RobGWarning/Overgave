using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using Overgave.ViewModels;

namespace Overgave.Views
{
    class TypeChangedParameterConvertor : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            MainWindowViewModel.CBItem parameters = new MainWindowViewModel.CBItem();
            foreach (var obj in values)
            {
                if (obj is string) parameters.Content = (string)obj;
                else if (obj is bool) parameters.IsChecked = (bool)obj;
            }
            return parameters;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            bool IsChecked = (bool)value;
            string Content = (string)value;
            return new object[] { IsChecked, Content };
        }
    }
}
