using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Printing;
using LanSysWebGIS.Views.UserManagement;

namespace LanSysWebGIS.UserControls
{
    public partial class Report : UserControl
    {
        private Dictionary<string, string> chartTypes = new Dictionary<string, string>();

        private Dictionary<string, string> reportTypes = new Dictionary<string, string>();

        public Report()
        {
            InitializeComponent();

            #region reportTypes


            reportTypes.Add("آمار جمعیت کل بر اساس نوع اقامت", "GetVwJamiat_Eghamat" + "Query");
            reportTypes.Add("آمار جمعیت بر اساس جنسیت", "GetVwJamiat_Jensiat" + "Query");
            reportTypes.Add("آمار جمعیت کل بر اساس محل کار یا تحصیل", "GetVwJamiat_MahaleKarYaTahsil" + "Query");
            reportTypes.Add("آمار جمعیت کل بر اساس محل تولد", "GetVwJamiat_MahaleTavalod" + "Query");
            reportTypes.Add("آمار جمعیت بر اساس سواد", "GetVwJamiat_savad" + "Query");
            reportTypes.Add("آمار جمعیت کل بر اساس شهر/دهستان", "GetVwJamiat_ShahrYaDehestan" + "Query");
            reportTypes.Add("آمار جمعیت کل بر اساس شغل", "GetVwJamiat_Shoghl" + "Query");
            reportTypes.Add("آمار جمعیت کل بر اساس وضعیت تأهل", "GetVwJamiat_Taahol" + "Query");
            reportTypes.Add("آمار جمعیت کل بر اساس سن", "GetVwJamiatKol_Sen" + "Query");
            reportTypes.Add("آمار جمعیت مرد بر اساس سن", "GetVwJamiatMard_Sen" + "Query");
            reportTypes.Add("آمار جمعیت زن بر اساس سن", "GetVwJamiatZan_Sen" + "Query");
            reportTypes.Add("آمار تعداد خانوار بر اساس شهر/دهستان", "GetVwKhanevar_ShahryaDehestan" + "Query");
            reportTypes.Add("آمار تعداد خانه ها بر اساس مساحت زیربنا", "GetVwMasahatZirBana" + "Query");
            //reportTypes.Add("آمار جمعیت کل بر اساس شماره بلوک", "GetVwJamiat_Block" + "Query");

            cmbReportType.ItemsSource = reportTypes;

            cmbReportType.SelectedIndex = 0;

            #endregion

            #region chartTypes

            chartTypes.Add("نمودار میله ای", "BarSeries");

            chartTypes.Add("نمودار ستونی", "ColumnSeries");

            chartTypes.Add("نمودار دایره ای", "PieSeries");

            chartTypes.Add("نمودار خطی", "LineSeries");

            cmbChartType.ItemsSource = chartTypes;

            cmbChartType.SelectedIndex = 0;

            #endregion

            //RibbonBar.reportDialog = this.ReportDialog;

            //RibbonBar.childReport = this.child;

            EntityDomainDataSource.QueryName = cmbReportType.SelectedValue.ToString();

            EntityDomainDataSource.Load();
        }

        private void EntityDomainDataSource_LoadedData(object sender, LoadedDataEventArgs e)
        {
            if (e.HasError)
            {
                MessageWindow win = new MessageWindow();
                win.messageTextBlock.Text = e.Error.ToString();
                win.Show();
            }

            RefreshChart();
        }

        private void ReportType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EntityDomainDataSource.QueryName = cmbReportType.SelectedValue.ToString();

            EntityDomainDataSource.Load();
        }

