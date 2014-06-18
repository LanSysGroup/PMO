using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.ServiceModel.DomainServices.Client;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using LanSysWebGIS.Web;
using Liquid;
using Lite.ExcelLibrary.SpreadSheet;
using LanSysWebGIS.Views.UserManagement;
using LanSysWebGIS.Assets.Resources;

namespace LanSysWebGIS.UserControls
{
    public partial class DataFormViewEdit : UserControl
    {

        private string getQueryString;

        public Liquid.Dialog newRecord;

        //DBDomainContext context = new DBDomainContext();
        PMOContext context = new PMOContext();

        public static Type type;

        public Dictionary<string, string> tableAlias2TableName = new Dictionary<string, string>();

        private Style rightCellStyle;

        public string queryString
        {
            set
            {
                getQueryString = "Get" + value + "Query";

                EntityDomainDataSource.QueryName = getQueryString;

                try
                {
                    EntityDomainDataSource.FilterDescriptors.Clear();
                }
                catch (Exception)
                {
                }

                FilterDescriptor filter;

                try
                {
                    Helpers.AccessLevelChecker.CheckAuthentication(Constants.Administrator);

                    filter = new FilterDescriptor("Organization", FilterOperator.IsEqualTo, (cmbEntity.SelectedItem as DataForms).ViewOrgs);
                }
                catch (Exception)
                {
                    filter = new FilterDescriptor("Organization", FilterOperator.IsEqualTo, WebContext.Current.User.Organization);
                }

                EntityDomainDataSource.FilterDescriptors.Add(filter);

                EntityDomainDataSource.Load();

                //type = EntityDomainDataSource.Data.GetType();

                //Assembly assembly = LanSysWebGIS.Web;

                //assembly.

                //foreach (Assembly currentassembly in AppDomain.CurrentDomain.GetAssemblies())
                //{
                //    type = currentassembly.GetType(value, false);
                //    if (currentassembly.GetType(value, false) != null) { type = currentassembly.GetType(value, false); }
                //}

                //type = Type.GetType(value);
            }
        }

        public DataFormViewEdit()
        {
            InitializeComponent();

            try
            {
                EntityDomainDataSource.FilterDescriptors.Clear();
            }
            catch (Exception)
            {
            }

            FilterDescriptor filter = new FilterDescriptor("Organization", FilterOperator.IsEqualTo, WebContext.Current.User.Organization);

            

            EntityDomainDataSource.FilterDescriptors.Add(filter);

            cmbEntity.ItemsSource = context.DataForms;
            cmbEntity.DisplayMemberPath = "NameFa";

            //context.Load(context.GetDataFormsQuery());

            try
            {
                if (WebContext.Current.User.Organization == "استانداری البرز")
                {
                    context.Load(context.GetDataFormsQuery().OrderBy(p=>p.NameFa), LoadBehavior.RefreshCurrent,
                                        callback =>
                                        {
                                            cmbEntity.SelectedIndex = 0;

                                            queryString = context.DataForms.Where(p => p == cmbEntity.SelectedItem as DataForms).
                                                Select(p => p.TableName).Single();

                                        }, null);
                }
                else
                {
                    context.Load(context.GetDataFormsQuery().Where(p => p.ViewOrgs == WebContext.Current.User.Organization).OrderBy(p => p.NameFa), LoadBehavior.RefreshCurrent,
                                         callback =>
                                         {
                                             cmbEntity.SelectedIndex = 0;

                                             queryString = context.DataForms.Where(p => p == cmbEntity.SelectedItem as DataForms).
                                                 Select(p => p.TableName).Single();

                                         }, null); 
                }
                
            }
            catch (Exception e)
            {

            }

            DataFormNew.entityDG = this.EntityDataGrid;

            DataFormNew.entityDDS = this.EntityDomainDataSource;

            rightCellStyle = new Style(typeof(DataGridCell));
            rightCellStyle.Setters.Add(new Setter(
                Control.HorizontalContentAlignmentProperty,
                HorizontalAlignment.Right));

            //EntityDomainDataSource.SubmittedChanges += (o, args) => EntityDomainDataSource.Load();

            //cmbEntity.SelectedIndex = 0;
        }


        private void LoginForm_AutoGeneratingField(object sender, DataFormAutoGeneratingFieldEventArgs e)
        {
        }


        private IEnumerable itemList;

        private PropertyInfo[] allProps;

        private void EntityDomainDataSource_LoadedData(object sender, LoadedDataEventArgs e)
        {
            if (e.HasError)
            {
                MessageWindow win = new MessageWindow();
                win.messageTextBlock.Text = e.Error.ToString();
                win.Show();

                e.MarkErrorAsHandled();
            }

            itemList = EntityDomainDataSource.Data;
        }

        //private void temporary_Click(object sender, RoutedEventArgs e)
        //{
        //    MessageWindow win = new MessageWindow();
        //    win.messageTextBlock.Text = ApplicationStrings.msgNotProperAccessLevel;
        //    win.Show();
        //}

