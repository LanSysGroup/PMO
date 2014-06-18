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
    public partial class SearchMapNumber : UserControl
    {
        public static AutoCompleteBox searchMapNumberAutoCompleteBox;

        public static string sheetNumber;

        public SearchMapNumber()
        {
            InitializeComponent();

            searchMapNumberAutoCompleteBox = this.sheetNumberAutoCompleteTextBox;

            //todo with busy indicator
            GeoMapsOperations.FillAutoCompleteTextBox(RibbonBar.selectedIndex);

            GeoMapsOperations.messageTextBlock02 = this.messageTextBlock02;
        }

        private void searchSheetNumberButton_Click(object sender, RoutedEventArgs e)
        {
            sheetNumber = sheetNumberAutoCompleteTextBox.Text.Trim().ToUpper();

            if (!string.IsNullOrEmpty(sheetNumber))
            {
                GeoMapsOperations.DoQuery(true, string.Format("SheetNumber='{0}'", sheetNumber));

                //QueryTask queryTask = new QueryTask(MapControl.indexService.Url + "/" + RibbonBar.selectedIndex);
                //queryTask.ExecuteCompleted += SearchSheetNumber_ExecuteCompleted;
                //queryTask.Failed += SearchSheetNumber_Failed;

                //// Bind data grid to query results
                //Binding resultFeaturesBinding = new Binding("LastResult.Features");
                //resultFeaturesBinding.Source = queryTask;
                //RibbonBar.geoMapsDatagrid.SetBinding(DataGrid.ItemsSourceProperty, resultFeaturesBinding);

                //Query query = new Query();
                //query.ReturnGeometry = true;
                //query.OutSpatialReference = GeoMapsOperations.map1.SpatialReference;
                //query.OutFields.AddRange(new string[] { "SheetName", "SheetNumber", "isSHP", "isGEO", "isSCAN" });
                //query.Where = string.Format("SheetNumber='{0}'", sheetNumber);

                //queryTask.ExecuteAsync(query);
            }
        }
        private void SearchSheetNumber_ExecuteCompleted(object sender, ESRI.ArcGIS.Client.Tasks.QueryEventArgs args)
        {
            if (args.FeatureSet.Features.Count > 0)
            {
                Graphic sheetGraphic = args.FeatureSet.Features[0];

                MapControl.geoMapsGraphicsLayer.ClearGraphics();

                GeoMapsOperations.gLayerVisibility.IsChecked = true;

                FillSymbol SampleStyle1 = App.Current.Resources["ResultsFillSymbol"] as FillSymbol;

                sheetGraphic.Symbol = SampleStyle1;
                MapControl.geoMapsGraphicsLayer.Graphics.Add(sheetGraphic);

                messageTextBlock02.Text = "پیدا شد !";

                //messageTextBlock.Text = sheetGraphic.Attributes["SheetName"].ToString().Length > 2 ? sheetGraphic.Attributes["SheetName"].ToString() : "No Name";

                GeoMapsOperations.shpRadio.IsEnabled = sheetGraphic.Attributes["isSHP"].ToString() == "1";
                GeoMapsOperations.shpRadio.IsChecked = false;

                GeoMapsOperations.geoRadio.IsEnabled = sheetGraphic.Attributes["isGEO"].ToString() == "1";
                GeoMapsOperations.geoRadio.IsChecked = false;

                GeoMapsOperations.scanRadio.IsEnabled = sheetGraphic.Attributes["isSCAN"].ToString() == "1";
                GeoMapsOperations.scanRadio.IsChecked = false;

                GeoMapsOperations.testGraphicCollection.Clear();
                GeoMapsOperations.testGraphicCollection.Add(sheetGraphic);
            }
            else
            {
                messageTextBlock02.Text = "پیدا نشد !";

                GeoMapsOperations.shpRadio.IsEnabled = false;
                GeoMapsOperations.shpRadio.IsChecked = false;
                GeoMapsOperations.geoRadio.IsEnabled = false;
                GeoMapsOperations.geoRadio.IsChecked = false;
                GeoMapsOperations.scanRadio.IsEnabled = false;
                GeoMapsOperations.scanRadio.IsChecked = false;

                //viewButton.IsEnabled = false;
                //downloadButton.IsEnabled = false;
            }

            //fillingSheetNameAutoCompleteTextBox = false;

        }
        private void SearchSheetNumber_Failed(object sender, TaskFailedEventArgs args)
        {
            MessageBox.Show("Query failed: " + args.Error);
        }

    }
}
