using System;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
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
using LanSysWebGIS.Assets.Resources;
using LanSysWebGIS.UserControls;
using LanSysWebGIS.UserControls.GeoMaps;

namespace LanSysWebGIS.Models
{
    public class GeoMapsOperations
    {
        #region Fields & Properties

        public static Map map1;

        public static ArcGISDynamicMapServiceLayer indexService;

        public static ArcGISDynamicMapServiceLayer georeferenced100kNIOCService;
        public static ArcGISDynamicMapServiceLayer georeferenced100kNIOCServiceClipped;
        public static ArcGISDynamicMapServiceLayer georeferenced1000kNIOCService;
        public static ArcGISDynamicMapServiceLayer georeferenced1000kNIOCServiceClipped;
        //public static ArcGISDynamicMapServiceLayer georeferenced100kGSIService;
        public static ArcGISDynamicMapServiceLayer georeferenced100kGSIServiceClipped;

        public static ArcGISDynamicMapServiceLayer PMOImagesServiceClipped;

        public static ArcGISDynamicMapServiceLayer activeService = new ArcGISDynamicMapServiceLayer();
        public static Dictionary<string, int> activeServiceLayerIDs = new Dictionary<string, int>();

        public static Dictionary<string, ArcGISDynamicMapServiceLayer> serviceName2ServiceDictionary = new Dictionary<string, ArcGISDynamicMapServiceLayer>();
        public static Dictionary<string, Dictionary<string, int>> serviceName2ServiceLayerIDsDictionary = new Dictionary<string, Dictionary<string, int>>();

        public static Dictionary<int, string> index2PureServiceNameDictionary = new Dictionary<int, string>() { 
        { 0, "PMOImagesService" },
        { 1, "georeferenced100kNIOCService" },
        { 2, "georeferenced1000kNIOCService" },
        { 3, "georeferenced100kGSIService" }
        };

        public static RadioButton shpRadio;
        public static RadioButton geoRadio;
        //public static RadioButton scanRadio;

        public static CheckBox gLayerVisibility;

        public static GraphicCollection sheetGraphicCollection = new GraphicCollection();
        public static GraphicCollection testGraphicCollection = new GraphicCollection();

        public static Dictionary<string, int> spatialReferenceName2WKID = new Dictionary<string, int>() { 
        { "Geographic", 4326 }, 
        { "UTM 38N WGS84", 32638 },
        { "UTM 39N WGS84", 32639 },
        { "UTM 40N WGS84", 32640 },
        { "UTM 41N WGS84", 32641 }
        };

        public static Dictionary<string, int> spatialReferenceName2Zone = new Dictionary<string, int>() { 
        { "Geographic", 0 }, 
        { "UTM 38N WGS84", 38 },
        { "UTM 39N WGS84", 39 },
        { "UTM 40N WGS84", 40 },
        { "UTM 41N WGS84", 41 }
        };

        public static string geometryServiceMode = "";

        public static IList<Graphic> projectedGraphics;

        public static Envelope resultsExtent = new Envelope();

        public static TextBlock messageTextBlock01;
        public static TextBlock messageTextBlock02;
        //public static TextBlock messageTextBlock2;

        public static CheckBox shpAvailableCheckBox;
        public static CheckBox georeferenceAvailableCheckBox;
        public static CheckBox scanAvailableCheckBox;

        public static Button checkAvailabilityButton;
        public static Button exportButton;

        public static string searchMethod = "";

        public static SpatialRelationship QuerySpatialRelationship = SpatialRelationship.esriSpatialRelIntersects;
        public static ESRI.ArcGIS.Client.Geometry.Geometry QueryGeometry;

        #endregion

        #region Change Service

