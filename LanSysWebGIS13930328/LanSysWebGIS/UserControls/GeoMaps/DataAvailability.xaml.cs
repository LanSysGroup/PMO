using System;
using System.Collections.Generic;
using System.IO;
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
using LanSysWebGIS.Models;
using Lite.ExcelLibrary.SpreadSheet;

namespace LanSysWebGIS.UserControls.GeoMaps
{
    public partial class DataAvailability : UserControl
    {
        public DataAvailability()
        {
            InitializeComponent();

            GeoMapsOperations.shpAvailableCheckBox = this.shpAvailableCheckBox;
            GeoMapsOperations.georeferenceAvailableCheckBox = this.shpAvailableCheckBox;
            GeoMapsOperations.scanAvailableCheckBox = this.scanAvailableCheckBox;

            GeoMapsOperations.checkAvailabilityButton = this.checkAvailabilityButton;
            GeoMapsOperations.exportButton = this.exportButton;

            InitDA();
        }

        private void InitDA()
        {
            GeoMapsOperations.ClearAll();

            checkAvailabilityButton.IsEnabled = false;
            exportButton.IsEnabled = false;

            //shpAvailableRadioButton.IsChecked = false;
            //georeferenceAvailableRadioButton.IsChecked = false;
            //scanAvailableRadioButton.IsChecked = false;

            shpAvailableCheckBox.IsChecked = false;
            georeferenceAvailableCheckBox.IsChecked = false;
            scanAvailableCheckBox.IsChecked = false;
        }

