using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Windows;
using System.Windows.Browser;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using LanSysWebGIS.Assets.Resources;
using LanSysWebGIS.Models;
using LanSysWebGIS.Views.UserManagement;
using LanSysWebGIS.Web;
using Lite.ExcelLibrary.SpreadSheet;
using GraphicFeatureDetails = LanSysWebGIS.Web.GraphicFeatureDetails;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Xml.Linq;

namespace LanSysWebGIS.UserControls.GeoMaps
{
    public partial class ShowFiles : UserControl
    {
        public ShowFiles()
        {
            InitializeComponent();

            RibbonBar.entityDataGrid = this.EntityDataGrid;

            SetSubjectsItemSource();

            GetAllFiles();
        }

        private PagedCollectionView pagedCol;

        private ObservableCollection<FilesDGItemSource> fdItemSourceList;

        private void GetAllFiles()
        {
            EntityDataGrid.ItemsSource = null;

            FileHandler fileHandler = new FileHandler();

            for (int i = 0; i < MapOperations.featureDetails.Count; i++)
            {
                if (string.IsNullOrWhiteSpace(MapOperations.featureDetails[i].ObjectCode))
                {
                    MapOperations.featureDetails.RemoveAt(i);
                }
            }

            System.ServiceModel.DomainServices.Client.InvokeOperation invoke = fileHandler.GetFileDetails(MapOperations.featureDetails);

            invoke.Completed += (o, args) =>
            {
                if (!invoke.HasError)
                {
                    //EntityDataGrid.ItemsSource = (List<FileDetails>)invoke.Value;

                    fdItemSourceList = new ObservableCollection<FilesDGItemSource>();

                    foreach (FileDetails fd in (List<FileDetails>)invoke.Value)
                    {
                        FilesDGItemSource fdItem = new FilesDGItemSource();

                        fdItem.filePath = fd.FilePath;

                        fdItem.ObjectName = fd.featureDetails.ObjectName;

                        fdItem.ObjCode = fd.featureDetails.ObjectCode;

                        fdItem.Subject = fd.Subject;

                        string[] sections = fd.FilePath.Split('/');

                        fdItem.FileName = sections.Last();

                        fdItem.LayerName = fd.featureDetails.LayerName;

                        fdItemSourceList.Add(fdItem);
                    }

                    pagedCol = new PagedCollectionView(fdItemSourceList);

                    pagedCol.GroupDescriptions.Add(new PropertyGroupDescription("ObjCode"));

                    EntityDataGrid.ItemsSource = pagedCol;

                    CollapseGroups(0, true);

                    SetLayersItemSource();
                }
                else
                {

                }
            };
        }

        //private void CollapseGroups(int groupingLevel, bool collapseAllSublevels)
        //{
        //    if (EntityDataGrid.ItemsSource == null)
        //        return;
        //    HashSet<CollectionViewGroup> groups = new HashSet<CollectionViewGroup>();
        //    foreach (object item in EntityDataGrid.ItemsSource)
        //        groups.Add(EntityDataGrid.GetGroupFromItem(item, groupingLevel));
        //    foreach (CollectionViewGroup group in groups)
        //        EntityDataGrid.CollapseRowGroup(group, collapseAllSublevels);

        //    //PagedCollectionView pcv = EntityDataGrid.ItemsSource as PagedCollectionView;
        //    //try
        //    //{
        //    //    foreach (CollectionViewGroup group in pcv.Groups)
        //    //    {
        //    //        EntityDataGrid.ScrollIntoView(group, null);
        //    //        EntityDataGrid.CollapseRowGroup(group, true);
        //    //    }
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    // Could not collapse group.
        //    //    MessageBox.Show(ex.Message);
        //    //}
        //}

        private void CollapseGroups(int groupingLevel, bool collapseAllSublevels)
        {
            if (EntityDataGrid.ItemsSource == null)
                return;
            HashSet<CollectionViewGroup> groups = new HashSet<CollectionViewGroup>();
            foreach (object item in EntityDataGrid.ItemsSource)
                groups.Add(EntityDataGrid.GetGroupFromItem(item, groupingLevel));
            foreach (CollectionViewGroup group in groups)
                EntityDataGrid.CollapseRowGroup(group, collapseAllSublevels);
        }

        private void SetLayersItemSource()
        {
            var layers = fdItemSourceList.Select(i => i.LayerName).Distinct().ToList<string>();

            layers.Insert(0, "All Layers");

            cmbLayer.ItemsSource = layers;

            cmbLayer.SelectedIndex = 0;
        }

        private void SetSubjectsItemSource()
        {
            FileHandler fileHandler = new FileHandler();

            System.ServiceModel.DomainServices.Client.InvokeOperation invoke = fileHandler.GetSubjects();

            invoke.Completed += (o, args) =>
            {
                if (!invoke.HasError)
                {
                    var temp = ((string[])invoke.Value).ToList<string>();

                    temp.Insert(0, "All Subjects");

                    cmbSubject.ItemsSource = temp;

                    cmbSubject.SelectedIndex = 0;
                }
                else
                {

                }
            };
        }

        private void ManageCmbSelectionChanged()
        {
            if (cmbLayer.SelectedIndex == 0 && cmbSubject.SelectedIndex == 0 && fdItemSourceList != null)
            {
                pagedCol = new PagedCollectionView(fdItemSourceList);
            }
            else if (cmbLayer.SelectedIndex > 0 && cmbSubject.SelectedIndex == 0 && fdItemSourceList != null)
            {
                pagedCol = new PagedCollectionView(fdItemSourceList.Where(p => p.LayerName == cmbLayer.SelectedItem.ToString()));
            }
            else if (cmbLayer.SelectedIndex == 0 && cmbSubject.SelectedIndex > 0 && fdItemSourceList != null)
            {
                pagedCol = new PagedCollectionView(fdItemSourceList.Where(p => p.Subject == cmbSubject.SelectedItem.ToString()));
            }
            else if (cmbLayer.SelectedIndex > 0 && cmbSubject.SelectedIndex > 0 && fdItemSourceList != null)
            {
                pagedCol = new PagedCollectionView(fdItemSourceList.Where(p => p.Subject == cmbSubject.SelectedItem.ToString() && p.LayerName == cmbLayer.SelectedItem.ToString()));
            }

            if (pagedCol != null)
            {
                pagedCol.GroupDescriptions.Add(new PropertyGroupDescription("ObjCode"));

                EntityDataGrid.ItemsSource = pagedCol;
            }
        }

        private void cmbLayer_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            ManageCmbSelectionChanged();
        }

        private void cmbSubject_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            ManageCmbSelectionChanged();
        }

        private void EntityDataGrid_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            if (((DataGrid)sender).SelectedIndex > -1)
            {
                HtmlPage.Window.Navigate(new Uri(((FilesDGItemSource)EntityDataGrid.SelectedItems[0]).filePath), "_blank");
            }
        }

        #region Export2Excel

        private PropertyInfo[] allProps;

        private IEnumerable itemList;

        private void ExportExcel_OnClick(object sender, RoutedEventArgs e)
        {
            allProps = EntityDataGrid.SelectedItem.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);

            itemList = EntityDataGrid.ItemsSource;

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
    }
}
