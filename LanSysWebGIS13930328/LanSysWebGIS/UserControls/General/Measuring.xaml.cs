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
using ESRI.ArcGIS.Client.Symbols;
using ESRI.ArcGIS.Client;
using LanSysWebGIS.Models;
using DevExpress.Xpf.Bars;

namespace LanSysWebGIS.UserControls
{
    public partial class Measuring : UserControl
    {
        bool isOpen = true;

        public static bool MeasureDistance = true;

        public static bool MeasureArea = true;

        public static bool MeasureFreehand = false;

        public static Map map1;

        public Measuring()
        {
            InitializeComponent();

            //RibbonBar.measuringControl = MeasuringDialog;

            MapOperations.txtLastLength = this.TextLengthResult;

            MapOperations.txtTotalLength = this.TextAreaResult;
        }

        public static Symbol activeSymbol = null;

        public static double length = 0;

        private void RadioMeasureLength_Checked(object sender, RoutedEventArgs e)
        {
            length = 0;

            TextLengthTitle.Text = "طول آخرین قطعه(متر)";
            TextAreaTitle.Text = "طول کل(متر)";

            TextLengthResult.Text = "";
            TextAreaResult.Text = "";

            activeSymbol = new SimpleLineSymbol();
            ((SimpleLineSymbol)activeSymbol).Color = new SolidColorBrush(Colors.Orange);
            ((SimpleLineSymbol)activeSymbol).Width = 2;

            MapControl.MyMeasSurface.IsEnabled = true;

            MeasureDistance = true;

            MeasureArea = false;

            if (!(bool)CheckMeasureFreehand.IsChecked)
            {
                MapControl.MyMeasSurface.DrawMode = DrawMode.Polyline;
            }
            else
            {
                MapControl.MyMeasSurface.DrawMode = DrawMode.Freehand;
            }
            
        }

        private void RadioMeasureArea_Checked(object sender, RoutedEventArgs e)
        {
            length = 0;

            TextLengthTitle.Text = "محیط(متر)";
            TextAreaTitle.Text = "مساحت(متر مربع)";

            TextLengthResult.Text = "";
            TextAreaResult.Text = "";

            activeSymbol = new SimpleFillSymbol();
            ((SimpleFillSymbol)activeSymbol).BorderBrush = new SolidColorBrush(Colors.Orange);
            ((SimpleFillSymbol)activeSymbol).Fill = new SolidColorBrush(Color.FromArgb(0xAA, 0xFF, 0xE7, 0x5F));
            ((SimpleFillSymbol)activeSymbol).BorderThickness = 2;

            MapControl.MyMeasSurface.IsEnabled = true;

            MeasureArea = true;

            MeasureDistance = false;

            if (!(bool)CheckMeasureFreehand.IsChecked)
            {
                MapControl.MyMeasSurface.DrawMode = DrawMode.Polygon;
            }
            else
            {
                MapControl.MyMeasSurface.DrawMode = DrawMode.Freehand;
            }
            
        }

        public static BarCheckItem bMeasure;

        private void CheckMeasureFreehand_Checked(object sender, RoutedEventArgs e)
        {
            MapControl.MyMeasSurface.DrawMode = DrawMode.Freehand;

            MeasureFreehand = true;  
        }

        private void CheckMeasureFreehand_Unchecked(object sender, RoutedEventArgs e)
        {
            if (MeasureArea)
            {
                MapControl.MyMeasSurface.DrawMode = DrawMode.Polygon;
            }
            else if (MeasureDistance)
            {
                MapControl.MyMeasSurface.DrawMode = DrawMode.Polyline;
            }

            MeasureFreehand = false;
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            MeasureArea = false;

            MeasureDistance = false;

            MeasureFreehand = false;

            MapControl.MyMeasSurface.IsEnabled = false;

            (map1.Layers["gLayerMeas"] as GraphicsLayer).ClearGraphics();

            bMeasure.IsChecked = false;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            RadioMeasureLength.IsChecked = false;

            RadioMeasureLength.IsChecked = true;
        }
    }
}
