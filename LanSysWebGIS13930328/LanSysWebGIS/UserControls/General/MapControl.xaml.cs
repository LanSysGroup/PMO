using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.DomainServices.Client;
using System.Windows;
using System.Windows.Controls;
using ESRI.ArcGIS.Client.Tasks;
using LanSysWebGIS.Models;
using System.ComponentModel;
using ESRI.ArcGIS.Client;
using DevExpress.Xpf.Bars;
using ESRI.ArcGIS.Client.Symbols;
using LanSysWebGIS.UserControls.GeoMaps;
using SPSSilverlight.SPSUtilities;
using ESRI.ArcGIS.Client.Geometry;
using System.Windows.Input;
using System.Windows.Media;
using ESRI.ArcGIS.Client.Toolkit.Primitives;
using LanSysWebGIS.Web;
using LanSysWebGIS.Helpers;
using LanSysWebGIS.Views.UserManagement;
using LanSysWebGIS.Assets.Resources;
using ESRI.ArcGIS.Client.Samples.MapPrinting;

namespace LanSysWebGIS.UserControls
{
    [Serializable]
    public partial class MapControl : UserControl, INotifyPropertyChanged
    {
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public static string baseServiceUrl;

        //GeoMaps

        public static string GeoMapsIndicesURL;

        public static string GeometryServiceURL;

        public static GraphicsLayer geoMapsGraphicsLayer;

        public static GraphicsLayer geoMapsXYGraphicsLayer;

        public static GraphicsLayer geoMapsDataCheckingGEOGraphicsLayer;
        public static GraphicsLayer geoMapsDataCheckingSCANGraphicsLayer;
        public static GraphicsLayer geoMapsDataCheckingSHPGraphicsLayer;

        public static GeometryService geoService = new GeometryService();

        //\GeoMaps

        public static string mapClickMode = "pan";

        public static MapOperations mapOp = new MapOperations();

        //string serviceURL = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["serviceURL"].link;

        public static double scale;

        public static DevExpress.Xpf.Bars.BarButtonItem nextView;

        public static DevExpress.Xpf.Bars.BarButtonItem prevView;

        public static ESRI.ArcGIS.Client.Geometry.Envelope envelope1;

        public static ESRI.ArcGIS.Client.Geometry.Envelope envelope2;

        //private static System.Windows.Visibility visibility = System.Windows.Visibility.Collapsed;

        //GeoMaps

        public static ArcGISDynamicMapServiceLayer indexService;

        public static ArcGISDynamicMapServiceLayer georeferenced100kNIOCService;
        public static LayerInfo[] georeferenced100kNIOCLayerInfoArray;
        public static Dictionary<string, int> georeferenced100kNIOCServiceLayerIDs;

        public static ArcGISDynamicMapServiceLayer georeferenced100kNIOCServiceClipped;
        public static LayerInfo[] georeferenced100kNIOCLayerInfoArrayClipped;
        public static Dictionary<string, int> georeferenced100kNIOCServiceLayerIDsClipped;

        public static ArcGISDynamicMapServiceLayer georeferenced1000kNIOCService;
        public static LayerInfo[] georeferenced1000kNIOCLayerInfoArray;
        public static Dictionary<string, int> georeferenced1000kNIOCServiceLayerIDs;

        public static ArcGISDynamicMapServiceLayer PMOImagesServiceClipped;
        public static LayerInfo[] PMOImagesServiceLayerInfoArrayClipped;
        public static Dictionary<string, int> PMOImagesServiceLayerIDsClipped;

        public static ArcGISDynamicMapServiceLayer PMOHydroRasters;

        public static ArcGISDynamicMapServiceLayer georeferenced1000kNIOCServiceClipped;
        public static LayerInfo[] georeferenced1000kNIOCLayerInfoArrayClipped;
        public static Dictionary<string, int> georeferenced1000kNIOCServiceLayerIDsClipped;

        //public static ArcGISDynamicMapServiceLayer georeferenced100kGSIService;
        //public static LayerInfo[] georeferenced100kGSILayerInfoArray;
        //public static Dictionary<string, int> georeferenced100kGSIServiceLayerIDs;

        public static ArcGISDynamicMapServiceLayer georeferenced100kGSIServiceClipped;
        public static LayerInfo[] georeferenced100kGSILayerInfoArrayClipped;
        public static Dictionary<string, int> georeferenced100kGSIServiceLayerIDsClipped;

        //\GeoMaps

        public static ArcGISDynamicMapServiceLayer dynamicService;

        //for Drawing and Measuring
        public static Draw MyDrawSurface;
        public static Draw MyMeasSurface;

        //for Query

        //public System.Windows.Visibility bookmarkVis
        //{
        //    get { return visibility; }
        //    set
        //    {
        //        visibility = value;
        //        OnPropertyChanged("bookmarkVis");
        //    }
        //}

        //List<string> baseServicesNames = new List<string> { "Atlas","Atlas_Anot" };

        List<string> baseServicesNames = new List<string>();

        public static List<SpatialServices> allServices = new List<SpatialServices>();

        //DBDomainContext context = new DBDomainContext();
        PMOContext context = new PMOContext();

        public static Grid layoutRoot;

        List<string> graphicLayersList = new List<string> { "graphicsLayer", "gLayersSelection", "gLayerDraw", "gLayerMeas", "gLayerQueryBuilder", "gLayerIdentify",
        "gLayerBuffer", "MySelectionGraphicsLayer","XYGraphicsLayer", "DataCheckingSHPGraphicsLayer", "DataCheckingGEOGraphicsLayer", "DataCheckingSCANGraphicsLayer"};

        public void AddGraphicLayersToMap(List<string> layersList)
        {
            foreach (string s in layersList)
            {
                GraphicsLayer gr = new GraphicsLayer();

                gr.ID = s;

                Map1.Layers.Insert(Map1.Layers.Count(), gr);

                if (gr.ID == "gLayersSelection")
                {
                    gr.MouseLeftButtonUp += GraphicsLayer_MouseLeftButtonUp;
                }
                else if (gr.ID == "gLayerDraw")
                {
                    gr.MouseLeftButtonUp += GraphicsLayer_MouseLeftButtonUp_1;
                }
            }
        }

