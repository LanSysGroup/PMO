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
using ESRI.ArcGIS.Client.Geometry;
using ESRI.ArcGIS.Client.Tasks;
using LanSysWebGIS.UserControls;

namespace LanSysWebGIS.Presenter.Hydro
{
    public class RasterComparisonViewModel : Notifier
    {
        Geoprocessor _geoprocessorTask;

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

        private string _cellSize;
        public string CellSize
        {
            get { return _cellSize; }
            set
            {
                _cellSize = value;
                OnPropertyChanged("CellSize");
            }
        }

        public static LanSysWebGIS.Controls.BusyIndicator RasterComparisonBusyIndicator;

        public void CompareRasters(string beforeRaster, string afterRaster)
        {
            _geoprocessorTask = new Geoprocessor("http://91.98.96.231/ArcGIS/rest/services/PMO/CutFillFinal/GPServer/CutFillTask");
            _geoprocessorTask.UpdateDelay = 2000;
            _geoprocessorTask.OutputSpatialReference = RibbonBar.map.SpatialReference;
            _geoprocessorTask.JobCompleted += GeoprocessorTask_JobCompleted;
            _geoprocessorTask.Failed += GeoprocessorTask_Failed;

            List<GPParameter> parameters = new List<GPParameter>();

            parameters.Add(new GPString("BeforeRasterName", beforeRaster));
            parameters.Add(new GPString("AfterRasterName", afterRaster));
            parameters.Add(new GPString("Output_Cell_Size", this.CellSize));
            parameters.Add(new GPDouble("Z_factor", double.Parse(this.ZFactor)));

            _geoprocessorTask.OutputSpatialReference = new SpatialReference(102100);
            _geoprocessorTask.ProcessSpatialReference = new SpatialReference(102100);
            _geoprocessorTask.SubmitJobAsync(parameters);

            RasterComparisonBusyIndicator.IsBusy = true;
        }

        private void GeoprocessorTask_Failed(object sender, TaskFailedEventArgs e)
        {
            RasterComparisonBusyIndicator.IsBusy = false;

            throw new Exception(e.Error.Message);
        }

        private void GeoprocessorTask_JobCompleted(object sender, JobInfoEventArgs e)
        {
            RasterComparisonBusyIndicator.IsBusy = false;

            if (e.JobInfo.JobStatus == esriJobStatus.esriJobSucceeded)
            {
                Geoprocessor geoprocessorTask = sender as Geoprocessor;

                RasterComparisonBusyIndicator.IsBusy = true;
                //System.Threading.Thread.Sleep(2000);

                geoprocessorTask.GetResultImageLayerCompleted += GeoprocessorTask_GetResultImageLayerCompleted;
                //Make sure the output parameter name is the same as what you set for the GP service
                geoprocessorTask.GetResultImageLayerAsync(e.JobInfo.JobId, "Output_CutFill");
            }
            else
            {
                //RasterComparisonBusyIndicator.IsBusy = false;
                MessageBox.Show("Geoprocessor service failed");
                //_displayViewshedInfo = false;
            }

            //System.Threading.Thread.Sleep(10000);
        }

        private void GeoprocessorTask_GetResultImageLayerCompleted(object sender, GetResultImageLayerEventArgs e)
        {
            RasterComparisonBusyIndicator.IsBusy = false;

            GPResultImageLayer imageLayer = e.GPResultImageLayer;
            imageLayer.ID = "CutFillLayer";
            //imageLayer.Opacity = 0.7;
            //Remove if layer exists already
            if (RibbonBar.map.Layers["CutFillLayer"] != null)
            {
                RibbonBar.map.Layers.Remove(RibbonBar.map.Layers["CutFillLayer"]);
            }
            //Finally: Add ImageLayer to map
            RibbonBar.map.Layers.Add(imageLayer);
        }
    }
}