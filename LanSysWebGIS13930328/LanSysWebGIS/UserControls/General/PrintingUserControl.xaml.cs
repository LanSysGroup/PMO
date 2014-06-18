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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ESRI.ArcGIS.Client;
using ESRI.ArcGIS.Client.Geometry;
using ESRI.ArcGIS.Client.Samples.MapPrinting;
using ESRI.ArcGIS.Client.Tasks;
using LanSysWebGIS.Assets.Resources;
using LanSysWebGIS.Helpers;
using LanSysWebGIS.Models;

namespace LanSysWebGIS.UserControls
{
    public partial class PrintingUserControl : UserControl
    {
        private string styleName;

        //private List<string> sheetNamesList; 

        public static Map mapPrint;

        public MapPoint MidPoint = new MapPoint();

        //public string sheetName = "MARUN";

        public string sheetName = "";

        public string legendBaseURI = "http://asus-nb/GeoMapsImages";

        public string legendTypeURI;
        public string legendTypeURI2;

        //public string legendURI = "http://asus-nb/GeoMapsImages/100kNIOC/MARUN.png";

        public string legendURI = "";

        public Dictionary<string, string> styleNameFa2Eng = new Dictionary<string, string>();

        private Envelope definedExtent = new Envelope();

        private List<GeoMapsLegendItem> LegendItems;

        private int isComboItemsSourceSet = 0;

        public PrintingUserControl()
        {
            InitializeComponent();

            styleNameFa2Eng.Add("ساده", "Basic");
            styleNameFa2Eng.Add("همراه با لژاندر", "WithLegend");
            styleNameFa2Eng.Add("همراه با لژاندر نقشه زمین شناسی", "WithGeoMapsLegend");

            MapOperations.printObject = this;
        }

        private void mapPrinterWithDialog_Loaded(object sender, RoutedEventArgs e)
        {
            mapPrinterWithDialog.Map = mapPrint;

            mapPrinterWithDialog.Map.ExtentChanged += Map_ExtentChanged;
        }

        private void Map_ExtentChanged(object sender, ExtentEventArgs e)
        {
            //mapPrinterWithDialog.XMin = e.NewExtent.XMin.ToString();
        }

        private void comboPrintStyle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = sender as ComboBox;

            //string styleName = null;
            Style style = null;

            if (combo != null && combo.SelectedIndex > 0)
                styleName = styleNameFa2Eng[(string)combo.SelectedItem];
            else if (combo != null && combo.SelectedItem != null && combo.SelectedIndex == 0)
            {
                styleName = "Basic";
            }

            if (!string.IsNullOrEmpty(styleName))
            {
                style = App.Current.Resources[styleName] as Style;
            }

            if (mapPrinterWithDialog != null)
                mapPrinterWithDialog.Style = style;

            if (mapPrinterWithDialog != null && definedExtent.Extent == null)
            {
                definedExtent = mapPrinterWithDialog.PrintExtent;
            }

            if (styleName == "WithGeoMapsLegend" && combo != null && combo.SelectedIndex > 0)
            {
                if (GeoMapsLegendStackPanel != null)
                {
                    //GeoMapsLegendComboBox.IsEnabled = true;
                    //GeoMapsLegendStackPanel.Visibility = Visibility.Visible;

                    //if (combo != null && combo.SelectedIndex > 0)
                    //{
                    //    GeoMapsLegendStackPanel.Height = 22;
                    //}
                    //else
                    //{
                    //    GeoMapsLegendStackPanel.Height = 0;
                    //}

                    GeoMapsLegendStackPanel.Height = 22;


                }

                SelectGeoMapsLegend();
            }
            else
            {
                if (GeoMapsLegendStackPanel != null)
                {
                    //GeoMapsLegendComboBox.IsEnabled = false;
                    //GeoMapsLegendStackPanel.Visibility = Visibility.Collapsed;

                    GeoMapsLegendStackPanel.Height = 0;
                }
            }


        }

