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
using System.ComponentModel;
using System.Reflection;
using LanSysWebGIS.Web;
using System.IO;
using Lite.ExcelLibrary.SpreadSheet;
using System.Collections;
using LanSysWebGIS.Views.UserManagement;
using LanSysWebGIS.Assets.Resources;

namespace LanSysWebGIS.UserControls
{
    public partial class ImageMetadataUserControl : UserControl
    {
        #region Fields

        private List<ComboBox> allComboBoxesList = new List<ComboBox>();

        private Dictionary<string, int> tt = new Dictionary<string, int>();

        private int columnCount = 0;

        private Dictionary<string, string> farsiFieldName2englishFieldName = new Dictionary<string, string>()
        {
        { "شناسه", "ObjectID" },
        { "شناسه تصویر", "ImageID" },
        { "فرمت تصویر", "ImageFormat" },
        { "سیستم تصویر EPSG", "ProjEPSG" },
        { "سیستم تصویر", "ProjSystem" },
        { "زون سیستم تصویر", "ProjZone" },
        { "بیضوی سیستم تصویر", "ProjElipse" },
        { "دیتوم سیستم تصویر", "ProjDatum" },
        { "مقیاس", "CentScale" },
        { "عرض جغرافیایی ابتدایی", "LatFirst" },
        { "عرض جغرافیایی انتهایی", "LatSecond" },
        { "نصف النهار مرکزی", "CentMeridian" },
        { "عرض جغرافیایی مرکز", "LatOrigin" },
        { "False Easting", "FalseEasting" },
        { "False Northing", "FalseNorthing" },
        { "طول پیکسل سایز", "PixelSize_X" },
        { "عرض پیکسل سایز", "PixelSize_Y" }
        };

        private bool isComboBoxFilled = false;

        private List<ImageMetadatas> imageMetadatas = new List<ImageMetadatas>();

        #endregion

        #region Initialization

        public ImageMetadataUserControl()
        {
            InitializeComponent();
        }

        #endregion

        #region Available Rasters

        private void ImageMetadataDomainDataSource_LoadedData(object sender, LoadedDataEventArgs e)
        {
            if (ImageMetadataDomainDataSource.DataView.Count != 0)
            {
                #region props
                //var a = ImageMetadataDomainDataSource.DataView.GetItemAt(0).GetType().GetProperties();

                //List<PropertyInfo> props = a.ToList<PropertyInfo>();

                //foreach (PropertyInfo item in props)
                //{
                //    try
                //    {

                //        item.Name;
                //    }
                //    catch (Exception e1)
                //    {
                //    }
                //}
                #endregion

                imageMetadatas = ImageMetadataDomainDataSource.Data.OfType<ImageMetadatas>().ToList<ImageMetadatas>();

                //fill combobox
                if (!isComboBoxFilled)
                {
                    GetDistinctListsForComboBox(imageMetadatas);

                    isComboBoxFilled = true;
                }
            }

            if (e.HasError)
            {
                MessageWindow win = new MessageWindow();
                win.messageTextBlock.Text = e.Error.ToString();
                win.Show();

                e.MarkErrorAsHandled();
            }
        }

        private void ImageMetadataDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            //e.Column.DisplayIndex = engFieldName2FieldIDDictionary[e.Column.Header.ToString()];

            //e.Column.Header = engFieldName2FarsiFieldNameDictionary[e.Column.Header.ToString()];

            tt.Add(e.Column.Header.ToString(), columnCount);

            columnCount++;

