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
using LanSysWebGIS.Web;
using LanSysWebGIS.Views.UserManagement;
using System.Windows.Controls.DataVisualization.Charting;
using System.Globalization;
using System.ServiceModel.DomainServices.Client;

namespace LanSysWebGIS.UserControls.Banader
{
    public partial class ReportDocFiles : UserControl
    {
        PMOContext context = new PMOContext();

        public ReportDocFiles()
        {
            InitializeComponent();

            context.Load(context.GetTblUsersQuery(), callback =>
                {
                    actUserName.ItemsSource = context.tblUsers.Select(s => s.UserID);
                }, null);


            PopulateUnacceptedFilesList();

            GetLatestDocsUploaded(800);
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            if ((!string.IsNullOrEmpty(FromDate.SelectedDate) && string.IsNullOrEmpty(ToDate.SelectedDate)) || (string.IsNullOrEmpty(FromDate.SelectedDate) && !string.IsNullOrEmpty(ToDate.SelectedDate)))
            {
                MessageWindow win = new MessageWindow();
                win.messageTextBlock.Text = "لطفا هر دو فیلد زمانی را پر کنید";
                win.Show();
                return;
            }

            reportChart.Series.Clear();
            reportChartDownload.Series.Clear();

            if (!string.IsNullOrEmpty(actUserName.Text))
            {
                FileUploadReport();
                FileDownloadReport();
                LoginReport();
            }
        }

        private void LoginReport()
        {
            PMOContext contextLogin = new PMOContext();

            contextLogin.UserLogs.Clear();

            contextLogin.Load(contextLogin.GetUserLogsQuery(), System.ServiceModel.DomainServices.Client.LoadBehavior.RefreshCurrent, callback =>
            {
                if (!string.IsNullOrEmpty(ToDate.SelectedDate))
                {
                    EntityDataGrid4.ItemsSource = contextLogin.UserLogs.Where(s => s.UserName == actUserName.Text && s.Action == "Login" && s.Date > DateTime.Parse(FromDate.SelectedDate) && s.Date < DateTime.Parse(ToDate.SelectedDate).AddDays(1)).OrderByDescending(s => s.Date);
                }
                else
                {
                    EntityDataGrid4.ItemsSource = contextLogin.UserLogs.Where(s => s.UserName == actUserName.Text && s.Action == "Login").OrderByDescending(s => s.Date);
                }

                tabLogin.Header = string.Format("گزارش ورود به سامانه ({0})", (EntityDataGrid4.ItemsSource as IEnumerable<UserLogs>).Count());
            }, null);
        }

        PMOContext contextUnaccepted = new PMOContext();
        private void PopulateUnacceptedFilesList()
        {
            int userId = string.IsNullOrEmpty(actUserName.Text) ? 8 : App.allUsers.FirstOrDefault(p => p.UserID == actUserName.Text).UsersID;

            contextUnaccepted.Load(contextUnaccepted.GetDocFilesUnacceptedQuery(userId), System.ServiceModel.DomainServices.Client.LoadBehavior.RefreshCurrent, callback =>
                {
                    dgUnaccpetdFiles.ItemsSource = contextUnaccepted.DocFiles;
                }, null);
        }

        private void FileDownloadReport()
        {
            PMOContext contextDownload = new PMOContext();

            contextDownload.DocFileUserLogs.Clear();

            contextDownload.Load(contextDownload.GetDocFileUserLogByQuery(App.allUsers.FirstOrDefault(p => p.UserID == actUserName.Text).UsersID), System.ServiceModel.DomainServices.Client.LoadBehavior.RefreshCurrent, callback =>
                {
                    if (!string.IsNullOrEmpty(ToDate.SelectedDate))
                    {
                        EntityDataGrid2.ItemsSource = contextDownload.DocFileUserLogs.Where(s => s.DateVisited > DateTime.Parse(FromDate.SelectedDate) && s.DateVisited < DateTime.Parse(ToDate.SelectedDate).AddDays(1));
                    }
                    else
                    {
                        EntityDataGrid2.ItemsSource = contextDownload.DocFileUserLogs;
                    }

                    AmalkardDownloadReport(contextDownload);


                }, null);
        }

        private void AmalkardDownloadReport(PMOContext context)
        {
            reportChartDownload.Series.Add(CreateDownloadChart(context));
        }