        #region Export2Excel

        private void Export2Excel_Click(object sender, RoutedEventArgs e)
        {
            allProps = EntityDataGrid.SelectedItem.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);

            Export2Excel(itemList, "Custom");
        }

        private void Export2Excel(IEnumerable items, string workSheetName)
        {
            // open file dialog to select an export file.   
            SaveFileDialog sDialog = new SaveFileDialog();
            sDialog.Filter = "Excel Files(*.xls)|*.xls";

            // create an instance of excel workbook
            Workbook workbook = new Workbook();

            if (sDialog.ShowDialog() == true)
            {
                // create a worksheet object
                Worksheet worksheet = new Worksheet(workSheetName);


                int counter = 0;

                foreach (DataGridColumn column in EntityDataGrid.Columns)
                {
                    //PropertyInfo property = row.GetType().GetProperty(f2e[column.Header.ToString()]);

                    //string cellValue = property.GetValue(row, null).ToString();

                    worksheet.Cells[0, counter] = new Cell(column.Header.ToString());

                    counter++;
                }

                int rowCounter = 0;

                foreach (var row in items)
                {
                    int columnCounter = 0;

                    foreach (DataGridColumn column in EntityDataGrid.Columns)
                    {
                        try
                        {
                            PropertyInfo property =
                                row.GetType().GetProperty(ExtractPropertyName(column.Header.ToString()));

                            string cellValue = property.GetValue(row, null).ToString();

                            worksheet.Cells[rowCounter + 1, columnCounter] = new Cell(cellValue);
                        }
                        catch (Exception a)
                        {
                        }
                        columnCounter++;
                    }

                    rowCounter++;
                }

                //add worksheet to workbook
                workbook.Worksheets.Add(worksheet);

                // get the selected file's stream
                Stream sFile = sDialog.OpenFile();
                workbook.Save(sFile);

                MessageWindow msg = new MessageWindow();
                msg.messageTextBlock.Text = "فایل با موفقیت ذخیره شد";
                msg.Show();
            }
        }

        private string ExtractPropertyName(string displayName)
        {
            foreach (var property in allProps)
            {
                string p =
                    property.GetCustomAttributes(typeof(DisplayAttribute), false).Cast<DisplayAttribute>().Single().
                        Name;

                if (p == displayName)
                {
                    return property.Name;

                    //return p;
                }
            }
            return "";
        }

        #endregion

        private void NewRecordButton_OnClick(object sender, RoutedEventArgs e)
        {
            //newRecord.IsOpen = true;

            //DataFormViewEditDialog.IsOpen = false;

            LanSysWebGIS.Helpers.AccessLevelChecker.CheckAuthentication(Constants.Administrator, Constants.ICZM, Constants.Monitoring);

            RibbonBar.GenerateChildWin<DataFormNew>("اضافه کردن رکورد جدید", 420, "dataFromChild");
        }

        private void EditRecordButton_OnClick(object sender, RoutedEventArgs e)
        {
            LanSysWebGIS.Helpers.AccessLevelChecker.CheckAuthentication(Constants.Administrator, Constants.ICZM, Constants.Monitoring);

            EntityDomainDataSource.SubmitChanges();
        }

        private void CancelEditRecordButton_OnClick(object sender, RoutedEventArgs e)
        {
            EntityDomainDataSource.RejectChanges();
        }

        private void DeleteRecordButton_OnClick(object sender, RoutedEventArgs e)
        {
            LanSysWebGIS.Helpers.AccessLevelChecker.CheckAuthentication(Constants.Administrator, Constants.ICZM, Constants.Monitoring);

            MessageWindow win = new MessageWindow();
            win.messageTextBlock.Text = ApplicationStrings.msgAreYouSureToDeleteRecord;

            win.CancelButton.Visibility = Visibility.Visible;
            win.Closed += (o, args) =>
            {
                if (win.DialogResult == true)
                {
                    EntityDomainDataSource.DataView.Remove(EntityDataGrid.SelectedItem);
                    EntityDomainDataSource.SubmitChanges();
                }
            };

            win.Show();
        }

        private void DataFormViewEditDialog_OnOpened(object sender, DialogEventArgs e)
        {
            EntityDomainDataSource.Load();
        }

        private void cmbEntity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EntityDomainDataSource.RejectChanges();

            queryString = (cmbEntity.SelectedItem as DataForms).TableName;
        }

        private void DataFormViewEditDialog_Closed(object sender, DialogEventArgs e)
        {
            EntityDomainDataSource.RejectChanges();
        }



        private void EntityDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Onvan" || e.PropertyName == "Vahed")
            {
                e.Column.Width = DataGridLength.SizeToCells;
            }
            else
            {
                e.Column.MaxWidth = 100;
                e.Column.CellStyle = rightCellStyle;
            }
        }
    }
}