            #region Manual
            //switch (e.Column.Header.ToString())
            //{
            //    case "ObjectID":
            //        e.Column.DisplayIndex = 0;
            //        e.Column.Header = "شناسه";
            //        break;
            //    case "ImageID":
            //        e.Column.DisplayIndex = 1;
            //        e.Column.Header = "شناسه تصویر";
            //        break;
            //    case "ImageFormat":
            //        e.Column.DisplayIndex = 2;
            //        e.Column.Header = "فرمت تصویر";
            //        break;
            //    case "ProjEPSG":
            //        e.Column.DisplayIndex = 3;
            //        e.Column.Header = "سیستم تصویر EPSG";
            //        break;
            //    case "ProjSystem":
            //        e.Column.DisplayIndex = 4;
            //        e.Column.Header = "سیستم تصویر";
            //        break;
            //    case "ProjZone":
            //        e.Column.DisplayIndex = 5;
            //        e.Column.Header = "زون سیستم تصویر";
            //        break;
            //    case "ProjElipse":
            //        e.Column.DisplayIndex = 6;
            //        e.Column.Header = "بیضوی سیستم تصویر";
            //        break;
            //    case "ProjDatum":
            //        e.Column.DisplayIndex = 7;
            //        e.Column.Header = "دیتوم سیستم تصویر";
            //        break;
            //    case "CentScale":
            //        e.Column.DisplayIndex = 8;
            //        e.Column.Header = "مقیاس";
            //        break;
            //    case "LatFirst":
            //        e.Column.DisplayIndex = 9;
            //        e.Column.Header = "عرض جغرافیایی ابتدایی";
            //        break;
            //    case "LatSecond":
            //        e.Column.DisplayIndex = 10;
            //        e.Column.Header = "عرض جغرافیایی انتهایی";
            //        break;
            //    case "CentMeridian":
            //        e.Column.DisplayIndex = 11;
            //        e.Column.Header = "نصف النهار مرکزی";
            //        break;
            //    case "LatOrigin":
            //        e.Column.DisplayIndex = 12;
            //        e.Column.Header = "عرض جغرافیایی مرکز";
            //        break;
            //    case "FalseEasting":
            //        e.Column.DisplayIndex = 13;
            //        e.Column.Header = "False Easting";
            //        break;
            //    case "FalseNorthing":
            //        e.Column.DisplayIndex = 14;
            //        e.Column.Header = "False Northing";
            //        break;
            //    case "PixelSize_X":
            //        e.Column.DisplayIndex = 15;
            //        e.Column.Header = "طول پیکسل سایز";
            //        break;
            //    case "PixelSize_Y":
            //        e.Column.DisplayIndex = 16;
            //        e.Column.Header = "عرض پیکسل سایز";
            //        break;
            //}
            #endregion
        }

        private void GetDistinctListsForComboBox(IList<ImageMetadatas> imageMetadatas)
        {
            try
            {
                SetComboBoxItemsSource((from p in imageMetadatas
                                        select p.CentMeridian.ToString()).Distinct().ToList<string>()
                , CentMeridianComboBox);
            }
            catch (Exception a)
            {
            }

            try
            {
                SetComboBoxItemsSource((from p in imageMetadatas
                                        select p.CentScale.ToString()).Distinct().ToList<string>()
                , CentScaleComboBox);
            }
            catch (Exception a)
            {
            }

            try
            {
                SetComboBoxItemsSource((from p in imageMetadatas
                                        select p.FalseEasting.ToString()).Distinct().ToList<string>()
                , FalseEastingComboBox);
            }
            catch (Exception a)
            {
            }

            try
            {
                SetComboBoxItemsSource((from p in imageMetadatas
                                        select p.FalseNorthing.ToString()).Distinct().ToList<string>()
                , FalseNorthingComboBox);
            }
            catch (Exception a)
            {
            }

            try
            {
                SetComboBoxItemsSource((from p in imageMetadatas
                                        select p.ImageFormat.ToString()).Distinct().ToList<string>()
                , ImageFormatComboBox);
            }
            catch (Exception a)
            {
            }

            try
            {
                SetComboBoxItemsSource((from p in imageMetadatas
                                        select p.ImageID.ToString()).Distinct().ToList<string>()
                , ImageIDComboBox);
            }
            catch (Exception a)
            {
            }

            try
            {
                SetComboBoxItemsSource((from p in imageMetadatas
                                        select p.LatFirst.ToString()).Distinct().ToList<string>()
                , Lat1stComboBox);
            }
            catch (Exception a)
            {
            }

            try
            {
                SetComboBoxItemsSource((from p in imageMetadatas
                                        select p.LatOrigin.ToString()).Distinct().ToList<string>()
                , LatOriginComboBox);
            }
            catch (Exception a)
            {
            }

            try
            {
                SetComboBoxItemsSource((from p in imageMetadatas
                                        select p.LatSecond.ToString()).Distinct().ToList<string>()
                , Lat2ndComboBox);
            }
            catch (Exception a)
            {
            }

            try
            {
                SetComboBoxItemsSource((from p in imageMetadatas
                                        select p.PixelSize_X.ToString()).Distinct().ToList<string>()
                , PixelSize_XComboBox);
            }
            catch (Exception a)
            {
            }

            try
            {
                SetComboBoxItemsSource((from p in imageMetadatas
                                        select p.PixelSize_Y.ToString()).Distinct().ToList<string>()
                , PixelSize_YComboBox);
            }
            catch (Exception a)
            {
            }

            try
            {
                SetComboBoxItemsSource((from p in imageMetadatas
                                        select p.ProjDatum.ToString()).Distinct().ToList<string>()
                , ProjDatumComboBox);
            }
            catch (Exception a)
            {
            }

            try
            {
                SetComboBoxItemsSource((from p in imageMetadatas
                                        select p.ProjElipse).Distinct().ToList<string>()
                , ProjElipseComboBox);
            }
            catch (Exception a)
            {
            }

            try
            {
                SetComboBoxItemsSource((from p in imageMetadatas
                                        select p.ProjEPSG.ToString()).Distinct().ToList<string>()
                , ProjEPSGComboBox);
            }
            catch (Exception a)
            {
            }

            try
            {
                SetComboBoxItemsSource((from p in imageMetadatas
                                        select p.ProjSystem.ToString()).Distinct().ToList<string>()
                , ProjSystemComboBox);
            }
            catch (Exception a)
            {
            }

            try
            {
                SetComboBoxItemsSource((from p in imageMetadatas
                                        select p.ProjZone.ToString()).Distinct().ToList<string>()
                , ProjZoneComboBox);
            }
            catch (Exception a)
            {
            }

            CreateAllComboBoxesList();
        }

