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
using ESRI.ArcGIS.Client;
using ESRI.ArcGIS.Client.Tasks;
using LanSysWebGIS.Models;
using ESRI.ArcGIS.Client.Symbols;
using LanSysWebGIS.Assets.Resources;
using LanSysWebGIS.Views.UserManagement;

namespace LanSysWebGIS.UserControls
{
    public partial class Buffer : UserControl
    {

        public Buffer()
        {
            InitializeComponent();

            //cmbLayerToBuffer.ItemsSource = MapControl.nonGroupLayersName;

            //cmbLayerToBuffer.SelectedIndex = 0;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            cmbLayerToBuffer.ItemsSource = MapControl.nonGroupLayersName;

            cmbLayerToBuffer.SelectedIndex = 0;

            rdbSelectFromActiveLayer.IsChecked = true;

            txtActiveLayer.Text = "لایه فعال: " + MapControl.cmbActiveLayerSelectedValue;
        }

        public static Map map1;

        internal void ExecuteBuffer(MapPoint clickPoint, Map myMap)
        {
            map1 = myMap;

            GraphicsLayer graphicsLayer = map1.Layers["gLayerBuffer"] as GraphicsLayer;
            graphicsLayer.ClearGraphics();

            Graphic graphic = new Graphic();

            if ((bool)rdbFreeSelect.IsChecked)
            {
                clickPoint.SpatialReference = map1.SpatialReference;

                graphic.Geometry = clickPoint;

                graphic.Symbol = LayoutRoot.Resources["DefaultClickSymbol"] as ESRI.ArcGIS.Client.Symbols.Symbol;
                
            }
            else if ((bool)rdbSelectFromActiveLayer.IsChecked)
            {
                //mapOp.selectFeatures(clickPoint, false);

                GraphicsLayer gLayersSelection = myMap.Layers["gLayersSelection"] as GraphicsLayer;

                graphic.Geometry = gLayersSelection.Graphics[0].Geometry;
                graphic.Symbol = new SimpleFillSymbol();

                gLayersSelection.ClearGraphics();


            }

            graphic.SetZIndex(1);
            graphicsLayer.Graphics.Add(graphic);

            GeometryService geometryService =
              new GeometryService(MapControl.GeometryServiceURL);
            geometryService.BufferCompleted += GeometryService_BufferCompleted;
            geometryService.Failed += GeometryService_Failed;

            // If buffer spatial reference is GCS and unit is linear, geometry service will do geodesic buffering
            BufferParameters bufferParams = new BufferParameters()
            {
                Unit = LinearUnit.Meter,
                BufferSpatialReference = new SpatialReference(102100),
                OutSpatialReference = map1.SpatialReference
            };
            bufferParams.Features.Add(graphic);
            bufferParams.Distances.Add(double.Parse(txtRadius.Text));

            geometryService.BufferAsync(bufferParams);
        }

        void GeometryService_BufferCompleted(object sender, GraphicsEventArgs args)
        {
            IList<Graphic> results = args.Results;
            GraphicsLayer graphicsLayer = map1.Layers["gLayerBuffer"] as GraphicsLayer;

            foreach (Graphic graphic in results)
            {
                graphic.Symbol = LayoutRoot.Resources["DefaultBufferSymbol"] as ESRI.ArcGIS.Client.Symbols.Symbol;
                graphicsLayer.Graphics.Add(graphic);
            }
        }

        private void GeometryService_Failed(object sender, TaskFailedEventArgs e)
        {
            throw new Exception(ErrorResources.GeometryServiceFailed);
        }

        private void rdbSelectFromActiveLayer_Checked(object sender, RoutedEventArgs e)
        {
            cmbLayerToBuffer.IsEnabled = true;
        }

        private void rdbFreeSelect_Checked(object sender, RoutedEventArgs e)
        {
            cmbLayerToBuffer.IsEnabled = false;
        }

        private void txtRadius_GotFocus(object sender, RoutedEventArgs e)
        {
            if (((TextBox)sender).Text == "شعاع بافر (متر)")
            {
                ((TextBox)sender).Text = "";
                ((TextBox)sender).Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void txtRadius_LostFocus(object sender, RoutedEventArgs e)
        {
            if (((TextBox)sender).Text == "")
            {
                ((TextBox)sender).Text = "شعاع بافر (متر)";
                ((TextBox)sender).Foreground = new SolidColorBrush(Colors.Gray);

            }
        }

        public void selectFeatures(MapPoint clickPoint, bool mapIdentify)
        {
            (map1.Layers["Atlas"] as ArcGISDynamicMapServiceLayer).VisibleLayers = MapControl.dynamicService.VisibleLayers;

            ESRI.ArcGIS.Client.Tasks.IdentifyParameters identifyParams = new IdentifyParameters()
            {
                Geometry = clickPoint,
                MapExtent = map1.Extent,
                Width = (int)map1.ActualWidth,
                Height = (int)map1.ActualHeight,
                LayerOption = LayerOption.all,
                SpatialReference = map1.SpatialReference
            };
            //identifyParams.LayerIds.AddRange((Atlas_Map.VisibleLayers).ToList<int>());
            identifyParams.LayerIds.Add(MapControl.layersName2layersNumberDic[MapControl.cmbActiveLayerSelectedValue]);

            IdentifyTask identifyTask = new IdentifyTask((map1.Layers["Atlas"] as ArcGISDynamicMapServiceLayer).Url);
            identifyTask.ExecuteCompleted += selectFeatures_ExecuteCompleted;
            identifyTask.Failed += selectFeatures_Failed;
            identifyTask.ExecuteAsync(identifyParams);
        }

        private void selectFeatures_ExecuteCompleted(object sender, IdentifyEventArgs args)
        {
            GraphicsLayer gLayersSelection = map1.Layers["gLayersBuffer"] as GraphicsLayer;

            if (RibbonBar.select)
            {
                gLayersSelection.ClearGraphics();
            }

            if (args.IdentifyResults != null && args.IdentifyResults.Count > 0)
            {
                foreach (IdentifyResult result in args.IdentifyResults)
                {
                    Graphic feature = result.Feature;

                    if (feature.Geometry is ESRI.ArcGIS.Client.Geometry.MapPoint)
                    {
                        SimpleMarkerSymbol sym = new SimpleMarkerSymbol();
                        sym.Color = new SolidColorBrush(Colors.Yellow);

                        feature.Symbol = sym;
                    }
                    else if (feature.Geometry is ESRI.ArcGIS.Client.Geometry.Polyline)
                    {
                        SimpleLineSymbol sym = new SimpleLineSymbol();
                        sym.Color = new SolidColorBrush(Colors.Yellow);
                        sym.Width = 2;

                        feature.Symbol = sym;
                    }
                    else if (feature.Geometry is ESRI.ArcGIS.Client.Geometry.Polygon)
                    {
                        SimpleFillSymbol sym = new SimpleFillSymbol();
                        sym.BorderBrush = new SolidColorBrush(Colors.Yellow);
                        sym.Fill = new SolidColorBrush(Color.FromArgb(0xC8, 0xFF, 0xFF, 0x99));
                        sym.BorderThickness = 2;

                        feature.Symbol = sym;
                    }

                    if (RibbonBar.select == true || RibbonBar.addToSelect == true)
                    {
                        gLayersSelection.Graphics.Add(feature);
                    }

                }
            }
        }

        private void selectFeatures_Failed(object sender, TaskFailedEventArgs e)
        {
            MessageWindow win = new MessageWindow();
            win.messageTextBlock.Text = ApplicationStrings.msgSelectFeatureFailed;
            win.Show();
        }

    }
}