        private ISeries CreateDownloadChart(PMOContext context)
        {
            BarSeries series = new BarSeries();

            series.DependentRangeAxis = new LinearAxis
            {
                Minimum = 0,
                Orientation = AxisOrientation.X,
                Location = AxisLocation.Bottom,
            };

            //series.Title = "تعداد";

            series.TransitionEasingFunction = new ElasticEase() { EasingMode = EasingMode.EaseOut };

            var dates = context.DocFileUserLogs.Select(i => i.DateVisited).OrderBy(i => i.Value).Distinct();

            if (!string.IsNullOrEmpty(ToDate.SelectedDate))
            {
                dates = dates.Where(s => s.Value > DateTime.Parse(FromDate.SelectedDate) && s.Value < DateTime.Parse(ToDate.SelectedDate).AddDays(1));
            }

            List<ReportObject> reportObject = new List<ReportObject>();

            foreach (var item in dates)
            {
                if (item != null)
                {
                    int count = context.DocFileUserLogs.Where(i => i.DateVisited == item).Count();

                    SilverlightPersianDatePicker.Converters.ToPersianDateConverter con = new SilverlightPersianDatePicker.Converters.ToPersianDateConverter();

                    //DateTime time = DateTime.Parse(con.Convert(item, typeof(LongTimeFormat), null, new CultureInfo("fa-ir")).ToString());

                    string formattedDate = con.Convert(item, typeof(LongTimeFormat), null, new CultureInfo("fa-ir")).ToString();

                    if (reportObject.Any(r => r.DateAdded == formattedDate))
                    {
                        reportObject.FirstOrDefault(r => r.DateAdded == formattedDate).Count += count;
                    }
                    else
                    {
                        reportObject.Add(new ReportObject() { DateAdded = formattedDate, Count = count });
                    }
                }
            }

            series.ItemsSource = reportObject;

            series.IsSelectionEnabled = true;

            series.DependentValuePath = "Count";

            series.IndependentValuePath = "DateAdded";

            return series;
        }

        private void FileUploadReport()
        {
            PMOContext contextUpload = new PMOContext();

            contextUpload.DocFiles.Clear();

            contextUpload.Load(contextUpload.GetDocFilesByQuery(actUserName.Text), System.ServiceModel.DomainServices.Client.LoadBehavior.RefreshCurrent, callback =>
            {
                if (!string.IsNullOrEmpty(ToDate.SelectedDate))
                {
                    EntityDataGrid.ItemsSource = contextUpload.DocFiles.Where(s => s.DateAdded > DateTime.Parse(FromDate.SelectedDate) && s.DateAdded < DateTime.Parse(ToDate.SelectedDate).AddDays(1));
                }
                else
                {
                    EntityDataGrid.ItemsSource = contextUpload.DocFiles;
                }

                AmalkardUploadReport(contextUpload);

            }, null);
        }

        private void AmalkardUploadReport(PMOContext contextUpload)
        {
            reportChart.Series.Add(CreateUploadChart(contextUpload));
        }

        private System.Windows.Controls.DataVisualization.Charting.ISeries CreateUploadChart(PMOContext contextUpload)
        {
            LineSeries series = new LineSeries();

            series.DependentRangeAxis = new LinearAxis
            {
                Minimum = 0,
                Orientation = AxisOrientation.Y,
                Location = AxisLocation.Left,
            };

            series.Title = "تعداد";

            series.TransitionEasingFunction = new ElasticEase() { EasingMode = EasingMode.EaseOut };

            var dates = contextUpload.DocFiles.Select(i => i.DateAdded).OrderBy(i => i.Value).Distinct();

            if (!string.IsNullOrEmpty(ToDate.SelectedDate))
            {
                dates = dates.Where(s => s.Value > DateTime.Parse(FromDate.SelectedDate) && s.Value < DateTime.Parse(ToDate.SelectedDate).AddDays(1));
            }

            List<ReportObject> reportObject = new List<ReportObject>();

            foreach (var item in dates)
            {
                if (item != null)
                {
                    int count = contextUpload.DocFiles.Where(i => i.DateAdded == item).Count();

                    SilverlightPersianDatePicker.Converters.ToPersianDateConverter con = new SilverlightPersianDatePicker.Converters.ToPersianDateConverter();

                    //DateTime time = DateTime.Parse(con.Convert(((DateTime)item).ToShortDateString(), typeof(ShortTimeFormat), null, new CultureInfo("fa-ir")).ToString());

                    string formattedDate = con.Convert(((DateTime)item).ToShortDateString(), typeof(ShortTimeFormat), null, new CultureInfo("fa-ir")).ToString();

                    if (reportObject.Any(r => r.DateAdded == formattedDate))
                    {
                        reportObject.FirstOrDefault(r => r.DateAdded == formattedDate).Count += count;
                    }
                    else
                    {
                        reportObject.Add(new ReportObject() { DateAdded = formattedDate, Count = count });
                    }
                }
            }

            series.ItemsSource = reportObject;

            series.IsSelectionEnabled = true;

            series.DependentValuePath = "Count";

            series.IndependentValuePath = "DateAdded";

            return series;
        }

