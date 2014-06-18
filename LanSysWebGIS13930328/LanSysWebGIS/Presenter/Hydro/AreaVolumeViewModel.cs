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
using ESRI.ArcGIS.Client.Tasks;
using LanSysWebGIS.UserControls;

namespace LanSysWebGIS.Presenter.Hydro
{
    public class AreaVolumeViewModel : Notifier
    {
        //private bool _isLoading;
        //public bool IsLoading
        //{
        //    get { return _isLoading; }
        //    set
        //    {
        //        _isLoading = value;
        //        OnPropertyChanged("IsLoading");
        //    }
        //}

        public string ReferencePlane;

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

        private string _zFactor;
        public string ZFactor
        {
            get { return _zFactor; }
            set
            {
                _zFactor = value;
                OnPropertyChanged("ZFactor");
            }
        }

        private string _heightOfPlain;
        public string HeightOfPlain
        {
            get { return _heightOfPlain; }
            set
            {
                _heightOfPlain = value;
                OnPropertyChanged("HeightOfPlain");
            }
        }

        private string _area2D;
        public string Area2D
        {
            get { return _area2D; }
            set
            {
                _area2D = value;
                OnPropertyChanged("Area2D");
            }
        }
        private string _area3D;
        public string Area3D
        {
            get { return _area3D; }
            set
            {
                _area3D = value;
                OnPropertyChanged("Area3D");
            }
        }
        private string _volume;
        public string Volume
        {
            get { return _volume; }
            set
            {
                _volume = value;
                OnPropertyChanged("Volume");
            }
        }


        public static LanSysWebGIS.Controls.BusyIndicator AreaVolumeBusyIndicator;

        Geoprocessor _geoprocessorTask;
        //ArcGISDynamicMapServiceLayer resultLayer = null;

        public void CalculateAreaVolume(string selectedLayerName)
        {
            AreaVolumeBusyIndicator.IsBusy = true;

            //this.RasterName = selectedLayerName;

            _geoprocessorTask = new Geoprocessor("http://91.98.96.231/ArcGIS/rest/services/PMO/AreaVolumeFinal/GPServer/AreaVolumeTask");
            _geoprocessorTask.JobCompleted += GeoprocessorTask_JobCompleted;
            _geoprocessorTask.Failed += GeoprocessorTask_Failed;

            List<GPParameter> parameters = new List<GPParameter>();

            parameters.Add(new GPString("InputRasterName ", selectedLayerName));
            parameters.Add(new GPString("Reference_Plane", this.ReferencePlane));
            parameters.Add(new GPDouble("Z_factor", double.Parse(this.ZFactor)));
            parameters.Add(new GPDouble("Height_of_Plane", double.Parse(this.HeightOfPlain)));

            _geoprocessorTask.OutputSpatialReference = new SpatialReference(102100);
            _geoprocessorTask.ProcessSpatialReference = new SpatialReference(102100);
            _geoprocessorTask.SubmitJobAsync(parameters);
        }

        private void GeoprocessorTask_Failed(object sender, TaskFailedEventArgs e)
        {
            AreaVolumeBusyIndicator.IsBusy = false;

            throw new Exception(e.Error.Message);
        }

        private void GeoprocessorTask_JobCompleted(object sender, JobInfoEventArgs e)
        {
            AreaVolumeBusyIndicator.IsBusy = false;
            //Map1.Cursor = System.Windows.Input.Cursors.Hand;
            if (e.JobInfo.JobStatus == esriJobStatus.esriJobSucceeded)
            {
                Geoprocessor geoprocessorTask = sender as Geoprocessor;

                geoprocessorTask.GetResultDataCompleted += (s3, e3) =>
                {
                    if (e3.Parameter is GPString)
                    {
                        string[] twoD3dVolume = ((ESRI.ArcGIS.Client.Tasks.GPString)(e3.Parameter)).Value.Split(';');
                        // Do something to show in silverlight

                        this.Area2D = twoD3dVolume[0];
                        this.Area3D = twoD3dVolume[1];
                        this.Volume = twoD3dVolume[2];
                    }

                    //AreaVolumeBusyIndicator.IsBusy = false;

                    geoprocessorTask.GetResultImageLayerCompleted += GeoprocessorTask_GetResultImageLayerCompleted;
                    //Make sure the output parameter name is the same as what you set for the GP service
                    geoprocessorTask.GetResultImageLayerAsync(e.JobInfo.JobId, "Output_Raster");
                };

                // Get the result data
                geoprocessorTask.GetResultDataAsync(e.JobInfo.JobId, "2D3DVolume");

                AreaVolumeBusyIndicator.IsBusy = true;
                //System.Threading.Thread.Sleep(2000);



                //resultLayer = geoprocessorTask.GetResultMapServiceLayer(e.JobInfo.JobId);
                //resultLayer.ID = "AreaVolumeImageLayer";
                //resultLayer.Initialized += resultLayer_Initialized;
                //resultLayer.InitializationFailed += new EventHandler<EventArgs>(resultLayer_InitializationFailed);
                //resultLayer.DisplayName = e.JobInfo.JobId;
                //if (resultLayer != null)
                //{
                //    //_displayViewshedInfo = true;
                //    //RibbonBar.map.Layers.Add(resultLayer);
                //}
            }
            else
            {
                AreaVolumeBusyIndicator.IsBusy = false;
                MessageBox.Show("Geoprocessor service failed");
                //_displayViewshedInfo = false;
            }

            //System.Threading.Thread.Sleep(10000);
        }

        //void resultLayer_Initialized(object sender, EventArgs e)
        //{
        //    ContourMapBusyIndicator.IsBusy = false;
        //}

        //private void resultLayer_InitializationFailed(object sender, EventArgs e)
        //{
        //    ContourMapBusyIndicator.IsBusy = false;

        //    throw new Exception("resultLayer_InitializationFailed");
        //}

        private void GeoprocessorTask_GetResultImageLayerCompleted(object sender, GetResultImageLayerEventArgs e)
        {
            AreaVolumeBusyIndicator.IsBusy = false;

            GPResultImageLayer imageLayer = e.GPResultImageLayer;
            imageLayer.ID = "AreaVolumeImageLayer";
            //imageLayer.Opacity = 0.7;
            //Remove if layer exists already
            if (RibbonBar.map.Layers["AreaVolumeImageLayer"] != null)
            {
                RibbonBar.map.Layers.Remove(RibbonBar.map.Layers["AreaVolumeImageLayer"]);
            }
            //Finally: Add ImageLayer to map
            RibbonBar.map.Layers.Add(imageLayer);
        }
    }
}