        public static void ChangeService(int selectedIndex, string clipString)
        {
            if (indexService == null)
            {
                throw new Exception(GeoMapsStrings.SpatialServiceError);
            }

            //todo for &
            if (selectedIndex == 4)
            {
                indexService.VisibleLayers = new int[] { 0, 2 };

                try
                {
                    activeService = serviceName2ServiceDictionary[(index2PureServiceNameDictionary[0]) + clipString];
                    activeServiceLayerIDs = serviceName2ServiceLayerIDsDictionary[(index2PureServiceNameDictionary[0]) + clipString];
                }
                catch (Exception a)
                {
                }
            }
            else
            {
                indexService.VisibleLayers = new int[] { selectedIndex };

                try
                {
                    activeService = serviceName2ServiceDictionary[(index2PureServiceNameDictionary[selectedIndex]) + clipString];
                    activeServiceLayerIDs = serviceName2ServiceLayerIDsDictionary[(index2PureServiceNameDictionary[selectedIndex]) + clipString];
                }
                catch (Exception a)
                {
                }

                //todo for autocomplete textbox
                FillAutoCompleteTextBox(selectedIndex);

                //todo for clear the map
                ClearAll();

                //todo for query builder
                //try
                //{
                //    QueryLayersComboBox.SelectedIndex = selectedIndex;
                //}
                //catch (Exception ex)
                //{
                //}
            }
        }

        #endregion

        #region Auto Compelete TextBox

        public static void FillAutoCompleteTextBox(int selectedIndex)
        {
            QueryTask queryTask = new QueryTask(indexService.Url + "/" + selectedIndex);
            queryTask.ExecuteCompleted += FillAutoCompleteTextBox_ExecuteCompleted;
            queryTask.Failed += FillAutoCompleteTextBox_Failed;

            Query query = new Query();
            query.ReturnGeometry = false;
            query.OutSpatialReference = map1.SpatialReference;
            //query.OutFields.AddRange(new string[] { "SheetName", "SheetNumber" });
            query.OutFields.AddRange(new string[] { "SheetName" });
            query.Where = String.Format("1=1");

            queryTask.ExecuteAsync(query);
        }
        private static void FillAutoCompleteTextBox_ExecuteCompleted(object sender, QueryEventArgs args)
        {
            if (args.FeatureSet.Features.Count > 0)
            {
                //messageTextBlock.Text = " Feature found !";

                //sheetNameAutoCompleteTextBox.Text = args.FeatureSet.Features[0].Attributes["SheetName"].ToString();

                //graphicForQuery = args.FeatureSet.Features[0];

                //if (tagNumber == 0 && !fillingSheetNameAutoCompleteTextBox)
                //{
                //    //Initialize radio buttons
                //    shpRadioButton.IsEnabled = args.FeatureSet.Features[0].Attributes["isSHP"].ToString() == "1";
                //    shpRadioButton.IsChecked = false;

                //    georeferenceRadioButton.IsEnabled = args.FeatureSet.Features[0].Attributes["isGEOREF"].ToString() == "1";
                //    georeferenceRadioButton.IsChecked = false;

                //    scanRadioButton.IsEnabled = args.FeatureSet.Features[0].Attributes["isScan"].ToString() == "1";
                //    scanRadioButton.IsChecked = false;

                //    viewButton.IsEnabled = (shpRadioButton.IsEnabled || georeferenceRadioButton.IsEnabled || scanRadioButton.IsEnabled);
                //    downloadButton.IsEnabled = (shpRadioButton.IsEnabled || georeferenceRadioButton.IsEnabled || scanRadioButton.IsEnabled);
                //}
                //else
                //{
                //    //IntersectPolygons();
                //}

                //if (fillingSheetNameAutoCompleteTextBox)
                //{
                List<string> allSheetName = new List<string>();
                //List<string> allSheetNumber = new List<string>();

                foreach (Graphic graphic in args.FeatureSet.Features)
                {
                    allSheetName.Add(graphic.Attributes["SheetName"].ToString());
                    //allSheetNumber.Add(graphic.Attributes["SheetNumber"].ToString());
                }

                //sheetNameAutoCompleteTextBox.ItemsSource = allSheetName;
                //sheetNumberAutoCompleteTextBox.ItemsSource = allSheetNumber;

                if (SearchName.searchNameAutoCompleteBox != null)
                {
                    SearchName.searchNameAutoCompleteBox.ItemsSource = allSheetName;
                }

                //if (SearchMapNumber.searchMapNumberAutoCompleteBox != null)
                //{
                //    SearchMapNumber.searchMapNumberAutoCompleteBox.ItemsSource = allSheetNumber;
                //}

                //}
            }
            else
            {
                //messageTextBlock.Text = " No features found !";

                //sheetNameAutoCompleteTextBox.Text = "";

                //shpRadioButton.IsEnabled = false;
                //shpRadioButton.IsChecked = false;
                //georeferenceRadioButton.IsEnabled = false;
                //georeferenceRadioButton.IsChecked = false;
                //scanRadioButton.IsEnabled = false;
                //scanRadioButton.IsChecked = false;

                //viewButton.IsEnabled = false;
                //downloadButton.IsEnabled = false;
            }

            //fillingSheetNameAutoCompleteTextBox = false;

        }
        private static void FillAutoCompleteTextBox_Failed(object sender, TaskFailedEventArgs args)
        {
            //MessageBox.Show("Query failed: " + args.Error);
        }

