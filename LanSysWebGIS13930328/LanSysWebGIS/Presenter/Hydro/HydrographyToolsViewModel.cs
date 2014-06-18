using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting.Compatible;
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
using BusyIndicator = LanSysWebGIS.Controls.BusyIndicator;
using PointCollection = ESRI.ArcGIS.Client.Geometry.PointCollection;

namespace LanSysWebGIS.Presenter
{
    public class HydrographyToolsViewModel : Notifier, INotifyPropertyChanged
    {
        public static Controls.BusyIndicator ProfileBusyIndicator;

        Draw _myDrawObject;
        GraphicsLayer _pointGraphicLayer;
        GraphicsLayer _lineGraphicLayer;
        Geoprocessor _geoprocessorTask;
        private PointCollection _pointCollection = new PointCollection();
        private string selectedLayerName;

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

        public event PropertyChangedEventHandler PropertyChanged;

        public HydrographyToolsViewModel()
        {
            _myDrawObject = new Draw(RibbonBar.map)
            {
                //LineSymbol = (App.Current.Resources["LineRenderer"] as SimpleRenderer).Symbol as LineSymbol
            };
            _myDrawObject.DrawComplete += _myDrawObject_DrawComplete;

            _myDrawObject.DrawMode = DrawMode.Polyline;
        }
        private void _myDrawObject_DrawComplete(object sender, DrawEventArgs e)
        {
            _pointGraphicLayer = RibbonBar.map.Layers["PointGraphicsLayer"] as GraphicsLayer;
            _pointGraphicLayer.Graphics.Add(new Graphic()
            {
                Geometry = new MapPoint(Double.NaN, Double.NaN)
            });

            _lineGraphicLayer = RibbonBar.map.Layers["LineGraphicsLayer"] as GraphicsLayer;
            _lineGraphicLayer.Graphics.Add(new Graphic()
            {
                Geometry = null
            });

            if (e.Geometry == null)
            {
                //ChartContainer.Visibility = System.Windows.Visibility.Collapsed;
                return;
            }

            try
            {
                IsLoading = true;
                ProfileBusyIndicator.IsBusy = IsLoading;

                _myDrawObject.IsEnabled = false;



                //this.Cursor = Cursors.Wait;

                _lineGraphicLayer.Graphics[0].Geometry = e.Geometry;

                _geoprocessorTask = new Geoprocessor("http://91.98.96.231/ArcGIS/rest/services/PMO/LanSysProfile/GPServer/ProfileTask");
                _geoprocessorTask.JobCompleted += CreateProfileTask_JobCompleted;
                _geoprocessorTask.Failed += CreateProfileTask_Failed;
                //graphicsLayer = MapOperations.map1.Layers["XYGraphicsLayer"] as GraphicsLayer;

                //Map1.Cursor = System.Windows.Input.Cursors.Wait;

                List<GPParameter> parameters = new List<GPParameter>();
                parameters.Add(new GPFeatureRecordSetLayer("Input_Polyline", e.Geometry));
                parameters.Add(new GPString("Raster_Name", "Raster_8905"));
                //Input Polyline
                //parameters.Add(new GPDouble("Contour_interval", double.Parse(this.ContourInterval)));
                //parameters.Add(new GPDouble("Base_contour", 0));
                //parameters.Add(new GPDouble("Z_factor", double.Parse(this.ContourZFactor)));
                //parameters.Add(new GPString("Output_Contour_Name", "webTest110"));
                parameters.Add(new GPString("MyWorkspace", @"C:\GeoData\GeoData(PMO)\Hyrography_Project\RWorkspae.gdb"));



                //parameters.Add(new GPString("Raster_Name", "raster_89052"));
                //parameters.Add(new GPLinearUnit("Distance", esriUnits.esriMiles, Convert.ToDouble(MilesTextBox.Text)));


                _geoprocessorTask.OutputSpatialReference = new SpatialReference(102100);
                _geoprocessorTask.ProcessSpatialReference = new SpatialReference(102100);

                //_geoprocessorTask.ReturnM = true;
                //_geoprocessorTask.ReturnZ = true;
                _geoprocessorTask.SubmitJobAsync(parameters);

                //GPExecuteResults results = await geoprocessorTask.ExecuteTaskAsync(parameters, _cts.Token);

                //if (results == null || results.OutParameters.Count == 0 || (results.OutParameters[0] as GPFeatureRecordSetLayer).FeatureSet.Features.Count == 0)
                //{
                //    MessageBox.Show("Fail to get elevation data. Draw another line");
                //    return;
                //}


            }
            catch (Exception ex)
            {
                IsLoading = false;
                ProfileBusyIndicator.IsBusy = IsLoading;

                if (ex is ServiceException)
                {
                    MessageBox.Show(String.Format("{0}: {1}", (ex as ServiceException).Code.ToString(),
                        (ex as ServiceException).Details[0]), "Error", MessageBoxButton.OK);
                    return;
                }
            }
            //finally
            //{
            //    this.Cursor = Cursors.Arrow;
            //}
        }

        private void CreateProfileTask_Failed(object sender, TaskFailedEventArgs e)
        {
            //ContourMapBusyIndicator.IsBusy = false;
            IsLoading = false;
            ProfileBusyIndicator.IsBusy = IsLoading;

            throw new Exception(e.Error.Message);
        }

