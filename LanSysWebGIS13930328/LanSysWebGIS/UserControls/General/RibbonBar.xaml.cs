using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Windows.Input;
using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Ribbon;
using DevExpress.Xpf.Editors.Settings;
using DevExpress.Xpf.Core;
using DevExpress.Utils;
using ESRI.SilverlightViewer.Utility;
using LanSysWebGIS.UserControls;
using LanSysWebGIS.Models;
using ESRI.ArcGIS.Client;
using DevExpress.Xpf.Editors;
using DevExpress.Data;
using ESRI.ArcGIS.Client.Symbols;
using System.Windows.Browser;
using LanSysWebGIS.UserControls.Banader.Hydrography;
using Vishcious.ArcGIS.SLContrib;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Media;
using LanSysWebGIS.Views.UserManagement;
using LanSysWebGIS.Web;
using LanSysWebGIS.Assets.Resources;
using ESRI.ArcGIS.Client.Projection;
using ESRI.ArcGIS.Client.Geometry;
using LanSysWebGIS.UserControls.GeoMaps;
using LanSysWebGIS.Helpers;
using LanSysWebGIS.UserControls.Banader;

namespace LanSysWebGIS.UserControls
{
    public partial class RibbonBar : UserControl
    {

        #region Fields and Properties

        //GeoMaps

        public static int selectedIndex = 0;

        public static string clipString = "";

        public static DataGrid geoMapsDatagrid;

        //\GeoMaps

        public static Map map;

        public static ArcGISDynamicMapServiceLayer AtlasAnot;

        public static double ribbonScale;

        public static bool bookmarkVisibility;

        public static bool mapIdentify = false;

        public static bool MeasureDistance = false;

        public static bool MeasureArea = false;

        //public static Liquid.Dialog IdentifyResult = new Liquid.Dialog();

        public static Liquid.Dialog QueryBuilderDialog;

        public static Liquid.Dialog RasterDialog;

        public static Liquid.Dialog AttachmentDialog;

        //public static Liquid.Dialog PrintDialog;

        public static Liquid.Dialog BufferDialog;

        public static Liquid.Dialog aboutUs;

        public static Liquid.Dialog uploadDataDialog;

        public static SearchPanel searchPanel;

        //public static Liquid.Dialog dataFormDialog;

        //public static Liquid.Dialog reportDialog;

        //public static ChildWin childReport;

        public static GraphicsLayer gLayerSelection;

        //public MapControl mapcontrol
        //{
        //    get
        //    {
        //        return DataContext as MapControl;
        //    }
        //}

        #endregion

        public RibbonBar()
        {
            InitializeComponent();

            bookmarkVisibility = true;

            RibbonControl.ShowApplicationButton = false;

            RibbonControl.RibbonTitleBarVisibility = RibbonTitleBarVisibility.Collapsed;

            MapControl.nextView = bNextView;

            MapControl.prevView = bPreviousView;

            //MapControl.bSearchMap = this.bSearchMap;

            MapOperations.xCoor = eGotoX;

            MapOperations.yCoor = eGotoY;

            MapOperations.zone = eGotoZone;

            Measuring.bMeasure = this.bMeasure;

            searchPanel = new SearchPanel();

            geoChild.childWinStack.Children.Add(searchPanel);

            RibbonControl.SelectedPageChanged += RibbonControlOnSelectedPageChanged;

            //rpGeoMaps.MouseLeftButtonDown += RpGeoMapsOnMouseLeftButtonUp;
        }

        private bool isGeoMapsChecked = true;

        private void RibbonControlOnSelectedPageChanged(object sender, RibbonPropertyChangedEventArgs ribbonPropertyChangedEventArgs)
        {
            if (RibbonControl.SelectedPage == rpGeoMaps && isGeoMapsChecked)
            {
                cGeoClipped.IsChecked = true;

                isGeoMapsChecked = false;
            }

        }


        private void bFullExtent_ItemClick(object sender, ItemClickEventArgs e)
        {
            MapOperations.fullExtent();
        }

        private void bInitialExtent_ItemClick(object sender, ItemClickEventArgs e)
        {
            MapOperations.initialExtent();
        }

        private void bAbout_ItemClick(object sender, ItemClickEventArgs e)
        {
            //GenerateChildWin<Banader.ArchiveSearch>("جستجوی اسناد و اطلاعات", 0, "archiveSearchChild");

            GenerateChildWin<MainCategory>("آرشیو مستندات", 0, "archiveView");
        }

        private void eRibbonStyle_EditValueChanged(object sender, RoutedEventArgs e)
        {
            if (RibbonControl != null)
                RibbonControl.RibbonStyle = (RibbonStyle)this.eRibbonStyle.EditValue;
        }

        void OptionsButton_Click(object sender, RoutedEventArgs e)
        {
            (RibbonControl.ApplicationMenu as ApplicationMenuInfo).ClosePopup();
        }
        void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            (RibbonControl.ApplicationMenu as ApplicationMenuInfo).ClosePopup();
        }

        #region #Gallery
        protected virtual void OnThemeDropDownGalleryInit(object sender, DropDownGalleryEventArgs e)
        {
            Gallery gallery = e.DropDownGallery.Gallery;
            gallery.AllowHoverImages = false;
            gallery.IsItemCaptionVisible = true;
            //gallery.ItemGlyphLocation = Dock.Top;
            gallery.IsGroupCaptionVisible = DefaultBoolean.True;
        }