        private void cmbChartType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshChart();
        }

        StackPanel printArea = new StackPanel();

        private void RefreshChart()
        {
            reportChart.Series.Clear();

            reportChart.Series.Add(CreateChartSeries());

            //printArea.FlowDirection = FlowDirection.RightToLeft;

            //printArea.Orientation = Orientation.Vertical;

            //printArea.Margin = new Thickness(0, 50, 0, 10);

            //StackPanel printReportType = new StackPanel();

            //printReportType.Orientation = Orientation.Horizontal;

            //printReportType.HorizontalAlignment = HorizontalAlignment.Center;

            //printReportType.Children.Add(new TextBlock() { Text = string.Format("نوع گزارش: {0}", cmbReportType.SelectedItem.ToString()) });

            //printArea.Children.Add(printReportType);

            ////var uielementcopy = (UIElement) XamlReader.Load(XamlWriter.Save(myUIelement));

            //Chart printChart = new Chart();

            //printChart.Width = 680;

            //printChart.Height = 430;

            //printChart.Series.Clear();

            //printChart.Series.Add(CreateChartSeries());

            //printArea.Children.Add(printChart);
        }

        private ISeries CreateChartSeries()
        {
            if (cmbChartType.SelectedValue.ToString() == "BarSeries")
            {
                BarSeries series = new BarSeries();

                series.DependentRangeAxis = new LinearAxis
                {
                    Minimum = 0,
                    Orientation = AxisOrientation.X,
                    Location = AxisLocation.Bottom,
                };

                series.Title = "کمیت";

                //series.AnimationSequence = AnimationSequence.Simultaneous;

                //series.TransitionDuration = new TimeSpan(1);

                series.TransitionEasingFunction = new ElasticEase(){EasingMode = EasingMode.EaseOut};

                series.ItemsSource = EntityDomainDataSource.Data;

                series.IsSelectionEnabled = true;

                series.DependentValuePath = "Y_Value";

                series.IndependentValuePath = "X_Value";

                return series;
            }

            else if (cmbChartType.SelectedValue.ToString() == "ColumnSeries")
            {
                ColumnSeries series = new ColumnSeries();

                series.DependentRangeAxis = new LinearAxis
                {
                    Minimum = 0,
                    Orientation = AxisOrientation.Y,
                    Location = AxisLocation.Right,
                };

                series.Title = "کمیت";

                series.TransitionEasingFunction = new ElasticEase() { EasingMode = EasingMode.EaseOut };

                series.ItemsSource = EntityDomainDataSource.Data;

                series.IsSelectionEnabled = true;

                series.DependentValuePath = "Y_Value";

                series.IndependentValuePath = "X_Value";

                return series;
            }
            else if (cmbChartType.SelectedValue.ToString() == "PieSeries")
            {
                PieSeries series = new PieSeries();

                series.TransitionEasingFunction = new ElasticEase() { EasingMode = EasingMode.EaseOut };

                series.ItemsSource = EntityDomainDataSource.Data;

                series.IsSelectionEnabled = true;

                series.DependentValuePath = "Y_Value";

                series.IndependentValuePath = "X_Value";

                return series;
            }
            else if (cmbChartType.SelectedValue.ToString() == "LineSeries")
            {
                LineSeries series = new LineSeries();

                series.DependentRangeAxis = new LinearAxis
                {
                    Minimum = 0,
                    Orientation = AxisOrientation.Y,
                    Location = AxisLocation.Right,
                };

                series.Title = "کمیت";

                series.TransitionEasingFunction = new ElasticEase() { EasingMode = EasingMode.EaseOut };

                series.ItemsSource = EntityDomainDataSource.Data;

                series.IsSelectionEnabled = true;

                series.DependentValuePath = "Y_Value";

                series.IndependentValuePath = "X_Value";

                return series;
            }

            return null;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Print(printArea, "گزارش", false);

            Print(printingArea, "گزارش", true);
        }

        private FrameworkElement _elementToPrint;
        private Double _elementOriginalWidth;
        private Double _elementOriginalHeight;

        private void Print(FrameworkElement elementToPrint, string documentName, bool stretchToFullSize)
        {
            PrintDocument doc = new PrintDocument();
            _elementToPrint = elementToPrint;
            doc.PrintPage += (s, args) =>
            {
                // Set element to be printed
                _elementOriginalWidth = _elementToPrint.Width;
                _elementOriginalHeight = _elementToPrint.Height;
                if (stretchToFullSize)
                {
                    _elementToPrint.Width = args.PrintableArea.Width;
                    _elementToPrint.Height = args.PrintableArea.Height;
                    // Printing only starts when args.PageVisual != null
                    // Only set args.PageVisual to elementToPrint once its size has been updated
                    _elementToPrint.SizeChanged += (s1, args1) =>
                    {
                        args.PageVisual = elementToPrint;
                    };
                }
                else
                {
                    args.PageVisual = elementToPrint;
                }

            };

            doc.BeginPrint += (s, args) =>
            {
                // Show that printing has begun: not implemented in this case
                //MessageBox.Show("Start");
            };
            doc.EndPrint += (s, args) =>
            {
                // Show that printing has ended: not implemented in this case

                // Reset printed element size to original
                //_elementToPrint.Width = _elementOriginalWidth;
                //_elementToPrint.Height = _elementOriginalHeight;

                //MessageBox.Show("End");

            };

            doc.Print(documentName);
        }
    }
}
