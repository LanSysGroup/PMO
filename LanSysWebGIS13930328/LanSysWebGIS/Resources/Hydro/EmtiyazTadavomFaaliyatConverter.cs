using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace LanSysWebGIS.Resources.Hydro
{
    public class EmtiyazTadavomFaaliyatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return HydroConverterHelper.ToEmtiyazTadavomFaaliyat((Web.Peymankar)value);
            //Web.Peymankar peymankar = (Web.Peymankar)value;

            //if (!peymankar.TedadSalhayeFaaliyat.HasValue)
            //{
            //    return 0;
            //}

            //double Ew = (double)parameter;

            //return 0.01 * Ew * peymankar.TedadSalhayeFaaliyat.Value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