        protected virtual void OnThemeItemClick(object sender, GalleryItemEventArgs e)
        {
            string themeName = (string)e.Item.Tag;
            ThemeManager.ApplicationThemeName = themeName;
        }
        #endregion #Gallery

        private void eMapScale_EditValueChanged(object sender, RoutedEventArgs e)
        {
            ribbonScale = double.Parse(((DevExpress.Xpf.Editors.ComboBoxEditItem)eMapScale.EditValue).Tag.ToString());

            //ribbonScale = eMapScale.EditValue.ToString();

            MapOperations.zoomToScale(ribbonScale);
        }

        private void bGoto_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (eGotoX.EditValue == null || eGotoY.EditValue == null || eGotoZone == null)
            {
                throw new Exception(ErrorResources.GoToXYError);
            }

            string[] latlonStrings;

            string zone = string.Empty;

            bool isNorth = true;

            foreach (char c in eGotoZone.EditValue.ToString())
            {
                if (Char.IsDigit(c))
                {
                    zone += c;
                }
                else
                {
                    if (c == 'N')
                    {
                        isNorth = true;
                    }
                    else if (c == 'S')
                    {
                        isNorth = false;
                    }
                    else
                    {
                        isNorth = true;
                    }
                }
            }

            if (zone == string.Empty)
            {
                MessageWindow win = new MessageWindow();
                win.messageTextBlock.Text = ErrorResources.ZoneIsNorthError;
                win.Show();
                return;
            }

            try
            {
                latlonStrings = Helpers.CoordinateTransformer.UTMToWGS84(double.Parse(eGotoX.EditValue.ToString()),
                                                                          double.Parse(eGotoY.EditValue.ToString()),
                                                                          int.Parse(zone),
                                                                          isNorth, 4);
            }
            catch (Exception)
            {
                MessageWindow win = new MessageWindow();
                win.messageTextBlock.Text = ErrorResources.InvalidInputCoor;
                win.Show();

                return;
            }

            WebMercator mercator = new WebMercator();

            MapPoint point = new MapPoint(double.Parse(latlonStrings[0]), double.Parse(latlonStrings[1]));