        #endregion

        #region Create Graphic

        public static Graphic CreateMapPointGraphic(string x, string y, SpatialReference sp)
        {
            ESRI.ArcGIS.Client.Geometry.MapPoint xyPoint;

            Graphic graphic = new Graphic();

            try
            {
                double xDouble = Double.Parse(x);
                double yDouble = Double.Parse(y);

                //xyPoint = new ESRI.ArcGIS.Client.Geometry.MapPoint(xDouble, yDouble, map1.SpatialReference);

                xyPoint = new ESRI.ArcGIS.Client.Geometry.MapPoint(xDouble, yDouble, sp);

                graphic = new Graphic()
                {
                    Geometry = xyPoint,
                    Symbol = new SimpleMarkerSymbol()
                };
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Invalid Coordinate!");
            }


            return graphic;
        }

        #endregion

        #region Clear

        public static void ClearAll()
        {
            shpRadio.IsEnabled = false;
            shpRadio.IsChecked = false;
            geoRadio.IsEnabled = false;
            geoRadio.IsChecked = false;
            //scanRadio.IsEnabled = false;
            //scanRadio.IsChecked = false;

            try
            {
                //this.sheetGraphic = null;

                gLayerVisibility.IsChecked = false;

                MapControl.geoMapsGraphicsLayer.ClearGraphics();



            }
            catch (Exception ex4)
            {
            }

            try
            {
                MapControl.geoMapsXYGraphicsLayer.ClearGraphics();
            }
            catch (Exception ex00)
            {
            }

            //try
            //{
            //    //isSHPDataAvailabilityChecked = false;
            //    //isGEODataAvailabilityChecked = false;
            //    //isSCANDataAvailabilityChecked = false;

            //    this.DataCheckingSHPGraphicsLayer.ClearGraphics();
            //}
            //catch (Exception ex02)
            //{
            //}

            //try
            //{
            //    this.DataCheckingGEOGraphicsLayer.ClearGraphics();

            //}
            //catch (Exception ex03)
            //{
            //}

            //try
            //{
            //    this.DataCheckingSCANGraphicsLayer.ClearGraphics();
            //}
            //catch (Exception ex04)
            //{
            //}

            //GeoMapsOperations.georeferenced100kNIOCService.Visible = false;
            //GeoMapsOperations.georeferenced100kNIOCServiceClipped.Visible = false;
            //GeoMapsOperations.georeferenced1000kNIOCServiceClipped.Visible = false;
            //GeoMapsOperations.georeferenced1000kNIOCService.Visible = false;
            ////GeoMapsOperations.georeferenced100kGSIService.Visible = false;
            //GeoMapsOperations.georeferenced100kGSIServiceClipped.Visible = false;

            //PMO
            GeoMapsOperations.PMOImagesServiceClipped.VisibleLayers = new int[] { };

            //100k NIOC
            //GeoMapsOperations.georeferenced100kNIOCService.VisibleLayers = new int[] { };
            //GeoMapsOperations.georeferenced100kNIOCServiceClipped.VisibleLayers = new int[] { };

            //1000k NIOC
            //GeoMapsOperations.georeferenced1000kNIOCService.VisibleLayers = new int[] { };
            //GeoMapsOperations.georeferenced1000kNIOCServiceClipped.VisibleLayers = new int[] { };

            //100k GSI
            //GeoMapsOperations.georeferenced100kGSIService.VisibleLayers = new int[] { };
            //GeoMapsOperations.georeferenced100kGSIServiceClipped.VisibleLayers = new int[] { };

            RibbonBar.geoMapsDatagrid.ItemsSource = null;

            if (GeoMapsOperations.messageTextBlock01 != null)
            {
                GeoMapsOperations.messageTextBlock01.Text = "";
            }

            if (GeoMapsOperations.messageTextBlock02 != null)
            {
                GeoMapsOperations.messageTextBlock02.Text = "";
            }



            //messageTextBlock2.Text = "";

            //messageTextBlock03.Text = "";
            //messageTextBlock04.Text = "";


            GeoMapsOperations.map1.ZoomTo(GeoMapsOperations.map1.Layers[1].FullExtent);

            //try
            //{
            //    graphicsLayerVisibility.IsChecked = true;
            //}
            //catch (Exception ex0)
            //{
            //}

            GeoMapsOperations.resultsExtent = null;

            //todo for query builder
            //ClearGraphicsQueryBuilder();

            //todo for available data button
            ClearAvailableDataButton();
        }

