using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using ESRI.ArcGIS.Client;
using ESRI.ArcGIS.Client.Geometry;
using ESRI.ArcGIS.Client.Symbols;
using ESRI.ArcGIS.Client.Tasks;
using LanSysWebGIS.Models;

namespace LanSysWebGIS.UserControls.GeoMaps
{
    public partial class SearchCoordinate : UserControl
    {
        private SpatialReference coordinateSelectedSpatialReference;

        private static int UtmZone = 0;

        public SearchCoordinate()
        {
            InitializeComponent();
        }

        private void coordinateSpatialReferenceComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem item = (sender as ComboBox).SelectedItem as ComboBoxItem;

            if ((sender as ComboBox).SelectedIndex > 0)
            {
                coordinateSelectedSpatialReference = new SpatialReference(GeoMapsOperations.spatialReferenceName2WKID[item.Content.ToString()]);

                UtmZone = GeoMapsOperations.spatialReferenceName2Zone[item.Content.ToString()];
            }
            else
            {
                coordinateSelectedSpatialReference = null;
            }

            if (item.Content.ToString() == "Geographic")
            {
                if (xCoordinateLabel != null)
                {
                    xCoordinateLabel.Content = "Lon:";
                    yCoordinateLabel.Content = "Lat:";

                    //xSearchTextBoxWaterMark.Text = "Longitude";
                    //ySearchTextBoxWaterMark.Text = "Latitude";

                    ySearchTextBox.Focus();
                    xSearchTextBox.Focus();
                }
            }
            else
            {
                try
                {
                    xCoordinateLabel.Content = " X : ";
                    yCoordinateLabel.Content = " Y : ";

                    //xSearchTextBoxWaterMark.Text = "X";
                    //ySearchTextBoxWaterMark.Text = "Y";

                    ySearchTextBox.Focus();
                    xSearchTextBox.Focus();
                }
                catch (Exception ex00)
                {
                }
            }
        }

        private void searchCoordinateButton_Click(object sender, RoutedEventArgs e)
        {
            GeoMapsOperations.geometryServiceMode = "Coordinate";

            string x = xSearchTextBox.Text;
            string y = ySearchTextBox.Text;

            //Intersection
            //this.XYGraphicsLayer = map1.Layers["XYGraphicsLayer"] as GraphicsLayer;
            //XYGraphicsLayer.ClearGraphics();

            MapControl.geoMapsXYGraphicsLayer.ClearGraphics();

            if (coordinateSelectedSpatialReference != null)
            {
                Graphic pointGraphic = GeoMapsOperations.CreateMapPointGraphic(x, y, coordinateSelectedSpatialReference);

                IList<Graphic> gg = new List<Graphic>();
                gg.Add(pointGraphic);

                ProjectCoordinate(gg, GeoMapsOperations.map1.SpatialReference);
            }
            else
            {
                Graphic pointGraphic = GeoMapsOperations.CreateMapPointGraphic(x, y, GeoMapsOperations.map1.SpatialReference);

                MapControl.geoMapsXYGraphicsLayer.Graphics.Add(pointGraphic);

                GeoMapsOperations.QuerySpatialRelationship = ESRI.ArcGIS.Client.Tasks.SpatialRelationship.esriSpatialRelIntersects;

                GeoMapsOperations.QueryGeometry = pointGraphic.Geometry;

                GeoMapsOperations.DoQuery(true, "1=1");

                ////Search
                //QueryTask queryTask = new QueryTask(MapControl.indexService.Url + "/" + RibbonBar.selectedIndex);
                //queryTask.ExecuteCompleted += SearchCoordinate_ExecuteCompleted;
                //queryTask.Failed += SearchCoordinate_Failed;

                //// Bind data grid to query results
                //Binding resultFeaturesBinding = new Binding("LastResult.Features");
                //resultFeaturesBinding.Source = queryTask;
                //RibbonBar.geoMapsDatagrid.SetBinding(DataGrid.ItemsSourceProperty, resultFeaturesBinding);

                //Query query = new Query();
                //query.ReturnGeometry = true;
                //query.OutSpatialReference = GeoMapsOperations.map1.SpatialReference;
                //query.OutFields.AddRange(new string[] { "SheetName", "SheetNumber", "isSHP", "isGEO", "isSCAN" });

                ////Point in Polygon
                //query.SpatialRelationship = ESRI.ArcGIS.Client.Tasks.SpatialRelationship.esriSpatialRelIntersects;
                //query.Geometry = pointGraphic.Geometry;

                //queryTask.ExecuteAsync(query);
            }
        }
        private static void SearchCoordinate_ExecuteCompleted(object sender, ESRI.ArcGIS.Client.Tasks.QueryEventArgs args)
        {
            if (args.FeatureSet.Features.Count > 0)
            {
                Graphic sheetGraphic = args.FeatureSet.Features[0];

                //this.graphicsLayer = map1.Layers["MySelectionGraphicsLayer"] as GraphicsLayer;
                //this.graphicsLayer.ClearGraphics();

                MapControl.geoMapsGraphicsLayer.ClearGraphics();

                GeoMapsOperations.gLayerVisibility.IsChecked = true;

                FillSymbol SampleStyle1 = App.Current.Resources["ResultsFillSymbol"] as FillSymbol;

                sheetGraphic.Symbol = SampleStyle1;
                MapControl.geoMapsGraphicsLayer.Graphics.Add(sheetGraphic);

                //messageTextBlock03.Text = sheetGraphic.Attributes["SheetName"].ToString().Length > 2 ? "Found !" : "No Name";

                GeoMapsOperations.shpRadio.IsEnabled = sheetGraphic.Attributes["isSHP"].ToString() == "1";
                GeoMapsOperations.shpRadio.IsChecked = false;

                GeoMapsOperations.geoRadio.IsEnabled = sheetGraphic.Attributes["isGEO"].ToString() == "1";
                GeoMapsOperations.geoRadio.IsChecked = false;

                //GeoMapsOperations.scanRadio.IsEnabled = sheetGraphic.Attributes["isSCAN"].ToString() == "1";
                //GeoMapsOperations.scanRadio.IsChecked = false;

                GeoMapsOperations.testGraphicCollection.Clear();
                GeoMapsOperations.testGraphicCollection.Add(sheetGraphic);
            }
            else
            {
                //messageTextBlock03.Text = "Not found !";

                //sheetNameAutoCompleteTextBox.Text = "";

                GeoMapsOperations.shpRadio.IsEnabled = false;
                GeoMapsOperations.shpRadio.IsChecked = false;
                GeoMapsOperations.geoRadio.IsEnabled = false;
                GeoMapsOperations.geoRadio.IsChecked = false;
                //GeoMapsOperations.scanRadio.IsEnabled = false;
                //GeoMapsOperations.scanRadio.IsChecked = false;

                //viewButton.IsEnabled = false;
                //downloadButton.IsEnabled = false;
            }

            //fillingSheetNameAutoCompleteTextBox = false;

        }
        private static void SearchCoordinate_Failed(object sender, TaskFailedEventArgs args)
        {
            MessageBox.Show("Query failed: " + args.Error);
        }

