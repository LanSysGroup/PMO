using System;
using System.Collections.Generic;
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
using ESRI.ArcGIS.Client.Symbols;
using ESRI.ArcGIS.Client.Tasks;
using LanSysWebGIS.UserControls;

namespace LanSysWebGIS.Presenter.Hydro
{
    public class ProfileViewModel : Notifier
    {
        private ESRI.ArcGIS.Client.Geometry.PointCollection _pointCollection;
        public ESRI.ArcGIS.Client.Geometry.PointCollection PointCollection
        {
            get { return _pointCollection; }
            set
            {
                _pointCollection = value;
                OnPropertyChanged("PointCollection");
            }
        }

        private string _distanceText;

        public string DistanceText
        {
            get { return _distanceText; }
            set
            {
                _distanceText = value;
                OnPropertyChanged("DistanceText");
            }
        }

        public ProfileViewModel(ESRI.ArcGIS.Client.Geometry.PointCollection points)
        {
            this.PointCollection = points;

            MapPoint lastPoint = PointCollection[PointCollection.Count - 1];

            //lblDistance.Text = string.Format("Total Distance {0} Kilometers", lastPoint.M.ToString());

            DistanceText = string.Format("طول کل: {0} متر", lastPoint.M.ToString());
        }

        public void ElevationChartMouseMove(object sender, MouseEventArgs e)
        {
            GraphicsLayer _pointGraphicLayer = RibbonBar.map.Layers["PointGraphicsLayer"] as GraphicsLayer;

            if (!(((System.Windows.FrameworkElement)(((System.Windows.RoutedEventArgs)(e)).OriginalSource)) is Ellipse))
            {
                (_pointGraphicLayer.Graphics[0].Geometry as MapPoint).X = Double.NaN;
                (_pointGraphicLayer.Graphics[0].Geometry as MapPoint).Y = Double.NaN;
            }
            else
            {
                Ellipse chartPoint = ((System.Windows.FrameworkElement)(((System.Windows.RoutedEventArgs)(e)).OriginalSource)) as Ellipse;
                MapPoint mapPoint = chartPoint.DataContext as MapPoint;

                (_pointGraphicLayer.Graphics[0].Geometry as MapPoint).X = mapPoint.X;
                (_pointGraphicLayer.Graphics[0].Geometry as MapPoint).Y = mapPoint.Y;
            }

            MapPoint lastPoint = PointCollection[PointCollection.Count - 1];

            //lblDistance.Text = string.Format("Total Distance {0} Kilometers", lastPoint.M.ToString());

            DistanceText = string.Format("طول کل: {0} متر", lastPoint.M.ToString());
        }

        //public void ElevationChartLoaded(object sender, RoutedEventArgs routedEventArgs)
        //{
        //    MapPoint lastPoint = PointCollection[PointCollection.Count - 1];

        //    //lblDistance.Text = string.Format("Total Distance {0} Kilometers", lastPoint.M.ToString());

        //    DistanceText = string.Format("طول کل: {0} متر", lastPoint.M.ToString());
        //}
    }
}