        public static void ClearAvailableDataButton()
        {
            try
            {
                //isSHPDataAvailabilityChecked = false;
                //isGEODataAvailabilityChecked = false;
                //isSCANDataAvailabilityChecked = false;

                MapControl.geoMapsDataCheckingGEOGraphicsLayer.ClearGraphics();
            }
            catch (Exception ee1)
            {
            }

            try
            {
                MapControl.geoMapsDataCheckingSCANGraphicsLayer.ClearGraphics();
            }
            catch (Exception ee1)
            {
            }

            try
            {
                MapControl.geoMapsDataCheckingSHPGraphicsLayer.ClearGraphics();
            }
            catch (Exception ee1)
            {
            }

            if (shpAvailableCheckBox != null)
            {
                shpAvailableCheckBox.IsChecked = false;
                georeferenceAvailableCheckBox.IsChecked = false;
                scanAvailableCheckBox.IsChecked = false;

                checkAvailabilityButton.IsEnabled = false;
                exportButton.IsEnabled = false;
            }
        }

        #endregion

        #region Query

        private static List<Graphic> hybridGraphicCollection = new List<Graphic>();

        public static void DoQuery(bool returnGeometry, string where)
        {
            //todo for &
            if (RibbonBar.selectedIndex == 3)
            {
                hybridGraphicCollection.Clear();

                QueryTask queryTask = new QueryTask(MapControl.indexService.Url + "/" + 0);

                queryTask.ExecuteCompleted += GeoMapsQuery_ExecuteCompleted;
                queryTask.Failed += GeoMapsQuery_Failed;

                Query query = new Query();
                query.ReturnGeometry = returnGeometry;
                query.OutSpatialReference = GeoMapsOperations.map1.SpatialReference;
                //query.OutFields.AddRange(new string[] { "SheetName", "SheetNumber", "isSHP", "isGEO", "isSCAN" });
                query.OutFields.AddRange(new string[] { "SheetName", "isSHP", "isGEO" });
                query.Where = where;

                if (searchMethod == "SearchName")
                {
                    //Nothing
                }
                else if (searchMethod == "SearchMapNumber")
                {

                }
                else if (searchMethod == "SearchGraphics")
                {
                    query.Geometry = QueryGeometry;
                }
                else if (searchMethod == "SearchCoordinate")
                {
                    query.SpatialRelationship = QuerySpatialRelationship;

                    query.Geometry = QueryGeometry;
                }
                else if (searchMethod == "SearchCoorArea")
                {
                    query.SpatialRelationship = QuerySpatialRelationship;

                    query.Geometry = QueryGeometry;
                }

                queryTask.ExecuteAsync(query);

                queryTask = new QueryTask(MapControl.indexService.Url + "/" + 2);
                queryTask.ExecuteCompleted += GeoMapsQuery_ExecuteCompleted;
                queryTask.Failed += GeoMapsQuery_Failed;

                queryTask.ExecuteAsync(query);
            }
            else
            {
                QueryTask queryTask = new QueryTask(MapControl.indexService.Url + "/" + RibbonBar.selectedIndex);

                queryTask.ExecuteCompleted += GeoMapsQuery_ExecuteCompleted;
                queryTask.Failed += GeoMapsQuery_Failed;

                // Bind data grid to query results
                Binding resultFeaturesBinding = new Binding("LastResult.Features");
                resultFeaturesBinding.Source = queryTask;
                RibbonBar.geoMapsDatagrid.SetBinding(DataGrid.ItemsSourceProperty, resultFeaturesBinding);

                Query query = new Query();
                query.ReturnGeometry = returnGeometry;
                query.OutSpatialReference = GeoMapsOperations.map1.SpatialReference;
                //query.OutFields.AddRange(new string[] { "SheetName", "SheetNumber", "isSHP", "isGEO", "isSCAN" });
                query.OutFields.AddRange(new string[] { "SheetName", "isSHP", "isGEO" });
                query.Where = where;

                if (searchMethod == "SearchName")
                {
                    //Nothing
                }
                else if (searchMethod == "SearchMapNumber")
                {

                }
                else if (searchMethod == "SearchGraphics")
                {
                    query.Geometry = QueryGeometry;
                }
                else if (searchMethod == "SearchCoordinate")
                {
                    query.SpatialRelationship = QuerySpatialRelationship;

                    query.Geometry = QueryGeometry;
                }
                else if (searchMethod == "SearchCoorArea")
                {
                    query.SpatialRelationship = QuerySpatialRelationship;

                    query.Geometry = QueryGeometry;
                }

                queryTask.ExecuteAsync(query);
            }
        }

