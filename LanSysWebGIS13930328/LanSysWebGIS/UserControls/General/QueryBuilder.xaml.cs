using ESRI.ArcGIS.Client.Toolkit;
using LanSysWebGIS.Models;
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

namespace LanSysWebGIS.UserControls
{
    public partial class QueryBuilder : UserControl
    {
        public static FeatureDataGrid QueryBuilderFeatureDataGrid;

        public QueryBuilder()
        {
            InitializeComponent();

            //Query Elements Start

            MapControl.mapOp.QueryFieldsListBox = this.QueryFieldsListBox;
            MapControl.mapOp.QueryFieldUniqueValuesListBox = this.QueryFieldUniqueValuesListBox;
            MapControl.mapOp.QueryWhereTextBox = this.QueryWhereTextBox;
            MapControl.mapOp.QueryLayersComboBox = this.QueryLayersComboBox;
            MapControl.mapOp.QueryStringLabel = this.QueryStringLabel;

            MapControl.mapOp.btnOperIs = this.btnOperIs;
            MapControl.mapOp.btnOperNot = this.btnOperNot;
            MapControl.mapOp.btnOperNULL = this.btnOperNULL;
            MapControl.mapOp.btnOperLike = this.btnOperLike;

            MapControl.mapOp.QueryBuilderFeatureDataGrid = QueryBuilderFeatureDataGrid;
            MapControl.mapOp.GetUniqueValuesButton = this.GetUniqueValuesButton;

            //Query Elements End

            QueryLayersComboBox.ItemsSource = MapControl.nonGroupLayersName;

            QueryLayersComboBox.SelectedIndex = 0;

            MapControl.mapOp.QueryBuilderDialog_Opened();
        }

        #region QueryBuilder
        //public static DevExpress.Xpf.Bars.BarCheckItem bSearchMap;

        private void QueryBuilderDialog_Closed(object sender, Liquid.DialogEventArgs e)
        {
            //bSearchMap.IsChecked = false;

            QueryBuilderFeatureDataGrid.Visibility = Visibility.Collapsed;
        }

        private void QueryLayersComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MapControl.mapOp.QueryLayersComboBox_SelectionChanged();
        }

        private void QueryFieldsListBox_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            bool doubleClick = MouseButtonHelper.IsDoubleClick(sender, e);

            MapControl.mapOp.QueryFieldsListBox_MouseLeftButtonUp(doubleClick);
        }

        private void QueryFieldsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            QueryFieldUniqueValuesListBox.ItemsSource = null;

            GetUniqueValuesButton.IsEnabled = true;
        }

        private void WhereClearButton_Click(object sender, RoutedEventArgs e)
        {
            QueryWhereTextBox.Text = "";

            QueryFieldsListBox.SelectedIndex = -1;
        }

        private void OperatorButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            MapControl.mapOp.OperatorButton_Click(button);
        }

        private void SubmitQueryButton_Click(object sender, RoutedEventArgs e)
        {
            MapControl.mapOp.SubmitQueryButton_Click();
        }

        private void ClearGraphicsQueryButton_Click(object sender, RoutedEventArgs e)
        {
            MapControl.mapOp.ClearGraphicsQueryButton_Click();
        }

        private void GetUniqueValuesButton_Click(object sender, RoutedEventArgs e)
        {
            MapControl.mapOp.GetUniqueValuesButton_Click();
        }

        private void QueryFieldUniqueValuesListBox_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            bool doubleClick = MouseButtonHelper.IsDoubleClick(sender, e);

            MapControl.mapOp.QueryFieldUniqueValuesListBox_MouseLeftButtonUp(doubleClick);
        }

        private void QueryBuilderDialog_Opened(object sender, Liquid.DialogEventArgs e)
        {
            
        }

        #endregion
    }
}
