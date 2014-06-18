using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using ESRI.ArcGIS.Client;
using ESRI.ArcGIS.Client.Geometry;
using ESRI.ArcGIS.Client.Symbols;
using ESRI.ArcGIS.Client.Tasks;
using LanSysWebGIS.Assets.Resources;
using LanSysWebGIS.Models;
using LanSysWebGIS.Presenter;
using LanSysWebGIS.Presenter.Hydro;
using LanSysWebGIS.Views.UserManagement;

namespace LanSysWebGIS.UserControls.Hydro
{
    public partial class ProfileView : UserControl
    {
        private ProfileViewModel _profileViewModel;

        public ProfileView(string layerName, ESRI.ArcGIS.Client.Geometry.PointCollection pointCollection)
        {
            InitializeComponent();

            _profileViewModel = new ProfileViewModel(pointCollection);

            this.DataContext = _profileViewModel;
        }

        void ElevationChart_MouseMove(object sender, MouseEventArgs e)
        {
            IEnumerable itemsSource = ((LineSeries)(((Chart)sender).Series[0])).ItemsSource;

            if (((ESRI.ArcGIS.Client.Geometry.PointCollection)itemsSource).Count > 0)
            {
                _profileViewModel.ElevationChartMouseMove(sender, e);
            }
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            GraphicsLayer _lineGraphicLayer = RibbonBar.map.Layers["LineGraphicsLayer"] as GraphicsLayer;
            _lineGraphicLayer.ClearGraphics();
        }

        //private void ElevationChart_Loaded(object sender, RoutedEventArgs e)
        //{
        //    IEnumerable itemsSource = ((LineSeries)(((Chart)sender).Series[0])).ItemsSource;

        //    if (((ESRI.ArcGIS.Client.Geometry.PointCollection)itemsSource).Count > 0)
        //    {
        //        _profileViewModel.ElevationChartLoaded(sender, e);
        //    }
        //}
    }
}