        public MapControl()
        {
            InitializeComponent();

            layoutRoot = this.LayoutRoot;

            context.Load(context.GetSpatialServicesQuery(), LoadBehavior.RefreshCurrent,
                                        callback =>
                                        {
                                            baseServicesNames.AddRange(context.SpatialServices.Where(p=>p.Visible ==true).Select(p => p.Name));

                                            allServices.AddRange(context.SpatialServices);

                                            InitMapControl();

                                        }, null);
        }

        public void InitMapControl()
        {
            int count = 0;

            foreach (string serviceName in baseServicesNames)
            {
                context.Load(context.GetSpatialServicesQuery(), LoadBehavior.RefreshCurrent, callback =>
                                        {
                                            count++;

                                            string serviceUrl = context.SpatialServices.Where(p => p.Name == serviceName).Select(p => p.Url).Single();

                                            //GeoMaps
                                            if (serviceName != "Geometry")
                                            {
                                                ArcGISDynamicMapServiceLayer ags = new ArcGISDynamicMapServiceLayer();

                                                ags.Url = serviceUrl;

                                                ags.ID = serviceName;

                                                if (serviceName == "Atlas_Preview")
                                                {
                                                    Atlas_Preview.Url = serviceUrl;
                                                }
                                                else if (serviceName.Contains("PMO"))
                                                {
                                                    if (serviceName.Contains("Indices"))
                                                    {
                                                        GeoMapsIndicesURL = serviceUrl + "/";

                                                        ags.ID = "Index";

                                                        ags.Initialized += Index_Initialized;

                                                        Map1.Layers.Insert(12, ags);
                                                    }
                                                    else if (serviceName == "PMOImages")
                                                    {
                                                        ags.Initialized += PMOImages_Initialized;

                                                        Map1.Layers.Insert(13, ags);
                                                    }
                                                    else if (serviceName == "PMOHydroRasters")
                                                    {
                                                        ags.Initialized += PMOHydroRasters_Initialized;

                                                        Map1.Layers.Insert(13, ags);
                                                    }
                                                    else if (serviceName == "GeoMaps1000kNIOC")
                                                    {
                                                        ags.Initialized += Georeferenced1000kNIOC_Initialized;

                                                        Map1.Layers.Insert(13, ags);
                                                    }
                                                    else if (serviceName == "GeoMaps100kNIOCClipped")
                                                    {
                                                        ags.Initialized += Georeferenced100kNIOCClipped_Initialized;

                                                        Map1.Layers.Insert(13, ags);
                                                    }
                                                    else if (serviceName == "GeoMaps1000kNIOCClipped")
                                                    {
                                                        ags.Initialized += Georeferenced1000kNIOCClipped_Initialized;

                                                        Map1.Layers.Insert(13, ags);
                                                    }
                                                    else if (serviceName == "GeoMaps100kGSI")
                                                    {
                                                        //ags.Initialized += Georeferenced100kGSI_Initialized; ;

                                                        //Map1.Layers.Insert(17, ags);
                                                    }
                                                    else if (serviceName == "GeoMaps100kGSIClipped")
                                                    {
                                                        ags.Initialized += Georeferenced100kGSIClipped_Initialized;

                                                        Map1.Layers.Insert(13, ags);
                                                    }

                                                    //todo ags.Initialized

                                                    //todo fill list or dictionary of services


                                                }
                                                else if (serviceName == "ET")
                                                {
                                                    ArcGISDynamicMapServiceLayer ags2 = new ArcGISDynamicMapServiceLayer();

                                                    ags2.Url = serviceUrl;

                                                    ags2.ID = serviceName;

                                                    //ags.Initialized += ArcGISDynamicMapServiceLayer_Initialized;

                                                    //baseServiceUrl = serviceUrl;

                                                    Map1.Layers.Insert(0, ags2);

                                                    //Map1.SnapToLevels = false;
                                                }

                                                else if (serviceName == "hill_ban_haj")
                                                {
                                                    ArcGISDynamicMapServiceLayer ags2 = new ArcGISDynamicMapServiceLayer();

                                                    ags2.Url = serviceUrl;

                                                    ags2.ID = serviceName;

                                                    //ags.Initialized += ArcGISDynamicMapServiceLayer_Initialized;

                                                    //baseServiceUrl = serviceUrl;

                                                    Map1.Layers.Insert(1, ags2);

                                                    //Map1.SnapToLevels = false;
                                                }

                                                else if (serviceName == "Iran")
                                                {
                                                    ArcGISDynamicMapServiceLayer ags2 = new ArcGISDynamicMapServiceLayer();

                                                    ags2.Url = serviceUrl;

                                                    ags2.ID = serviceName;

                                                    ags2.Visible = false;

                                                    //ags.Initialized += ArcGISDynamicMapServiceLayer_Initialized;

                                                    //baseServiceUrl = serviceUrl;

                                                    Map1.Layers.Insert(2, ags2);

                                                    //Map1.SnapToLevels = false;
                                                }

                                                else if (serviceName == "IranHill")
                                                {
                                                    ArcGISDynamicMapServiceLayer ags2 = new ArcGISDynamicMapServiceLayer();

                                                    ags2.Url = serviceUrl;

                                                    ags2.ID = serviceName;

                                                    ags2.Visible = false;

                                                    //ags.Initialized += ArcGISDynamicMapServiceLayer_Initialized;

                                                    //baseServiceUrl = serviceUrl;

                                                    Map1.Layers.Insert(3, ags2);

                                                    //Map1.SnapToLevels = false;
                                                }

                                                else if (serviceName == "Worldview2M")
                                                {
                                                    ArcGISDynamicMapServiceLayer ags2 = new ArcGISDynamicMapServiceLayer();

                                                    ags2.Url = serviceUrl;

                                                    ags2.ID = serviceName;

                                                    //ags.Initialized += ArcGISDynamicMapServiceLayer_Initialized;

                                                    //baseServiceUrl = serviceUrl;

                                                    Map1.Layers.Insert(4, ags2);

                                                    //Map1.SnapToLevels = false;
                                                }



                                                //else if (serviceName == "Worldview2P")
                                                //{
                                                //    ArcGISTiledMapServiceLayer ags2 = new ArcGISTiledMapServiceLayer();

                                                //    ags2.Url = serviceUrl;

                                                //    ags2.ID = serviceName;

                                                //    //ags.Initialized += ArcGISDynamicMapServiceLayer_Initialized;

                                                //    //baseServiceUrl = serviceUrl;

                                                //    Map1.Layers.Insert(1, ags2);

                                                //    //Map1.SnapToLevels = false;
                                                //}

                                                //else if (serviceName == "Iran")
                                                //{
                                                //    ArcGISTiledMapServiceLayer ags2 = new ArcGISTiledMapServiceLayer();

                                                //    ags2.Url = serviceUrl;

                                                //    ags2.ID = serviceName;

                                                //    //ags.Initialized += ArcGISDynamicMapServiceLayer_Initialized;

                                                //    //baseServiceUrl = serviceUrl;

                                                //    Map1.Layers.Insert(1, ags2);

                                                //    //Map1.SnapToLevels = false;
                                                //}
                                                else
                                                {
                                                    if (serviceName == "Atlas")
                                                    {
                                                        ags.Initialized += ArcGISDynamicMapServiceLayer_Initialized;

                                                        baseServiceUrl = serviceUrl;

                                                        Map1.Layers.Insert(6, ags);
                                                    }
                                                }

                                                //todo for basemaps
                                                //Map1.Layers.Insert(0, ags);


                                                //if (serviceName == "Atlas")
                                                //{
                                                //    ags.Initialized += ArcGISDynamicMapServiceLayer_Initialized;

                                                //    baseServiceUrl = serviceUrl;
                                                //}

                                                //if (serviceName != "Atlas_Preview")
                                                //{
                                                //    Map1.Layers.Insert(1, ags);
                                                //}   
                                                //else if (serviceName == "Atlas_Preview")
                                                //{
                                                //    Atlas_Preview.Url = serviceUrl;
                                                //}
                                            }
                                            else
                                            {
                                                GeometryServiceURL = serviceUrl;

                                                geoService.Url = GeometryServiceURL;

                                                //geoService = new GeometryService(GeometryServiceURL);
                                            }
                                            //\GeoMaps

                                            if (count == baseServicesNames.Count)
                                            {
                                                AddGraphicLayersToMap(graphicLayersList);

                                                RemoveTestGrpahicLayers();

                                                geoMapsGraphicsLayer = Map1.Layers["MySelectionGraphicsLayer"] as GraphicsLayer;

                                                geoMapsXYGraphicsLayer = Map1.Layers["XYGraphicsLayer"] as GraphicsLayer;

                                                geoMapsDataCheckingGEOGraphicsLayer = Map1.Layers["DataCheckingGEOGraphicsLayer"] as GraphicsLayer;

                                                geoMapsDataCheckingSCANGraphicsLayer = Map1.Layers["DataCheckingSCANGraphicsLayer"] as GraphicsLayer;

                                                geoMapsDataCheckingSHPGraphicsLayer = Map1.Layers["DataCheckingSHPGraphicsLayer"] as GraphicsLayer;
                                            }
                                        }, null);
            }

            vectorExpander.IsExpanded = true;

            //GeoMaps

            GeoMapsOperations.map1 = Map1;

            SearchGraphics.map = Map1;

            RibbonBar.leg = this.MyLegend2;

            //\GeoMaps

            MapOperations.map1 = Map1;

            RibbonBar.map = Map1;

            TableOfContent.map = this.Map1;

            SpatialQuery.map = Map1;

            MapOperations.bookmark = this.bookmark;

            //RibbonBar.IdentifyResult = this.IdentifyResult;

            //RibbonBar.QueryBuilderDialog = this.QueryBuilderDialog;

            //RibbonBar.RasterDialog = this.RasterDialog;

            RibbonBar.AttachmentDialog = this.AttachmentDialog;

            //RibbonBar.PrintDialog = this.PrintDialog;

            RibbonBar.BufferDialog = this.BufferDialog;

            RibbonBar.gLayerSelection = Map1.Layers["gLayersSelection"] as GraphicsLayer;

            RibbonBar.identifyExpander = this.identifyExpander;

            RibbonBar.aboutUs = this.aboutUs;

            //RibbonBar.uploadDataDialog = this.UploadDialog;

            //dataFormViewEdit.newRecord = this.dataFormNew.DataFormNewDialog;

            //RibbonBar.dataFormDialog = this.dataFormViewEdit.DataFormViewEditDialog;

            Measuring.map1 = Map1;

            PrintingUserControl.mapPrint = this.Map1;

            MapOperations.MyAttachmentEditor = this.MyAttachmentEditor;

            this.DataContext = this;

            //expander.Background.Opacity = 0.7;

            MapOperations.IdentifyComboBox = IdentifyComboBox;

            QueryBuilder.QueryBuilderFeatureDataGrid = QueryBuilderFeatureDataGrid;

            //for drawing
            MyDrawSurface = new Draw(Map1)
            {
                LineSymbol = new SimpleLineSymbol(),
                FillSymbol = new SimpleFillSymbol()
                //LineSymbol = LayoutRoot.Resources["DefaultLineSymbol"] as SimpleLineSymbol,
                //FillSymbol = LayoutRoot.Resources["DefaultFillSymbol"] as FillSymbol
            };
            MyDrawSurface.DrawComplete += MapOperations.MyDrawSurface_DrawComplete;

            MyMeasSurface = new Draw(Map1)
            {
                LineSymbol = new SimpleLineSymbol(),
                FillSymbol = new SimpleFillSymbol()
                //LineSymbol = LayoutRoot.Resources["DefaultLineSymbol"] as SimpleLineSymbol,
                //FillSymbol = LayoutRoot.Resources["DefaultFillSymbol"] as FillSymbol
            };
            MyMeasSurface.DrawBegin += MapOperations.MyMeasSurface_DrawBegin;
            MyMeasSurface.DrawComplete += MapOperations.MyMeasSurface_DrawComplete;
            MyMeasSurface.VertexAdded += MapOperations.MyMeasSurface_VertexAdded;
        }