        private void CreateAllComboBoxesList()
        {
            allComboBoxesList.Add(CentMeridianComboBox);
            allComboBoxesList.Add(CentScaleComboBox);
            allComboBoxesList.Add(FalseEastingComboBox);
            allComboBoxesList.Add(FalseNorthingComboBox);
            allComboBoxesList.Add(ImageFormatComboBox);
            allComboBoxesList.Add(ImageIDComboBox);
            allComboBoxesList.Add(Lat1stComboBox);
            allComboBoxesList.Add(LatOriginComboBox);
            allComboBoxesList.Add(Lat2ndComboBox);
            allComboBoxesList.Add(PixelSize_XComboBox);
            allComboBoxesList.Add(PixelSize_YComboBox);
            allComboBoxesList.Add(ProjDatumComboBox);
            allComboBoxesList.Add(ProjElipseComboBox);
            allComboBoxesList.Add(ProjEPSGComboBox);
            allComboBoxesList.Add(ProjSystemComboBox);
            allComboBoxesList.Add(ProjZoneComboBox);
        }

        private void SetComboBoxItemsSource(List<string> itemsSource, ComboBox combobox)
        {
            if (AndOperator.IsChecked == true)
            {
                itemsSource.Insert(0, "همه موارد");
            }
            else
            {
                itemsSource.Insert(0, "هیچ کدام");
            }

            combobox.ItemsSource = itemsSource;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ImageMetadataDomainDataSource.FilterDescriptors.Clear();
            }
            catch (Exception ee)
            {
            }

            #region Filter Descriptors

            //ImageID
            try
            {
                if (ImageIDComboBox.SelectedIndex > 0)
                {
                    string imageIDFilter = ImageIDComboBox.SelectedItem.ToString();
                    FilterDescriptor imageIDFilterDescriptor = new FilterDescriptor("ImageID", FilterOperator.IsEqualTo, imageIDFilter);
                    ImageMetadataDomainDataSource.FilterDescriptors.Add(imageIDFilterDescriptor);
                }
            }
            catch (Exception ee)
            {
            }

            //ImageFormat
            try
            {
                if (ImageFormatComboBox.SelectedIndex > 0)
                {
                    string ImageFormatFilter = ImageFormatComboBox.SelectedItem.ToString();
                    FilterDescriptor ImageFormatFilterDescriptor = new FilterDescriptor("ImageFormat", FilterOperator.IsEqualTo, ImageFormatFilter);
                    ImageMetadataDomainDataSource.FilterDescriptors.Add(ImageFormatFilterDescriptor);
                }
            }
            catch (Exception ee)
            {
            }

