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
using ProjNet.CoordinateSystems;
using ProjNet.CoordinateSystems.Transformations;

namespace LanSysWebGIS.Helpers
{
    public static class CoordinateTransformer
    {
        public static string[] WGS84ToUTM(double lon, double lat, int decimalCount)
        {
            //Point p = e.GetPosition(map);
            //double scale = 360 / map.ActualWidth;
            //Point pGeo = new Point(p.X * scale - 180, 90 - p.Y * scale);
            //locationLong.Text = string.Format("{0}", pGeo.X);
            //locationLat.Text = string.Format("{0}", pGeo.Y);

            //Transform to UTM
            CoordinateTransformationFactory ctfac = new CoordinateTransformationFactory();
            ICoordinateSystem wgs84geo = ProjNet.CoordinateSystems.GeographicCoordinateSystem.WGS84;
            //int zone = (int)Math.Ceiling((pGeo.X + 180) / 6);
            int zone = (int)Math.Ceiling((lon + 180) / 6);
            //ICoordinateSystem utm = ProjNet.CoordinateSystems.ProjectedCoordinateSystem.WGS84_UTM(zone, pGeo.Y > 0);
            ICoordinateSystem utm = ProjNet.CoordinateSystems.ProjectedCoordinateSystem.WGS84_UTM(zone, lat > 0);
            ICoordinateTransformation trans = ctfac.CreateFromCoordinateSystems(wgs84geo, utm);

            Point wgsPoint = new Point(lon, lat);

            Point pUtm = trans.MathTransform.Transform(wgsPoint);
            //locationX.Text = string.Format("N{0}", pUtm.Y);
            //locationY.Text = string.Format("E{0}", pUtm.X);
            //locationZone.Text = string.Format("Zone {0}{1}", zone, pGeo.Y > 0 ? 'N' : 'S');
            return new string[] { Math.Round(pUtm.Y, decimalCount).ToString(), Math.Round(pUtm.X, decimalCount).ToString(), string.Format("{0}{1}", zone, lat > 0 ? 'N' : 'S') };
        }

        public static string[] UTMToWGS84(double x, double y, int zone, bool isNorth, int decimalCount)
        {
            //Transform to UTM
            CoordinateTransformationFactory ctfac = new CoordinateTransformationFactory();
            ICoordinateSystem utmGeo = ProjNet.CoordinateSystems.ProjectedCoordinateSystem.WGS84_UTM(zone,isNorth);
            //int zone = (int)Math.Ceiling((pGeo.X + 180) / 6);
            //int zone = (int)Math.Ceiling((lon + 180) / 6);
            //ICoordinateSystem utm = ProjNet.CoordinateSystems.ProjectedCoordinateSystem.WGS84_UTM(zone, pGeo.Y > 0);
            ICoordinateSystem wgs84geo = ProjNet.CoordinateSystems.GeographicCoordinateSystem.WGS84;
            ICoordinateTransformation trans = ctfac.CreateFromCoordinateSystems(utmGeo, wgs84geo);

            Point utmPoint = new Point(y,x);

            Point pWGS84 = trans.MathTransform.Transform(utmPoint);

            return new string[] { Math.Round(pWGS84.X, decimalCount).ToString(), Math.Round(pWGS84.Y, decimalCount).ToString()}; ;
        }
    }
}
