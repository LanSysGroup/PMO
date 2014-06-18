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
    public partial class SearchCoorArea : UserControl
    {
        private SpatialReference bboxSelectedSpatialReference;

        private static int UtmZone = 0;

        public SearchCoorArea()
        {
            InitializeComponent();
        }

        private void bboxSpatialReferenceComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem item = (sender as ComboBox).SelectedItem as ComboBoxItem;

            if ((sender as ComboBox).SelectedIndex > 0)
            {
                bboxSelectedSpatialReference = new SpatialReference(GeoMapsOperations.spatialReferenceName2WKID[item.Content.ToString()]);

                UtmZone = GeoMapsOperations.spatialReferenceName2Zone[item.Content.ToString()];
            }
            else
            {
                bboxSelectedSpatialReference = null;
            }

            //if (item.Content.ToString() == "Geographic")
            //{
            //    if (xCoordinateLabel != null)
            //    {
            //        xCoordinateLabel.Content = "Lon:";
            //        yCoordinateLabel.Content = "Lat:";

            //        //xSearchTextBoxWaterMark.Text = "Longitude";
            //        //ySearchTextBoxWaterMark.Text = "Latitude";

            //        xMinSearchTextBox.Focus();
            //        yMinSearchTextBox.Focus();
            //        xMaxSearchTextBox.Focus();
            //        yMaxSearchTextBox.Focus();
            //    }
            //}
            //else
            //{
                try
                {
                    //xMinSearchTextBoxWatermark.Text = "X Min";
                    //yMinSearchTextBoxWatermark.Text = "Y Min";
                    //xMaxSearchTextBoxWatermark.Text = "X Max";
                    //yMaxSearchTextBoxWatermark.Text = "Y Max";

                    xMinSearchTextBox.Focus();
                    yMinSearchTextBox.Focus();
                    xMaxSearchTextBox.Focus();
                    yMaxSearchTextBox.Focus();
                }
                catch (Exception ex00)
                {
                }
            //}
        }

        private void searchBBoxButton_Click(object sender, RoutedEventArgs e)
        {
            GeoMapsOperations.geometryServiceMode = "BBOX";

            string xMin = xMinSearchTextBox.Text;
            string xMax = xMaxSearchTextBox.Text;
            string yMin = yMinSearchTextBox.Text;
            string yMax = yMaxSearchTextBox.Text;

            double xMinDouble = 0;
            double xMaxDouble = 0;
            double yMinDouble = 0;
            double yMaxDouble = 0;

            ESRI.ArcGIS.Client.Geometry.Envelope envelope;

            try
            {
                xMinDouble = Double.Parse(xMin);
                xMaxDouble = Double.Parse(xMax);
                yMinDouble = Double.Parse(yMin);
                yMaxDouble = Double.Parse(yMax);
            }
            catch (Exception ex)
            {
                MessageBox.Show("مختصات نامعتبر است!");
            }

            MapControl.geoMapsXYGraphicsLayer.ClearGraphics();

            if (bboxSelectedSpatialReference != null)
            {
                envelope = new ESRI.ArcGIS.Client.Geometry.Envelope(xMinDouble, yMinDouble, xMaxDouble, yMaxDouble);

                envelope.SpatialReference = bboxSelectedSpatialReference;

                Graphic g = new Graphic();
                g.Geometry = envelope;

                //Graphic pointGraphic = CreateMapPointGraphic(xTextBox.Text, yTextBox.Text, gotoxySelectedSpatialReference);

                IList<Graphic> gg = new List<Graphic>();
                gg.Add(g);

                ProjectCoordinate(gg, GeoMapsOperations.map1.SpatialReference);
            }
            else
            {
                envelope = new ESRI.ArcGIS.Client.Geometry.Envelope(xMinDouble, yMinDouble, xMaxDouble, yMaxDouble);

                envelope.SpatialReference = GeoMapsOperations.map1.SpatialReference;

                Graphic g = new Graphic();
                g.Geometry = envelope;

                FillSymbol SampleStyle1 = App.Current.Resources["DefaultFillSymbol"] as FillSymbol;

                g.Symbol = SampleStyle1;

                MapControl.geoMapsXYGraphicsLayer.Graphics.Add(g);

                GeoMapsOperations.QuerySpatialRelationship = ESRI.ArcGIS.Client.Tasks.SpatialRelationship.esriSpatialRelIntersects;

                GeoMapsOperations.QueryGeometry = g.Geometry;

                GeoMapsOperations.DoQuery(true, "1=1");

                //QueryTask queryTask = new QueryTask(URLIndexService + indexComboBox.SelectedIndex);
                //queryTask.ExecuteCompleted += QueryTaskForBBOX_ExecuteCompleted;
                //queryTask.Failed += QueryTaskForBBOX_Failed;

                //// Bind data grid to query results
                //Binding resultFeaturesBinding = new Binding("LastResult.Features");
                //resultFeaturesBinding.Source = queryTask;
                //QueryDetailsDataGrid.SetBinding(DataGrid.ItemsSourceProperty, resultFeaturesBinding);

                //Query query = new ESRI.ArcGIS.Client.Tasks.Query();

                //// Specify fields to return from query
                //query.OutFields.AddRange(new string[] { "SheetName", "SheetNumber", "isSHP", "isGEO", "isSCAN" });
                //query.Geometry = envelope;

                //// Return geometry with result features
                //query.ReturnGeometry = true;
                //query.OutSpatialReference = map1.SpatialReference;

                //queryTask.ExecuteAsync(query);
                ////Graphic pointGraphic = CreateMapPointGraphic(xTextBox.Text, yTextBox.Text, map1.SpatialReference);

                //try
                //{
                //    XYGraphicsLayer.Graphics.Add(pointGraphic);

                //    ESRI.ArcGIS.Client.Geometry.Envelope envelope =
                //        new ESRI.ArcGIS.Client.Geometry.Envelope(pointGraphic.Geometry.Extent.XMin - 30000, pointGraphic.Geometry.Extent.YMin - 30000, pointGraphic.Geometry.Extent.XMax + 30000, pointGraphic.Geometry.Extent.YMax + 30000);

                //    map1.ZoomTo(envelope);
                //}
                //catch (Exception e1)
                //{
                //    MessageBox.Show("Invalid Coordinate !");
                //}

            }
        }

        public static void ProjectCoordinate(IList<Graphic> graphics, SpatialReference outSpatialReference)
        {
            string[] xyMin = new string[5];

            string[] xyMax = new string[5];

            List<Graphic> grList = new List<Graphic>();

            if (UtmZone == 0)
            {

            }
            else
            {
                foreach (Graphic graphic in graphics)
                {
                    xyMin = Helpers.CoordinateTransformer.UTMToWGS84(graphic.Geometry.Extent.YMin,
                                                                     graphic.Geometry.Extent.XMin, UtmZone, true, 4);

                    Graphic gr = new Graphic();

                    MapPoint mapPointMin = new MapPoint();

                    mapPointMin.X = double.Parse(xyMin[0]);

                    mapPointMin.Y = double.Parse(xyMin[1]);

                    mapPointMin.SpatialReference = GeoMapsOperations.map1.SpatialReference;

                    xyMax = Helpers.CoordinateTransformer.UTMToWGS84(graphic.Geometry.Extent.YMax,
                                                                     graphic.Geometry.Extent.XMax, UtmZone, true, 4);

                    MapPoint mapPointMax = new MapPoint();

                    mapPointMax.X = double.Parse(xyMax[0]);

                    mapPointMax.Y = double.Parse(xyMax[1]);

                    mapPointMax.SpatialReference = GeoMapsOperations.map1.SpatialReference;

                    Envelope envelope = new Envelope(mapPointMin.X, mapPointMin.Y, mapPointMax.X, mapPointMax.Y);

                    envelope.SpatialReference = GeoMapsOperations.map1.SpatialReference;

                    gr.Geometry = envelope;

                    grList.Add(gr);
                }
            }

            geometryService_ProjectCompleted(null, grList);
        }

        public static void geometryService_ProjectCompleted(object sender, List<Graphic> args)
        {
            if (args != null && args.Count != 0)
            {
                GeoMapsOperations.projectedGraphics = args;

                //Coordinate
                if (GeoMapsOperations.geometryServiceMode == "BBOX")
                {
                    Graphic projectedGraphic = GeoMapsOperations.projectedGraphics[0];

                    FillSymbol SampleStyle1 = App.Current.Resources["DefaultFillSymbol"] as FillSymbol;

                    projectedGraphic.Symbol = SampleStyle1;

                    MapControl.geoMapsXYGraphicsLayer.Graphics.Add(projectedGraphic);

                    GeoMapsOperations.QuerySpatialRelationship = ESRI.ArcGIS.Client.Tasks.SpatialRelationship.esriSpatialRelIntersects;

                    GeoMapsOperations.QueryGeometry = projectedGraphic.Geometry;

                    GeoMapsOperations.DoQuery(true, "1=1");
                }
            }
        }
    }
}