        private void checkAvailabilityButton_Click(object sender, RoutedEventArgs e)
        {
            if (RibbonBar.selectedIndex == 3)
            {
                throw new Exception(GeoMapsStrings.DataAvailabilityError);
            }

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

            bool checking = false;
            //try
            //{
            //    this.DataCheckingSHPGraphicsLayer.ClearGraphics();
            //}
            //catch (Exception ex01)
            //{
            //}

            //shpAvailableRadioButton.IsEnabled = false;
            //georeferenceAvailableRadioButton.IsEnabled = false;
            //scanAvailableRadioButton.IsEnabled = false;

            shpAvailableCheckBox.IsEnabled = false;
            georeferenceAvailableCheckBox.IsEnabled = false;
            scanAvailableCheckBox.IsEnabled = false;



            if (shpAvailableCheckBox.IsChecked == true)
            {
                checking = true;

                QueryTask shpQueryTask = new QueryTask(MapControl.indexService.Url + "/" + RibbonBar.selectedIndex);
                shpQueryTask.ExecuteCompleted += checkingSHPAvailableData_ExecuteCompleted;
                shpQueryTask.Failed += checkingSHPAvailableData_Failed;

                Query shpQuery = new Query();
                shpQuery.ReturnGeometry = true;
                shpQuery.OutSpatialReference = GeoMapsOperations.map1.SpatialReference;
                //query.OutFields.AddRange(new string[] { "isGEO" });
                shpQuery.OutFields.Add("*");

                shpQuery.Where = "isSHP=1";
                shpQueryTask.ExecuteAsync(shpQuery);
            }

            if (georeferenceAvailableCheckBox.IsChecked == true)
            {
                checking = true;

                QueryTask geoQueryTask = new QueryTask(MapControl.indexService.Url + "/" + RibbonBar.selectedIndex);
                geoQueryTask.ExecuteCompleted += checkingGEOAvailableData_ExecuteCompleted;
                geoQueryTask.Failed += checkingGEOAvailableData_Failed;

                Query geoQuery = new Query();
                geoQuery.ReturnGeometry = true;
                geoQuery.OutSpatialReference = GeoMapsOperations.map1.SpatialReference;
                //query.OutFields.AddRange(new string[] { "isGEO" });
                geoQuery.OutFields.Add("*");

                geoQuery.Where = "isGEO=1";
                geoQueryTask.ExecuteAsync(geoQuery);
            }

            //if (scanAvailableCheckBox.IsChecked == true)
            //{
            //    checking = true;

            //    QueryTask scanQueryTask = new QueryTask(MapControl.indexService.Url + "/" + RibbonBar.selectedIndex);
            //    scanQueryTask.ExecuteCompleted += checkingSCANAvailableData_ExecuteCompleted;
            //    scanQueryTask.Failed += checkingSCANAvailableData_Failed;

            //    Query scanQuery = new Query();
            //    scanQuery.ReturnGeometry = true;
            //    scanQuery.OutSpatialReference = GeoMapsOperations.map1.SpatialReference;
            //    //query.OutFields.AddRange(new string[] { "isGEO" });
            //    scanQuery.OutFields.Add("*");

            //    scanQuery.Where = "isSCAN=1";
            //    scanQueryTask.ExecuteAsync(scanQuery);
            //}

            if (!checking)
            {
                //shpAvailableRadioButton.IsEnabled = true;
                //georeferenceAvailableRadioButton.IsEnabled = true;
                //scanAvailableRadioButton.IsEnabled = true;

                shpAvailableCheckBox.IsEnabled = true;
                georeferenceAvailableCheckBox.IsEnabled = true;
                scanAvailableCheckBox.IsEnabled = true;
            }




            ////Bind data grid to query results
            //Binding resultFeaturesBinding2 = new Binding("LastResult.Features");
            //resultFeaturesBinding2.Source = queryTask;
            //AvailableDataGrid.SetBinding(DataGrid.ItemsSourceProperty, resultFeaturesBinding2);



            //if (shpAvailableRadioButton.IsChecked == true && isSHPDataAvailabilityChecked == false)
            //{
            //    query.Where = "isSHP=1";
            //    queryTask.ExecuteAsync(query);
            //}
            //else if (georeferenceAvailableRadioButton.IsChecked == true && isGEODataAvailabilityChecked == false)
            //{
            //    query.Where = "isGEO=1";
            //    queryTask.ExecuteAsync(query);
            //}
            //else if (scanAvailableRadioButton.IsChecked == true && isSCANDataAvailabilityChecked == false)
            //{
            //    query.Where = "isSCAN=1";
            //    queryTask.ExecuteAsync(query);
            //}
            //else
            //{
            //    //shpAvailableRadioButton.IsEnabled = true;
            //    //georeferenceAvailableRadioButton.IsEnabled = true;
            //    //scanAvailableRadioButton.IsEnabled = true;

            //    shpAvailableCheckBox.IsChecked = true;
            //    georeferenceAvailableCheckBox.IsChecked = true;
            //    scanAvailableCheckBox.IsChecked = true;
            //}

            //query.Where = "1=1";
            //query.OutFields.AddRange(new string[] { "SheetName", "SheetNumber", "isSHP", "isGEO", "isSCAN" });

            //query.Where = string.Format("SheetName='{0}'", this.sheetName);


        }

