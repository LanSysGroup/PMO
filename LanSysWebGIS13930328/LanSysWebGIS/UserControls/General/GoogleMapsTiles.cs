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
using ESRI.ArcGIS.Client;
using ESRI.ArcGIS.Client.Geometry;
using LanSysWebGIS.Web;
using System.Linq;

namespace LanSysWebGIS.UserControls
{
    public class GoogleMapsTiles : TiledMapServiceLayer
    {
        private static string[] subDomains = { "a", "b", "c" };

        private const string baseUrl = "http://cpedsrv/Caches/WebCaches/GoogleMaps/{0}/gm_{1}_{2}_{3}.png";

        //private const string baseUrl = "http://91.98.96.231/Caches/WebCaches/GoogleMaps/{0}/gm_{1}_{2}_{3}.png";

        //private string baseUrl = MapControl.allServices.FirstOrDefault(s => s.Name == "GoogleMaps").Url;

        PMOContext context = new PMOContext();

        //private const string baseUrl = context.SpatialServices.Where(p => p.Name == serviceName).Select(p => p.Url).Single();;

        private double cornerCoordinate = 20037508.3427892;
        public override void Initialize()
        {

            this.FullExtent = new ESRI.ArcGIS.Client.Geometry.Envelope(-20037508.3427892, -20037508.3427892, 20037508.3427892, 20037508.3427892)
            //this.FullExtent = new ESRI.ArcGIS.Client.Geometry.Envelope(-10037508.3427892, -10037508.3427892, 10037508.3427892, 10037508.3427892)
            {
                SpatialReference = new SpatialReference(102100)//102113)
            };
            // This layer's spatial reference
            this.SpatialReference = new SpatialReference(102100);
            // Set up tile information. Each tile is 256x256px, 19 levels.
            this.TileInfo = new TileInfo()
            {
                Height = 256,
                Width = 256,
                Origin = new MapPoint(-cornerCoordinate, cornerCoordinate) { SpatialReference = new ESRI.ArcGIS.Client.Geometry.SpatialReference(102100) },
                Lods = new Lod[21]
            };
            // Set the resolutions for each level. Each level is half the resolution of the previous one.
            double resolution = cornerCoordinate * 2 / 256;
            for (int i = 0; i < TileInfo.Lods.Length; i++)
            {
                TileInfo.Lods[i] = new Lod() { Resolution = resolution };
                resolution /= 2;
            }
            // Call base initialize to raise the initialization event
            base.Initialize();
        }

        public override string GetTileUrl(int level, int row, int col)
        {
            // Select a subdomain based on level/row/column so that it will always
            // be the same for a specific tile. Multiple subdomains allows the user
            // to load more tiles simultanously. To take advantage of the browser cache
            // the following expression also makes sure that a specific tile will always 
            // hit the same subdomain.
            int subdomain = 14;// = subDomains[(level + col + row) % subDomains.Length];
            //if (level>14)
            //{
            //    subdomain = level;
            //}

            //if (level > 15)
            //{
            //  return  string.Format(baseUrl2, level, col, row, level);
            //}
            return string.Format(baseUrl, level, col, row, level);
        }

    }
}