            if (map.SpatialReference.WKID == 102100)
            {
                MapPoint geom = (MapPoint)mercator.FromGeographic(point);

                MapOperations.zoomToXY(geom.X.ToString(), geom.Y.ToString());
            }
            else if (map.SpatialReference.WKID == 4326)
            {
                MapOperations.zoomToXY(point.X.ToString(), point.Y.ToString());
            }
            else
            {
                throw new Exception("سیستم مختصات را چک کنید");
            }
        }

        private void bAddToBookmark_ItemClick(object sender, ItemClickEventArgs e)
        {
            bookmarkVisibility = (bool)bAddToBookmark.IsChecked;
            MapOperations.ShowHideBookmark(bookmarkVisibility);
        }

        private void bZoomIn_ItemClick(object sender, ItemClickEventArgs e)
        {
            MapOperations.ZoomIn();
        }

        private void bZoomOut_ItemClick(object sender, ItemClickEventArgs e)
        {
            MapOperations.ZoomOut();
        }

        public static Expander identifyExpander;

        private void bIdentifyMap_ItemClick(object sender, ItemClickEventArgs e)
        {
            //MapControl.mapClickMode = MapControl.mapClickMode == "identify" ? "pan" : "identify";

            //if (MapControl.mapClickMode == "pan")
            //{
            //    bPan.IsChecked = true;
            //}

            MapOperations.ClearGraphicsFromMap();

            if ((bool)bIdentifyMap.IsChecked)
            {

                MapControl.mapClickMode = "identify";

                identifyExpander.IsExpanded = true;

                bEraseDraw.IsChecked = false;
                bDrawPoint.IsChecked = false;
                bDrawLine.IsChecked = false;
                bDrawPolygon.IsChecked = false;
                bPan.IsChecked = false;
                sbModes.IsChecked = false;
                bMeasure.IsChecked = false;
                bIdentifyImage.IsChecked = false;
            }

            //IdentifyResult.IsOpen = !IdentifyResult.IsOpen;

            //if (IdentifyResult.IsOpen)
            //{
            //    MapControl.mapClickMode = "identify";
            //}
            //else
            //{
            //    MapControl.mapClickMode = "select";
            //}
        }

        public static bool IsPrevClicked = false;

        private void bPreviousView_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MapControl.currentExtentIndex != 0)
            {
                MapControl.currentExtentIndex--;

                if (MapControl.currentExtentIndex == 0)
                {
                    bPreviousView.IsEnabled = false;
                }

                MapControl.newExtent = false;

                map.IsHitTestVisible = false;
                map.ZoomTo(MapControl.extentHistory[MapControl.currentExtentIndex]);

                bNextView.IsEnabled = true;
            }
        }

        public static bool isNextClicked = false;

        private void bNextView_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MapControl.currentExtentIndex < MapControl.extentHistory.Count - 1)
            {
                MapControl.currentExtentIndex++;

                if (MapControl.currentExtentIndex == (MapControl.extentHistory.Count - 1))
                {
                    bNextView.IsEnabled = false;
                }

                MapControl.newExtent = false;

                map.IsHitTestVisible = false;
                map.ZoomTo(MapControl.extentHistory[MapControl.currentExtentIndex]);
                bPreviousView.IsEnabled = true;
            }
        }

        private void bZoomToFeature_ItemClick(object sender, ItemClickEventArgs e)
        {
            MapOperations.ZoomToFeature();
        }

        public static Symbol activeSymbol = null;

        private void bDrawPoint_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            if (bDrawPoint.IsChecked == true)
            {
                MapControl.MyDrawSurface.DrawMode = DrawMode.Point;

                activeSymbol = new SimpleMarkerSymbol();
                ((SimpleMarkerSymbol)activeSymbol).Color = new SolidColorBrush(Colors.Yellow);

                erase = false;
                bEraseDraw.IsChecked = false;
                bDrawLine.IsChecked = false;
                bDrawPolygon.IsChecked = false;
                bPan.IsChecked = false;
                sbModes.IsChecked = false;
                bMeasure.IsChecked = false;
                bIdentifyImage.IsChecked = false;
                bIdentifyMap.IsChecked = false;
                MapControl.MyDrawSurface.IsEnabled = true;
            }
            else
            {
                MapControl.MyDrawSurface.IsEnabled = false;
            }
        }

        private void bDrawLine_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            if (bDrawLine.IsChecked == true)
            {
                MapControl.MyDrawSurface.DrawMode = DrawMode.Polyline;

                activeSymbol = new LineSymbol();
                ((LineSymbol)activeSymbol).Color = new SolidColorBrush(Colors.Yellow);
                ((LineSymbol)activeSymbol).Width = 2;

                erase = false;
                bEraseDraw.IsChecked = false;
                bDrawPoint.IsChecked = false;
                bDrawPolygon.IsChecked = false;
                bPan.IsChecked = false;
                sbModes.IsChecked = false;
                bMeasure.IsChecked = false;
                bIdentifyImage.IsChecked = false;
                bIdentifyMap.IsChecked = false;
                MapControl.MyDrawSurface.IsEnabled = true;
            }
            else
            {
                MapControl.MyDrawSurface.IsEnabled = false;
            }
        }

        private void bDrawPolygon_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            if (bDrawPolygon.IsChecked == true)
            {
                MapControl.MyDrawSurface.DrawMode = DrawMode.Polygon;

                activeSymbol = new SimpleFillSymbol();
                ((SimpleFillSymbol)activeSymbol).Fill = new SolidColorBrush(Color.FromArgb(0xC8, 0xFF, 0xFF, 0x99));
                ((SimpleFillSymbol)activeSymbol).BorderBrush = new SolidColorBrush(Colors.Yellow);
                ((SimpleFillSymbol)activeSymbol).BorderThickness = 2;

                erase = false;
                bEraseDraw.IsChecked = false;
                bDrawLine.IsChecked = false;
                bDrawPoint.IsChecked = false;
                bPan.IsChecked = false;
                sbModes.IsChecked = false;
                bMeasure.IsChecked = false;
                bIdentifyImage.IsChecked = false;
                bIdentifyMap.IsChecked = false;
                MapControl.MyDrawSurface.IsEnabled = true;
            }
            else
            {
                MapControl.MyDrawSurface.IsEnabled = false;
            }
        }

        public static bool erase = false;

        private void bEraseDraw_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            if (bEraseDraw.IsChecked == true)
            {
                MapControl.mapClickMode = "pan";
                erase = true;
                bDrawLine.IsChecked = false;
                bDrawPoint.IsChecked = false;
                bDrawPolygon.IsChecked = false;
                bPan.IsChecked = false;
                sbModes.IsChecked = false;
                bMeasure.IsChecked = false;
                bIdentifyImage.IsChecked = false;
                bIdentifyMap.IsChecked = false;
            }
            else
            {
                erase = false;
            }
        }

        private void bClearAll_ItemClick(object sender, ItemClickEventArgs e)
        {
            MapOperations.ClearAllDrawings();
        }

        //public static Liquid.Dialog measuringControl;

        private void bMeasure_ItemClick(object sender, ItemClickEventArgs e)
        {
            //measuringControl.IsOpen = !measuringControl.IsOpen;

            if ((bool)bMeasure.IsChecked)
            {
                GenerateChildWin<Measuring>("اندازه گیری", 0, "measureChild");
                bPan.IsChecked = false;
                sbModes.IsChecked = false;
                bDrawLine.IsChecked = false;
                bDrawPoint.IsChecked = false;
                bDrawPolygon.IsChecked = false;
                bEraseDraw.IsChecked = false;
                bIdentifyImage.IsChecked = false;
                bIdentifyMap.IsChecked = false;
            }
        }

        private void BarItemLink_Unloaded(object sender, RoutedEventArgs e)
        {

        }

        //Hamid Edit Raster Start
        private List<string> layerVis = new List<string>();

        public static ESRI.ArcGIS.Client.Toolkit.Legend leg;

        private void bBingMap_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (bBingMap.IsChecked == true)
            {
                foreach (string layerName in leg.LayerIDs)
                {
                    foreach (ArcGISDynamicMapServiceLayer layer in map.Layers.OfType<ArcGISDynamicMapServiceLayer>())
                    {
                        if (layer.ID == layerName && layerVis.Contains(layerName))
                        {
                            layer.Visible = true;
                        }
                    }
                }

                layerVis.Clear();
            }
            else
            {
                foreach (string layerName in leg.LayerIDs)
                {
                    foreach (ArcGISDynamicMapServiceLayer layer in map.Layers.OfType<ArcGISDynamicMapServiceLayer>())
                    {
                        if (layer.ID == layerName)
                        {
                            if (layer.Visible == true)
                            {
                                layerVis.Add(layer.ID);
                            }

                            layer.Visible = false;
                        }
                    }
                }
            }
        }

        //Hamid Edit Raster End

        private void bIdentifyImage_ItemClick(object sender, ItemClickEventArgs e)
        {
            if ((bool)bIdentifyImage.IsChecked)
            {
                bEraseDraw.IsChecked = false;
                bDrawPoint.IsChecked = false;
                bDrawLine.IsChecked = false;
                bDrawPolygon.IsChecked = false;
                bEraseDraw.IsChecked = false;
                bPan.IsChecked = false;
                sbModes.IsChecked = false;
                bMeasure.IsChecked = false;
                bIdentifyMap.IsChecked = false;

                MessageWindow win = new MessageWindow();
                win.messageTextBlock.Text = ApplicationStrings.msgNotAvailable;
                win.Show();
            }
        }

        private void bPrint_ItemClick(object sender, ItemClickEventArgs e)
        {
            //PrintDialog.IsOpen = !PrintDialog.IsOpen;    

            GenerateChildWin<PrintingUserControl>("پرینت", 315, "printChild");
        }

        #region Upload Maps

        private void bUploadData_ItemClick(object sender, ItemClickEventArgs e)
        {
            //uploadDataDialog.IsOpen = !uploadDataDialog.IsOpen;

            //GenerateChildWin<FileUpload>("آپلود داده", 330, "uploadChild");
        }

        private void bShowLayers_ItemClick(object sender, ItemClickEventArgs e)
        {
            MessageWindow win = new MessageWindow();

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;

            if (!(ofd.ShowDialog() ?? false))
                return;

            FileInfo shapeFile = null;
            FileInfo dbfFile = null;
            string fileName = "";
            int length = 0;
            foreach (FileInfo fi in ofd.Files)
            {
                if (fi.Extension.ToLower() == ".shp")
                {
                    shapeFile = fi;

                    fileName = shapeFile.Name;
                    length = fi.Name.Length - 4;
                    fileName = fileName.Substring(0, length);
                }
                if (fi.Extension.ToLower() == ".dbf")
                {
                    dbfFile = fi;
                }
            }

            ShapeFile shapeFileReader = new ShapeFile();
            if (shapeFile != null && dbfFile != null)
            {
                try
                {
                    shapeFileReader.Read(shapeFile, dbfFile);
                }
                catch (Exception e2)
                {
                    win.messageTextBlock.Text = ApplicationStrings.msgViewShp1;
                    win.Show();

                    return;
                }

            }
            else
            {
                win.messageTextBlock.Text = ApplicationStrings.msgViewShp2;
                win.Show();

                return;
            }

            GraphicsLayer graphicsLayer = new GraphicsLayer();
            map.Layers.Add(graphicsLayer);

            foreach (ShapeFileRecord record in shapeFileReader.Records)
            {
                Graphic graphic = record.ToGraphic();
                if (graphic != null)
                {
                    graphicsLayer.Graphics.Add(graphic);
                }

            }

            win.messageTextBlock.Text = ApplicationStrings.msgViewShp3;
            win.Show();

        }

        #endregion


        private void bSearchMap_ItemClick(object sender, ItemClickEventArgs e)
        {
            GenerateChildWin<QueryBuilder>("جستجوی لایه برداری", 0, "QueryBuilderChild");

            //QueryBuilderDialog.IsOpen = !QueryBuilderDialog.IsOpen;

            //if (bSearchMap.IsChecked == true)
            //{
            //    QueryBuilderDialog.IsOpen = true;
            //}
            //else if (bSearchMap.IsChecked == false)
            //{
            //    QueryBuilderDialog.IsOpen = false;
            //}
        }

        public static bool select;
        public static bool addToSelect;
        public static bool remove;

        private void bSelect_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (bSelect.IsChecked == true)
            {

                bAddToSelect.IsChecked = false;
                bRemoveFromSelect.IsChecked = false;
                sbModes.IsChecked = true;
                select = true;
                addToSelect = false;
                remove = false;
                MapControl.mapClickMode = "select";

                //MapOperations.CreateFeatureService(false);

                //MapOperations.SetTransparencyToMap();
            }
            else
            {
                if (MapControl.mapClickMode == "select")
                {
                    MapControl.mapClickMode = "pan";
                }

                select = false;
                if (!(bool)bSelect.IsChecked && !(bool)bAddToSelect.IsChecked && !(bool)bRemoveFromSelect.IsChecked)
                {
                    sbModes.IsChecked = false;
                }
            }
        }

        private void bAddToSelect_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (bAddToSelect.IsChecked == true)
            {

                bSelect.IsChecked = false;
                bRemoveFromSelect.IsChecked = false;
                sbModes.IsChecked = true;
                addToSelect = true;
                select = false;
                remove = false;
                MapControl.mapClickMode = "select";

                //MapOperations.CreateFeatureService(false);

                //MapOperations.SetTransparencyToMap();
            }
            else
            {
                MapControl.mapClickMode = "pan";
                addToSelect = false;
                if (!(bool)bSelect.IsChecked && !(bool)bAddToSelect.IsChecked && !(bool)bRemoveFromSelect.IsChecked)
                {
                    sbModes.IsChecked = false;
                }
            }
        }

        private void bRemoveFromSelect_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (bRemoveFromSelect.IsChecked == true)
            {
                bSelect.IsChecked = false;
                bAddToSelect.IsChecked = false;
                sbModes.IsChecked = true;
                remove = true;
                addToSelect = false;
                select = false;
                MapControl.mapClickMode = "select";

                //MapOperations.CreateFeatureService(false);

                //MapOperations.SetTransparencyToMap();
            }
            else
            {
                MapControl.mapClickMode = "pan";
                remove = false;
                if (!(bool)bSelect.IsChecked && !(bool)bAddToSelect.IsChecked && !(bool)bRemoveFromSelect.IsChecked)
                {
                    sbModes.IsChecked = false;
                }
            }
        }

        private void sbModes_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            if (!(bool)sbModes.IsChecked)
            {
                bSelect.IsChecked = false;
                bAddToSelect.IsChecked = false;
                bRemoveFromSelect.IsChecked = false;

                //MapOperations.RemoveTransparencyFromMap();
            }
            else if ((bool)sbModes.IsChecked)
            {
                bPan.IsChecked = false;
                bMeasure.IsChecked = false;
                bDrawLine.IsChecked = false;
                bDrawPoint.IsChecked = false;
                bDrawPolygon.IsChecked = false;
                bEraseDraw.IsChecked = false;
                bIdentifyImage.IsChecked = false;
                bIdentifyMap.IsChecked = false;

                if (!(bool)bSelect.IsChecked && !(bool)bAddToSelect.IsChecked && !(bool)bRemoveFromSelect.IsChecked)
                {
                    bSelect.IsChecked = true;
                }
            }
        }

        public static DataGrid entityDataGrid;

        private void bClearSelection_ItemClick(object sender, ItemClickEventArgs e)
        {
            //MapOperations.ClearGraphicsFromMap();
            //gLayerSelection.ClearGraphics();
            (map.Layers["gLayersSelection"] as GraphicsLayer).ClearGraphics();
            (map.Layers["gLayerIdentify"] as GraphicsLayer).ClearGraphics();

            try
            {
                MapControl.mapOp.ClearGraphicsQueryButton_Click();
            }
            catch (Exception)
            {

            }

            try
            {
                entityDataGrid.ItemsSource = null;
            }
            catch (Exception eeee)
            {

            }

            try
            {
                (map.Layers["XYGraphicsLayer"] as GraphicsLayer).ClearGraphics();
            }
            catch (Exception eeee)
            {

            }

            try
            {
                (map.Layers["LineGraphicsLayer"] as GraphicsLayer).ClearGraphics();
            }
            catch (Exception eeee)
            {

            }

            try
            {
                (map.Layers["PointGraphicsLayer"] as GraphicsLayer).ClearGraphics();
            }
            catch (Exception eeee)
            {

            }

            if (RibbonBar.map.Layers["ContourMapLayer"] != null)
            {
                RibbonBar.map.Layers.Remove(RibbonBar.map.Layers["ContourMapLayer"]);
            }
            if (RibbonBar.map.Layers["CutFillLayer"] != null)
            {
                RibbonBar.map.Layers.Remove(RibbonBar.map.Layers["CutFillLayer"]);
            }
            if (RibbonBar.map.Layers["AreaVolumeImageLayer"] != null)
            {
                RibbonBar.map.Layers.Remove(RibbonBar.map.Layers["AreaVolumeImageLayer"]);
            }

            MapOperations.isAnyFeatureSelected = false;
        }

        private void bPan_ItemClick(object sender, ItemClickEventArgs e)
        {
            if ((bool)bPan.IsChecked)
            {
                MapControl.mapClickMode = "pan";
                sbModes.IsChecked = false;
                bMeasure.IsChecked = false;
                bDrawLine.IsChecked = false;
                bDrawPoint.IsChecked = false;
                bDrawPolygon.IsChecked = false;
                bEraseDraw.IsChecked = false;
                bIdentifyImage.IsChecked = false;
                bIdentifyMap.IsChecked = false;
                remove = false;
                addToSelect = false;
                select = false;

                //measuringControl.IsOpen = !measuringControl.IsOpen;
                //Measuring.MeasureDistance = false;
                //Measuring.MeasureArea = false;
                //Measuring.MeasureFreehand = false;
                //MapControl.MyMeasSurface.IsEnabled = false;

                //(map.Layers["gLayerMeas"] as GraphicsLayer).ClearGraphics();
            }
        }

        private void bFullScreen_ItemClick(object sender, ItemClickEventArgs e)
        {
            //App.Current.Host.Content.IsFullScreen = !App.Current.Host.Content.IsFullScreen;
            //GenerateChildWin<Hydro.ArzyabiVaTashkisSalahiyat>("دستور العمل ارزیابی و تشخیص صلاحیت پیمانکاران لایروبی", 0, "ArzyabiVaTashkisSalahiyat");
            //GenerateChildWin<Hydro.IMO>("دستور العمل ارزیابی و تشخیص صلاحیت پیمانکاران لایروبی", 0, "IMO");
            Helpers.AccessLevelChecker.CheckAdmin();
            GenerateChildWin<Banader.EmployeesForm>("بانک اطلاعات کارکنان مهندسی سواحل و بنادر", 0, "EmployeeBank");
        }

        private void bProjectIdent_ItemClick(object sender, ItemClickEventArgs e)
        {
            Presenter.Hydro.ProjectIdentificationPresenter presenter =
                new Presenter.Hydro.ProjectIdentificationPresenter();

            GenerateChildWin<Hydro.ProjectIdentification>("شناسنامه پروژه", 0, "projectIdentification", presenter);
        }

        private void bPeymankarForm_ItemClick(object sender, ItemClickEventArgs e)
        {
            GenerateChildWin<Hydro.SalahiyatPeymankaran>("فرم صلاحیت پیمانکار", 0, "SalahiyatPeymankaran");
        }

        private void bGeoProcessingTools_ItemClick(object sender, ItemClickEventArgs e)
        {
            GenerateChildWin<HydrographyTools>("محاسبات هیدروگرافی", 0, "hyrotools");
        }

        private void bSearchImage_ItemClick(object sender, ItemClickEventArgs e)
        {
            RasterDialog.IsOpen = !RasterDialog.IsOpen;
        }

        private void bAttachment_ItemClick(object sender, ItemClickEventArgs e)
        {
            AttachmentDialog.IsOpen = !AttachmentDialog.IsOpen;
        }

        private void cShowLabels_ItemClick(object sender, ItemClickEventArgs e)
        {
            AtlasAnot.Visible = (bool)cShowLabels.IsChecked;
        }

        private void bBuffer_ItemClick(object sender, ItemClickEventArgs e)
        {
            BufferDialog.IsOpen = !BufferDialog.IsOpen;
        }

        private void bViewData_ItemClick(object sender, ItemClickEventArgs e)
        {
            //dataFormDialog.IsOpen = !dataFormDialog.IsOpen;

            //Helpers.AccessLevelChecker.CheckAuthentication(Constants.Administrator, Constants.Manager, Constants.Editor);

            //GenerateChildWin<DataFormViewEdit>("نمایش و ویرایش فرم ها", 0, "dataformChild");

            Helpers.AccessLevelChecker.CheckAuthentication(Constants.Administrator, Constants.ICOPMAS, Constants.ICZM, Constants.Monitoring);

            GenerateChildWin<ArchiveSearch>("جستجوی اسناد", 0, "archiveSearchChild");
        }

        private void bViewReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            //reportDialog.IsOpen = !reportDialog.IsOpen;

            Helpers.AccessLevelChecker.CheckAuthentication(Constants.Administrator, Constants.ICOPMAS, Constants.ICZM, Constants.Monitoring);

            GenerateChildWin<MainCategory>("مشاهده آرشیو اسناد", 0, "archiveViewChild");
        }

        private void bUserManagement_ItemClick(object sender, ItemClickEventArgs e)
        {
            Helpers.AccessLevelChecker.CheckAdmin();

            UserManagementWindow userManagementWindow = new UserManagementWindow();

            userManagementWindow.Show();
        }

        private void bChangePassword_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (WebContext.Current.User.IsAuthenticated)
            {
                ChangePasswordWindow win = new ChangePasswordWindow();

                win.Show();
            }
            else
            {
                throw new Exception(ErrorResources.ChangePassException);
            }
        }

        //GeoMaps
        private void bChangeUserInfo_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void bGeoMapName_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (eGeoDataType != null)
            {
                //if (((DevExpress.Xpf.Editors.ComboBoxEditItem)eGeoDataType.EditValue).Tag.ToString().Contains("&"))
                //{
                //    throw new Exception(GeoMapsStrings.SearchMapNameError);
                //}
                if (selectedIndex == 3)
                {
                    throw new Exception(GeoMapsStrings.SearchMapNameError);
                }
                else
                {
                    GenerateGeoMapsChildWin<SearchName>("جستجوی تصویر ماهواره ای بر اساس نام تصویر", 0, "GeoMapChild");
                }
            }
        }

        //private void bGeoMapNo_ItemClick(object sender, ItemClickEventArgs e)
        //{
        //    if (eGeoDataType != null)
        //    {
        //        //if (((DevExpress.Xpf.Editors.ComboBoxEditItem)eGeoDataType.EditValue).Tag.ToString().Contains("&"))
        //        //{
        //        //    throw new Exception(GeoMapsStrings.SearchMapNumberError);
        //        //}
        //        if (selectedIndex == 3)
        //        {
        //            throw new Exception(GeoMapsStrings.SearchMapNumberError);
        //        }
        //        else
        //        {
        //            GenerateGeoMapsChildWin<SearchMapNumber>("جستجوی نقشه زمین شناسی بر اساس شماره نقشه", 0, "GeoMapChild");
        //        }
        //    }
        //}

        private void bGeoMouseClick_ItemClick(object sender, ItemClickEventArgs e)
        {
            GenerateGeoMapsChildWin<SearchByClick>("جستجوی تصویر ماهواره ای بر اساس کلیک ماوس", 0, "GeoMapChild");
        }

        private void bGeoDrawing_ItemClick(object sender, ItemClickEventArgs e)
        {
            GenerateGeoMapsChildWin<SearchGraphics>("جستجوی تصویر ماهواره ای به صورت ترسیمی", 0, "GeoMapChild");
        }

        private void bGeoCoor_ItemClick(object sender, ItemClickEventArgs e)
        {
            GenerateGeoMapsChildWin<SearchCoordinate>("جستجوی تصویر ماهواره ای بر اساس مختصات", 0, "GeoMapChild");
        }

        private void bGeoCoorArea_ItemClick(object sender, ItemClickEventArgs e)
        {
            GenerateGeoMapsChildWin<SearchCoorArea>("جستجوی تصویر ماهواره ای بر اساس محدوده مختصاتی", 0, "GeoMapChild");
        }

        private void cShowIndex_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (cShowIndex != null && cShowIndex.IsChecked == true)
            {
                MapControl.indexService.Visible = true;
            }
            else if (cShowIndex != null && cShowIndex.IsChecked == false)
            {
                MapControl.indexService.Visible = false;
            }
        }

        private void bGeoCheckDataAvailability_ItemClick(object sender, ItemClickEventArgs e)
        {
            GenerateChildWin<DataAvailability>("چک کردن موجودی داده", 0, "DataAvailChild");
        }

        private void bGeoClearGraphics_ItemClick(object sender, ItemClickEventArgs e)
        {
            GeoMapsOperations.ClearAll();
        }

        private void cGeoClipped_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (cGeoClipped != null && cGeoClipped.IsChecked == true)
            {
                //todo change if(clipMode) by if(clipString.Contain) or ...
                //this.clipMode = true;

                geoMapsDatagrid.SelectionMode = DataGridSelectionMode.Extended;

                clipString = "Clipped";

                //todo create static services in MapControl or GeoMapsOperations
                //try
                //{
                //    georeferenced100kNIOCServiceClipped.VisibleLayers = new int[] { };
                //    //georeferenced1000kNIOCClippedService.VisibleLayers = new int[] { };
                //}
                //catch (Exception ex)
                //{
                //}

                //indexComboBox_SelectionChanged(this, schea);
                GeoMapsOperations.ChangeService(selectedIndex, clipString);
            }
            else if (cGeoClipped != null && cGeoClipped.IsChecked == false)
            {
                //todo change if(clipMode) by if(clipString.Contain) or ...
                //this.clipMode = false;
                geoMapsDatagrid.SelectionMode = DataGridSelectionMode.Single;


                clipString = "";
                //indexComboBox_SelectionChanged(this, schea);

                GeoMapsOperations.ChangeService(selectedIndex, clipString);
            }
        }
        //\GeoMaps

        //GeoMaps
        private void EGeoDataType_OnEditValueChanged(object sender, RoutedEventArgs e)
        {
            if (eGeoDataType != null)
            {
                if (((DevExpress.Xpf.Editors.ComboBoxEditItem)eGeoDataType.EditValue).Tag.ToString().Contains("&"))
                {
                    //todo for &
                    selectedIndex = 3;
                }
                else
                {
                    selectedIndex = int.Parse(((DevExpress.Xpf.Editors.ComboBoxEditItem)eGeoDataType.EditValue).Tag.ToString());

                    GeoMapsOperations.ChangeService(selectedIndex, clipString);
                }
            }
        }
        //\GeoMaps


        #region Search By Draw 0315

        static SolidColorBrush solidcolor = new SolidColorBrush(Colors.Yellow);

        static SolidColorBrush transparentcolor = new SolidColorBrush(Color.FromArgb(0xC8, 0xFF, 0xFF, 0x99));

        private void bSearchPoint_ItemClick(object sender, ItemClickEventArgs e)
        {
            MapControl.MyDrawSurface.DrawMode = DrawMode.Point;

            activeSymbol = new SimpleMarkerSymbol();
            ((SimpleMarkerSymbol)activeSymbol).Color = solidcolor;

            //erase = false;
            //bEraseDraw.IsChecked = false;
            //bDrawLine.IsChecked = false;
            //bDrawPolygon.IsChecked = false;
            //bPan.IsChecked = false;
            //sbModes.IsChecked = false;
            //bMeasure.IsChecked = false;
            //bIdentifyImage.IsChecked = false;
            //bIdentifyMap.IsChecked = false;
            MapControl.MyDrawSurface.IsEnabled = true;

            MapControl.MyDrawSurface.DrawComplete += MySearchDrawSurfaceOnDrawComplete;
        }

        public static void MySearchDrawSurfaceOnDrawComplete(object sender, DrawEventArgs drawEventArgs)
        {
            Graphic gr = new Graphic();

            if (searchDrawFreehand)
            {
                gr.Geometry = GeometryTool.FreehandToPolygon(drawEventArgs.Geometry as ESRI.ArcGIS.Client.Geometry.Polyline);
                activeSymbol = new SimpleFillSymbol();
                ((SimpleFillSymbol)activeSymbol).Fill = transparentcolor;
                ((SimpleFillSymbol)activeSymbol).BorderBrush = solidcolor;
                ((SimpleFillSymbol)activeSymbol).BorderThickness = 2;
                gr.Symbol = activeSymbol;

                GraphicsLayer gLayerIdentify = map.Layers["gLayerIdentify"] as GraphicsLayer;

                gLayerIdentify.Graphics.Add(gr);

                MapOperations.FindFeaturesIntersectingDraw(gr.Geometry);

                searchDrawFreehand = false;
            }
            else
            {
                MapOperations.FindFeaturesIntersectingDraw(drawEventArgs.Geometry);
            }

            MapControl.MyDrawSurface.DrawComplete -= MySearchDrawSurfaceOnDrawComplete;

            MapControl.MyDrawSurface.IsEnabled = false;
        }

        private void bSearchLine_ItemClick(object sender, ItemClickEventArgs e)
        {
            MapControl.MyDrawSurface.DrawMode = DrawMode.Polyline;

            activeSymbol = new LineSymbol();
            ((LineSymbol)activeSymbol).Color = solidcolor;
            ((LineSymbol)activeSymbol).Width = 2;

            MapControl.MyDrawSurface.IsEnabled = true;

            MapControl.MyDrawSurface.DrawComplete += MySearchDrawSurfaceOnDrawComplete;
        }

        private void bSearchFreeLine_ItemClick(object sender, ItemClickEventArgs e)
        {
            MapControl.MyDrawSurface.DrawMode = DrawMode.Freehand;

            activeSymbol = new LineSymbol();
            ((LineSymbol)activeSymbol).Color = solidcolor;
            ((LineSymbol)activeSymbol).Width = 2;

            MapControl.MyDrawSurface.IsEnabled = true;

            MapControl.MyDrawSurface.DrawComplete += MySearchDrawSurfaceOnDrawComplete;
        }

        private void bSearchRectangle_ItemClick(object sender, ItemClickEventArgs e)
        {
            MapControl.MyDrawSurface.DrawMode = DrawMode.Rectangle;

            activeSymbol = new SimpleFillSymbol();
            ((SimpleFillSymbol)activeSymbol).Fill = transparentcolor;
            ((SimpleFillSymbol)activeSymbol).BorderBrush = solidcolor;
            ((SimpleFillSymbol)activeSymbol).BorderThickness = 2;

            MapControl.MyDrawSurface.IsEnabled = true;

            MapControl.MyDrawSurface.DrawComplete += MySearchDrawSurfaceOnDrawComplete;
        }

        private void bSearchPolygon_ItemClick(object sender, ItemClickEventArgs e)
        {
            MapControl.MyDrawSurface.DrawMode = DrawMode.Polygon;

            activeSymbol = new SimpleFillSymbol();
            ((SimpleFillSymbol)activeSymbol).Fill = transparentcolor;
            ((SimpleFillSymbol)activeSymbol).BorderBrush = solidcolor;
            ((SimpleFillSymbol)activeSymbol).BorderThickness = 2;

            MapControl.MyDrawSurface.IsEnabled = true;

            MapControl.MyDrawSurface.DrawComplete += MySearchDrawSurfaceOnDrawComplete;
        }

        private static bool searchDrawFreehand = false;

        private void bSearchFreePoly_ItemClick(object sender, ItemClickEventArgs e)
        {

            searchDrawFreehand = true;
            MapControl.MyDrawSurface.DrawMode = DrawMode.Freehand;

            activeSymbol = new LineSymbol();
            ((LineSymbol)activeSymbol).Color = solidcolor;
            ((LineSymbol)activeSymbol).Width = 2;

            MapControl.MyDrawSurface.IsEnabled = true;

            MapControl.MyDrawSurface.DrawComplete += MySearchDrawSurfaceOnDrawComplete;
        }

        private void bViewDocsButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MapOperations.isAnyFeatureSelected)
            {
                GenerateChildWin<ShowFiles>(GeoMapsStrings.ShowRelatedDocuments, 0, "ShowFileChild");
            }
            else
            {
                MessageWindow win = new MessageWindow();
                win.messageTextBlock.Text = GeoMapsStrings.NoFeatureSelected;
                win.Show();
            }
        }

        #endregion

        public static void GenerateChildWin<T>(string title, int childWinWidth, string name, Notifier presenter = null)
            where T : UserControl
        {
            ChildWin child = new ChildWin();

            child.OKButton.Visibility = Visibility.Collapsed;

            child.CancelButton.Visibility = Visibility.Collapsed;

            if (childWinWidth != 0)
            {
                child.Width = childWinWidth;
            }

            child.Title = title;

            child.Name = name;

            child.ParentLayoutRoot = MainPage.layoutRoot;

            if (presenter != null)
            {
                var instance = Activator.CreateInstance(typeof(T), presenter);

                ((UserControl)instance).DataContext = presenter;

                child.childWinStack.Children.Add(instance as UIElement);
            }
            else
            {
                var instance = Activator.CreateInstance(typeof(T));

                child.childWinStack.Children.Add(instance as UIElement);
            }

            try
            {
                child.Show();
            }
            catch (Exception)
            {
                //
            }


        }

        public static ChildWin geoChild = new ChildWin();

        public static void GenerateGeoMapsChildWin<T>(string title, int childWinWidth, string name)
            where T : UserControl
        {
            var instance = Activator.CreateInstance(typeof(T));

            string[] splittedStrings = typeof(T).FullName.Split('.');

            GeoMapsOperations.searchMethod = splittedStrings[3];

            searchPanel.SearchTopPortion.Children.Clear();

            searchPanel.SearchTopPortion.Children.Add(instance as UIElement);

            geoChild.OKButton.Visibility = Visibility.Collapsed;

            geoChild.CancelButton.Visibility = Visibility.Collapsed;

            if (childWinWidth != 0)
            {
                geoChild.Width = childWinWidth;
            }

            geoChild.Title = title;

            //geoChild.Name = name;

            geoChild.ParentLayoutRoot = MapControl.layoutRoot;

            try
            {
                geoChild.Show();
            }
            catch (Exception)
            {

            }

        }

        private void bSelectLayers_ItemClick(object sender, ItemClickEventArgs e)
        {
            //GenerateChildWin<SelectLayers>("انتخاب لایه ها", 300,"selectLayerChild");
        }

        private void bIMO_ItemClick(object sender, ItemClickEventArgs e)
        {
            //GenerateChildWin<Hydro.IMO>("IMO", 0, "IMOChild");
        }

        private void bArzyabi_ItemClick(object sender, ItemClickEventArgs e)
        {
            GenerateChildWin<Hydro.ArzyabiVaTashkisSalahiyat>("دستور العمل ارزیابی و تشخیص صلاحیت پیمانکاران لایروبی", 0, "ArzyabiVaTashkisSalahiyat");
        }

        private void bArchiveReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            Helpers.AccessLevelChecker.CheckAdmin();

            GenerateChildWin<Banader.ReportDocFiles>("گزارش عملکرد آرشیو", 0, "ArchiveReport");
        }
    }

    public class RecentItem
    {
        public int Number { get; set; }
        public string FileName { get; set; }
    }

    public class ButtonWithImageContent
    {
        public string ImageSource { get; set; }
        public object Content { get; set; }
    }
}