        private void PMOHydroRasters_Initialized(object sender, EventArgs e)
        {
            PMOHydroRasters = Map1.Layers["PMOHydroRasters"] as ArcGISDynamicMapServiceLayer;

            //geoMapsOper.georeferenced1000kNIOCServiceClipped = georeferenced1000kNIOCServiceClipped;

            //GeoMapsOperations.PMOImagesServiceClipped = PMOImagesServiceClipped;

            PMOHydroRasters.VisibleLayers = new int[] { };

            //PMOImagesServiceLayerInfoArrayClipped = PMOImagesServiceClipped.Layers;

            //PMOImagesServiceLayerIDsClipped = new Dictionary<string, int>();

            //if (PMOImagesServiceLayerInfoArrayClipped == null)
            //{
            //    throw new Exception(GeoMapsStrings.SpatialServiceError);
            //}

            //for (int i = 0; i < PMOImagesServiceLayerInfoArrayClipped.Length; i++)
            //{
            //    PMOImagesServiceLayerIDsClipped[PMOImagesServiceLayerInfoArrayClipped[i].Name.ToUpper()] = PMOImagesServiceLayerInfoArrayClipped[i].ID;
            //}

            //geoMapsOper.serviceName2ServiceDictionary["georeferenced1000kNIOCServiceClipped"] = georeferenced1000kNIOCServiceClipped;
            //geoMapsOper.serviceName2ServiceLayerIDsDictionary["georeferenced1000kNIOCServiceClipped"] = georeferenced1000kNIOCServiceLayerIDsClipped;

            //GeoMapsOperations.serviceName2ServiceDictionary["PMOImagesServiceClipped"] = PMOImagesServiceClipped;
            //GeoMapsOperations.serviceName2ServiceLayerIDsDictionary["PMOImagesServiceClipped"] = PMOImagesServiceLayerIDsClipped;
        }