        private void checkingSHPAvailableData_ExecuteCompleted(object sender, ESRI.ArcGIS.Client.Tasks.QueryEventArgs args)
        {
            exportButton.IsEnabled = true;

            FeatureSet featureSet = args.FeatureSet;

            //availableDataGrid.ItemsSource = featureSet;
            //MessageBox.Show(AvailableDataGrid.Columns.Count.ToString());

            if (featureSet == null || featureSet.Features.Count < 1)
            {
                MessageBox.Show("No features retured from query");

                shpAvailableCheckBox.IsEnabled = true;
                georeferenceAvailableCheckBox.IsEnabled = true;
                scanAvailableCheckBox.IsEnabled = true;

                return;
            }

            //geoMapsDataCheckingSHPGraphicsLayer = GeoMapsOperations.map1.Layers["DataCheckingSHPGraphicsLayer"] as GraphicsLayer;

            if (featureSet != null && featureSet.Features.Count > 0)
            {
                //isSHPDataAvailabilityChecked = true;

                foreach (Graphic feature in featureSet.Features)
                {
                    FillSymbol SampleStyle1 = App.Current.Resources["SHPDataAvailabilityFillSymbol"] as FillSymbol;

                    feature.Symbol = SampleStyle1;

                    //feature.Symbol = LayoutRoot.Resources["SHPDataAvailabilityFillSymbol"] as FillSymbol;
                    //feature.Symbol = LayoutRoot.Resources["SHPPictureFillSymbol"] as PictureFillSymbol;

                    MapControl.geoMapsDataCheckingSHPGraphicsLayer.Graphics.Add(feature);
                }
            }

            shpAvailableCheckBox.IsEnabled = true;
            georeferenceAvailableCheckBox.IsEnabled = true;
            scanAvailableCheckBox.IsEnabled = true;
        }
        private void checkingSHPAvailableData_Failed(object sender, TaskFailedEventArgs args)
        {
            //shpAvailableRadioButton.IsEnabled = true;
            //georeferenceAvailableRadioButton.IsEnabled = true;
            //scanAvailableRadioButton.IsEnabled = true;

            shpAvailableCheckBox.IsEnabled = true;
            georeferenceAvailableCheckBox.IsEnabled = true;
            scanAvailableCheckBox.IsEnabled = true;

            MessageBox.Show("Query failed: " + args.Error);
        }

        private void checkingGEOAvailableData_ExecuteCompleted(object sender, ESRI.ArcGIS.Client.Tasks.QueryEventArgs args)
        {
            exportButton.IsEnabled = true;

            FeatureSet featureSet = args.FeatureSet;

            //availableDataGrid.ItemsSource = featureSet;
            //MessageBox.Show(AvailableDataGrid.Columns.Count.ToString());

            if (featureSet == null || featureSet.Features.Count < 1)
            {
                MessageBox.Show("No features retured from query");

                shpAvailableCheckBox.IsEnabled = true;
                georeferenceAvailableCheckBox.IsEnabled = true;
                scanAvailableCheckBox.IsEnabled = true;

                return;
            }

            //DataCheckingGEOGraphicsLayer = GeoMapsOperations.map1.Layers["DataCheckingGEOGraphicsLayer"] as GraphicsLayer;

            if (featureSet != null && featureSet.Features.Count > 0)
            {
                //isGEODataAvailabilityChecked = true;

                foreach (Graphic feature in featureSet.Features)
                {
                    FillSymbol SampleStyle1 = App.Current.Resources["GEODataAvailabilityFillSymbol"] as FillSymbol;

                    feature.Symbol = SampleStyle1;
                    
                    //feature.Symbol = LayoutRoot.Resources["GEODataAvailabilityFillSymbol"] as FillSymbol;

                    MapControl.geoMapsDataCheckingGEOGraphicsLayer.Graphics.Add(feature);
                }
            }

            shpAvailableCheckBox.IsEnabled = true;
            georeferenceAvailableCheckBox.IsEnabled = true;
            scanAvailableCheckBox.IsEnabled = true;
        }
        private void checkingGEOAvailableData_Failed(object sender, TaskFailedEventArgs args)
        {
            //shpAvailableRadioButton.IsEnabled = true;
            //georeferenceAvailableRadioButton.IsEnabled = true;
            //scanAvailableRadioButton.IsEnabled = true;

            shpAvailableCheckBox.IsEnabled = true;
            georeferenceAvailableCheckBox.IsEnabled = true;
            scanAvailableCheckBox.IsEnabled = true;

            MessageBox.Show("Query failed: " + args.Error);
        }

