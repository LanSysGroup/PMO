using System;
using System.Linq;
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
    public class EmtiyazModiranVaKarkonanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return HydroConverterHelper.ToEmtiyazModiranVaKarkonan((Web.Peymankar)value);
            //Web.Peymankar peymankar = (Web.Peymankar)value;

            //try
            //{
            //    double result = 0;

            //    foreach (var item in peymankar.Persons)
            //    {
            //        if (!item.TajrobeSanavati.HasValue)
            //            continue;

            //        //tajrobe sanavati
            //        double fi = item.TajrobeSanavati.HasValue ?
            //            Math.Min(item.TajrobeSanavati.Value, 15) : 0;

            //        bool isRelated = item.IsMortabet == "رشته مرتبط";

            //        //emtiyaz tahsil
            //        double m;

            //        switch (item.MadrakTahsili)
            //        {
            //            case "سیکل":
            //                m = 2.5;
            //                break;
            //            case "دیپلم":
            //                m = isRelated ? 7 : 0;
            //                break;
            //            case "فوق دیپلم":
            //                m = isRelated ? 20 : 0;
            //                break;
            //            case "لیسانس":
            //                m = isRelated ? 35 : 10;
            //                break;
            //            case "فوق لیسانس":
            //                m = isRelated ? 45 : 15;
            //                break;
            //            case "دکترا":
            //                m = isRelated ? 60 : 25;
            //                break;
            //            default:
            //                m = 0;
            //                break;
            //        }

            //        //zarib tajrobe
            //        double h;

            //        switch (item.Semat)
            //        {
            //            case "مدیر عامل":
            //            case "اعضاء هیئت مدیره":
            //                h = 8;
            //                break;
            //            case "کارکنان":
            //                h = 4;
            //                break;
            //            default:
            //                h = 0;
            //                break;
            //        }

            //        result += m + h * item.TajrobeSanavati.Value;
            //    }

            //    return result;
            //}
            //catch (Exception)
            //{
            //    return 0;
            //}

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
