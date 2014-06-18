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
using ESRI.ArcGIS.Client.Geometry;
using ESRI.ArcGIS.Client.Symbols;
using ESRI.ArcGIS.Client.Tasks;
using ESRI.SilverlightViewer.Utility;
using LanSysWebGIS.Models;
using LanSysWebGIS.UserControls.GeoMaps;

namespace LanSysWebGIS.UserControls
{
    public partial class SpatialQuery : UserControl
    {
        public static Draw MySpatialQuerySurface;

        public static Map map;

        private HyperlinkButton selectedHB = new HyperlinkButton();

        private bool isfreepoly = false;

        public SpatialQuery()
        {
            InitializeComponent();

            MySpatialQuerySurface = new Draw(map)
            {
                LineSymbol = App.Current.Resources["DefaultLineSymbol"] as LineSymbol,
                FillSymbol = App.Current.Resources["DefaultFillSymbol"] as FillSymbol
            };
            MySpatialQuerySurface.DrawComplete += MySpatialQuerySurface_DrawComplete;
        }

        private void GeometryDrawMode_Click(object sender, RoutedEventArgs e)
        {
            var queryAllHButtons = this.DrawModeButtonStack.Descendents().OfType<HyperlinkButton>();

            foreach (var hyperlinkButton in queryAllHButtons)
            {
                hyperlinkButton.Effect = null;
            }

            this.selectedHB = sender as HyperlinkButton;

            HyperlinkButton button = sender as HyperlinkButton;

            System.Windows.Media.Effects.DropShadowEffect dropShadowEffect = new System.Windows.Media.Effects.DropShadowEffect();
            dropShadowEffect.Opacity = 1;
            dropShadowEffect.ShadowDepth = 5;
            dropShadowEffect.BlurRadius = 50;
            dropShadowEffect.Color = Colors.Cyan;
            button.Effect = dropShadowEffect;

            String drawTypeName = (String)button.Tag;

            isfreepoly = false;

            switch (drawTypeName)
            {
                case "Point":
                    MySpatialQuerySurface.DrawMode = DrawMode.Point;
                    break;
                case "Polyline":
                    MySpatialQuerySurface.DrawMode = DrawMode.Polyline;
                    //MyDrawSurface.LineSymbol = new LineSymbol();
                    break;
                case "Polygon":
                    MySpatialQuerySurface.DrawMode = DrawMode.Polygon;
                    //MyDrawSurface.FillSymbol = new SimpleFillSymbol();
                    break;
                case "Rectangle":
                    MySpatialQuerySurface.DrawMode = DrawMode.Rectangle;
                    //MyDrawSurface.FillSymbol = new SimpleFillSymbol();
                    break;
                case "Freeline":
                    MySpatialQuerySurface.DrawMode = DrawMode.Freehand;
                    //MyDrawSurface.LineSymbol = new LineSymbol();
                    break;
                case "Freepoly":
                    MySpatialQuerySurface.DrawMode = DrawMode.Freehand;
                    isfreepoly = true;
                    //MyDrawSurface.FillSymbol = new SimpleFillSymbol();
                    break;
                default: // Clear
                    MySpatialQuerySurface.DrawMode = DrawMode.None;
                    //gl = MapQuery.Layers["gLayerDraw"] as GraphicsLayer;
                    //this.drawGraphicsLayer.ClearGraphics();
                    //MyDataGrid.ItemsSource = null;
                    //MyDataGrid.Visibility = Visibility.Visible;
                    break;
            }
            MySpatialQuerySurface.IsEnabled = (MySpatialQuerySurface.DrawMode != DrawMode.None);

            GraphicsLayer graphicsLayer = MapOperations.map1.Layers["gLayersSelection"] as GraphicsLayer;
            graphicsLayer.ClearGraphics();
        }

        private static ESRI.ArcGIS.Client.Geometry.Geometry geom;

