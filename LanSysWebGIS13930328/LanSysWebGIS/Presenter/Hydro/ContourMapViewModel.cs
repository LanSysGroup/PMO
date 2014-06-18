using System;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Controls;
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
using LanSysWebGIS.Models;
using LanSysWebGIS.UserControls;
using LanSysWebGIS.UserControls.Hydro;

namespace LanSysWebGIS.Presenter.Hydro
{
    public class ContourMapViewModel : Notifier
    {
        private bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                OnPropertyChanged("IsLoading");
            }
        }

        private string _rasterName;
        public string RasterName
        {
            get { return _rasterName; }
            set
            {
                _rasterName = value;
                OnPropertyChanged("RasterName");
            }
        }

        private string _contourInterval;
        public string ContourInterval
        {
            get { return _contourInterval; }
            set
            {
                _contourInterval = value;
                OnPropertyChanged("ContourInterval");
            }
        }

        private string _contourZFactor;
        public string ContourZFactor
        {
            get { return _contourZFactor; }
            set
            {
                _contourZFactor = value;
                OnPropertyChanged("ContourZFactor");
            }
        }

        public static LanSysWebGIS.Controls.BusyIndicator ContourMapBusyIndicator;

        Geoprocessor _geoprocessorTask;
        ArcGISDynamicMapServiceLayer resultLayer = null;
        GraphicsLayer graphicsLayer = null;

        public void CreateContourMap(string selectedLayerName)
        {
            ContourMapBusyIndicator.IsBusy = true;

            //this.RasterName = selectedLayerName;

            _geoprocessorTask = new Geoprocessor("http://91.98.96.231/ArcGIS/rest/services/PMO/ContourFinal/GPServer/ContourTask");
            _geoprocessorTask.JobCompleted += GeoprocessorTask_JobCompleted;
            _geoprocessorTask.Failed += GeoprocessorTask_Failed;
            graphicsLayer = MapOperations.map1.Layers["XYGraphicsLayer"] as GraphicsLayer;

            //Map1.Cursor = System.Windows.Input.Cursors.Wait;

            List<GPParameter> parameters = new List<GPParameter>();
            //parameters.Add(new GPString("Raster_Name", "raster_89052"));
            //parameters.Add(new GPString("Raster_Name", this.RasterName));
            parameters.Add(new GPString("Raster_Name", selectedLayerName));
            parameters.Add(new GPDouble("Contour_interval", double.Parse(this.ContourInterval)));
            //parameters.Add(new GPDouble("Base_contour", 0));
            parameters.Add(new GPDouble("Z_factor", double.Parse(this.ContourZFactor)));
            //parameters.Add(new GPString("Output_Contour_Name", "webTest110"));
            parameters.Add(new GPString("anzaliworkspace", @"C:\GeoData\GeoData(PMO)\Hyrography_Project\RWorkspae.gdb"));


            //parameters.Add(new GPFeatureRecordSetLayer("Input_Features", mapPoint));
            //parameters.Add(new GPString("Raster_Name", "raster_89052"));
            //parameters.Add(new GPLinearUnit("Distance", esriUnits.esriMiles, Convert.ToDouble(MilesTextBox.Text)));


            _geoprocessorTask.OutputSpatialReference = new SpatialReference(102100);
            _geoprocessorTask.ProcessSpatialReference = new SpatialReference(102100);
            _geoprocessorTask.SubmitJobAsync(parameters);
        }

        private void GeoprocessorTask_Failed(object sender, TaskFailedEventArgs e)
        {
            ContourMapBusyIndicator.IsBusy = false;

            throw new Exception(e.Error.Message);
        }

        private void GeoprocessorTask_JobCompleted(object sender, JobInfoEventArgs e)
        {
            ContourMapBusyIndicator.IsBusy = false;
            //Map1.Cursor = System.Windows.Input.Cursors.Hand;
            if (e.JobInfo.JobStatus == esriJobStatus.esriJobSucceeded)
            {
                //    foreach (GPParameter gpParameter in e.Results.OutParameters)
                //{
                //    if (gpParameter is GPFeatureRecordSetLayer)
                //    {
                //        GPFeatureRecordSetLayer gpLayer = gpParameter as GPFeatureRecordSetLayer;
                //        foreach (Graphic graphic in gpLayer.FeatureSet.Features)
                //        {
                //          graphic.Symbol = LayoutRoot.Resources["PathLineSymbol"] as Symbol;
                //          _graphicsLayer.Graphics.Add(graphic);
                //        }
                //    }
                //}

                Geoprocessor geoprocessorTask = sender as Geoprocessor;

                geoprocessorTask.GetResultDataCompleted += (s3, e3) =>
                {
                    if (e3.Parameter is GPString)
                    {
                        // Do something to show in silverlight
                    }
                    else if (e3.Parameter is GPFeatureRecordSetLayer)
                    {
                        // Do something to show in silverlight
                        GPFeatureRecordSetLayer gpresultLayer = e3.Parameter as GPFeatureRecordSetLayer;

                        //if (feature.Geometry is ESRI.ArcGIS.Client.Geometry.MapPoint)
                        //{
                        //    SimpleMarkerSymbol sym = new SimpleMarkerSymbol();
                        //    sym.Color = new SolidColorBrush(Colors.Yellow);

                        //    feature.Symbol = sym;
                        //}
                        //else if (feature.Geometry is ESRI.ArcGIS.Client.Geometry.Polyline)
                        //{
                        //    SimpleLineSymbol sym = new SimpleLineSymbol();
                        //    sym.Color = new SolidColorBrush(Colors.Yellow);
                        //    sym.Width = 2;

                        //    feature.Symbol = sym;
                        //}
                        //else if (feature.Geometry is ESRI.ArcGIS.Client.Geometry.Polygon)
                        //{
                        //    SimpleFillSymbol sym = new SimpleFillSymbol();
                        //    sym.BorderBrush = new SolidColorBrush(Colors.Yellow);
                        //    sym.Fill = new SolidColorBrush(Color.FromArgb(0xC8, 0xFF, 0xFF, 0x99));
                        //    sym.BorderThickness = 2;

                        //    feature.Symbol = sym;
                        //}


                        foreach (Graphic graphic in gpresultLayer.FeatureSet.Features)
                        {
                            SimpleLineSymbol sym = new SimpleLineSymbol();
                            sym.Color = new SolidColorBrush(Colors.Yellow);
                            sym.Width = 2;

                            graphic.Symbol = sym;
                            graphicsLayer.Graphics.Add(graphic);
                        }
                    }

                    MapOperations.map1.Layers.Add(graphicsLayer);

                    ContourMapBusyIndicator.IsBusy = false;
                };

                // Get the result data
                //geoprocessorTask.GetResultDataAsync(e.JobInfo.JobId, "Output_Contour");

                ContourMapBusyIndicator.IsBusy = true;
                //System.Threading.Thread.Sleep(2000);

                resultLayer = geoprocessorTask.GetResultMapServiceLayer(e.JobInfo.JobId);
                resultLayer.Initialized += resultLayer_Initialized;
                resultLayer.InitializationFailed += new EventHandler<EventArgs>(resultLayer_InitializationFailed);
                resultLayer.DisplayName = e.JobInfo.JobId;

                resultLayer.ID = "ContourMapLayer";

                if (resultLayer != null)
                {
                    //_displayViewshedInfo = true;

                    if (RibbonBar.map.Layers["ContourMapLayer"] != null)
                    {
                        RibbonBar.map.Layers.Remove(RibbonBar.map.Layers["ContourMapLayer"]);
                    }

                    RibbonBar.map.Layers.Add(resultLayer);
                }
            }
            else
            {
                ContourMapBusyIndicator.IsBusy = false;
                MessageBox.Show("Geoprocessor service failed");
                //_displayViewshedInfo = false;
            }

            //System.Threading.Thread.Sleep(10000);
        }

        void resultLayer_Initialized(object sender, EventArgs e)
        {
            ContourMapBusyIndicator.IsBusy = false;
        }

        private void resultLayer_InitializationFailed(object sender, EventArgs e)
        {
            ContourMapBusyIndicator.IsBusy = false;

            throw new Exception("resultLayer_InitializationFailed");
        }
    }
}
