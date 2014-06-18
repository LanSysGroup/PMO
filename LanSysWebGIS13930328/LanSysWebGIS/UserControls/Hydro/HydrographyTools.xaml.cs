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
using ESRI.ArcGIS.Client;
using ESRI.ArcGIS.Client.Symbols;
using ESRI.ArcGIS.Client.Tasks;
using LanSysWebGIS.Assets.Resources;
using LanSysWebGIS.Presenter;
using LanSysWebGIS.UserControls.Hydro;
using LanSysWebGIS.Views.UserManagement;

namespace LanSysWebGIS.UserControls.Banader.Hydrography
{
    public partial class HydrographyTools : UserControl
    {
        HydrographyToolsViewModel _hydrographyToolsViewModel = new HydrographyToolsViewModel();

        private string selectedLayerName;

        public HydrographyTools()
        {
            InitializeComponent();

            this.DataContext = _hydrographyToolsViewModel;

            var layersList = new List<String>();

            foreach (var layer in MapControl.PMOHydroRasters.Layers)
            {
                layersList.Add(layer.Name);
            }

            cmbRasterName.ItemsSource = layersList;
        }


        private void cmbNahie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //todo demo
            cmbRasterName.IsEnabled = true;
        }

        private void cmbRasterName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //todo change view published rasters
            //this.selectedLayerName = ((((ComboBox) sender).SelectedItem) as ComboBoxItem).Content.ToString();

            this.selectedLayerName = ((ComboBox)sender).SelectedValue.ToString();

            MapControl.PMOHydroRasters.VisibleLayers = new int[] { ((ComboBox)sender).SelectedIndex };

            if (MapControl.PMOHydroRasters != null)
            {
                RibbonBar.map.ZoomTo(MapControl.PMOHydroRasters.FullExtent);
            }
        }

        //Tools
        private void btnContourMap_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(this.selectedLayerName))
            {
                throw new Exception("ابتدا باید یک تصویر را انتخاب کنید");
            }
            else
            {
                _hydrographyToolsViewModel.OpenContourDialog(this.selectedLayerName);
            }

        }

        private void btnLayrubiMeasurement_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnProfile_Click(object sender, RoutedEventArgs e)
        {
            _hydrographyToolsViewModel.StartDrawing(this.selectedLayerName);
            //_hydrographyToolsViewModel.DrawLineForProfile(this.selectedLayerName);
        }



        private void btnRasterComparison_Click(object sender, RoutedEventArgs e)
        {
            _hydrographyToolsViewModel.OpenRasterComparisonDialog((List<String>)(cmbRasterName.ItemsSource));
        }

        private void btnLayrubiVolume_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(this.selectedLayerName))
            {
                throw new Exception("ابتدا باید یک تصویر را انتخاب کنید");
            }
            else
            {
                _hydrographyToolsViewModel.OpenAreaVolumeDialog(this.selectedLayerName);
            }
        }

        private void btnBuffer_Click(object sender, RoutedEventArgs e)
        {
            _hydrographyToolsViewModel.OpenBufferDialog();
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            MapControl.PMOHydroRasters.VisibleLayers = new int[] { };

            //todo for ابعاد هیدروگرافی
            //todo for پروفیل
            
            
            
            //todo for حریم

            if (RibbonBar.map.Layers["ContourMapLayer"] != null)
            {
                RibbonBar.map.Layers.Remove(RibbonBar.map.Layers["ContourMapLayer"]);
            }
            if (RibbonBar.map.Layers["CutFillLayer"] != null)
            {
                RibbonBar.map.Layers.Remove(RibbonBar.map.Layers["CutFillLayer"]);
            }
            if (RibbonBar.map.Layers["AreaVolumeImageLayer"] != null)
            {
                RibbonBar.map.Layers.Remove(RibbonBar.map.Layers["AreaVolumeImageLayer"]);
            }
        }
    }
}