        private void CreateProfileTask_JobCompleted(object sender, JobInfoEventArgs e)
        {
            IsLoading = false;
            ProfileBusyIndicator.IsBusy = IsLoading;
            //ContourMapBusyIndicator.IsBusy = false;
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

                //PointCollection = new ESRI.ArcGIS.Client.Geometry.PointCollection();

                _pointCollection.Clear();

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


                        foreach (Graphic feature in gpresultLayer.FeatureSet.Features)
                        {
                            SimpleMarkerSymbol sym = new SimpleMarkerSymbol();
                            sym.Color = new SolidColorBrush(Colors.Yellow);

                            feature.Symbol = sym;

                            _pointCollection.Add(new MapPoint()
                            {
                                X = Math.Round(Double.Parse(feature.Attributes["POINT_X"].ToString()), 3),
                                Y = Math.Round(Double.Parse(feature.Attributes["POINT_Y"].ToString()), 3),
                                Z = Math.Round(Double.Parse(feature.Attributes["POINT_Z"].ToString()), 3),
                                M = Math.Round(Double.Parse(feature.Attributes["POINT_M"].ToString()), 3),
                                SpatialReference = RibbonBar.map.SpatialReference
                            });
                            //graphic.Symbol = sym;
                            //graphicsLayer.Graphics.Add(graphic);
                        }


                        IsLoading = false;
                        ProfileBusyIndicator.IsBusy = IsLoading;

                    }

                    OpenProfileDialog();
                };

                //Get the result data
                geoprocessorTask.GetResultDataAsync(e.JobInfo.JobId, "OutputPointZM");

                IsLoading = true;
                ProfileBusyIndicator.IsBusy = IsLoading;

                //ContourMapBusyIndicator.IsBusy = true;
                ////System.Threading.Thread.Sleep(2000);

                //resultLayer = geoprocessorTask.GetResultMapServiceLayer(e.JobInfo.JobId);
                //resultLayer.Initialized += resultLayer_Initialized;
                //resultLayer.InitializationFailed += new EventHandler<EventArgs>(resultLayer_InitializationFailed);
                //resultLayer.DisplayName = e.JobInfo.JobId;
                //if (resultLayer != null)
                //{
                //    //_displayViewshedInfo = true;
                //    RibbonBar.map.Layers.Add(resultLayer);
                //}
            }
            else
            {
                //ContourMapBusyIndicator.IsBusy = false;
                MessageBox.Show("Geoprocessor service failed");
                //_displayViewshedInfo = false;
            }

            //System.Threading.Thread.Sleep(10000);
        }

        public void cmbNahieSelectionChanged()
        {
            //MessageBox.Show("ok");
        }

        public void OpenContourDialog(string selectedLayerName)
        {
            ContourMapView contourMapView = new ContourMapView(selectedLayerName);

            ChildWin child = new ChildWin();

            child.OKButton.Visibility = Visibility.Collapsed;
            child.CancelButton.Visibility = Visibility.Collapsed;

            child.Title = "رسم منحنی میزان";
            child.Name = "ContourMap";

            child.ParentLayoutRoot = MainPage.layoutRoot;

            child.childWinStack.Children.Add(contourMapView);

            try
            {
                child.ShowDialog();
            }
            catch (Exception)
            {
                //
            }
        }

        public void OpenBufferDialog()
        {
            RibbonBar.GenerateChildWin<SpatialQuery>("تعیین حریم", 0, "buffer");
        }

        public void StartDrawing(string selectedLayerName)
        {
            this.selectedLayerName = selectedLayerName;

            _myDrawObject.IsEnabled = true;
        }
        private void OpenProfileDialog()
        {
            ProfileView contourMapView = new ProfileView(selectedLayerName, this._pointCollection);

            ChildWin child = new ChildWin();

            child.OKButton.Visibility = Visibility.Collapsed;
            child.CancelButton.Visibility = Visibility.Collapsed;

            child.Title = "ترسیم پروفیل";
            child.Name = "profile";

            child.ParentLayoutRoot = MainPage.layoutRoot;

            child.childWinStack.Children.Add(contourMapView);

            try
            {
                child.Show();
            }
            catch (Exception exception)
            {
                //
            }
        }

        internal void OpenAreaVolumeDialog(string selectedLayerName)
        {
            AreaVolumeView areaVolumeView = new AreaVolumeView(selectedLayerName);

            ChildWin child = new ChildWin();

            child.OKButton.Visibility = Visibility.Collapsed;
            child.CancelButton.Visibility = Visibility.Collapsed;

            child.Title = "محاسبه مساحت و حجم";
            child.Name = "AreaVolume";

            child.ParentLayoutRoot = MainPage.layoutRoot;

            child.childWinStack.Children.Add(areaVolumeView);

            try
            {
                child.Show();
            }
            catch (Exception)
            {
                //
            }
        }

        public void OpenRasterComparisonDialog(List<String> rasters)
        {
            RasterComparisonView rasterComparisonView = new RasterComparisonView(rasters);

            ChildWin child = new ChildWin();

            child.OKButton.Visibility = Visibility.Collapsed;
            child.CancelButton.Visibility = Visibility.Collapsed;

            child.Title = "مقایسه تصویرها";
            child.Name = "RasterComparison";

            child.ParentLayoutRoot = MainPage.layoutRoot;

            child.childWinStack.Children.Add(rasterComparisonView);

            try
            {
                child.Show();
            }
            catch (Exception)
            {
                //
            }
        }
    }
}
