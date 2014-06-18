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
using LanSysWebGIS.Assets.Resources;
using LanSysWebGIS.Models;

namespace LanSysWebGIS.UserControls.GeoMaps
{
    public partial class SearchBottomPortion : UserControl
    {
        private int shpCount;
        private int georeferencedCount;
        private int scanCount;


        public SearchBottomPortion()
        {
            InitializeComponent();

            RibbonBar.geoMapsDatagrid = this.QueryDetailsDataGrid;

            GeoMapsOperations.gLayerVisibility = this.graphicsLayerVisibility;

            GeoMapsOperations.shpRadio = this.shpRadioButton;
            GeoMapsOperations.geoRadio = this.georeferenceRadioButton;
            //GeoMapsOperations.scanRadio = this.scanRadioButton;
        }

        private void QueryDetailsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (Graphic g in e.AddedItems)
                g.Select();

            foreach (Graphic g in e.RemovedItems)
                g.UnSelect();

            if (QueryDetailsDataGrid.SelectedItems.Count > 1)
            {
                shpCount = 0;
                georeferencedCount = 0;
                scanCount = 0;

                GeoMapsOperations.sheetGraphicCollection.Clear();
                GeoMapsOperations.testGraphicCollection.Clear();

                List<Graphic> graphicsItemList = QueryDetailsDataGrid.SelectedItems as List<Graphic>;

                for (int i = 0; i < QueryDetailsDataGrid.SelectedItems.Count; i++)
                {
                    Graphic temporaryGraphics = QueryDetailsDataGrid.SelectedItems[i] as Graphic;

                    GeoMapsOperations.sheetGraphicCollection.Add(temporaryGraphics);
                    GeoMapsOperations.testGraphicCollection.Add(temporaryGraphics);

                    if ((temporaryGraphics.Attributes["isSHP"]).ToString() == "1")
                    {
                        shpCount++;
                    }

                    if ((temporaryGraphics.Attributes["isGEO"]).ToString() == "1")
                    {
                        georeferencedCount++;
                    }

                    //if ((temporaryGraphics.Attributes["isSCAN"]).ToString() == "1")
                    //{
                    //    scanCount++;
                    //}

                    shpRadioButton.IsEnabled = shpCount > 0;

                    georeferenceRadioButton.IsEnabled = georeferencedCount > 0;

                    //scanRadioButton.IsEnabled = scanCount > 0;
                }
            }

            else if (QueryDetailsDataGrid.SelectedItems.Count == 1)
            {
                GeoMapsOperations.sheetGraphicCollection.Clear();
                GeoMapsOperations.testGraphicCollection.Clear();

                Graphic sheetGraphic = QueryDetailsDataGrid.SelectedItem as Graphic;

                shpRadioButton.IsEnabled = sheetGraphic.Attributes["isSHP"].ToString() == "1";
                shpRadioButton.IsChecked = false;

                georeferenceRadioButton.IsEnabled = sheetGraphic.Attributes["isGEO"].ToString() == "1";
                georeferenceRadioButton.IsChecked = false;

                //scanRadioButton.IsEnabled = sheetGraphic.Attributes["isSCAN"].ToString() == "1";
                //scanRadioButton.IsChecked = false;

                GeoMapsOperations.sheetGraphicCollection.Add(sheetGraphic);
                GeoMapsOperations.testGraphicCollection.Add(sheetGraphic);
            }