            //ProjEPSG
            try
            {
                if (ProjEPSGComboBox.SelectedIndex > 0)
                {
                    string ProjEPSGFilter = ProjEPSGComboBox.SelectedItem.ToString();
                    FilterDescriptor ProjEPSGFilterDescriptor = new FilterDescriptor("ProjEPSG", FilterOperator.IsEqualTo, ProjEPSGFilter);
                    ImageMetadataDomainDataSource.FilterDescriptors.Add(ProjEPSGFilterDescriptor);
                }
            }
            catch (Exception ee)
            {
            }

            //ProjSystem
            try
            {
                if (ProjSystemComboBox.SelectedIndex > 0)
                {
                    string ProjSystemFilter = ProjSystemComboBox.SelectedItem.ToString();
                    FilterDescriptor ProjSystemFilterDescriptor = new FilterDescriptor("ProjSystem", FilterOperator.IsEqualTo, ProjSystemFilter);
                    ImageMetadataDomainDataSource.FilterDescriptors.Add(ProjSystemFilterDescriptor);
                }
            }
            catch (Exception ee)
            {
            }

            //ProjZone
            try
            {
                if (ProjZoneComboBox.SelectedIndex > 0)
                {
                    string ProjZoneFilter = ProjZoneComboBox.SelectedItem.ToString();
                    FilterDescriptor ProjZoneFilterDescriptor = new FilterDescriptor("ProjZone", FilterOperator.IsEqualTo, ProjZoneFilter);
                    ImageMetadataDomainDataSource.FilterDescriptors.Add(ProjZoneFilterDescriptor);
                }
            }
            catch (Exception ee)
            {
            }

            //ProjElipse
            try
            {
                if (ProjElipseComboBox.SelectedIndex > 0)
                {
                    string ProjElipseFilter = ProjElipseComboBox.SelectedItem.ToString();
                    FilterDescriptor ProjElipseFilterDescriptor = new FilterDescriptor("ProjElipse", FilterOperator.IsEqualTo, ProjElipseFilter);
                    ImageMetadataDomainDataSource.FilterDescriptors.Add(ProjElipseFilterDescriptor);
                }
            }
            catch (Exception ee)
            {
            }

            //ProjDatum
            try
            {
                if (ProjDatumComboBox.SelectedIndex > 0)
                {
                    string ProjDatumFilter = ProjDatumComboBox.SelectedItem.ToString();
                    FilterDescriptor ProjDatumFilterDescriptor = new FilterDescriptor("ProjDatum", FilterOperator.IsEqualTo, ProjDatumFilter);
                    ImageMetadataDomainDataSource.FilterDescriptors.Add(ProjDatumFilterDescriptor);
                }
            }
            catch (Exception ee)
            {
            }

            //CentScale
            try
            {
                if (CentScaleComboBox.SelectedIndex > 0)
                {
                    string CentScaleFilter = CentScaleComboBox.SelectedItem.ToString();
                    FilterDescriptor CentScaleFilterDescriptor = new FilterDescriptor("CentScale", FilterOperator.IsEqualTo, CentScaleFilter);
                    ImageMetadataDomainDataSource.FilterDescriptors.Add(CentScaleFilterDescriptor);
                }
            }
            catch (Exception ee)
            {
            }

            //Lat1st
            try
            {
                if (Lat1stComboBox.SelectedIndex > 0)
                {
                    string Lat1stFilter = Lat1stComboBox.SelectedItem.ToString();
                    FilterDescriptor Lat1stFilterDescriptor = new FilterDescriptor("LatFirst", FilterOperator.IsEqualTo, Lat1stFilter);
                    ImageMetadataDomainDataSource.FilterDescriptors.Add(Lat1stFilterDescriptor);
                }
            }
            catch (Exception ee)
            {
            }

            //Lat2nd
            try
            {
                if (Lat2ndComboBox.SelectedIndex > 0)
                {
                    string Lat2ndFilter = Lat2ndComboBox.SelectedItem.ToString();
                    FilterDescriptor Lat2ndFilterDescriptor = new FilterDescriptor("LatSecond", FilterOperator.IsEqualTo, Lat2ndFilter);
                    ImageMetadataDomainDataSource.FilterDescriptors.Add(Lat2ndFilterDescriptor);
                }
            }
            catch (Exception ee)
            {
            }

