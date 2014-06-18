using System;
using System.Net;
using System.ServiceModel.DomainServices.Client;
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
using DevExpress.Xpf.Bars;
using LanSysWebGIS.UserControls;
using ESRI.ArcGIS.Client.Symbols;
using ESRI.ArcGIS.Client.Tasks;
using System.Windows.Controls.Primitives;
using ESRI.ArcGIS.Client.Symbols;
using System.Text;
using ESRI.ArcGIS.Client.Geometry;
using ESRI.ArcGIS.Client;
using System.Linq;
using System.Collections.Generic;
using LanSysWebGIS.Web;
using SPSSilverlight.SPSUtilities;
using LanSysWebGIS.Models;
using ESRI.SilverlightViewer.Utility;
using ESRI.ArcGIS.Client.Toolkit;
using LanSysWebGIS.Views.UserManagement;
using LanSysWebGIS.Assets.Resources;
using LanSysWebGIS.Helpers;
using System.Collections.ObjectModel;

namespace LanSysWebGIS.Models
{
    public class MapOperations
    {
        private static ArcGISDynamicMapServiceLayer Atlas_Map;

        public static Map map1;

        public static ESRI.ArcGIS.Client.Toolkit.Bookmark bookmark;

        public static GraphicsLayer gLayersSelection;
        private static GraphicsLayer gLayerDraw;

        private static GraphicsLayer gLayerMeas;

        public static ComboBox IdentifyComboBox;

        public DataGrid identifyDataGrid;

        public static BarEditItem xCoor;

        public static BarEditItem yCoor;

        public static BarEditItem zone;

        public static LanSysWebGIS.Controls.BusyIndicator mainBusy;

        private bool mapIdentify = false;

        public static DependencyObject printObject;

        public MapOperations()
        {
            MapControl.geoService.LengthsCompleted += GeoService_LengthCompleted;

            MapControl.geoService.AreasAndLengthsCompleted += GeoService_AreasAndLengthCompleted;

            //geoService.Failed += Geoservice_Failed;

        }

        public static void fullExtent()
        {
            if (map1 == null)
                return;
            Atlas_Map = map1.Layers["Atlas"] as ArcGISDynamicMapServiceLayer;
            Envelope env = Atlas_Map.FullExtent;
            map1.ZoomTo(env);
        }

        public static void initialExtent()
        {
            if (map1 == null)
                return;
            Atlas_Map = map1.Layers["Atlas"] as ArcGISDynamicMapServiceLayer;
            Envelope env = Atlas_Map.InitialExtent;
            map1.ZoomTo(env);
        }

        public static void zoomToScale(double ribbonScale)
        {
            if (map1 == null)
                return;
            double scale = ribbonScale;
            map1.ZoomToResolution(CalculateResolution(scale));

        }

        private static double CalculateResolution(double scale)
        {
            double dpi = 96;
            //double mapunitInMeters = 111319.5;
            //double mapunitInMeters = 1;

            double mapunitInMeters = map1.SpatialReference.WKID == 4326 ? 111319.5 : 1;
            double newRes = scale / (dpi * 39.37 * mapunitInMeters);
            return newRes;
        }

        public static void zoomToXY(string x, string y)
        {
            ESRI.ArcGIS.Client.Geometry.MapPoint xyPoint;
            GraphicsLayer gLayer = map1.Layers["graphicsLayer"] as GraphicsLayer;
            gLayer.Graphics.Clear();

            try
            {
                double xDouble = Double.Parse(x);
                double yDouble = Double.Parse(y);

                xyPoint = new ESRI.ArcGIS.Client.Geometry.MapPoint(xDouble, yDouble, map1.SpatialReference);

                ESRI.ArcGIS.Client.Geometry.Envelope envelope =
                new ESRI.ArcGIS.Client.Geometry.Envelope(xDouble - 200, yDouble - 200, xDouble + 200, yDouble + 200);

                map1.ZoomTo(envelope.Expand(3));

                Graphic pointGraphic = new Graphic() { Geometry = xyPoint, Symbol = new SimpleMarkerSymbol() };

                gLayer.Graphics.Add(pointGraphic);
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorResources.ZoomToXYError);
            }

        }