        private void RemoveTestGrpahicLayers()
        {
            for (int i = Map1.Layers.Count - 1; i >= 0; i--)
            {
                try
                {
                    if (Map1.Layers[i].ID.Contains("testGraphic"))
                        Map1.Layers.Remove(Map1.Layers[i]);
                }
                catch (Exception eeee)
                {
                }
                
            }

            //foreach (Layer layer in Map1.Layers.OfType<GraphicsLayer>())
            //{
            //    if (layer.ID.Contains("testGraphic"))
            //        Map1.Layers.Remove(layer);
            //}
        }

        //GeoMaps

        //Index
        private void Index_Initialized(object sender, EventArgs e)
        {
            indexService = Map1.Layers["Index"] as ArcGISDynamicMapServiceLayer;

            //geoMapsOper.indexService = indexService;

            GeoMapsOperations.indexService = indexService;

            indexService.VisibleLayers = new int[] { };


            //todo for query builder
            //indexLayerInfoArray = indexService.Layers;

            //indexLayerIDs = new Dictionary<string, int>();

            //for (int i = 0; i < indexLayerInfoArray.Length; i++)
            //{
            //    indexLayerIDs[indexLayerInfoArray[i].Name.ToUpper()] = indexLayerInfoArray[i].ID;

            //    //query builder
            //    //layersInfo.Add(new ArcGISLayerInfo(indexService.Url + "/" + indexComboBox.SelectedIndex.ToString()));
            //    layersInfo.Add(new ArcGISLayerInfo(indexService.Url + "/" + i.ToString()));
            //    //
            //}
        }

        private void PMOImages_Initialized(object sender, EventArgs e)
        {
            PMOImagesServiceClipped = Map1.Layers["PMOImages"] as ArcGISDynamicMapServiceLayer;

            //geoMapsOper.georeferenced1000kNIOCServiceClipped = georeferenced1000kNIOCServiceClipped;

            GeoMapsOperations.PMOImagesServiceClipped = PMOImagesServiceClipped;

            PMOImagesServiceClipped.VisibleLayers = new int[] { };

            PMOImagesServiceLayerInfoArrayClipped = PMOImagesServiceClipped.Layers;

            PMOImagesServiceLayerIDsClipped = new Dictionary<string, int>();

            if (PMOImagesServiceLayerInfoArrayClipped == null)
            {
                throw new Exception(GeoMapsStrings.SpatialServiceError);
            }

            for (int i = 0; i < PMOImagesServiceLayerInfoArrayClipped.Length; i++)
            {
                PMOImagesServiceLayerIDsClipped[PMOImagesServiceLayerInfoArrayClipped[i].Name.ToUpper()] = PMOImagesServiceLayerInfoArrayClipped[i].ID;
            }

            //geoMapsOper.serviceName2ServiceDictionary["georeferenced1000kNIOCServiceClipped"] = georeferenced1000kNIOCServiceClipped;
            //geoMapsOper.serviceName2ServiceLayerIDsDictionary["georeferenced1000kNIOCServiceClipped"] = georeferenced1000kNIOCServiceLayerIDsClipped;

            GeoMapsOperations.serviceName2ServiceDictionary["PMOImagesServiceClipped"] = PMOImagesServiceClipped;
            GeoMapsOperations.serviceName2ServiceLayerIDsDictionary["PMOImagesServiceClipped"] = PMOImagesServiceLayerIDsClipped;
        }

