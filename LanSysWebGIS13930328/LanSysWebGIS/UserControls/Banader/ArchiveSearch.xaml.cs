using LanSysWebGIS.Web;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.ServiceModel.DomainServices.Client;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using LanSysWebGIS.Helpers;
using System.Text;
using LanSysWebGIS.Models;
using System.Windows.Browser;

namespace LanSysWebGIS.UserControls.Banader
{
    public partial class ArchiveSearch : UserControl
    {
        private bool _isLoadingData = true;
        public bool IsLoadingData
        {
            get { return _isLoadingData; }
            set
            {
                if (b1 && b2 && b3 && b4 && b5)
                {
                    this._isLoadingData = false;

                    OnPropertyChanged("IsLoadingData");
                }
                else
                {
                    this._isLoadingData = true;
                };
            }
        }

        public ObservableCollection<Web.tblInfoType> InfoTypes = new ObservableCollection<tblInfoType>();

        public ObservableCollection<Web.tblDataType> DataTypes = new ObservableCollection<tblDataType>();

        bool b1 = false, b2 = false, b3 = false, b4 = false, b5 = false;

        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ArchiveSearch()
        {
            InitializeComponent();

            busyIndicator.IsBusy = true;

            PMOContext context = new PMOContext();

            this.lstInfoType.DataContext = InfoTypes;

            this.lstDataType.DataContext = DataTypes;

            //resultDomainDataSource.FilterOperator = FilterDescriptorLogicalOperator.Or;

            context.Load(context.GetTblDataTypeQuery(), LoadBehavior.RefreshCurrent,
                                        callback =>
                                        {
                                            foreach (var item in context.tblDataTypes)
                                            {
                                                this.DataTypes.Add(item);
                                            }

                                            b1 = true;

                                            checkBusyIndicator();

                                        }, null);

            context.Load(context.GetTblInfoTypeQuery(), LoadBehavior.MergeIntoCurrent,
                                        callback =>
                                        {
                                            foreach (var item in context.tblInfoTypes)
                                            {
                                                this.InfoTypes.Add((item));
                                            }

                                            b2 = true;

                                            checkBusyIndicator();

                                        }, null);

            //List<string> fileFormats = new List<string>() { "PDF", "Word", "Excel", "Autocad", "JPEG", "Other" };

            Dictionary<string, string> fileFormats = new Dictionary<string, string>() { { "PDF", ".pdf" }, { "Word", ".doc" }, { "Excel", ".xls" }, { "Autocad", ".dwg" }, { "JPEG", ".jpg" }, { "Other", "other" } };

            foreach (var fileFormat in fileFormats)
            {
                CheckBox chk = new CheckBox();

                chk.Content = fileFormat.Key;

                chk.Tag = fileFormat.Value;

                lstFileFormat.Items.Add(chk);
            }

            context.Load(context.GetTblOstanQuery(), LoadBehavior.MergeIntoCurrent,
                                       callback =>
                                       {
                                           foreach (var item in context.tblOstans)
                                           {
                                               cmbOstan.Items.Add(item.Name_Fa);
                                           }

                                           b3 = true;

                                           checkBusyIndicator();

                                       }, null);

            context.Load(context.GetTblPortsQuery(), LoadBehavior.MergeIntoCurrent,
                                       callback =>
                                       {
                                           foreach (var item in context.tblPorts)
                                           {
                                               cmbPort.Items.Add(item.Name);
                                           }

                                           b4 = true;

                                           checkBusyIndicator();

                                       }, null);

            context.Load(context.GetZoneQuery(), LoadBehavior.MergeIntoCurrent,
                                       callback =>
                                       {
                                           foreach (var item in context.Zones)
                                           {
                                               cmbZone.Items.Add(item.Name);
                                           }

                                           b5 = true;

                                           checkBusyIndicator();

                                       }, null);
        }

