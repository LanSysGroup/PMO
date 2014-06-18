using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Linq;

namespace LanSysWebGIS.Resources.Hydro
{
    public static class HydroConverterHelper
    {
        public static double ToEmtiyazKarhayeAnjamShode(Web.Peymankar peymankar)
        {
            DateTime now = DateTime.Now;

            double result;

            try
            {
                result = peymankar.Peymanha.Sum(i => Math.Pow(1.2, now.Year - (i.TarikhePayan.Value.Year + i.TarikheShoro.Value.Year) / 2) * i.MablagePeyman.Value);
            }
            catch (Exception)
            {
                result = 0;
            }

            return result;
        }

        public static double ToEmtiyazModiranVaKarkonan(Web.Peymankar peymankar)
        {
            try
            {
                double result = 0;

                foreach (var item in peymankar.Persons)
                {
                    if (!item.TajrobeSanavati.HasValue)
                        continue;

                    //tajrobe sanavati
                    double fi = item.TajrobeSanavati.HasValue ?
                        Math.Min(item.TajrobeSanavati.Value, 15) : 0;

                    bool isRelated = item.IsMortabet == "رشته مرتبط";

                    //emtiyaz tahsil
                    double m;

                    switch (item.MadrakTahsili)
                    {
                        case "سیکل":
                            m = 2.5;
                            break;
                        case "دیپلم":
                            m = isRelated ? 7 : 0;
                            break;
                        case "فوق دیپلم":
                            m = isRelated ? 20 : 0;
                            break;
                        case "لیسانس":
                            m = isRelated ? 35 : 10;
                            break;
                        case "فوق لیسانس":
                            m = isRelated ? 45 : 15;
                            break;
                        case "دکترا":
                            m = isRelated ? 60 : 25;
                            break;
                        default:
                            m = 0;
                            break;
                    }

                    //zarib tajrobe
                    double h;

                    switch (item.Semat)
                    {
                        case "مدیر عامل":
                        case "اعضاء هیئت مدیره":
                            h = 8;
                            break;
                        case "کارکنان":
                            h = 4;
                            break;
                        default:
                            h = 0;
                            break;
                    }

                    result += m + h * item.TajrobeSanavati.Value;
                }

                if (peymankar.TedadGovahinameha.HasValue)
                {
                    result += peymankar.TedadGovahinameha.Value * 150;
                }

                return result;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static double ToEmtiyazTadavomFaaliyat(Web.Peymankar peymankar)
        {
            if (!peymankar.TedadSalhayeFaaliyat.HasValue)
            {
                return 0;
            }

            double Ew = ToEmtiyazKarhayeAnjamShode(peymankar);

            return 0.01 * Ew * peymankar.TedadSalhayeFaaliyat.Value;
        }

        internal static double ToEmtiyazTakhasosVaTajrobe(Web.Peymankar peymankar)
        {
            return ToEmtiyazKarhayeAnjamShode(peymankar) +
                ToEmtiyazModiranVaKarkonan(peymankar) +
                ToEmtiyazTadavomFaaliyat(peymankar);

        }

        internal static double ToEmtiyazTavanMali(Web.Peymankar peymankar)
        {
            if (!peymankar.TavanMaliBolandModat.HasValue || !peymankar.TavanMaliJari.HasValue || !peymankar.Gardeshmali.HasValue)
            {
                return 0;
            }
            else
            {
                return 0.5 * peymankar.Gardeshmali.Value + 1.5 * peymankar.TavanMaliJari.Value + peymankar.TavanMaliBolandModat.Value;
            }

        }

        internal static double ToEmtiyazSalahiyatLayroob(Web.Peymankar peymankar)
        {
            return
                0.3 * ToEmtiyazTakhasosVaTajrobe(peymankar) +
                0.5 * (peymankar.EmtiyazMashinalat.HasValue ? peymankar.EmtiyazMashinalat.Value : 0) +
                0.2 * ToEmtiyazTavanMali(peymankar);
        }

        internal static double ToEmtiyazSalahiyatBilBarj(Web.Peymankar peymankar)
        {
            return
                0.3 * ToEmtiyazTakhasosVaTajrobe(peymankar) +
                0.35 * (peymankar.EmtiyazMashinalat.HasValue ? peymankar.EmtiyazMashinalat.Value : 0) +
                0.35 * ToEmtiyazTavanMali(peymankar);
        }
    }
}