        //100k NIOC
        private void Georeferenced100kNIOC_Initialized(object sender, EventArgs e)
        {
            georeferenced100kNIOCService = Map1.Layers["GeoMaps100kNIOC"] as ArcGISDynamicMapServiceLayer;

            //geoMapsOper.georeferenced100kNIOCService = georeferenced100kNIOCService;

            GeoMapsOperations.georeferenced100kNIOCService = georeferenced100kNIOCService;

            georeferenced100kNIOCService.VisibleLayers = new int[] { };

            georeferenced100kNIOCLayerInfoArray = georeferenced100kNIOCService.Layers;

            georeferenced100kNIOCServiceLayerIDs = new Dictionary<string, int>();

            if (georeferenced100kNIOCLayerInfoArray == null)
            {
                throw new Exception(GeoMapsStrings.SpatialServiceError);
            }

            for (int i = 0; i < georeferenced100kNIOCLayerInfoArray.Length; i++)
            {
                georeferenced100kNIOCServiceLayerIDs[georeferenced100kNIOCLayerInfoArray[i].Name.ToUpper()] = georeferenced100kNIOCLayerInfoArray[i].ID;
            }

            //geoMapsOper.serviceName2ServiceDictionary["georeferenced100kNIOCService"] = georeferenced100kNIOCService;
            //geoMapsOper.serviceName2ServiceLayerIDsDictionary["georeferenced100kNIOCService"] = georeferenced100kNIOCServiceLayerIDs;

            GeoMapsOperations.serviceName2ServiceDictionary["georeferenced100kNIOCService"] = georeferenced100kNIOCService;
            GeoMapsOperations.serviceName2ServiceLayerIDsDictionary["georeferenced100kNIOCService"] = georeferenced100kNIOCServiceLayerIDs;
        }
        //100k NIOC Clipped
        private void Georeferenced100kNIOCClipped_Initialized(object sender, EventArgs e)
        {
            georeferenced100kNIOCServiceClipped = Map1.Layers["GeoMaps100kNIOCClipped"] as ArcGISDynamicMapServiceLayer;

            //geoMapsOper.georeferenced100kNIOCServiceClipped = georeferenced100kNIOCServiceClipped;

            GeoMapsOperations.georeferenced100kNIOCServiceClipped = georeferenced100kNIOCServiceClipped;

            georeferenced100kNIOCServiceClipped.VisibleLayers = new int[] { };

            georeferenced100kNIOCLayerInfoArrayClipped = georeferenced100kNIOCServiceClipped.Layers;

            georeferenced100kNIOCServiceLayerIDsClipped = new Dictionary<string, int>();

            if (georeferenced100kNIOCLayerInfoArrayClipped == null)
            {
                throw new Exception(GeoMapsStrings.SpatialServiceError);
            }

            for (int i = 0; i < georeferenced100kNIOCLayerInfoArrayClipped.Length; i++)
            {
                georeferenced100kNIOCServiceLayerIDsClipped[georeferenced100kNIOCLayerInfoArrayClipped[i].Name.ToUpper()] = georeferenced100kNIOCLayerInfoArrayClipped[i].ID;
            }

            //geoMapsOper.serviceName2ServiceDictionary["georeferenced100kNIOCServiceClipped"] = georeferenced100kNIOCServiceClipped;
            //geoMapsOper.serviceName2ServiceLayerIDsDictionary["georeferenced100kNIOCServiceClipped"] = georeferenced100kNIOCServiceLayerIDsClipped;

            GeoMapsOperations.serviceName2ServiceDictionary["georeferenced100kNIOCServiceClipped"] = georeferenced100kNIOCServiceClipped;
            GeoMapsOperations.serviceName2ServiceLayerIDsDictionary["georeferenced100kNIOCServiceClipped"] = georeferenced100kNIOCServiceLayerIDsClipped;
        }

        //1000k NIOC
        private void Georeferenced1000kNIOC_Initialized(object sender, EventArgs e)
        {
            georeferenced1000kNIOCService = Map1.Layers["GeoMaps1000kNIOC"] as ArcGISDynamicMapServiceLayer;

            //geoMapsOper.georeferenced1000kNIOCService = georeferenced1000kNIOCService;

            GeoMapsOperations.georeferenced1000kNIOCService = georeferenced1000kNIOCService;

            georeferenced1000kNIOCService.VisibleLayers = new int[] { };

            georeferenced1000kNIOCLayerInfoArray = georeferenced1000kNIOCService.Layers;

            georeferenced1000kNIOCServiceLayerIDs = new Dictionary<string, int>();

            if (georeferenced1000kNIOCLayerInfoArray == null)
            {
                throw new Exception(GeoMapsStrings.SpatialServiceError);
            }

            for (int i = 0; i < georeferenced1000kNIOCLayerInfoArray.Length; i++)
            {
                georeferenced1000kNIOCServiceLayerIDs[georeferenced1000kNIOCLayerInfoArray[i].Name.ToUpper()] = georeferenced1000kNIOCLayerInfoArray[i].ID;
            }

            //geoMapsOper.serviceName2ServiceDictionary["georeferenced1000kNIOCService"] = georeferenced1000kNIOCService;
            //geoMapsOper.serviceName2ServiceLayerIDsDictionary["georeferenced1000kNIOCService"] = georeferenced1000kNIOCServiceLayerIDs;

            GeoMapsOperations.serviceName2ServiceDictionary["georeferenced1000kNIOCService"] = georeferenced1000kNIOCService;
            GeoMapsOperations.serviceName2ServiceLayerIDsDictionary["georeferenced1000kNIOCService"] = georeferenced1000kNIOCServiceLayerIDs;
        }
        //1000k NIOC Clipped
        private void Georeferenced1000kNIOCClipped_Initialized(object sender, EventArgs e)
        {
            georeferenced1000kNIOCServiceClipped = Map1.Layers["GeoMaps1000kNIOCClipped"] as ArcGISDynamicMapServiceLayer;

            //geoMapsOper.georeferenced1000kNIOCServiceClipped = georeferenced1000kNIOCServiceClipped;

            GeoMapsOperations.georeferenced1000kNIOCServiceClipped = georeferenced1000kNIOCServiceClipped;

            georeferenced1000kNIOCServiceClipped.VisibleLayers = new int[] { };

            georeferenced1000kNIOCLayerInfoArrayClipped = georeferenced1000kNIOCServiceClipped.Layers;

            georeferenced1000kNIOCServiceLayerIDsClipped = new Dictionary<string, int>();

            if (georeferenced1000kNIOCLayerInfoArrayClipped == null)
            {
                throw new Exception(GeoMapsStrings.SpatialServiceError);
            }

            for (int i = 0; i < georeferenced1000kNIOCLayerInfoArrayClipped.Length; i++)
            {
                georeferenced1000kNIOCServiceLayerIDsClipped[georeferenced1000kNIOCLayerInfoArrayClipped[i].Name.ToUpper()] = georeferenced1000kNIOCLayerInfoArrayClipped[i].ID;
            }

            //geoMapsOper.serviceName2ServiceDictionary["georeferenced1000kNIOCServiceClipped"] = georeferenced1000kNIOCServiceClipped;
            //geoMapsOper.serviceName2ServiceLayerIDsDictionary["georeferenced1000kNIOCServiceClipped"] = georeferenced1000kNIOCServiceLayerIDsClipped;

            GeoMapsOperations.serviceName2ServiceDictionary["georeferenced1000kNIOCServiceClipped"] = georeferenced1000kNIOCServiceClipped;
            GeoMapsOperations.serviceName2ServiceLayerIDsDictionary["georeferenced1000kNIOCServiceClipped"] = georeferenced1000kNIOCServiceLayerIDsClipped;
        }

