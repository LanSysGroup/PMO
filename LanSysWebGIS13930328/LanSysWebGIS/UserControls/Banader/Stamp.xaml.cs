using LanSysWebGIS.Views.UserManagement;
using LanSysWebGIS.Web;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace LanSysWebGIS.UserControls.Banader
{
    public partial class Stamp : ChildWindow
    {
        private Presenter.DocFileViewModel docFileViewModel;
        private Models.DocSubjectTreeViewModel docSubjectTreeViewModel;
        private PMOContext context = new PMOContext();

        bool isBulk;

        public Stamp(Models.DocSubjectTreeViewModel docSubjectTreeViewModel)
        {
            InitializeComponent();
            // TODO: Complete member initialization
            this.docSubjectTreeViewModel = docSubjectTreeViewModel;
            isBulk = true;
        }

        public Stamp(Presenter.DocFileViewModel docFileViewModel, Models.DocSubjectTreeViewModel docSubjectTreeViewModel)
        {
            InitializeComponent();
            // TODO: Complete member initialization
            this.docFileViewModel = docFileViewModel;
            this.docSubjectTreeViewModel = docSubjectTreeViewModel;
            isBulk = false;

            LoadForm();
        }

        private void LoadForm()
        {
            var docFileQuery = context.GetDocFilesForQuery(this.docSubjectTreeViewModel.SubjectId);

            context.Load(docFileQuery, System.ServiceModel.DomainServices.Client.LoadBehavior.RefreshCurrent,
            callback =>
            {
                DocFile thisFile = context.DocFiles.FirstOrDefault(i => i.FileID == this.docFileViewModel.FileId);

                SilverlightPersianDatePicker.Converters.ToPersianDateConverter con = new SilverlightPersianDatePicker.Converters.ToPersianDateConverter();

                //DateTime time = DateTime.Parse(con.Convert(((DateTime)item).ToShortDateString(), typeof(ShortTimeFormat), null, new CultureInfo("fa-ir")).ToString());
                if (thisFile.toDate != null)
                {
                    toDate.SelectedDate = thisFile.toDate.ToString();
                    txtToDate.Text = (con.Convert(((DateTime)thisFile.toDate).ToShortDateString(), typeof(ShortTimeFormat), null, new CultureInfo("fa-ir"))).ToString();
                }
                if (thisFile.fromDate != null)
                {
                    fromDate.SelectedDate = thisFile.fromDate.ToString();
                    txtFromDate.Text = (con.Convert(((DateTime)thisFile.fromDate).ToShortDateString(), typeof(ShortTimeFormat), null, new CultureInfo("fa-ir"))).ToString();
                }
                if (thisFile.LatX != null)
                {
                    latitude.Text = thisFile.LatX.ToString();
                }
                if (thisFile.LongY != null)
                {
                    longitude.Text = thisFile.LongY.ToString();
                }
            }, null);

        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            var docFileQuery = context.GetDocFilesForQuery(this.docSubjectTreeViewModel.SubjectId);

            if (isBulk)
            {
                context.Load(docFileQuery, System.ServiceModel.DomainServices.Client.LoadBehavior.RefreshCurrent,
                callback1 =>
                {
                    for (int i = 0; i < context.DocFiles.Count; i++)
                    {
                        var doc = context.DocFiles.Skip(i).First() as DocFile;

                        if (toDate.SelectedDate != "")
                        {
                            doc.toDate = DateTime.Parse(toDate.SelectedDate);
                        }
                        else
                        {
                            doc.toDate = null;
                        }
                        if (fromDate.SelectedDate != "")
                        {
                            doc.fromDate = DateTime.Parse(fromDate.SelectedDate);
                        }
                        else
                        {
                            doc.fromDate = null;
                        }
                        if (!string.IsNullOrEmpty(latitude.Text))
                        {
                            doc.LatX = double.Parse(latitude.Text);
                        }
                        else
                        {
                            doc.LatX = null;
                        }
                        if (!string.IsNullOrEmpty(longitude.Text))
                        {
                            doc.LongY = double.Parse(longitude.Text);
                        }
                        else
                        {
                            doc.LongY = null;
                        }
                    }

                    context.SubmitChanges();
                }, null);
            }
            else
            {
                context.Load(docFileQuery, System.ServiceModel.DomainServices.Client.LoadBehavior.RefreshCurrent,
                callback =>
                {
                    var doc = context.DocFiles.FirstOrDefault(i => i.FileID == this.docFileViewModel.FileId);

                    if (toDate.SelectedDate != "")
                    {
                        doc.toDate = DateTime.Parse(toDate.SelectedDate);
                    }
                    else
                    {
                        doc.toDate = null;
                    }
                    if (fromDate.SelectedDate != "")
                    {
                        doc.fromDate = DateTime.Parse(fromDate.SelectedDate);
                    }
                    else
                    {
                        doc.fromDate = null;
                    }
                    if (!string.IsNullOrEmpty(latitude.Text))
                    {
                        doc.LatX = double.Parse(latitude.Text);
                    }
                    else
                    {
                        doc.LatX = null;
                    }
                    if (!string.IsNullOrEmpty(longitude.Text))
                    {
                        doc.LongY = double.Parse(longitude.Text);
                    }
                    else
                    {
                        doc.LongY = null;
                    }

                    context.SubmitChanges();
                }, null);
            }

            MessageWindow win = new MessageWindow();

            win.messageTextBlock.Text = "تغییر با موفقیت اعمال شد";

            win.Show();

            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void ChildWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                this.DialogResult = true;
            }
            else if (e.Key == Key.Escape)
            {
                this.DialogResult = false;
            }
        }
    }
}