        public static void ProjectCoordinate(IList<Graphic> graphics, SpatialReference outSpatialReference)
        {
            string[] xy = new string[5];

            if (UtmZone == 0)
            {

            }
            else
            {
                foreach (Graphic graphic in graphics)
                {
                    xy = Helpers.CoordinateTransformer.UTMToWGS84((graphic.Geometry as MapPoint).Y,
                                                             (graphic.Geometry as MapPoint).X,
                                                             UtmZone, true, 4);
                }
            }

            Graphic gr = new Graphic();

            //MapPoint mapPoint = (MapPoint)gr.Geometry;

            MapPoint mapPoint = new MapPoint();

            mapPoint.X = double.Parse(xy[0]);

            mapPoint.Y = double.Parse(xy[1]);

            mapPoint.SpatialReference = GeoMapsOperations.map1.SpatialReference;

            gr.Geometry = mapPoint;

            List<Graphic> grList = new List<Graphic>();

            grList.Add(gr);

            geometryService_ProjectCompleted(null, grList);

            //GeometryService geometryService = new GeometryService(MapControl.GeometryServiceURL);
            //geometryService.ProjectCompleted += new EventHandler<GraphicsEventArgs>(geometryService_ProjectCompleted);

            //geometryService.ProjectAsync(graphics, outSpatialReference);
        }

        public static void geometryService_ProjectCompleted(object sender, List<Graphic> args)
        {
            if (args != null && args.Count != 0)
            {
                GeoMapsOperations.projectedGraphics = args;

                //Coordinate
                if (GeoMapsOperations.geometryServiceMode == "Coordinate")
                {
                    Graphic projectedGraphic = GeoMapsOperations.projectedGraphics[0];
                    projectedGraphic.Symbol = new SimpleMarkerSymbol();

                    MapControl.geoMapsXYGraphicsLayer.Graphics.Add(projectedGraphic);

                    GeoMapsOperations.QuerySpatialRelationship = ESRI.ArcGIS.Client.Tasks.SpatialRelationship.esriSpatialRelIntersects;

                    GeoMapsOperations.QueryGeometry = projectedGraphic.Geometry;

                    GeoMapsOperations.DoQuery(true, "1=1");

                    //QueryTask queryTask = new QueryTask(MapControl.indexService.Url + "/" + RibbonBar.selectedIndex);
                    //queryTask.ExecuteCompleted += SearchCoordinate_ExecuteCompleted;
                    //queryTask.Failed += SearchCoordinate_Failed;

                    //// Bind data grid to query results
                    //Binding resultFeaturesBinding = new Binding("LastResult.Features");
                    //resultFeaturesBinding.Source = queryTask;
                    //RibbonBar.geoMapsDatagrid.SetBinding(DataGrid.ItemsSourceProperty, resultFeaturesBinding);

                    //Query query = new ESRI.ArcGIS.Client.Tasks.Query();

                    //// Specify fields to return from query
                    //query.OutFields.AddRange(new string[] { "SheetName", "SheetNumber", "isSHP", "isGEO", "isSCAN" });


                    //// Return geometry with result features
                    //query.ReturnGeometry = true;
                    //query.OutSpatialReference = GeoMapsOperations.map1.SpatialReference;

                    ////Point in Polygon
                    //query.SpatialRelationship = ESRI.ArcGIS.Client.Tasks.SpatialRelationship.esriSpatialRelIntersects;
                    //query.Geometry = projectedGraphic.Geometry;

                    //queryTask.ExecuteAsync(query);
                }
            }
        }
    }
}