        private static void GeoMapsQuery_ExecuteCompleted(object sender, ESRI.ArcGIS.Client.Tasks.QueryEventArgs args)
        {
            FeatureSet featureSet = args.FeatureSet;

            // args.FeatureSet.Features.Count == 1
            if (featureSet != null && featureSet.Features.Count > 0)
            {
                if (RibbonBar.selectedIndex == 3)
                {
                    foreach (Graphic feature in featureSet.Features)
                    {
                        FillSymbol SampleStyle1 = App.Current.Resources["ResultsFillSymbol"] as FillSymbol;

                        feature.Symbol = SampleStyle1;
                        MapControl.geoMapsGraphicsLayer.Graphics.Add(feature);

                        hybridGraphicCollection.Add(feature);
                    }

                    RibbonBar.geoMapsDatagrid.ItemsSource = hybridGraphicCollection;

                    //if (clipMode)
                    if (RibbonBar.clipString.Contains("Clipped"))
                    {
                        List<Graphic> sa = RibbonBar.geoMapsDatagrid.ItemsSource as List<Graphic>;

                        //List<DataGridRow> sa2 = sa.ToList<DataGridRow>();

                        //foreach (DataGridRow row in QueryDetailsDataGrid.ItemsSource)
                        //{
                        //    MessageBox.Show(row.GetIndex().ToString());
                        //}

                        RibbonBar.geoMapsDatagrid.SelectedItems.Clear();

                        for (int i = 0; i < hybridGraphicCollection.Count; i++)
                        {
                            //DataItemGraphic d = new DataItemGraphic();
                            //d.FID = sa[i].Attributes["FID"].ToString();
                            //d.SheetName = sa[i].Attributes["SheetName"].ToString();



                            //graphic2sheetName.Add(graphicCounter++, sa[i].Attributes["SheetName"].ToString());
                            try
                            {
                                RibbonBar.geoMapsDatagrid.SelectedItems.Add(sa[i]);
                            }
                            catch (Exception aad)
                            {
                            }
                        }
                    }

                    if (searchMethod == "SearchName")
                    {
                        messageTextBlock01.Text = "پیدا شد !";
                    }
                    else if (searchMethod == "SearchMapNumber")
                    {
                        messageTextBlock02.Text = "پیدا شد !";
                    }
                    else if (searchMethod == "SearchGraphics")
                    {
                        SearchGraphics.MySpatialQuerySurface.IsEnabled = false;
                    }
                    else if (searchMethod == "SearchCoordinate")
                    {

                    }
                    else if (searchMethod == "SearchCoorArea")
                    {

                    }
                }
                else
                {
                    if (searchMethod == "SearchGraphics" || searchMethod == "SearchCoorArea")
                    {
                        foreach (Graphic feature in featureSet.Features)
                        {
                            FillSymbol SampleStyle1 = App.Current.Resources["ResultsFillSymbol"] as FillSymbol;

                            feature.Symbol = SampleStyle1;
                            MapControl.geoMapsGraphicsLayer.Graphics.Add(feature);
                        }

                        //if (clipMode)
                        if (RibbonBar.clipString.Contains("Clipped"))
                        {
                            List<Graphic> sa = RibbonBar.geoMapsDatagrid.ItemsSource as List<Graphic>;

                            //List<DataGridRow> sa2 = sa.ToList<DataGridRow>();

                            //foreach (DataGridRow row in QueryDetailsDataGrid.ItemsSource)
                            //{
                            //    MessageBox.Show(row.GetIndex().ToString());
                            //}

                            for (int i = 0; i < featureSet.Features.Count; i++)
                            {
                                //DataItemGraphic d = new DataItemGraphic();
                                //d.FID = sa[i].Attributes["FID"].ToString();
                                //d.SheetName = sa[i].Attributes["SheetName"].ToString();



                                //graphic2sheetName.Add(graphicCounter++, sa[i].Attributes["SheetName"].ToString());
                                RibbonBar.geoMapsDatagrid.SelectedItems.Add(sa[i]);
                            }
                        }
                    }
                    else
                    {
                        Graphic sheetGraphic = args.FeatureSet.Features[0];


                        //this.graphicsLayer = map1.Layers["MySelectionGraphicsLayer"] as GraphicsLayer;
                        //this.graphicsLayer.ClearGraphics();

                        MapControl.geoMapsGraphicsLayer.ClearGraphics();



                        FillSymbol SampleStyle1 = App.Current.Resources["ResultsFillSymbol"] as FillSymbol;

                        sheetGraphic.Symbol = SampleStyle1;
                        MapControl.geoMapsGraphicsLayer.Graphics.Add(sheetGraphic);



                        GeoMapsOperations.shpRadio.IsEnabled = sheetGraphic.Attributes["isSHP"].ToString() == "1";
                        GeoMapsOperations.shpRadio.IsChecked = false;

                        GeoMapsOperations.geoRadio.IsEnabled = sheetGraphic.Attributes["isGEO"].ToString() == "1";
                        GeoMapsOperations.geoRadio.IsChecked = false;

                        //GeoMapsOperations.scanRadio.IsEnabled = sheetGraphic.Attributes["isSCAN"].ToString() == "1";
                        //GeoMapsOperations.scanRadio.IsChecked = false;

                        GeoMapsOperations.testGraphicCollection.Clear();
                        GeoMapsOperations.testGraphicCollection.Add(sheetGraphic);
                    }

                    GeoMapsOperations.gLayerVisibility.IsChecked = true;

                    if (searchMethod == "SearchName")
                    {
                        messageTextBlock01.Text = "پیدا شد !";
                    }
                    else if (searchMethod == "SearchMapNumber")
                    {
                        messageTextBlock02.Text = "پیدا شد !";
                    }
                    else if (searchMethod == "SearchGraphics")
                    {
                        SearchGraphics.MySpatialQuerySurface.IsEnabled = false;
                    }
                    else if (searchMethod == "SearchCoordinate")
                    {

                    }
                    else if (searchMethod == "SearchCoorArea")
                    {

                    }
                }
            }
            else
            {
                if (searchMethod == "SearchName")
                {
                    messageTextBlock01.Text = "پیدا نشد !";
                }
                else if (searchMethod == "SearchMapNumber")
                {
                    messageTextBlock02.Text = "پیدا نشد !";
                }
                else if (searchMethod == "SearchGraphics")
                {
                    MessageBox.Show("No features retured from query");
                }
                else if (searchMethod == "SearchCoordinate")
                {

                }
                else if (searchMethod == "SearchCoorArea")
                {

                }


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
        private static void GeoMapsQuery_Failed(object sender, TaskFailedEventArgs args)
        {
            MessageBox.Show("Query failed: " + args.Error);
        }

        #endregion

    }
}
