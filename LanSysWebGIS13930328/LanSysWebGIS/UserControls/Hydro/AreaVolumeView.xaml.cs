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
    public partial class AreaVolumeView : UserControl
    {
        private string selectedLayerName;

        private AreaVolumeViewModel _areaVolumeViewModel = new AreaVolumeViewModel();

        public AreaVolumeView(string layer)
        {
            InitializeComponent();

            this.selectedLayerName = layer;

            this.txbRasterName.Text = this.selectedLayerName;

            this.DataContext = _areaVolumeViewModel;
        }

        private void btnCalculateAreaVolume_Click(object sender, RoutedEventArgs e)
        {
            _areaVolumeViewModel.CalculateAreaVolume(this.selectedLayerName);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            (((this.Parent as StackPanel).Parent as Grid).Parent as ChildWin).Close();
        }

        private void cmbReferencePlane_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbReferencePlane != null)
            {
                _areaVolumeViewModel.ReferencePlane = ((ComboBoxItem)cmbReferencePlane.SelectedItem).Tag.ToString();
            }
        }
    }
}