        ////100k GSI
        //private void Georeferenced100kGSI_Initialized(object sender, EventArgs e)
        //{
        //    georeferenced100kGSIService = Map1.Layers["GeoMaps100kGSI"] as ArcGISDynamicMapServiceLayer;

        //    GeoMapsOperations.georeferenced100kGSIService = georeferenced100kGSIService;

        //    georeferenced100kGSIService.VisibleLayers = new int[] { };

        //    georeferenced100kGSILayerInfoArray = georeferenced100kGSIService.Layers;

        //    georeferenced100kGSIServiceLayerIDs = new Dictionary<string, int>();

        //    if (georeferenced100kGSILayerInfoArray == null)
        //    {
        //        throw new Exception(GeoMapsStrings.SpatialServiceError);
        //    }

        //    for (int i = 0; i < georeferenced100kGSILayerInfoArray.Length; i++)
        //    {
        //        georeferenced100kGSIServiceLayerIDs[georeferenced100kGSILayerInfoArray[i].Name.ToUpper()] = georeferenced100kGSILayerInfoArray[i].ID;
        //    }

        //    //geoMapsOper.serviceName2ServiceDictionary["georeferenced100kNIOCService"] = georeferenced100kNIOCService;
        //    //geoMapsOper.serviceName2ServiceLayerIDsDictionary["georeferenced100kNIOCService"] = georeferenced100kNIOCServiceLayerIDs;

        //    GeoMapsOperations.serviceName2ServiceDictionary["georeferenced100kGSIService"] = georeferenced100kGSIService;
        //    GeoMapsOperations.serviceName2ServiceLayerIDsDictionary["georeferenced100kGSIService"] = georeferenced100kGSIServiceLayerIDs;
        //}
        //100k GSI Clipped
        private void Georeferenced100kGSIClipped_Initialized(object sender, EventArgs e)
        {
            georeferenced100kGSIServiceClipped = Map1.Layers["GeoMaps100kGSIClipped"] as ArcGISDynamicMapServiceLayer;

            GeoMapsOperations.georeferenced100kGSIServiceClipped = georeferenced100kGSIServiceClipped;

            georeferenced100kGSIServiceClipped.VisibleLayers = new int[] { };

            georeferenced100kGSILayerInfoArrayClipped = georeferenced100kGSIServiceClipped.Layers;

            georeferenced100kGSIServiceLayerIDsClipped = new Dictionary<string, int>();

            if (georeferenced100kGSILayerInfoArrayClipped == null)
            {
                throw new Exception(GeoMapsStrings.SpatialServiceError);
            }

            for (int i = 0; i < georeferenced100kGSILayerInfoArrayClipped.Length; i++)
            {
                georeferenced100kGSIServiceLayerIDsClipped[georeferenced100kGSILayerInfoArrayClipped[i].Name.ToUpper()] = georeferenced100kGSILayerInfoArrayClipped[i].ID;
            }

            GeoMapsOperations.serviceName2ServiceDictionary["georeferenced100kGSIServiceClipped"] = georeferenced100kGSIServiceClipped;
            GeoMapsOperations.serviceName2ServiceLayerIDsDictionary["georeferenced100kGSIServiceClipped"] = georeferenced100kGSIServiceLayerIDsClipped;
        }

        //\GeoMaps

        private void ArcGISDynamicMapServiceLayer_Initialized(object sender, EventArgs e)
        {
            dynamicService = sender as ArcGISDynamicMapServiceLayer;

            mapOp.dynamicService = dynamicService;

            //if (dynamicService.VisibleLayers == null)
            //    dynamicService.VisibleLayers = GetDefaultVisibleLayers(dynamicService);

            GetDefaultVisibleLayers(dynamicService);

            //dynamicService.VisibleLayers = null;


            //PopulateActiveLayer(dynamicService);

            //MapOperations.ZoomIn();

            //MapOperations.fullExtent();

            //Map1.Extent = (Map1.Layers["Atlas"] as ArcGISDynamicMapServiceLayer).InitialExtent;
        }

        //private void PopulateActiveLayer(ArcGISDynamicMapServiceLayer dynamicService)
        //{
        //    foreach (LayerInfo item in dynamicService.Layers)
        //    {
        //        cmbActiveLayer.Items.Add(item.Name);
        //    }
        //}

        public void CalculateScale()
        {
            double dpi = 96;
            double resolution = Map1.Resolution;
            scale = Math.Ceiling(resolution * dpi * 39.37);

            if (Math.Abs(scale - RibbonBar.ribbonScale) < 2)
                scale = RibbonBar.ribbonScale;
        }

        private bool isFirst = true;

        private int count = 0;

        public static List<Envelope> extentHistory = new List<Envelope>();
        public static int currentExtentIndex = 0;
        public static bool newExtent = true;

        private void Map1_ExtentChanged(object sender, ESRI.ArcGIS.Client.ExtentEventArgs e)
        {
            //CalculateScale();

            txtScale.Text = Map1.Scale.ToString();

            if (e.OldExtent == null)
            {
                extentHistory.Add(e.NewExtent.Clone());
                return;
            }

            if (newExtent)
            {
                currentExtentIndex++;

                if (extentHistory.Count - currentExtentIndex > 0)
                    extentHistory.RemoveRange(currentExtentIndex, (extentHistory.Count - currentExtentIndex));

                nextView.IsEnabled = false;
                prevView.IsEnabled = true;

                extentHistory.Add(e.NewExtent.Clone());
            }
            else
            {
                Map1.IsHitTestVisible = true;
                newExtent = true;
            }
        }

        private ESRI.ArcGIS.Client.Projection.WebMercator webMercator = new ESRI.ArcGIS.Client.Projection.WebMercator();

        private void Map1_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (Map1.Extent != null && Map1.SpatialReference.WKID == 102100)
            {
                System.Windows.Point screenPoint = e.GetPosition(Map1);
                ESRI.ArcGIS.Client.Geometry.MapPoint mapPoint = Map1.ScreenToMap(screenPoint);
                try
                {
                    //txtX.Text = Math.Round(((MapPoint)webMercator.ToGeographic(mapPoint)).X, 4).ToString();
                    //txtY.Text = Math.Round(((MapPoint)webMercator.ToGeographic(mapPoint)).Y, 4).ToString();

                    string[] xyStrings = CoordinateTransformer.WGS84ToUTM(((MapPoint)webMercator.ToGeographic(mapPoint)).X,
                        ((MapPoint)webMercator.ToGeographic(mapPoint)).Y, 5);

                    txtX.Text = xyStrings[0];
                    txtY.Text = xyStrings[1];
                }
                catch (Exception fff)
                {

                }

            }
        }