        private void checkingSCANAvailableData_ExecuteCompleted(object sender, ESRI.ArcGIS.Client.Tasks.QueryEventArgs args)
        {
            exportButton.IsEnabled = true;

            FeatureSet featureSet = args.FeatureSet;

            //availableDataGrid.ItemsSource = featureSet;
            //MessageBox.Show(AvailableDataGrid.Columns.Count.ToString());

            if (featureSet == null || featureSet.Features.Count < 1)
            {
                MessageBox.Show("No features retured from query");

                shpAvailableCheckBox.IsEnabled = true;
                georeferenceAvailableCheckBox.IsEnabled = true;
                scanAvailableCheckBox.IsEnabled = true;

                return;
            }

            //DataCheckingSCANGraphicsLayer = GeoMapsOperations.map1.Layers["DataCheckingSCANGraphicsLayer"] as GraphicsLayer;

            if (featureSet != null && featureSet.Features.Count > 0)
            {
                //isSCANDataAvailabilityChecked = true;

                foreach (Graphic feature in featureSet.Features)
                {
                    FillSymbol SampleStyle1 = App.Current.Resources["SCANDataAvailabilityFillSymbol"] as FillSymbol;

                    feature.Symbol = SampleStyle1;

                    //feature.Symbol = LayoutRoot.Resources["SCANDataAvailabilityFillSymbol"] as FillSymbol;

                    MapControl.geoMapsDataCheckingSCANGraphicsLayer.Graphics.Add(feature);
                }
            }

            shpAvailableCheckBox.IsEnabled = true;
            georeferenceAvailableCheckBox.IsEnabled = true;
            scanAvailableCheckBox.IsEnabled = true;
        }
        private void checkingSCANAvailableData_Failed(object sender, TaskFailedEventArgs args)
        {
            //shpAvailableRadioButton.IsEnabled = true;
            //georeferenceAvailableRadioButton.IsEnabled = true;
            //scanAvailableRadioButton.IsEnabled = true;

            shpAvailableCheckBox.IsChecked = true;
            georeferenceAvailableCheckBox.IsChecked = true;
            scanAvailableCheckBox.IsChecked = true;

            MessageBox.Show("Query failed: " + args.Error);
        }

        private void clearAvailableDataButton_Click(object sender, RoutedEventArgs e)
        {
            GeoMapsOperations.ClearAvailableDataButton();
        }

        private void AvailableDataType_Checked(object sender, RoutedEventArgs e)
        {
            checkAvailabilityButton.IsEnabled = true;
        }


        private void exportButton_Click(object sender, RoutedEventArgs e)
        {
            Export2Excel(null);
        }

