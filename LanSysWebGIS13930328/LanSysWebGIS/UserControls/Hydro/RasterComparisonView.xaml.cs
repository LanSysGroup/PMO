using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using ESRI.ArcGIS.Client.Geometry;
using ESRI.ArcGIS.Client.Tasks;
using LanSysWebGIS.Presenter.Hydro;

namespace LanSysWebGIS.UserControls.Hydro
{
    public partial class RasterComparisonView : UserControl
    {
        RasterComparisonViewModel _rasterComparisonViewModel = new RasterComparisonViewModel();

        public RasterComparisonView(List<String> rasterNames)
        {
            InitializeComponent();

            MapControl.PMOHydroRasters.Opacity = 0;

            this.DataContext = _rasterComparisonViewModel;

            cmbBeforeRaster.ItemsSource = rasterNames;
            cmbAfterRaster.ItemsSource = rasterNames;
        }

        private void cmbBeforeRaster_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cmbAfterRaster_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnRasterComparison_Click(object sender, RoutedEventArgs e)
        {
            string beforeRaster = cmbBeforeRaster.SelectedItem.ToString();
            string afterRaster = cmbAfterRaster.SelectedItem.ToString();

            _rasterComparisonViewModel.CompareRasters(beforeRaster, afterRaster);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            (((this.Parent as StackPanel).Parent as Grid).Parent as ChildWin).Close();

            MapControl.PMOHydroRasters.Opacity = 1;
        }
    }
}