            //CentMeridian
            try
            {
                if (CentMeridianComboBox.SelectedIndex > 0)
                {
                    string CentMeridianFilter = CentMeridianComboBox.SelectedItem.ToString();
                    FilterDescriptor CentMeridianFilterDescriptor = new FilterDescriptor("CentMeridian", FilterOperator.IsEqualTo, CentMeridianFilter);
                    ImageMetadataDomainDataSource.FilterDescriptors.Add(CentMeridianFilterDescriptor);
                }
            }
            catch (Exception ee)
            {
            }

            //LatOrigin
            try
            {
                if (LatOriginComboBox.SelectedIndex > 0)
                {
                    string LatOriginFilter = LatOriginComboBox.SelectedItem.ToString();
                    FilterDescriptor LatOriginFilterDescriptor = new FilterDescriptor("LatOrigin", FilterOperator.IsEqualTo, LatOriginFilter);
                    ImageMetadataDomainDataSource.FilterDescriptors.Add(LatOriginFilterDescriptor);
                }
            }
            catch (Exception ee)
            {
            }

            //FalseEasting
            try
            {
                if (FalseEastingComboBox.SelectedIndex > 0)
                {
                    string FalseEastingFilter = FalseEastingComboBox.SelectedItem.ToString();
                    FilterDescriptor FalseEastingFilterDescriptor = new FilterDescriptor("FalseEasting", FilterOperator.IsEqualTo, FalseEastingFilter);
                    ImageMetadataDomainDataSource.FilterDescriptors.Add(FalseEastingFilterDescriptor);
                }
            }
            catch (Exception ee)
            {
            }

            //FalseNorthing
            try
            {
                if (FalseNorthingComboBox.SelectedIndex > 0)
                {
                    string FalseNorthingFilter = FalseNorthingComboBox.SelectedItem.ToString();
                    FilterDescriptor FalseNorthingFilterDescriptor = new FilterDescriptor("FalseNorthing", FilterOperator.IsEqualTo, FalseNorthingFilter);
                    ImageMetadataDomainDataSource.FilterDescriptors.Add(FalseNorthingFilterDescriptor);
                }
            }
            catch (Exception ee)
            {
            }

            //PixelSize_X
            try
            {
                if (PixelSize_XComboBox.SelectedIndex > 0)
                {
                    string PixelSize_XFilter = PixelSize_XComboBox.SelectedItem.ToString();
                    FilterDescriptor PixelSize_XFilterDescriptor = new FilterDescriptor("PixelSize_X", FilterOperator.IsEqualTo, PixelSize_XFilter);
                    ImageMetadataDomainDataSource.FilterDescriptors.Add(PixelSize_XFilterDescriptor);
                }
            }
            catch (Exception ee)
            {
            }

            //PixelSize_Y
            try
            {
                if (PixelSize_YComboBox.SelectedIndex > 0)
                {
                    string PixelSize_YFilter = PixelSize_YComboBox.SelectedItem.ToString();
                    FilterDescriptor PixelSize_YFilterDescriptor = new FilterDescriptor("PixelSize_Y", FilterOperator.IsEqualTo, PixelSize_YFilter);
                    ImageMetadataDomainDataSource.FilterDescriptors.Add(PixelSize_YFilterDescriptor);
                }
            }
            catch (Exception ee)
            {
            }

            ImageMetadataDomainDataSource.Load();
            //ImageMetadataDataPager.Source = ImageMetadataDomainDataSource.Data;