            try
            {
                this.graphicsLayerVisibility.IsChecked = true;
            }
            catch (Exception ex)
            {
            }
        }
        private void QueryDetailsDataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.MouseEnter += Row_MouseEnter;
            e.Row.MouseLeave += Row_MouseLeave;
        }
        void Row_MouseEnter(object sender, MouseEventArgs e)
        {
            (((System.Windows.FrameworkElement)(sender)).DataContext as Graphic).Select();
        }
        void Row_MouseLeave(object sender, MouseEventArgs e)
        {
            DataGridRow row = sender as DataGridRow;
            Graphic g = ((System.Windows.FrameworkElement)(sender)).DataContext as Graphic;

            if (!QueryDetailsDataGrid.SelectedItems.Contains(g))
                g.UnSelect();
        }


        private void shpRadioButton_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            shpRadioButton.FontStyle = shpRadioButton.FontStyle == FontStyles.Normal ? shpRadioButton.FontStyle = FontStyles.Italic : shpRadioButton.FontStyle = FontStyles.Normal;
        }
        //private void scanRadioButton_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        //{
        //    scanRadioButton.FontStyle = scanRadioButton.FontStyle == FontStyles.Normal ? scanRadioButton.FontStyle = FontStyles.Italic : scanRadioButton.FontStyle = FontStyles.Normal;
        //}
        private void georeferenceRadioButton_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            georeferenceRadioButton.FontStyle = georeferenceRadioButton.FontStyle == FontStyles.Normal ? georeferenceRadioButton.FontStyle = FontStyles.Italic : georeferenceRadioButton.FontStyle = FontStyles.Normal;
        }

        //View
        private void viewAvailableDataButton_Click(object sender, RoutedEventArgs e)
        {
            //this.sheetName = sheetGraphic.Attributes["SheetName"].ToString().ToUpper();

            if (georeferenceRadioButton.IsChecked == true)
            {
                try
                {
                    //
                    //setting visibility of all layers to false

                    //todo for &
                    if (RibbonBar.selectedIndex == 3)
                    {
                        GeoMapsOperations.georeferenced100kNIOCServiceClipped.Visible = true;
                        GeoMapsOperations.georeferenced100kGSIServiceClipped.Visible = true;
                    }
                    else
                    {
                        //todo for nioc
                        //GeoMapsOperations.georeferenced100kNIOCService.Visible = false;
                        //GeoMapsOperations.georeferenced100kNIOCServiceClipped.Visible = false;
                        //GeoMapsOperations.georeferenced1000kNIOCServiceClipped.Visible = false;
                        //GeoMapsOperations.georeferenced1000kNIOCService.Visible = false;
                        //GeoMapsOperations.georeferenced100kGSIService.Visible = false;
                        //GeoMapsOperations.georeferenced100kGSIServiceClipped.Visible = false;

                        //this.FontFamily = new System.Windows.Media.FontFamily("Comic sans MS");

                        //shpDynamicServiceLayer.Visible = false;

                        GeoMapsOperations.activeService.Visible = true;
                    }


                    //activeService.VisibleLayers = new int[] { activeServiceLayerIDs[this.sheetName] };

                    List<int> activeServiceVisibleLayers = new List<int>();

                    GeoMapsOperations.resultsExtent = GeoMapsOperations.testGraphicCollection[0].Geometry.Extent;

                    if (RibbonBar.selectedIndex == 3)
                    {
                        List<int> georeferenced100kNIOCServiceVisibleLayers = new List<int>();

                        List<int> georeferenced100kGSIServiceVisibleLayers = new List<int>();

                        for (int i = 0; i < QueryDetailsDataGrid.SelectedItems.Count; i++)
                        {
                            string sheetName = GeoMapsOperations.testGraphicCollection[i].Attributes["SheetName"].ToString().ToUpper();
                            try
                            {
                                //string sheetName = GeoMapsOperations.testGraphicCollection[i].Attributes["SheetName"].ToString().ToUpper();
                                georeferenced100kGSIServiceVisibleLayers.Add(MapControl.georeferenced100kGSIServiceLayerIDsClipped[sheetName]);

                                GeoMapsOperations.resultsExtent = GeoMapsOperations.resultsExtent.Union(GeoMapsOperations.testGraphicCollection[i].Geometry.Extent);
                            }
                            catch (Exception ex0)
                            {
                                try
                                {
                                    georeferenced100kNIOCServiceVisibleLayers.Add(MapControl.georeferenced100kNIOCServiceLayerIDsClipped[sheetName]);

                                    GeoMapsOperations.resultsExtent = GeoMapsOperations.resultsExtent.Union(GeoMapsOperations.testGraphicCollection[i].Geometry.Extent);
                                }
                                catch (Exception erer)
                                {
                                }

                                //MessageBox.Show("oooooo");
                            }

                        }

                        GeoMapsOperations.georeferenced100kGSIServiceClipped.VisibleLayers = georeferenced100kGSIServiceVisibleLayers.ToArray<int>();
                        GeoMapsOperations.georeferenced100kNIOCServiceClipped.VisibleLayers = georeferenced100kNIOCServiceVisibleLayers.ToArray<int>();
                    }
                    else
                    {
                        for (int i = 0; i < QueryDetailsDataGrid.SelectedItems.Count; i++)
                        {
                            try
                            {
                                string sheetName = GeoMapsOperations.testGraphicCollection[i].Attributes["SheetName"].ToString().ToUpper();
                                activeServiceVisibleLayers.Add(GeoMapsOperations.activeServiceLayerIDs[sheetName]);

                                GeoMapsOperations.resultsExtent = GeoMapsOperations.resultsExtent.Union(GeoMapsOperations.testGraphicCollection[i].Geometry.Extent);
                            }
                            catch (Exception ex0)
                            {
                                //MessageBox.Show("oooooo");
                            }

                        }
                        GeoMapsOperations.activeService.VisibleLayers = activeServiceVisibleLayers.ToArray<int>();
                    }





                    ////ToDo (Automation)
                    //if (indexComboBox.SelectedIndex == 0)
                    //{
                    //    georeferenced100kNIOCServiceClipped.Visible = true;
                    //    //georeferenced1000kNIOCClippedService.Visible = false;
                    //    georeferenced100kNIOCService.Visible = false;
                    //    georeferenced1000kNIOCService.Visible = false;

                    //    //shpDynamicServiceLayer.Visible = false;

                    //    if (additiveMode)
                    //    {
                    //        List<int> currentVisibleLayers = georeferenced100kNIOCServiceClipped.VisibleLayers.ToList<int>();
                    //        currentVisibleLayers.Add(georeferenced100kNIOCServiceLayerIDsClipped[this.sheetName]);

                    //        georeferenced100kNIOCServiceClipped.VisibleLayers = currentVisibleLayers.ToArray();
                    //    }
                    //    else
                    //    {
                    //        georeferenced100kNIOCServiceClipped.VisibleLayers = new int[] { georeferenced100kNIOCServiceLayerIDsClipped[this.sheetName] };
                    //    }

                    //}
                    //else if (indexComboBox.SelectedIndex == 1)
                    //{
                    //    //georeferenced100kNIOCClippedService.Visible = true;
                    //    ////georeferenced1000kNIOCClippedService.Visible = false;
                    //    //georeferenced100kNIOCService.Visible = false;
                    //    //georeferenced1000kNIOCService.Visible = false;



                    //    //georeferenced1000kNIOCClippedService.Visible = true;

                    //    ////shpDynamicServiceLayer.Visible = false;

                    //    //georeferenced1000kNIOCClippedService.VisibleLayers = new int[] { georeferenced1000kNIOCClippedLayerIDs[this.sheetName] };
                    //}

                    ////additional button
                    ////map1.ZoomTo(sheetGraphic.Geometry);

                    graphicsLayerVisibility.IsChecked = false;
                }
                catch (Exception ex8)
                {
                    MessageBox.Show("An Error Occurred");
                }
            }
            else if (shpRadioButton.IsChecked == true)
            {
                //shp.Visible = true;
                //georefDynamicServiceLayer.Visible = false;

                //shpDynamicServiceLayer.VisibleLayers = new int[] { shpLayerIDs[sheetName] };

                //map1.ZoomTo(graphicForQuery.Geometry);


            }
            //else if (scanRadioButton.IsChecked == true)
            //{
            //    //MessageBox.Show("scanRadioButton.IsChecked = " + scanRadioButton.IsChecked);
            //}

            //if (clipMode)
            //{
            //    //if (QueryDetailsDataGrid.SelectedItems.Count > 1)
            //    //{

            //    //}
            //    //else
            //    //{

            //    //}
            //    #region 1

            //}
            //    #endregion
            ////
            ////
            ////
            ////
            ////  
            ////
            //else
            //{
            //    if (georeferenceRadioButton.IsChecked == true)
            //    {
            //        try
            //        {
            //            //
            //            //setting visibility of all layers to false

            //            georeferenced100kNIOCService.Visible = false;
            //            georeferenced100kNIOCServiceClipped.Visible = false;
            //            //georeferenced1000kNIOCClippedService.Visible = false;
            //            georeferenced1000kNIOCService.Visible = false;
            //            //shpDynamicServiceLayer.Visible = false;

            //            activeService.Visible = true;

            //            //activeService.VisibleLayers = new int[] { activeServiceLayerIDs[this.sheetName] };

            //            List<int> activeServiceVisibleLayers = new List<int>();

            //            for (int i = 0; i < QueryDetailsDataGrid.SelectedItems.Count; i++)
            //            {
            //                string sheetName = this.testGraphicCollection[i].Attributes["SheetName"].ToString().ToUpper();
            //                activeServiceVisibleLayers.Add(activeServiceLayerIDs[sheetName]);
            //            }

            //            activeService.VisibleLayers = activeServiceVisibleLayers.ToArray<int>();

            //            graphicsLayerVisibility.IsChecked = false;
            //        }
            //        catch (Exception ex8)
            //        {
            //            MessageBox.Show("متاسفانه امکان نمایش این نقشه وجود ندارد");
            //        }
            //    }
            //    #region shp & scan
            //    else if (shpRadioButton.IsChecked == true)
            //    {
            //        //shp.Visible = true;
            //        //georefDynamicServiceLayer.Visible = false;

            //        //shpDynamicServiceLayer.VisibleLayers = new int[] { shpLayerIDs[sheetName] };

            //        //map1.ZoomTo(graphicForQuery.Geometry);


            //    }
            //    else if (scanRadioButton.IsChecked == true)
            //    {
            //        //MessageBox.Show("scanRadioButton.IsChecked = " + scanRadioButton.IsChecked);
            //    }
            //    #endregion
            //}



        }

        //Zoom
        private void zoomAvailableDataButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GeoMapsOperations.map1.ZoomTo(GeoMapsOperations.resultsExtent);
            }
            catch (Exception ex)
            {
            }
            //ToDo for sheetGraphicCollection
        }

        //Download
        private void downloadAvailableDataButton_Click(object sender, RoutedEventArgs e)
        {
            //todo
            throw new Exception(ApplicationStrings.msgNotProperAccessLevel);
        }

        //Clear
        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            GeoMapsOperations.ClearAll();
        }

        private void graphicsLayerVisibility_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                MapControl.geoMapsGraphicsLayer.Visible = true;
            }
            catch (Exception ex5)
            {
            }
            try
            {
                MapControl.geoMapsXYGraphicsLayer.Visible = true;
            }
            catch (Exception ex7)
            {
            }
        }
        private void graphicsLayerVisibility_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                MapControl.geoMapsGraphicsLayer.Visible = false;
            }
            catch (Exception ex6)
            {
            }
            try
            {
                MapControl.geoMapsXYGraphicsLayer.Visible = false;
            }
            catch (Exception ex8)
            {
            }
        }

        private void dataTypeRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            viewAvailableDataButton.IsEnabled = true;
        }
        private void dataTypeRadioButton_Unchecked(object sender, RoutedEventArgs e)
        {
            viewAvailableDataButton.IsEnabled = false;
        }
    }
}