        private void Map1_MouseClick(object sender, ESRI.ArcGIS.Client.Map.MouseEventArgs e)
        {
            ESRI.ArcGIS.Client.Geometry.MapPoint clickPoint = e.MapPoint;

            switch (mapClickMode)
            {
                case "pan" // Select by a Point
                :
                    {
                        mapOp.ExtractCoor(clickPoint);
                    }
                    break;
                case "select" // Select by a Point
                :
                    {
                        mapOp.selectFeatures(clickPoint, false);
                    }
                    break;
                case "identify" // Identify
                :
                    {
                        mapOp.identifyFeatures(clickPoint, true);
                    }
                    break;
                case "attachment" //Attachment
                :
                    {
                    }
                    break;
                case "buffer" //Buffer
                :
                    {
                        buffer.ExecuteBuffer(clickPoint, Map1);
                    }
                    break;
                default:
                    // Clear
                    break;
            }
        }

        public static List<ArcGISLayerInfo> layersInfo = new List<ArcGISLayerInfo>();

        ESRI.ArcGIS.Client.LayerInfo[] layerInfoArray;

        //List<LayerInfo> layerList;

        private int[] GetDefaultVisibleLayers(ArcGISDynamicMapServiceLayer dynamicServiceLayer)
        {
            List<int> visibleLayerIDList = new List<int>();

            layerInfoArray = dynamicServiceLayer.Layers;

            for (int index = 0; index < layerInfoArray.Length; index++)
            {
                //query builder

                layersName2layersNumberDic.Add(layerInfoArray[index].Name, index);

                //try
                //{
                //    layersName2layersNumberDic.Add(layerInfoArray[index].Name, index);
                //}
                //catch (Exception)
                //{
                //}
                

                //layersName2layersNumberDic.Add(index, layerInfoArray[index].Name);

                layersInfo.Add(new ArcGISLayerInfo(dynamicService.Url + "/" + index.ToString(), new ArcGISLayerInfoReadyHandler(infohandler)));
                //layersInfo.Add(new ArcGISLayerInfo(dynamicService.Url + "/" + index.ToString()));

                if (layerInfoArray[index].DefaultVisibility)
                    visibleLayerIDList.Add(index);
            }

            //layerList = layerInfoArray.ToList<LayerInfo>();

            mapOp.layersInfo = layersInfo;

            return visibleLayerIDList.ToArray();
        }

        int layersHandledCount = 0;

        public static List<int> groupLayersIndex = new List<int>();

        public static List<string> nonGroupLayersName = new List<string>();

        //public static Dictionary<int, string> layersName2layersNumberDic = new Dictionary<int, string>();

        public static Dictionary<string, int> layersName2layersNumberDic = new Dictionary<string, int>();

        private void infohandler(object a, ArcGISLayerInfoEventArgs args)
        {
            //layersName2layersNumberDic.Add(args.LayerInfo.LayerName, layersHandledCount);

            layersHandledCount++;

            if (layersHandledCount == dynamicService.Layers.Length)
            {
                for (int i = layersInfo.Count - 1; i >= 0; i--)
                {
                    if (layersInfo[i].LayerType == "Group Layer")
                    {
                        //layersInfo.RemoveAt(i);

                        //layerList.RemoveAt(i);

                        groupLayersIndex.Add(i);
                    }
                    else
                        nonGroupLayersName.Add(dynamicService.Layers[i].Name);
                }
                nonGroupLayersName.Reverse();

                cmbActiveLayer.ItemsSource = nonGroupLayersName;

                cmbActiveLayer.SelectedIndex = 0;

                cmbActiveLayerSelectedValue = cmbActiveLayer.SelectedValue.ToString();


            }
        }

        private void ArcGISDynamicMapServiceLayer_InitializationFailed(EventArgs e)
        {
            MessageWindow win = new MessageWindow();
            win.messageTextBlock.Text = ApplicationStrings.msgMapInitFailed;
            win.Show();
        }

        private void IdentifyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = IdentifyComboBox.SelectedIndex;