        private void SelectGeoMapsLegend()
        {
            try
            {
                LegendItems = new List<GeoMapsLegendItem>();

                isComboItemsSourceSet = 0;

                QueryTask queryTask;

                if (RibbonBar.selectedIndex == 0 || RibbonBar.selectedIndex == 3)
                {
                    queryTask = new QueryTask(MapControl.indexService.Url + "/" + 0);

                    legendTypeURI = "/100kNIOC/";
                    legendTypeURI2 = "/100kGSI/";
                }
                else if (RibbonBar.selectedIndex == 1)
                {
                    queryTask = new QueryTask(MapControl.indexService.Url + "/" + 1);

                    legendTypeURI = "/1000kNIOC/";
                }
                else if (RibbonBar.selectedIndex == 2)
                {
                    queryTask = new QueryTask(MapControl.indexService.Url + "/" + 2);

                    legendTypeURI = "/100kGSI/";
                }
                else if (RibbonBar.selectedIndex == 4)
                {
                    queryTask = new QueryTask(MapControl.indexService.Url + "/" + 4);

                    legendTypeURI = "/250kNIOC/";
                }
                else
                {
                    throw new Exception(GeoMapsStrings.BadPrintingTemplateError);
                }

                queryTask.ExecuteCompleted += GeoMapsSelectIndexQuery_ExecuteCompleted;
                queryTask.Failed += GeoMapsSelectIndexQuery_Failed;

                Query query = new Query();
                query.ReturnGeometry = false;
                //query.Geometry = mapPrinterWithDialog.PrintExtent;
                query.Geometry = definedExtent;
                query.OutSpatialReference = GeoMapsOperations.map1.SpatialReference;
                query.OutFields.AddRange(new string[] { "SheetName" });
                query.Where = "1=1";

                queryTask.ExecuteAsync(query);

                if (RibbonBar.selectedIndex == 3)
                {
                    QueryTask queryTask2 = new QueryTask(MapControl.indexService.Url + "/" + 2);
                    queryTask2.ExecuteCompleted += G2eoMapsSelectIndexQuery_ExecuteCompleted;
                    queryTask2.Failed += G2eoMapsSelectIndexQuery_Failed;

                    queryTask2.ExecuteAsync(query);
                }

            }
            catch (Exception eee)
            {
            }
        }

        private void GeoMapsSelectIndexQuery_ExecuteCompleted(object sender, ESRI.ArcGIS.Client.Tasks.QueryEventArgs args)
        {
            FeatureSet featureSet = args.FeatureSet;

            isComboItemsSourceSet++;

            //LegendItems = new List<GeoMapsLegendItem>();

            if (featureSet != null && featureSet.Features.Count > 0)
            {
                foreach (Graphic feature in featureSet.Features)
                {
                    try
                    {
                        sheetName = feature.Attributes["SheetName"].ToString().Trim();

                        legendURI = legendBaseURI + legendTypeURI + sheetName + ".png";

                        if (!String.IsNullOrWhiteSpace(sheetName))
                        {
                            LegendItems.Add(new GeoMapsLegendItem() { SheetName = sheetName, LegendURI = legendURI, IndexType = legendTypeURI });
                        }
                    }
                    catch (Exception e1)
                    {
                    }
                }

                if (RibbonBar.selectedIndex == 3 && isComboItemsSourceSet == 2)
                {
                    GeoMapsLegendComboBox.ItemsSource = LegendItems;

                    isComboItemsSourceSet = 0;
                }
                else if (RibbonBar.selectedIndex != 3)
                {
                    GeoMapsLegendComboBox.ItemsSource = LegendItems;
                }
            }
            else
            {
                throw new Exception(GeoMapsStrings.BadPrintingExtentError);
            }
        }
        private void GeoMapsSelectIndexQuery_Failed(object sender, TaskFailedEventArgs args)
        {
            isComboItemsSourceSet++;

            if (RibbonBar.selectedIndex != 3)
            {
                LegendItems = new List<GeoMapsLegendItem>();

                GeoMapsLegendComboBox.ItemsSource = null;

                mapPrinterWithDialog.GeoMapsLegendUri = "/LanSysWebGIS;component/Pictures/Icon/legend.jpg";
            }
        }