        private void MySpatialQuerySurface_DrawComplete(object sender, ESRI.ArcGIS.Client.DrawEventArgs args)
        {
            MySpatialQuerySurface.IsEnabled = false;
            
            this.selectedHB.Effect = null;

            //MapControl.geoMapsGraphicsLayer.ClearGraphics();

            if (isfreepoly)
            {
                geom = GeometryTool.FreehandToPolygon(args.Geometry as ESRI.ArcGIS.Client.Geometry.Polyline);
            }
            else
            {
                geom = args.Geometry;
            }

            ExecuteBuffer();
            //MapControl.mapOp.PerformSpatialQuery();
        }
        internal void ExecuteBuffer()
        {
            GraphicsLayer graphicsLayer = MapOperations.map1.Layers["gLayersSelection"] as GraphicsLayer;
            //graphicsLayer.ClearGraphics();

            Graphic drawingGrpahic = new Graphic();

            drawingGrpahic.Geometry = geom;

            drawingGrpahic.SetZIndex(1);
            graphicsLayer.Graphics.Add(drawingGrpahic);

            MapControl.geoService.BufferCompleted += GeometryService_BufferCompleted;
            MapControl.geoService.Failed += GeometryService_Failed;

            // If buffer spatial reference is GCS and unit is linear, geometry service will do geodesic buffering
            BufferParameters bufferParams = new BufferParameters()
            {
                Unit = LinearUnit.Meter,
                BufferSpatialReference = new SpatialReference(102100),
                OutSpatialReference = drawingGrpahic.Geometry.SpatialReference
            };
            bufferParams.Features.Add(drawingGrpahic);
            bufferParams.Distances.Add(double.Parse(searchRadiousTextBox.Text));

            MapControl.geoService.BufferAsync(bufferParams);
        }

        void GeometryService_BufferCompleted(object sender, GraphicsEventArgs args)
        {
            IList<Graphic> results = args.Results;
            GraphicsLayer graphicsLayer = MapOperations.map1.Layers["gLayersSelection"] as GraphicsLayer;

            foreach (Graphic graphic in results)
            {
                graphic.Symbol = App.Current.Resources["DefaultBufferSymbol"] as ESRI.ArcGIS.Client.Symbols.Symbol;
                try
                {
                    graphicsLayer.Graphics.Add(graphic);
                }
                catch (Exception ee)
                {

                }
                
            }
        }

        private void GeometryService_Failed(object sender, TaskFailedEventArgs e)
        {
            MessageBox.Show("Geometry Service error: " + e.Error);
        }
        //private void QueryTaskForGraphics_ExecuteCompleted(object sender, ESRI.ArcGIS.Client.Tasks.QueryEventArgs args)
        //{
        //    FeatureSet featureSet = args.FeatureSet;

        //    if (featureSet == null || featureSet.Features.Count < 1)
        //    {
        //        MessageBox.Show("No features retured from query");
        //        return;
        //    }

        //    //this.graphicsLayer = map1.Layers["MySelectionGraphicsLayer"] as GraphicsLayer;

        //    if (featureSet != null && featureSet.Features.Count > 0)
        //    {
        //        //this.testGraphicCollection.Clear();
        //        foreach (Graphic feature in featureSet.Features)
        //        {
        //            FillSymbol SampleStyle1 = App.Current.Resources["ResultsFillSymbol"] as FillSymbol;

        //            feature.Symbol = SampleStyle1;
        //            MapControl.geoMapsGraphicsLayer.Graphics.Add(feature);

        //            //this.testGraphicCollection.Add(feature);
        //        }

        //        //if (clipMode)
        //        if (RibbonBar.clipString.Contains("Clipped"))
        //        {
        //            List<Graphic> sa = RibbonBar.geoMapsDatagrid.ItemsSource as List<Graphic>;

        //            //List<DataGridRow> sa2 = sa.ToList<DataGridRow>();

        //            //foreach (DataGridRow row in QueryDetailsDataGrid.ItemsSource)
        //            //{
        //            //    MessageBox.Show(row.GetIndex().ToString());
        //            //}

        //            for (int i = 0; i < featureSet.Features.Count; i++)
        //            {
        //                //DataItemGraphic d = new DataItemGraphic();
        //                //d.FID = sa[i].Attributes["FID"].ToString();
        //                //d.SheetName = sa[i].Attributes["SheetName"].ToString();



        //                //graphic2sheetName.Add(graphicCounter++, sa[i].Attributes["SheetName"].ToString());
        //                RibbonBar.geoMapsDatagrid.SelectedItems.Add(sa[i]);
        //            }
        //        }
        //    }
        //    MySpatialQuerySurface.IsEnabled = false;

        //    GeoMapsOperations.gLayerVisibility.IsChecked = true;
        //}
        //private void QueryTaskForGraphics_Failed(object sender, TaskFailedEventArgs args)
        //{
        //    MessageBox.Show("Query failed: " + args.Error);
        //}
    }
}