        public static void panToXY(string x, string y)
        {
            ESRI.ArcGIS.Client.Geometry.MapPoint xyPoint;

            try
            {
                double xDouble = Double.Parse(x);
                double yDouble = Double.Parse(y);

                xyPoint = new ESRI.ArcGIS.Client.Geometry.MapPoint(xDouble, yDouble, map1.SpatialReference);

                map1.PanTo(xyPoint);
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorResources.ZoomToXYError);
            }

        }

        public static void ZoomIn()
        {
            map1.Zoom(2);
        }

        public static void ZoomOut()
        {
            map1.Zoom(0.5);
        }

        public static void ShowHideBookmark(bool vis)
        {
            if (vis)
                bookmark.Visibility = System.Windows.Visibility.Visible;
            else
                bookmark.Visibility = System.Windows.Visibility.Collapsed;
        }

        public static void ZoomToFeature()
        {
            if (gLayersSelection == null || gLayersSelection.Graphics.Count == 0)
            {
                throw new Exception(ErrorResources.ZoomToFeature);
            }

            Envelope env = new Envelope();

            foreach (Graphic graphic in gLayersSelection.Graphics)
            {
                if (graphic.Geometry is MapPoint)
                {
                    Envelope envPoint = new Envelope((graphic.Geometry as MapPoint).X - 2000, (graphic.Geometry as MapPoint).Y - 2000,
                        (graphic.Geometry as MapPoint).X + 2000, (graphic.Geometry as MapPoint).Y + 2000);

                    env = env.Union(envPoint);
                }
                else
                {
                    env = env.Union(graphic.Geometry.Extent);
                }
            }


            map1.ZoomTo(env);
        }

        private static ESRI.ArcGIS.Client.Projection.WebMercator webMercator = new ESRI.ArcGIS.Client.Projection.WebMercator();

        internal void ExtractCoor(ESRI.ArcGIS.Client.Geometry.MapPoint mapPoint)
        {
            if (map1.SpatialReference.WKID != 102100)
            {
                throw new Exception("سیستم مختصات را چک کنید");
            }

            string[] xyStrings = CoordinateTransformer.WGS84ToUTM(((MapPoint)webMercator.ToGeographic(mapPoint)).X,
                        ((MapPoint)webMercator.ToGeographic(mapPoint)).Y, 5);

            xCoor.EditValue = xyStrings[0];

            yCoor.EditValue = xyStrings[1];

            zone.EditValue = xyStrings[2];
        }

        #region Select Feature

        public void selectFeatures(MapPoint clickPoint, bool mapIdentify)
        {
            this.mapIdentify = mapIdentify;

            Atlas_Map = map1.Layers["Atlas"] as ArcGISDynamicMapServiceLayer;

            Atlas_Map.VisibleLayers = MapControl.dynamicService.VisibleLayers;

            ESRI.ArcGIS.Client.Tasks.IdentifyParameters identifyParams = new IdentifyParameters()
            {
                Geometry = clickPoint,
                MapExtent = map1.Extent,
                Width = (int)map1.ActualWidth,
                Height = (int)map1.ActualHeight,
                LayerOption = LayerOption.all,
                SpatialReference = map1.SpatialReference
            };
            //identifyParams.LayerIds.AddRange((Atlas_Map.VisibleLayers).ToList<int>());
            identifyParams.LayerIds.Add(MapControl.layersName2layersNumberDic[MapControl.cmbActiveLayerSelectedValue]);

            IdentifyTask identifyTask = new IdentifyTask(Atlas_Map.Url);
            identifyTask.ExecuteCompleted += selectFeatures_ExecuteCompleted;
            identifyTask.Failed += selectFeatures_Failed;
            identifyTask.ExecuteAsync(identifyParams);
        }

        private void selectFeatures_ExecuteCompleted(object sender, IdentifyEventArgs args)
        {
            gLayersSelection = map1.Layers["gLayersSelection"] as GraphicsLayer;

            if (RibbonBar.select)
            {
                gLayersSelection.ClearGraphics();
            }

            if (args.IdentifyResults != null && args.IdentifyResults.Count > 0)
            {
                foreach (IdentifyResult result in args.IdentifyResults)
                {
                    Graphic feature = result.Feature;

                    if (feature.Geometry is ESRI.ArcGIS.Client.Geometry.MapPoint)
                    {
                        SimpleMarkerSymbol sym = new SimpleMarkerSymbol();
                        sym.Color = new SolidColorBrush(Colors.Yellow);

                        feature.Symbol = sym;
                    }
                    else if (feature.Geometry is ESRI.ArcGIS.Client.Geometry.Polyline)
                    {
                        SimpleLineSymbol sym = new SimpleLineSymbol();
                        sym.Color = new SolidColorBrush(Colors.Yellow);
                        sym.Width = 2;

                        feature.Symbol = sym;
                    }
                    else if (feature.Geometry is ESRI.ArcGIS.Client.Geometry.Polygon)
                    {
                        SimpleFillSymbol sym = new SimpleFillSymbol();
                        sym.BorderBrush = new SolidColorBrush(Colors.Yellow);
                        sym.Fill = new SolidColorBrush(Color.FromArgb(0xC8, 0xFF, 0xFF, 0x99));
                        sym.BorderThickness = 2;

                        feature.Symbol = sym;
                    }

                    if (RibbonBar.select == true || RibbonBar.addToSelect == true)
                    {
                        gLayersSelection.Graphics.Add(feature);
                    }

                }
            }
        }

        private void selectFeatures_Failed(object sender, TaskFailedEventArgs e)
        {
            MessageWindow win = new MessageWindow();
            win.messageTextBlock.Text = ApplicationStrings.msgSelectFeatureFailed;
            win.Show();
        }

        #endregion

        #region Identify Feature

        public void identifyFeatures(ESRI.ArcGIS.Client.Geometry.Geometry clickPoint, bool mapIdentify)
        {
            this.mapIdentify = mapIdentify;

            Atlas_Map = map1.Layers["Atlas"] as ArcGISDynamicMapServiceLayer;

            Atlas_Map.VisibleLayers = MapControl.dynamicService.VisibleLayers;

            ESRI.ArcGIS.Client.Tasks.IdentifyParameters identifyParams = new IdentifyParameters()
            {
                Geometry = clickPoint,
                MapExtent = map1.Extent,
                Width = (int)map1.ActualWidth,
                Height = (int)map1.ActualHeight,
                LayerOption = LayerOption.all,
                SpatialReference = map1.SpatialReference
            };
            identifyParams.LayerIds.AddRange((Atlas_Map.VisibleLayers).ToList<int>());

            IdentifyTask identifyTask = new IdentifyTask(Atlas_Map.Url);
            identifyTask.ExecuteCompleted += identifyFeatures_ExecuteCompleted;
            identifyTask.Failed += identifyFeatures_Failed;
            identifyTask.ExecuteAsync(identifyParams);
        }

        private void identifyFeatures_ExecuteCompleted(object sender, IdentifyEventArgs args)
        {
            gLayersSelection = map1.Layers["gLayerIdentify"] as GraphicsLayer;
            gLayersSelection.ClearGraphics();

            if (args.IdentifyResults != null && args.IdentifyResults.Count > 0)
            {
                foreach (IdentifyResult result in args.IdentifyResults)
                {
                    Graphic feature = result.Feature;

                    if (feature.Geometry is ESRI.ArcGIS.Client.Geometry.MapPoint)
                    {
                        SimpleMarkerSymbol sym = new SimpleMarkerSymbol();
                        sym.Color = new SolidColorBrush(Colors.Yellow);

                        feature.Symbol = sym;
                    }
                    else if (feature.Geometry is ESRI.ArcGIS.Client.Geometry.Polyline)
                    {
                        SimpleLineSymbol sym = new SimpleLineSymbol();
                        sym.Color = new SolidColorBrush(Colors.Yellow);
                        sym.Width = 2;

                        feature.Symbol = sym;
                    }
                    else if (feature.Geometry is ESRI.ArcGIS.Client.Geometry.Polygon)
                    {
                        SimpleFillSymbol sym = new SimpleFillSymbol();
                        sym.BorderBrush = new SolidColorBrush(Colors.Yellow);
                        sym.Fill = new SolidColorBrush(Color.FromArgb(0xC8, 0xFF, 0xFF, 0x99));
                        sym.BorderThickness = 2;

                        feature.Symbol = sym;
                    }
                    gLayersSelection.Graphics.Add(feature);
                }
                ShowIdentifyResults(args.IdentifyResults);
            }
        }

        private void ShowIdentifyResults(List<IdentifyResult> results)
        {
            dataItems = new List<DataItem>();

            if (results != null && results.Count > 0)
            {
                IdentifyComboBox.Items.Clear();
                foreach (IdentifyResult result in results)
                {
                    Graphic feature = result.Feature;

                    //string symbol = "";
                    //if (feature.Geometry is ESRI.ArcGIS.Client.Geometry.MapPoint)
                    //{
                    //    feature.Symbol = new SimpleMarkerSymbol();
                    //}
                    //else if (feature.Geometry is ESRI.ArcGIS.Client.Geometry.Polygon)
                    //{
                    //    feature.Symbol = new SimpleFillSymbol();
                    //}

                    string title = result.Value.ToString() + " (" + result.LayerName + ")";
                    dataItems.Add(new DataItem()
                    {
                        Title = title,
                        Data = feature.Attributes,
                        featureGraphic = feature
                    });
                    IdentifyComboBox.Items.Add(title);
                }

                IdentifyComboBox.SelectedIndex = 0;
            }
        }

        public void IdentifySelectionChanged(int index, DataGrid IdentifyDetailsDataGrid)
        {
            gLayersSelection = map1.Layers["gLayerIdentify"] as GraphicsLayer;

            if (index > -1)
            {
                gLayersSelection = map1.Layers["gLayerIdentify"] as GraphicsLayer;
                gLayersSelection.ClearGraphics();
                IdentifyDetailsDataGrid.ItemsSource = dataItems[index].Data;

                identifyDataGrid = IdentifyDetailsDataGrid;

                dataItems[index].featureGraphic.Selected = true;
                gLayersSelection.Graphics.Add(dataItems[index].featureGraphic);
            }
        }

        private void identifyFeatures_Failed(object sender, TaskFailedEventArgs e)
        {
            MessageWindow win = new MessageWindow();
            win.messageTextBlock.Text = ApplicationStrings.msgSelectFeatureFailed;
            win.Show();
        }

        private List<DataItem> dataItems = null;

        public class DataItem
        {
            public string Title { get; set; }
            public IDictionary<string, object> Data { get; set; }
            public Graphic featureGraphic { get; set; }
        }

        #endregion

        #region Draw

        public static void MyDrawSurface_DrawComplete(object sender, ESRI.ArcGIS.Client.DrawEventArgs args)
        {
            gLayerDraw = map1.Layers["gLayerDraw"] as GraphicsLayer;

            Graphic drawingGraphic = new ESRI.ArcGIS.Client.Graphic()
            {
                Geometry = args.Geometry,
                Symbol = RibbonBar.activeSymbol
            };

            gLayerDraw.Graphics.Add(drawingGraphic);

            //MapControl.MyDrawSurface.IsEnabled = false;
        }

        public static void ClearAllDrawings()
        {
            try
            {
                //ClearGraphicsFromMap();
                gLayerDraw.Graphics.Clear();
            }
            catch (Exception e)
            {
                throw new Exception(ErrorResources.ClearDrawingError);
            }
        }
        #endregion

        #region Measuring

        //public static GeometryService geoService = new GeometryService(MapControl.GeometryServiceURL);

        public static void MyMeasSurface_DrawBegin(object sender, EventArgs args)
        {
            gLayerMeas = map1.Layers["gLayerMeas"] as GraphicsLayer;

            gLayerMeas.ClearGraphics();
        }

        public static void MyMeasSurface_DrawComplete(object sender, ESRI.ArcGIS.Client.DrawEventArgs args)
        {
            vertexNo = 0;

            gLayerMeas = map1.Layers["gLayerMeas"] as GraphicsLayer;

            Graphic drawingGraphic = new ESRI.ArcGIS.Client.Graphic()
            {
                Geometry = args.Geometry,
                Symbol = Measuring.activeSymbol
            };

            if (Measuring.MeasureFreehand && Measuring.MeasureArea)
            {
                drawingGraphic.Geometry = GeometryTool.FreehandToPolygon(args.Geometry as ESRI.ArcGIS.Client.Geometry.Polyline);
            }

            gLayerMeas.Graphics.Add(drawingGraphic);

            //MapControl.MyMeasSurface.IsEnabled = false;

            if (map1.SpatialReference.WKID == 4326)
            {
                GraphicCollection grCol = new GraphicCollection();

                Graphic gr = new Graphic()
                {
                    Geometry = webMercator.FromGeographic(gLayerMeas.Graphics[0].Geometry),
                };

                grCol.Add(gr);

                if (Measuring.MeasureDistance)
                {
                    MapControl.geoService.LengthsAsync(grCol, LinearUnit.Meter, true, null);

                    //RibbonBar.MeasureDistance = false;
                }
                else if (Measuring.MeasureArea)
                {
                    MapControl.geoService.AreasAndLengthsAsync(grCol, LinearUnit.Meter, LinearUnit.Meter, null);
                }
            }
            else
            {
                if (Measuring.MeasureDistance)
                {
                    MapControl.geoService.LengthsAsync(gLayerMeas.Graphics, LinearUnit.Meter, true, null);

                    //RibbonBar.MeasureDistance = false;
                }
                else if (Measuring.MeasureArea)
                {
                    MapControl.geoService.AreasAndLengthsAsync(gLayerMeas.Graphics, LinearUnit.Meter, LinearUnit.Meter, null);
                }
            }
        }

        public static TextBlock txtTotalLength;

        public static TextBlock txtLastLength;

        public static void GeoService_LengthCompleted(object sender, LengthsEventArgs args)
        {
            Measuring.length += args.Results[0];

            txtLastLength.Text = Math.Round(args.Results[0], 5).ToString();
            txtTotalLength.Text = Math.Round(Measuring.length, 5).ToString();
        }

        public static void GeoService_AreasAndLengthCompleted(object sender, AreasAndLengthsEventArgs args)
        {
            txtLastLength.Text = Math.Round(args.Results.Lengths[0], 5).ToString();

            double area = Math.Abs(args.Results.Areas[0]);
            txtTotalLength.Text = Math.Round(area, 5).ToString();
        }

        static int vertexNo = 0;

        public static void MyMeasSurface_VertexAdded(object sender, ESRI.ArcGIS.Client.VertexAddedEventArgs args)
        {
            vertexNo++;

            if (Measuring.MeasureFreehand == false && Measuring.MeasureArea == false && vertexNo > 1)
            {
                MapControl.MyMeasSurface.CompleteDraw();
            }
        }
        #endregion

        #region Query

        public List<ArcGISLayerInfo> layersInfo;
        private Dictionary<int, string> fieldNumber2fieldNameDictionary = new Dictionary<int, string>();
        public ListBox QueryFieldsListBox;
        public ListBox QueryFieldUniqueValuesListBox;
        public TextBox QueryWhereTextBox;
        public ComboBox QueryLayersComboBox;
        public TextBlock QueryStringLabel;
        public Button btnOperIs;
        public Button btnOperNot;
        public Button btnOperNULL;
        public Button btnOperLike;
        public GraphicsLayer gLayerQueryBuilder;
        public ESRI.ArcGIS.Client.Toolkit.FeatureDataGrid QueryBuilderFeatureDataGrid;
        public Button GetUniqueValuesButton;
        public ArcGISDynamicMapServiceLayer dynamicService;


        //public void LoadLayerInfo()
        //{
        //    for (int index = 0; index < dynamicService.Layers.Length; index++)
        //    {
        //        //query builder
        //        layersInfo.Add(new ArcGISLayerInfo(dynamicService.Url + "/" + index.ToString()));

        //        //
        //    }
        //}

        public void QueryLayersComboBox_SelectionChanged()
        {
            //if (QueryFieldsListBox.)
            //{
            //QueryFieldsListBox.ItemsSource = null;
            //}

            QueryFieldsListBox.Items.Clear();

            if (QueryFieldUniqueValuesListBox.ItemsSource != null)
            {
                QueryFieldUniqueValuesListBox.ItemsSource = null;
            }

            QueryWhereTextBox.Text = "";

            fieldNumber2fieldNameDictionary.Clear();

            if (layersInfo[MapControl.layersName2layersNumberDic[QueryLayersComboBox.SelectedValue.ToString()]].IsReady)
            {
                string fieldType = "";

                int counter = 0;
                foreach (ArcGISLayerField field in layersInfo[MapControl.layersName2layersNumberDic[QueryLayersComboBox.SelectedValue.ToString()]].Fields)
                {
                    fieldType = field.Type.Substring(13); // "esriFieldType".Length

                    if (!fieldType.Equals("Geometry"))
                    {
                        QueryFieldsListBox.Items.Add(new ListBoxItem() { Content = string.Format("{0} ({1})", field.Alias, fieldType), Tag = field, Height = 20 });
                        fieldNumber2fieldNameDictionary.Add(counter, field.Name);
                        counter++;
                    }
                    //if (!fieldType.Equals("Geometry") && !fieldType.Equals("Raster") && !fieldType.Equals("Blob"))
                    //{
                    //    QueryFieldsListBox.Items.Add(new ListBoxItem() { Content = string.Format("{0} ({1})", field.Alias, fieldType), Tag = field, Height = 20 });
                    //}
                }
            }

            QueryStringLabel.Text = "SELECT * FROM " + layersInfo[MapControl.layersName2layersNumberDic[QueryLayersComboBox.SelectedValue.ToString()]].LayerName + " WHERE:";
        }

        public void QueryFieldsListBox_MouseLeftButtonUp(bool doubleClick)
        {
            if (doubleClick)
            {
                ListBoxItem item = QueryFieldsListBox.SelectedItem as ListBoxItem;

                if (item != null && item.Tag != null)
                {
                    ArcGISLayerField queryField = item.Tag as ArcGISLayerField;
                    QueryWhereTextBox.Text = QueryWhereTextBox.Text.Insert(QueryWhereTextBox.SelectionStart, queryField.Name + " ");
                    QueryWhereTextBox.SelectionStart = QueryWhereTextBox.Text.Length;
                    QueryWhereTextBox.Focus();

                    EsriFieldType fieldType = (EsriFieldType)Enum.Parse(typeof(EsriFieldType), queryField.Type, false);
                    switch (fieldType)
                    {
                        case EsriFieldType.esriFieldTypeOID:
                        case EsriFieldType.esriFieldTypeGUID:
                        case EsriFieldType.esriFieldTypeGlobalID:
                        case EsriFieldType.esriFieldTypeSmallInteger:
                        case EsriFieldType.esriFieldTypeInteger:
                        case EsriFieldType.esriFieldTypeSingle:
                        case EsriFieldType.esriFieldTypeDouble:
                            btnOperIs.IsEnabled = false;
                            btnOperNot.IsEnabled = false;
                            btnOperNULL.IsEnabled = false;
                            btnOperLike.IsEnabled = false;
                            break;
                        default:
                            btnOperIs.IsEnabled = true;
                            btnOperNot.IsEnabled = true;
                            btnOperNULL.IsEnabled = true;
                            btnOperLike.IsEnabled = true;
                            break;
                    }
                }
            }
        }

        public void OperatorButton_Click(Button button)
        {
            string sqlText = QueryWhereTextBox.Text;

            ListBoxItem selected = QueryFieldsListBox.SelectedItem as ListBoxItem;

            if (button.Content.Equals("Like"))
            {
                QueryWhereTextBox.Text = sqlText.Insert(QueryWhereTextBox.SelectionStart, "LIKE '%[value]%' ");
            }
            else
            {
                QueryWhereTextBox.Text = sqlText.Insert(QueryWhereTextBox.SelectionStart, button.Content.ToString().ToUpper() + " ");
            }

            QueryWhereTextBox.SelectionStart = QueryWhereTextBox.Text.Length;
            QueryWhereTextBox.Focus();
        }

        public void SubmitQueryButton_Click()
        {
            if (gLayerQueryBuilder != null)
            {
                gLayerQueryBuilder.ClearGraphics();
            }

            string sWhere = QueryWhereTextBox.Text.Trim();

            string baseServiceUrl = MapControl.baseServiceUrl.EndsWith("//")
                                            ? MapControl.baseServiceUrl
                                            : MapControl.baseServiceUrl + "//";

            if (!string.IsNullOrEmpty(sWhere))
            {
                QueryTask QueryBuilderQueryTask = new QueryTask(baseServiceUrl + MapControl.layersName2layersNumberDic[QueryLayersComboBox.SelectedValue.ToString()]);
                QueryBuilderQueryTask.ExecuteCompleted += QueryBuilder_ExecuteCompleted;
                QueryBuilderQueryTask.Failed += QueryBuilder_Failed;

                Query queryBuilderQuery = new Query();
                queryBuilderQuery.ReturnGeometry = true;
                queryBuilderQuery.OutSpatialReference = map1.SpatialReference;
                queryBuilderQuery.OutFields.Add("*");
                queryBuilderQuery.Where = sWhere;

                QueryBuilderQueryTask.ExecuteAsync(queryBuilderQuery);
            }
        }

        private void QueryBuilder_ExecuteCompleted(object sender, ESRI.ArcGIS.Client.Tasks.QueryEventArgs args)
        {
            FeatureSet featureSet = args.FeatureSet;

            if (featureSet == null || featureSet.Features.Count < 1)
            {
                MessageWindow win = new MessageWindow();
                win.messageTextBlock.Text = ApplicationStrings.msgQueryBuilderNoFeatureFound;
                win.Show();

                return;
            }

            gLayerQueryBuilder = map1.Layers["gLayerQueryBuilder"] as GraphicsLayer;

            if (featureSet != null && featureSet.Features.Count > 0)
            {
                foreach (Graphic feature in featureSet.Features)
                {
                    if (feature.Geometry is ESRI.ArcGIS.Client.Geometry.MapPoint)
                    {
                        SimpleMarkerSymbol sym = new SimpleMarkerSymbol();
                        sym.Color = new SolidColorBrush(Colors.Yellow);

                        feature.Symbol = sym;
                    }
                    else if (feature.Geometry is ESRI.ArcGIS.Client.Geometry.Polyline)
                    {
                        SimpleLineSymbol sym = new SimpleLineSymbol();
                        sym.Color = new SolidColorBrush(Colors.Yellow);
                        sym.Width = 2;

                        feature.Symbol = sym;
                    }
                    else if (feature.Geometry is ESRI.ArcGIS.Client.Geometry.Polygon)
                    {
                        SimpleFillSymbol sym = new SimpleFillSymbol();
                        sym.BorderBrush = new SolidColorBrush(Colors.Yellow);
                        sym.Fill = new SolidColorBrush(Color.FromArgb(0xC8, 0xFF, 0xFF, 0x99));
                        sym.BorderThickness = 2;

                        feature.Symbol = sym;
                    }

                    gLayerQueryBuilder.Graphics.Add(feature);
                }
            }

            QueryBuilderFeatureDataGrid.GraphicsLayer = gLayerQueryBuilder;
            QueryBuilderFeatureDataGrid.Visibility = System.Windows.Visibility.Visible;
        }

        private void QueryBuilder_Failed(object sender, TaskFailedEventArgs args)
        {
            MessageWindow win = new MessageWindow();
            win.messageTextBlock.Text = ApplicationStrings.msgQueryFailed;
            win.Show();
        }

        public void ClearGraphicsQueryButton_Click()
        {
            if (gLayerQueryBuilder != null)
            {
                gLayerQueryBuilder.ClearGraphics();
            }

            QueryBuilderFeatureDataGrid.Visibility = System.Windows.Visibility.Collapsed;
        }

        public void GetUniqueValuesButton_Click()
        {
            string baseServiceUrl = MapControl.baseServiceUrl.EndsWith("//")
                                            ? MapControl.baseServiceUrl
                                            : MapControl.baseServiceUrl + "//";

            if (true)
            {
                QueryTask GetUniqueValuesQueryTask = new QueryTask(baseServiceUrl + MapControl.layersName2layersNumberDic[QueryLayersComboBox.SelectedValue.ToString()]);
                GetUniqueValuesQueryTask.ExecuteCompleted += GetUniqueValues_ExecuteCompleted;
                GetUniqueValuesQueryTask.Failed += GetUniqueValues_Failed;

                Query GetUniqueValuesQuery = new Query();
                GetUniqueValuesQuery.ReturnGeometry = false;
                GetUniqueValuesQuery.OutSpatialReference = map1.SpatialReference;
                GetUniqueValuesQuery.OutFields.Add(fieldNumber2fieldNameDictionary[QueryFieldsListBox.SelectedIndex]);
                GetUniqueValuesQuery.Where = "1=1";

                GetUniqueValuesQueryTask.ExecuteAsync(GetUniqueValuesQuery);
            }
        }

        private void GetUniqueValues_ExecuteCompleted(object sender, ESRI.ArcGIS.Client.Tasks.QueryEventArgs args)
        {
            List<string> distinctList = new List<string>();

            IList<Graphic> graphicList = args.FeatureSet.Features;

            if (args.FeatureSet == null || graphicList.Count < 1)
            {
                MessageWindow win = new MessageWindow();
                win.messageTextBlock.Text = ApplicationStrings.msgQueryHasNoOutput;
                win.Show();

                return;
            }

            if (args.FeatureSet != null && graphicList.Count > 0)
            {
                ListBoxItem selected = QueryFieldsListBox.SelectedItem as ListBoxItem;

                var s = (from g in graphicList
                         orderby g.Attributes[fieldNumber2fieldNameDictionary[QueryFieldsListBox.SelectedIndex]]
                         select g.Attributes[fieldNumber2fieldNameDictionary[QueryFieldsListBox.SelectedIndex]]).Distinct();

                if (selected.Content.ToString().Contains("String"))
                {
                    foreach (var value in s)
                    {
                        if (value != null)
                        {
                            distinctList.Add("'" + value.ToString() + "'");
                        }
                        else
                        {
                            distinctList.Add("NULL");
                        }
                    }
                }
                else
                {
                    foreach (var value in s)
                    {
                        if (value != null)
                        {
                            distinctList.Add(value.ToString());
                        }
                        else
                        {
                            distinctList.Add("NULL");
                        }
                    }
                }
                QueryFieldUniqueValuesListBox.ItemsSource = distinctList;

                GetUniqueValuesButton.IsEnabled = false;
            }
        }

        private void GetUniqueValues_Failed(object sender, TaskFailedEventArgs args)
        {
            MessageWindow win = new MessageWindow();
            win.messageTextBlock.Text = ApplicationStrings.msgQueryFailed;
            win.Show();
        }

        public void QueryFieldUniqueValuesListBox_MouseLeftButtonUp(bool doubleClick)
        {
            ListBoxItem selected = QueryFieldsListBox.SelectedItem as ListBoxItem;

            if (doubleClick)
            {
                if (QueryFieldUniqueValuesListBox.ItemsSource != null)
                {
                    if (selected.Content.ToString().Contains("String"))
                    {
                        QueryWhereTextBox.Text = QueryWhereTextBox.Text.Insert(QueryWhereTextBox.SelectionStart, QueryFieldUniqueValuesListBox.SelectedItem.ToString() + " ");
                    }
                    else
                    {
                        QueryWhereTextBox.Text = QueryWhereTextBox.Text.Insert(QueryWhereTextBox.SelectionStart, QueryFieldUniqueValuesListBox.SelectedItem.ToString() + " ");
                    }
                    QueryWhereTextBox.SelectionStart = QueryWhereTextBox.Text.Length;
                    QueryWhereTextBox.Focus();
                }
            }
        }

        public void QueryBuilderDialog_Opened()
        {
            if (QueryLayersComboBox.SelectedIndex > -1)
            {
                QueryStringLabel.Text = "SELECT * FROM " + layersInfo[MapControl.layersName2layersNumberDic[QueryLayersComboBox.SelectedValue.ToString()]].LayerName + " WHERE:";
            }
            else
            {
                QueryStringLabel.Text = "SELECT * FROM ... WHERE:";
            }
        }

        #endregion

        #region General

        public static void ClearGraphicsFromMap()
        {
            foreach (GraphicsLayer graphic in map1.Layers.OfType<GraphicsLayer>())
            {
                if (graphic.GetType() != typeof(FeatureLayer))
                {
                    graphic.ClearGraphics();
                }
            }
        }

        public static FeatureLayer currentFeatureLayer;

        public static AttachmentEditor MyAttachmentEditor;

        public static void CreateFeatureService(bool isForAttachment)
        {
            currentFeatureLayer = new FeatureLayer();

            currentFeatureLayer.ID = "currentFeatureLayer";

            string mapURL = (map1.Layers["Atlas"] as ArcGISDynamicMapServiceLayer).Url.EndsWith("/") ? (map1.Layers["Atlas"] as ArcGISDynamicMapServiceLayer).Url : (map1.Layers["Atlas"] as ArcGISDynamicMapServiceLayer).Url + "/";

            currentFeatureLayer.Url = mapURL + MapControl.layersName2layersNumberDic[MapControl.cmbActiveLayerSelectedValue.ToString()];

            currentFeatureLayer.AutoSave = false;

            currentFeatureLayer.DisableClientCaching = true;

            currentFeatureLayer.OutFields.Add("*");

            currentFeatureLayer.Mode = FeatureLayer.QueryMode.OnDemand;

            if (isForAttachment)
            {
                currentFeatureLayer.MouseLeftButtonUp += FeatureLayer_MouseLeftButtonUp;
            }
        }

        private static void FeatureLayer_MouseLeftButtonUp(object sender, GraphicMouseButtonEventArgs e)
        {
            FeatureLayer featureLayer = sender as FeatureLayer;

            for (int i = 0; i < featureLayer.SelectionCount; i++)
                featureLayer.SelectedGraphics.ToList()[i].UnSelect();

            e.Graphic.Select();

            MyAttachmentEditor.GraphicSource = e.Graphic;
        }

        public static string prevFeatureServiceURL = "";

        public static void SetTransparencyToMap()
        {
            if (currentFeatureLayer.Url != prevFeatureServiceURL)
            {
                RemoveTransparencyFromMap();
            }

            prevFeatureServiceURL = currentFeatureLayer.Url;

            //map1.Layers.Add(MapOperations.currentFeatureLayer);

            map1.Layers.Insert(5, MapOperations.currentFeatureLayer);

            map1.Layers["Atlas"].Opacity = 0.1;

            map1.Layers["GoogleMap"].Opacity = 0.1;
        }

        public static void RemoveTransparencyFromMap()
        {
            map1.Layers.Remove(MapOperations.currentFeatureLayer);

            map1.Layers["Atlas"].Opacity = 1;

            map1.Layers["GoogleMap"].Opacity = 1;
        }

        #endregion

        #region Search By Draw 0315

        public static void FindFeaturesIntersectingDraw(ESRI.ArcGIS.Client.Geometry.Geometry drawingGeom)
        {
            mainBusy.IsBusy = true;

            Atlas_Map = map1.Layers["Atlas"] as ArcGISDynamicMapServiceLayer;

            Atlas_Map.VisibleLayers = MapControl.dynamicService.VisibleLayers;

            ESRI.ArcGIS.Client.Tasks.IdentifyParameters identifyParams = new IdentifyParameters()
            {
                Geometry = drawingGeom,
                MapExtent = map1.Extent,
                Width = (int)map1.ActualWidth,
                Height = (int)map1.ActualHeight,
                LayerOption = LayerOption.all,
                SpatialReference = map1.SpatialReference
            };

            //GeoMapsDBDomainContext context = new GeoMapsDBDomainContext();

            //context.Load(context.GetLayersWithDocQuery(), LoadBehavior.RefreshCurrent,
            //                            callback =>
            //                            {
            //                                List<int> layerNums = new List<int>();

            //                                foreach (var layer in context.LayersWithDocs)
            //                                {
            //                                    layerNums.Add(MapControl.layersName2layersNumberDic[layer.LayerName]);
            //                                }


            //                                identifyParams.LayerIds.AddRange(layerNums);

            //                                IdentifyTask identifyTask = new IdentifyTask(Atlas_Map.Url);
            //                                identifyTask.ExecuteCompleted += FindFeaturesIntersectingDraw_ExecuteCompleted;
            //                                identifyTask.Failed += FindFeaturesIntersectingDraw_Failed;
            //                                identifyTask.ExecuteAsync(identifyParams);
            //                            }, null);
        }

        public static ObservableCollection<GraphicFeatureDetails> featureDetails = new ObservableCollection<GraphicFeatureDetails>();

        public static bool isAnyFeatureSelected = false;

        private static void FindFeaturesIntersectingDraw_ExecuteCompleted(object sender, IdentifyEventArgs args)
        {
            ClearAllDrawings();

            featureDetails.Clear();

            gLayersSelection = map1.Layers["gLayerIdentify"] as GraphicsLayer;
            gLayersSelection.ClearGraphics();

            if (args.IdentifyResults != null && args.IdentifyResults.Count > 0)
            {
                isAnyFeatureSelected = true;

                foreach (IdentifyResult result in args.IdentifyResults)
                {
                    Graphic feature = result.Feature;

                    if (feature.Geometry is ESRI.ArcGIS.Client.Geometry.MapPoint)
                    {
                        SimpleMarkerSymbol sym = new SimpleMarkerSymbol();
                        sym.Color = new SolidColorBrush(Colors.Red);

                        feature.Symbol = sym;
                    }
                    else if (feature.Geometry is ESRI.ArcGIS.Client.Geometry.Polyline)
                    {
                        SimpleLineSymbol sym = new SimpleLineSymbol();
                        sym.Color = new SolidColorBrush(Colors.Yellow);
                        sym.Width = 2;

                        feature.Symbol = sym;
                    }
                    else if (feature.Geometry is ESRI.ArcGIS.Client.Geometry.Polygon)
                    {
                        SimpleFillSymbol sym = new SimpleFillSymbol();
                        sym.BorderBrush = new SolidColorBrush(Colors.Blue);
                        sym.Fill = new SolidColorBrush(Color.FromArgb(159, 192, 210, 238));
                        sym.BorderThickness = 2;

                        feature.Symbol = sym;
                    }
                    gLayersSelection.Graphics.Add(feature);

                    GraphicFeatureDetails gfd = new GraphicFeatureDetails();

                    gfd.LayerName = result.LayerName;

                    try
                    {
                        gfd.ObjectCode = result.Feature.Attributes["ObjCode"].ToString();
                    }
                    catch (Exception)
                    {
                        gfd.ObjectCode = "";
                    }

                    try
                    {
                        gfd.ObjectName = result.Feature.Attributes["ObjectName"].ToString();
                    }
                    catch (Exception)
                    {
                        gfd.ObjectName = "";
                    }

                    featureDetails.Add(gfd);
                }
            }
            else
            {
                isAnyFeatureSelected = false;
            }

            MapControl.MyDrawSurface.DrawComplete -= RibbonBar.MySearchDrawSurfaceOnDrawComplete;

            MapControl.MyDrawSurface.IsEnabled = false;

            mainBusy.IsBusy = false;
        }

        private static void FindFeaturesIntersectingDraw_Failed(object sender, TaskFailedEventArgs e)
        {
            ClearAllDrawings();

            mainBusy.IsBusy = false;

            MessageWindow win = new MessageWindow();
            win.messageTextBlock.Text = ApplicationStrings.msgSelectFeatureFailed;
            win.Show();
        }

        #endregion
    }
}
