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
using LanSysWebGIS.Presenter.Hydro;

namespace LanSysWebGIS.UserControls.Hydro
{
    public partial class ContourMapView : UserControl
    {
        private string selectedLayerName;

        private ContourMapViewModel _contourMapViewModel = new ContourMapViewModel();

        public ContourMapView(string layer)
        {
            InitializeComponent();

            this.selectedLayerName = layer;

            this.txbRasterName.Text = this.selectedLayerName;

            this.DataContext = _contourMapViewModel;
        }

        private void btnCreateContour_Click(object sender, RoutedEventArgs e)
        {
            _contourMapViewModel.CreateContourMap(this.selectedLayerName);

            //((ChildWin)this.Parent).Close();
            (((this.Parent as StackPanel).Parent as Grid).Parent as ChildWin).Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            //((ChildWin)this.Parent).Close();
            (((this.Parent as StackPanel).Parent as Grid).Parent as ChildWin).Close();
        }
    }
}