            mapOp.IdentifySelectionChanged(index, IdentifyDetailsDataGrid);
        }

        private void IdentifyResult_Closed(object sender, Liquid.DialogEventArgs e)
        {
            mapClickMode = "pan";

            (Map1.Layers["gLayerIdentify"] as GraphicsLayer).ClearGraphics();
        }

        private void IdentifyGrid_Loaded(object sender, RoutedEventArgs e)
        {
            //IdentifyResult.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;

            //IdentifyResult.HorizontalOffset = 10;
        }



        private void Image_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            //logo.Opacity = 1;
        }

        private void logo_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            //logo.Opacity = 0.6;
        }

        private void GraphicsLayer_MouseLeftButtonUp(object sender, GraphicMouseButtonEventArgs e)
        {
            if (RibbonBar.remove == true)
            {
                MapOperations.gLayersSelection.Graphics.Remove(e.Graphic);

                //gLayersSelection.Graphics.RemoveAt(0);
                //foreach (Graphic item in gLayersSelection.Graphics)
                //{
                //    if (item.Geometry == feature.Geometry.Extent)
                //    {
                //        gLayersSelection.Graphics.Remove(item);
                //        break;
                //    }
                //}   
            }
        }

        public static string cmbActiveLayerSelectedValue;

        //public static FeatureLayer currentFeatureLayer;

        private void cmbActiveLayer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            buffer.txtActiveLayer.Text = "لایه فعال: " + cmbActiveLayer.SelectedValue.ToString();

            cmbActiveLayerSelectedValue = cmbActiveLayer.SelectedValue.ToString();

            if (Map1.Layers["Atlas"].Opacity < 1)
            {
                MapOperations.RemoveTransparencyFromMap();

                MapOperations.CreateFeatureService(AttachmentDialog.IsOpen);

                MapOperations.SetTransparencyToMap();
            }

            //currentFeatureLayer = new FeatureLayer();

            //currentFeatureLayer.ID = "currentFeatureLayer";

            //currentFeatureLayer.Url = @"http://91.98.96.231/ArcGIS/rest/services/Atlas0/FeatureServer/" + layersName2layersNumberDic[cmbActiveLayer.SelectedValue.ToString()];

            //currentFeatureLayer.AutoSave = false;

            //currentFeatureLayer.DisableClientCaching = true;

            //currentFeatureLayer.OutFields.Add("*");

            //currentFeatureLayer.Mode = FeatureLayer.QueryMode.OnDemand;

            //currentFeatureLayer.MouseLeftButtonUp += FeatureLayer_MouseLeftButtonUp;
        }

        private void GraphicsLayer_MouseLeftButtonUp_1(object sender, GraphicMouseButtonEventArgs e)
        {
            if (RibbonBar.erase == true)
            {
                GraphicsLayer graphic = Map1.Layers["gLayerDraw"] as GraphicsLayer;
                try
                {
                    if (graphic.Graphics != null)
                    {
                        graphic.Graphics.Remove(e.Graphic);
                    }
                }
                catch (Exception)
                {

                }
            }
        }

        //private void TOC_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        //{
        //    TOCBorder.Opacity = 1;
        //}

        //private void TOC_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        //{
        //    TOCBorder.Opacity = 0.7;
        //}





        private void AttachmentDialog_MouseEnter(object sender, MouseEventArgs e)
        {
            AttachmentDialog.Opacity = 1;
        }

        private void AttachmentDialog_MouseLeave(object sender, MouseEventArgs e)
        {
            AttachmentDialog.Opacity = 0.7;
        }

        private void AttachmentDialog_Closed(object sender, Liquid.DialogEventArgs e)
        {
            MapOperations.RemoveTransparencyFromMap();

            MapControl.mapClickMode = "pan";
        }

        private void AttachmentDialog_Opened(object sender, Liquid.DialogEventArgs e)
        {
            MapOperations.CreateFeatureService(true);

            MapOperations.SetTransparencyToMap();

            //Map1.Layers.Add(MapOperations.currentFeatureLayer);

            //Map1.Layers["Atlas"].Opacity = 0.5;

            MapControl.mapClickMode = "attachment";
        }

        private void MyAttachmentEditor_UploadFailed(object sender, ESRI.ArcGIS.Client.Toolkit.AttachmentEditor.UploadFailedEventArgs e)
        {
            MessageWindow win = new MessageWindow();
            win.messageTextBlock.Text = e.Result.Message;
            win.Show();
        }

        public static ESRI.ArcGIS.Client.Toolkit.AttachmentEditor attEditor;


        private void Expander_Expanded(object sender, RoutedEventArgs e)
        {
            foreach (Expander item in expanderStack.Children.OfType<Expander>())
            {
                if (item.Name != ((Expander)sender).Name)
                    item.IsExpanded = false;
            }
        }

        private void MyLegend_Refreshed(object sender, ESRI.ArcGIS.Client.Toolkit.Legend.RefreshedEventArgs e)
        {
            if (e.LayerItem.LayerItems != null)
            {
                foreach (LayerItemViewModel layerItemVM in e.LayerItem.LayerItems)
                {
                    if (layerItemVM.IsExpanded)
                        layerItemVM.IsExpanded = false;

                    if (layerItemVM.LayerItems != null)
                        foreach (LayerItemViewModel sublayerItemVM in layerItemVM.LayerItems)
                            if (sublayerItemVM.IsExpanded)
                                sublayerItemVM.IsExpanded = false;
                }
            }
            else
            {
                e.LayerItem.IsExpanded = false;
            }
        }

        private void MyRasterLegend_Refreshed(object sender, ESRI.ArcGIS.Client.Toolkit.Legend.RefreshedEventArgs e)
        {
            // remove useless street map sublayers
            if (e.LayerItem.Layer is ArcGISTiledMapServiceLayer)
                e.LayerItem.LayerItems = null;

            if (e.LayerItem.IsExpanded)
                e.LayerItem.IsExpanded = false;

            if (e.LayerItem.LayerItems != null)
            {
                foreach (LayerItemViewModel layerItemVM in e.LayerItem.LayerItems)
                {
                    if (layerItemVM.IsExpanded)
                        layerItemVM.IsExpanded = false;

                    if (layerItemVM.LayerItems != null)
                        foreach (LayerItemViewModel sublayerItemVM in layerItemVM.LayerItems)
                            if (sublayerItemVM.IsExpanded)
                                sublayerItemVM.IsExpanded = false;
                }
            }
            else
            {
                e.LayerItem.IsExpanded = false;
            }
        }

        private void BufferDialog_Closed(object sender, Liquid.DialogEventArgs e)
        {
            MapControl.mapClickMode = "pan";

            GraphicsLayer graphicsLayer = Map1.Layers["gLayerBuffer"] as GraphicsLayer;
            graphicsLayer.ClearGraphics();
        }

        private void BufferDialog_Opened(object sender, Liquid.DialogEventArgs e)
        {
            MapControl.mapClickMode = "buffer";
        }

        private void MyLegend_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
        }

        private void MyLegend_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
        }

        private void MyLegend_MouseLeave(object sender, MouseEventArgs e)
        {
            if (MapOperations.printObject != null)
            {
                var esriMap = VisualElementHelper.FindMapName<ESRI.ArcGIS.Client.Map>("PrintMap", MapOperations.printObject);

                //((PrintingUserControl)MapOperations.printObject).mapPrinterWithDialog.Map = Map1;

                //foreach (var item in esriMap.Layers)
                //{
                //    if (item.GetType() == typeof(ArcGISDynamicMapServiceLayer))
                //    {
                //        if (item.ID == "Atlas")
                //        {
                //            ((ArcGISDynamicMapServiceLayer)item).VisibleLayers = ((ArcGISDynamicMapServiceLayer)esriMap.Layers[item.ID]).VisibleLayers;

                //            ((ArcGISDynamicMapServiceLayer)item).Refresh();
                //        }
                        
                //    }
                //}

                esriMap = new Map();


                //= this.Map1

                //ESRI.ArcGIS.Client.Map

                //ESRI.ArcGIS.Client.Toolkit.Legend
            }
        }

        //private void TOCLoaded(object sender, EventArgs e)
        //{
        //    TOC.Expand();
        //}
    }
}