        private void Export2Excel(string mode)
        {
            // open file dialog to select an export file.   
            SaveFileDialog sDialog = new SaveFileDialog();
            sDialog.Filter = "Excel Files(*.xls)|*.xls";

            // create an instance of excel workbook
            Workbook workbook = new Workbook();

            if (sDialog.ShowDialog() == true)
            {
                if (mode != null)
                {
                    //// create a worksheet object
                    //Worksheet queryBuilderWorksheet = new Worksheet("Custom");

                    //GraphicCollection gcollection = gLayerQueryBuilder.Graphics;
                    //int attCount = gcollection[0].Attributes.Count;

                    //Dictionary<int, string> fieldNumber2fieldNameDictionary = new Dictionary<int, string>();

                    //int h = 0;

                    //foreach (var item in gcollection[0].Attributes)
                    //{
                    //    fieldNumber2fieldNameDictionary[h] = item.Key.ToString();

                    //    queryBuilderWorksheet.Cells[0, h++] = new Cell(item.Key.ToString());
                    //}

                    //for (int i = 0; i < gLayerQueryBuilder.Graphics.Count; i++)
                    //{
                    //    for (int j = 0; j < attCount; j++)
                    //    {
                    //        try
                    //        {
                    //            queryBuilderWorksheet.Cells[i + 1, j] = new Cell((gcollection[i].Attributes[fieldNumber2fieldNameDictionary[j]].ToString()));
                    //        }
                    //        catch (Exception qq)
                    //        {
                    //        }
                    //    }
                    //}

                    ////add worksheet to workbook
                    //workbook.Worksheets.Add(queryBuilderWorksheet);
                }
                else
                {
                    if (shpAvailableCheckBox.IsChecked == true)
                    {
                        // create a worksheet object
                        Worksheet shpWorksheet = new Worksheet("Shapefile");

                        GraphicCollection gcollection = MapControl.geoMapsDataCheckingSHPGraphicsLayer.Graphics;
                        int attCount = gcollection[0].Attributes.Count;

                        Dictionary<int, string> fieldNumber2fieldNameDictionary = new Dictionary<int, string>();

                        int h = 0;

                        foreach (var item in gcollection[0].Attributes)
                        {
                            fieldNumber2fieldNameDictionary[h] = item.Key.ToString();

                            shpWorksheet.Cells[0, h++] = new Cell(item.Key.ToString());
                        }

                        for (int i = 0; i < MapControl.geoMapsDataCheckingSHPGraphicsLayer.Graphics.Count; i++)
                        {
                            for (int j = 0; j < attCount; j++)
                            {
                                try
                                {
                                    shpWorksheet.Cells[i + 1, j] = new Cell((gcollection[i].Attributes[fieldNumber2fieldNameDictionary[j]].ToString()));
                                }
                                catch (Exception qq)
                                {
                                }
                            }
                        }

                        //add worksheet to workbook
                        workbook.Worksheets.Add(shpWorksheet);
                    }
                    if (georeferenceAvailableCheckBox.IsChecked == true)
                    {
                        // create a worksheet object
                        Worksheet geoWorksheet = new Worksheet("Georeference");

                        GraphicCollection gcollection = MapControl.geoMapsDataCheckingGEOGraphicsLayer.Graphics;
                        int attCount = gcollection[0].Attributes.Count;

                        Dictionary<int, string> fieldNumber2fieldNameDictionary = new Dictionary<int, string>();

                        int h = 0;

                        foreach (var item in gcollection[0].Attributes)
                        {
                            fieldNumber2fieldNameDictionary[h] = item.Key.ToString();

                            geoWorksheet.Cells[0, h++] = new Cell(item.Key.ToString());
                        }

                        for (int i = 0; i < MapControl.geoMapsDataCheckingGEOGraphicsLayer.Graphics.Count; i++)
                        {
                            for (int j = 0; j < attCount; j++)
                            {
                                try
                                {
                                    geoWorksheet.Cells[i + 1, j] = new Cell((gcollection[i].Attributes[fieldNumber2fieldNameDictionary[j]].ToString()));
                                }
                                catch (Exception qq)
                                {
                                }

                            }
                        }

                        //add worksheet to workbook
                        workbook.Worksheets.Add(geoWorksheet);
                    }
                    if (scanAvailableCheckBox.IsChecked == true)
                    {
                        // create a worksheet object
                        Worksheet scanWorksheet = new Worksheet("Scan");

                        GraphicCollection gcollection = MapControl.geoMapsDataCheckingSCANGraphicsLayer.Graphics;
                        int attCount = gcollection[0].Attributes.Count;

                        Dictionary<int, string> fieldNumber2fieldNameDictionary = new Dictionary<int, string>();

                        int h = 0;

                        foreach (var item in gcollection[0].Attributes)
                        {
                            fieldNumber2fieldNameDictionary[h] = item.Key.ToString();

                            scanWorksheet.Cells[0, h++] = new Cell(item.Key.ToString());
                        }

                        for (int i = 0; i < MapControl.geoMapsDataCheckingSCANGraphicsLayer.Graphics.Count; i++)
                        {
                            for (int j = 0; j < attCount; j++)
                            {
                                try
                                {
                                    scanWorksheet.Cells[i + 1, j] = new Cell((gcollection[i].Attributes[fieldNumber2fieldNameDictionary[j]].ToString()));
                                }
                                catch (Exception qq)
                                {
                                }
                            }
                        }

                        //add worksheet to workbook
                        workbook.Worksheets.Add(scanWorksheet);
                    }
                }

                // get the selected file's stream
                Stream sFile = sDialog.OpenFile();

                try
                {
                    workbook.Save(sFile);
                }
                catch (Exception eee)
                {
                    throw new Exception(eee.Message);
                }
                
            }
        }
    }
}