            #endregion
        }

        private void AndOperator_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                ImageMetadataDomainDataSource.FilterOperator = FilterDescriptorLogicalOperator.And;

                if (isComboBoxFilled)
                {
                    SetAndOperator(allComboBoxesList);
                }

                ImageMetadataDomainDataSource.Load();
            }
            catch (Exception a)
            {
            }
        }
        private void OrOperator_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                ImageMetadataDomainDataSource.FilterOperator = FilterDescriptorLogicalOperator.Or;

                if (isComboBoxFilled)
                {
                    SetOrOperator(allComboBoxesList);
                }

                ImageMetadataDomainDataSource.Load();
            }
            catch (Exception a)
            {
            }
        }

        private void SetOrOperator(List<ComboBox> all)
        {
            foreach (ComboBox combobox in all)
            {
                try
                {
                    List<string> itemsSource = new List<string>();
                    itemsSource = combobox.ItemsSource.OfType<string>().ToList<string>();

                    itemsSource[0] = "هیچ کدام";

                    combobox.ItemsSource = itemsSource;
                }
                catch (Exception a)
                {
                }
            }
        }
        private void SetAndOperator(List<ComboBox> all)
        {
            foreach (ComboBox combobox in all)
            {
                try
                {
                    List<string> itemsSource = new List<string>();
                    itemsSource = combobox.ItemsSource.OfType<string>().ToList<string>();

                    itemsSource[0] = "همه موارد";

                    combobox.ItemsSource = itemsSource;
                }
                catch (Exception a)
                {
                }
            }
        }

        private void temporary_Click(object sender, RoutedEventArgs e)
        {
            //TODO
            MessageWindow win = new MessageWindow();
            win.messageTextBlock.Text = ApplicationStrings.msgNotProperAccessLevel;
            win.Show();
        }

        #endregion

        #region Export2Excel

        private void Export2ExcelImageMetadataButton_Click(object sender, RoutedEventArgs e)
        {
            Export2Excel(imageMetadatas, "Custom");
        }

        private void Export2Excel(IEnumerable metadata, string workSheetName)
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

                //var a = ImageMetadataDomainDataSource.DataView.GetItemAt(0).GetType().GetProperties();

                //List<PropertyInfo> props = a.ToList<PropertyInfo>();

                //foreach (PropertyInfo item in props)
                //{
                //    try
                //    {
                //        ImageMetadataDomainDataSource.DataView.GetItemAt(0).GetType().GetP
                //        item.Name;
                //    }
                //    catch (Exception e1)
                //    {
                //    }
                //}



                //IEnumerable source = ImageMetadataDataGrid.ItemsSource;

                //DomainDataSourceView view = (DomainDataSourceView)ImageMetadataDataGrid.ItemsSource;

                //var aa = view[1];

                int counter = 0;

                foreach (DataGridColumn column in ImageMetadataDataGrid.Columns)
                {
                    //PropertyInfo property = row.GetType().GetProperty(f2e[column.Header.ToString()]);

                    //string cellValue = property.GetValue(row, null).ToString();

                    worksheet.Cells[0, counter] = new Cell(column.Header.ToString());

                    counter++;
                }

                int rowCounter = 0;

                foreach (var row in metadata)
                {
                    int columnCounter = 0;

                    foreach (DataGridColumn column in ImageMetadataDataGrid.Columns)
                    {
                        try
                        {
                            PropertyInfo property = row.GetType().GetProperty(farsiFieldName2englishFieldName[column.Header.ToString()]);

                            string cellValue = property.GetValue(row, null).ToString();

                            worksheet.Cells[rowCounter + 1, columnCounter] = new Cell(cellValue);
                        }
                        catch (Exception a)
                        {
                        }
                        columnCounter++;
                    }
                    //IEnumerable a = (IEnumerable)item0;

                    //foreach (var item in item0)
                    //{
                    //    try
                    //    {
                    //        queryBuilderWorksheet.Cells[i0 + 1, j0] = new Cell(item.ToString());
                    //    }
                    //    catch (Exception qq)
                    //    {
                    //    }
                    //    j0++;
                    //}
                    rowCounter++;
                }



                //for (int i = 0; i < metadata.Count; i++)
                //{
                //    for (int j = 0; j < columnCount; j++)
                //    {
                //        try
                //        {
                //            queryBuilderWorksheet.Cells[i + 1, j] = new Cell("");
                //        }
                //        catch (Exception qq)
                //        {
                //        }
                //    }
                //}



                //for (int i = 0; i < metadata.Count; i++)
                //{
                //    //List<object> o = (List<object>)metadata[i];



                //    for (int j = 0; j < columnCount; j++)
                //    {

                //    }
                //}

                //add worksheet to workbook
                workbook.Worksheets.Add(worksheet);

                // get the selected file's stream
                Stream sFile = sDialog.OpenFile();
                workbook.Save(sFile);

                MessageWindow win = new MessageWindow();
                win.messageTextBlock.Text = ApplicationStrings.msgFileSaved;
                win.Show();
            }
        }

        #endregion
    }
}