        private string FormatDateToPersian(DateTime time)
        {
            string year = time.Year.ToString();
            string month = time.Month.ToString();
            string day = time.Day.ToString();

            return year + @"/" + month + @"/" + day;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            LanSysWebGIS.WebMethodsService.WebMethodsServiceSoapClient soap = new WebMethodsService.WebMethodsServiceSoapClient();

            soap.GetDateCompleted += soap_GetDateCompleted;

            soap.GetDateAsync();
        }

        void soap_GetDateCompleted(object sender, WebMethodsService.GetDateCompletedEventArgs e)
        {
            ToDate.SelectedDate = e.Result.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in dgUnaccpetdFiles.SelectedItems)
            {
                (item as DocFile).Flag = true;
            }
            contextUnaccepted.SubmitChanges();
        }

        private void EntityDomainDataSource_LoadedData(object sender, LoadedDataEventArgs e)
        {

        }
        private void GetLatestDocsUploaded(int count)
        {
            PMOContext contextLatest = new PMOContext();

            contextLatest.Load(contextLatest.GetLatestDocFilesQuery(count), System.ServiceModel.DomainServices.Client.LoadBehavior.RefreshCurrent, callback =>
            {

                AllUploadsChart.Series.Add(CreateAllUploadsChart(contextLatest));

            }, null);
        }

        private ISeries CreateAllUploadsChart(PMOContext contextLatest)
        {
            LineSeries series = new LineSeries();

            series.DependentRangeAxis = new LinearAxis
            {
                Minimum = 0,
                Orientation = AxisOrientation.Y,
                Location = AxisLocation.Left,
            };

            series.Title = "تعداد";

            series.TransitionEasingFunction = new ElasticEase() { EasingMode = EasingMode.EaseOut };

            var dates = contextLatest.DocFiles.Select(i => i.DateAdded).OrderBy(i => i.Value).Distinct();

            if (!string.IsNullOrEmpty(ToDate.SelectedDate))
            {
                dates = dates.Where(s => s.Value > DateTime.Parse(FromDate.SelectedDate) && s.Value < DateTime.Parse(ToDate.SelectedDate).AddDays(1));
            }

            List<ReportObject> reportObject = new List<ReportObject>();

            foreach (var item in dates)
            {
                if (item != null)
                {
                    int count = contextLatest.DocFiles.Where(i => i.DateAdded == item).Count();

                    SilverlightPersianDatePicker.Converters.ToPersianDateConverter con = new SilverlightPersianDatePicker.Converters.ToPersianDateConverter();

                    //DateTime time = DateTime.Parse(con.Convert(((DateTime)item).ToShortDateString(), typeof(ShortTimeFormat), null, new CultureInfo("fa-ir")).ToString());

                    string formattedDate = con.Convert(((DateTime)item).ToShortDateString(), typeof(ShortTimeFormat), null, new CultureInfo("fa-ir")).ToString();

                    if (reportObject.Any(r => r.DateAdded == formattedDate))
                    {
                        reportObject.FirstOrDefault(r => r.DateAdded == formattedDate).Count += count;
                    }
                    else
                    {
                        reportObject.Add(new ReportObject() { DateAdded = formattedDate, Count = count });
                    }
                }
            }

            series.ItemsSource = reportObject;

            series.IsSelectionEnabled = true;

            series.DependentValuePath = "Count";

            series.IndependentValuePath = "DateAdded";

            return series;

            //if (!string.IsNullOrEmpty(ToDate.SelectedDate))
            //{
            //    EntityDataGrid3.ItemsSource = contextLatest.DocFiles.Where(s => s.DateAdded > DateTime.Parse(FromDate.SelectedDate) && s.DateAdded < DateTime.Parse(ToDate.SelectedDate).AddDays(1));
            //}
            //else
            //{
            //    EntityDataGrid3.ItemsSource = contextLatest.DocFiles;
            //}
        }

    }

    public class ReportObject
    {
        public string DateAdded { get; set; }

        public int Count { get; set; }
    }
}
