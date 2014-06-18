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
using ESRI.ArcGIS.Client.Symbols;
using ESRI.ArcGIS.Client.Tasks;
using LanSysWebGIS.Models;

namespace LanSysWebGIS.UserControls.GeoMaps
{
    public partial class SearchName : UserControl
    {
        public static AutoCompleteBox searchNameAutoCompleteBox;

        public static string sheetName;

        public SearchName()
        {
            InitializeComponent();

            searchNameAutoCompleteBox = this.sheetNameAutoCompleteTextBox;

            //todo with busy indicator
            GeoMapsOperations.FillAutoCompleteTextBox(RibbonBar.selectedIndex);

            GeoMapsOperations.messageTextBlock01 = this.messageTextBlock01;
        }

        private void searchSheetNameButton_Click(object sender, RoutedEventArgs e)
        {
            sheetName = sheetNameAutoCompleteTextBox.Text;

            if (!string.IsNullOrEmpty(sheetName))
            {
                //QueryTask queryTask = new QueryTask(MapControl.indexService.Url + "/" + RibbonBar.selectedIndex);
                //queryTask.ExecuteCompleted += SearchSheetName_ExecuteCompleted;
                //queryTask.Failed += SearchSheetName_Failed;

                //// Bind data grid to query results
                //Binding resultFeaturesBinding = new Binding("LastResult.Features");
                //resultFeaturesBinding.Source = queryTask;
                //RibbonBar.geoMapsDatagrid.SetBinding(DataGrid.ItemsSourceProperty, resultFeaturesBinding);

                //Query query = new Query();
                //query.ReturnGeometry = true;
                //query.OutSpatialReference = GeoMapsOperations.map1.SpatialReference;
                //query.OutFields.AddRange(new string[] { "SheetName", "SheetNumber", "isSHP", "isGEO", "isSCAN" });
                //query.Where = string.Format("SheetName='{0}'", sheetName);

                //queryTask.ExecuteAsync(query);

                GeoMapsOperations.DoQuery(true, string.Format("SheetName='{0}'", sheetName));
            }
            else
            {
                
            }
        }

        private void SearchSheetName_ExecuteCompleted(object sender, ESRI.ArcGIS.Client.Tasks.QueryEventArgs args)
        {
            // args.FeatureSet.Features.Count == 1
            if (args.FeatureSet.Features.Count > 0)
            {
                //
                //this.testGraphicCollection.Clear();
                //for (int i = 0; i < args.FeatureSet.Features.Count; i++)
                //{
                //    this.testGraphicCollection.Add(args.FeatureSet.Features[i]);
                //}
                //
                Graphic sheetGraphic = args.FeatureSet.Features[0];

                MapControl.geoMapsGraphicsLayer.ClearGraphics();

                GeoMapsOperations.gLayerVisibility.IsChecked = true;

                FillSymbol SampleStyle1 = App.Current.Resources["ResultsFillSymbol"] as FillSymbol;

                sheetGraphic.Symbol = SampleStyle1;
                MapControl.geoMapsGraphicsLayer.Graphics.Add(sheetGraphic);

                messageTextBlock01.Text = "پیدا شد !";

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
                messageTextBlock01.Text = "پیدا نشد !";

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
        private void SearchSheetName_Failed(object sender, TaskFailedEventArgs args)
        {
            MessageBox.Show("Query failed: " + args.Error);
        }
    }
}