        private void G2eoMapsSelectIndexQuery_ExecuteCompleted(object sender, ESRI.ArcGIS.Client.Tasks.QueryEventArgs args)
        {
            FeatureSet featureSet = args.FeatureSet;

            isComboItemsSourceSet++;

            if (featureSet != null && featureSet.Features.Count > 0)
            {
                foreach (Graphic feature in featureSet.Features)
                {
                    try
                    {
                        sheetName = feature.Attributes["SheetName"].ToString().Trim();

                        legendURI = legendBaseURI + legendTypeURI2 + sheetName + ".png";

                        if (!String.IsNullOrWhiteSpace(sheetName))
                        {
                            LegendItems.Add(new GeoMapsLegendItem() { SheetName = sheetName, LegendURI = legendURI, IndexType = legendTypeURI2 });
                        }
                    }
                    catch (Exception e1)
                    {
                    }
                }

                if (isComboItemsSourceSet == 2)
                {
                    GeoMapsLegendComboBox.ItemsSource = LegendItems;

                    isComboItemsSourceSet = 0;
                }
            }
            else
            {
                throw new Exception(GeoMapsStrings.BadPrintingExtentError);
            }
        }
        private void G2eoMapsSelectIndexQuery_Failed(object sender, TaskFailedEventArgs args)
        {
            isComboItemsSourceSet++;

            //LegendItems = new List<GeoMapsLegendItem>();

            //GeoMapsLegendComboBox.ItemsSource = null;

            //mapPrinterWithDialog.GeoMapsLegendUri = "/LanSysWebGIS;component/Pictures/Icon/legend.jpg";
        }

        private void mapPrinter_DefinedExtentChanged(object sender, DefinedExtentChangedEventArgs e)
        {
            definedExtent = e.Extent;

            mapPrinterWithDialog.XMin = mapPrinterWithDialog.PagesGeometries.ToList()[0].Extent.XMin;
            mapPrinterWithDialog.YMin = mapPrinterWithDialog.PagesGeometries.ToList()[0].Extent.YMin;
            mapPrinterWithDialog.XMax = mapPrinterWithDialog.PagesGeometries.ToList()[0].Extent.XMax;
            mapPrinterWithDialog.YMax = mapPrinterWithDialog.PagesGeometries.ToList()[0].Extent.YMax;

            if (styleName == "WithGeoMapsLegend")
            {
                SelectGeoMapsLegend();
            }
        }

        private void mapPrinter_PageChanged(object sender, PageChangedEventArgs e)
        {
            var mapPrinter = sender as MapPrinter;

            if (mapPrinter != null)
            {
                mapPrinter.XMin = mapPrinter.PagesGeometries.ToList()[e.Page - 1].Extent.XMin;
                mapPrinter.YMin = mapPrinter.PagesGeometries.ToList()[e.Page - 1].Extent.YMin;
                mapPrinter.XMax = mapPrinter.PagesGeometries.ToList()[e.Page - 1].Extent.XMax;
                mapPrinter.YMax = mapPrinter.PagesGeometries.ToList()[e.Page - 1].Extent.YMax;
            }
        }

        private void GeoMapsLegendComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string tempLegendTypeURI = legendTypeURI;

            try
            {
                sheetName = ((GeoMapsLegendItem)(GeoMapsLegendComboBox.SelectedItem)).SheetName.ToString().Trim();

                tempLegendTypeURI = ((GeoMapsLegendItem)(GeoMapsLegendComboBox.SelectedItem)).IndexType.ToString().Trim();

                //tempLegendTypeURI = LegendItems.Where(q => q.SheetName == "sheetName").Select(p => p.IndexType).First();
            }
            catch (Exception exe)
            {
                //sheetName = "";
            }

            legendURI = legendBaseURI + tempLegendTypeURI + sheetName + ".png";

            //Image image = (Image)(App.Current.Resources["GeologyMapsLegend"]);
            //Image image = (Image)(mapPrinterWithDialog.Style.

            //image.Source = new BitmapImage(new Uri(legendURI, UriKind.Absolute)); 

            //Grid g = VisualTreeHelper.GetChild(MapPrinterDialog, 0) as Grid;
            //StackPanel s = VisualTreeHelper.GetChild(g, 1) as StackPanel;
            //Image image = VisualTreeHelper.GetChild(s, 0) as Image;

            var image = VisualElementHelper.FindImageName<Image>("GeologyMapsLegend", this);

            image.Source = new BitmapImage(new Uri(legendURI, UriKind.Absolute)); 

            //mapPrinterWithDialog.GeoMapsLegendUri = legendURI;
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            MapOperations.printObject = null;
        }
    }
}