        private void checkBusyIndicator()
        {
            busyIndicator.IsBusy = !(b1 && b2 && b3 && b4 && b5);
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            var context = new PMOContext();

            StringBuilder stringBuilder = new StringBuilder();

            int i = 0, j = 0;

            if (selectedDataTypes.Count > 0)
            {
                stringBuilder.Append("(");
            }

            foreach (string keyword in selectedDataTypes)
            {
                if (i > 0)
                {
                    stringBuilder.Append(" OR ");
                }

                i++;
                j++;

                stringBuilder.Append(String.Format("DataName = \"{0}\"", keyword));
            }

            if (selectedDataTypes.Count > 0)
            {
                stringBuilder.Append(") AND ");
                i = 0;
            }

            if (selectedInfoTypes.Count > 0)
            {
                stringBuilder.Append("(");
            }

            foreach (string keyword in selectedInfoTypes)
            {
                if (i > 0)
                {
                    stringBuilder.Append(" OR ");
                }

                i++;
                j++;

                stringBuilder.Append(String.Format("InfoName = \"{0}\"", keyword));
            }

            if (selectedInfoTypes.Count > 0)
            {
                stringBuilder.Append(") AND ");
                i = 0;
            }

            if (lstFileFormat.Items.Cast<CheckBox>().Any(p => p.IsChecked.Value))
            {
                stringBuilder.Append("(");
            }

            foreach (string keyword in lstFileFormat.Items.Cast<CheckBox>().Where(p => p.IsChecked.Value).Select((p => p.Tag.ToString())))
            {
                if (i > 0)
                {
                    stringBuilder.Append(" OR ");
                }

                i++;
                j++;



                if (keyword == "jpg")
                {
                    stringBuilder.Append(String.Format("FileExt = \".jpg\" OR FileExt = \".jpeg\""));
                }
                else if (keyword == "doc")
                {
                    stringBuilder.Append(String.Format("FileExt = \".doc\" OR FileExt = \".docx\""));
                }
                else if (keyword == "xls")
                {
                    stringBuilder.Append(String.Format("FileExt = \".xls\" OR FileExt = \".xlsx\""));
                }
                else if (keyword == "other")
                {
                    stringBuilder.Append(String.Format("(FileExt <> \".doc\" AND FileExt <> \".docx\" AND FileExt <> \".jpg\" AND FileExt <> \".jpeg\" AND FileExt <> \".dwg\" AND " +
                                                       "FileExt <> \".xls\" AND FileExt <> \".xlsx\" AND FileExt <> \".pdf\")"));
                }
                else
                {
                    stringBuilder.Append(String.Format("FileExt = \"{0}\"", keyword));
                }
            }

            if (lstFileFormat.Items.Cast<CheckBox>().Any(p => p.IsChecked.Value))
            {
                stringBuilder.Append(") AND ");
                i = 0;
            }

            if (cmbOstan.SelectedIndex != -1)
            {
                stringBuilder.Append("(");
                stringBuilder.Append(String.Format("OstanName = \"{0}\"", cmbOstan.SelectedItem.ToString()));
                stringBuilder.Append(") AND ");

                j++;
            }

            if (cmbPort.SelectedIndex != -1)
            {
                stringBuilder.Append("(");
                stringBuilder.Append(String.Format("PortName = \"{0}\"", cmbPort.SelectedItem.ToString()));
                stringBuilder.Append(") AND ");

                j++;
            }

            if (cmbZone.SelectedIndex != -1)
            {
                stringBuilder.Append("(");
                stringBuilder.Append(String.Format("ZoneName = \"{0}\"", cmbZone.SelectedItem.ToString()));
                stringBuilder.Append(") AND ");

                j++;
            }

            string keywords = "";
            if (!string.IsNullOrWhiteSpace(txtKeyWords.Text))
            {
                keywords = txtKeyWords.Text;
            }

            if (j > 0)
            {
                stringBuilder.Remove(stringBuilder.Length - 5, 4);
            }
            else
            {
                stringBuilder.Clear();
            }

            context.Load(context.GetSearchResultQuery(stringBuilder.ToString(), keywords), LoadBehavior.RefreshCurrent, callback =>
            {
                dtgSearchResult.ItemsSource = context.vwLinkDocs;
            }, null);

        }

        List<string> selectedDataTypes = new List<string>();

        private void DataTypesCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            selectedDataTypes.Add(((CheckBox)sender).Content.ToString());
        }

        private void DataTypesCheckBox_UnChecked(object sender, RoutedEventArgs e)
        {
            selectedDataTypes.Remove(((CheckBox)sender).Content.ToString());
        }

        List<string> selectedInfoTypes = new List<string>();

        private void InfoTypesCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            selectedInfoTypes.Add(((CheckBox)sender).Content.ToString());
        }

        private void InfoTypesCheckBox_UnChecked(object sender, RoutedEventArgs e)
        {
            selectedInfoTypes.Remove(((CheckBox)sender).Content.ToString());
        }

        private void dtgSearchResult_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (MouseButtonHelper.IsDoubleClick(sender, e))
            {
                if (((DataGrid)sender).SelectedIndex > -1)
                {
                    string path = ((vwLinkDocs)dtgSearchResult.SelectedItems[0]).FileFullName;

                    path = @"\" + path.Replace("cpedsrv", "172.16.1.243").Replace("CPEDSRV", "172.16.1.243").Replace(@"//", @"\").Replace(@"\\", @"\");

                    HtmlPage.Window.Navigate(new Uri(path, UriKind.RelativeOrAbsolute), "_blank");
                }
            }
        }

        private void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                this.btnSearch.Focus();
                btnSearch_Click(null, null);
            }
            else if (e.Key == Key.Escape)
            {
                (((this.Parent as StackPanel).Parent as Grid).Parent as ChildWin).Close();
            }
        }
    }
}



