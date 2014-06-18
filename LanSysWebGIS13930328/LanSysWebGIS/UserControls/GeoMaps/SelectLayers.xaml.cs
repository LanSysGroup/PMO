using System;
using System.Collections.Generic;
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
using LanSysWebGIS.Assets.Resources;
using LanSysWebGIS.Models;
using LanSysWebGIS.Views.UserManagement;
using LanSysWebGIS.Web;

namespace LanSysWebGIS.UserControls
{
    public partial class SelectLayers : UserControl
    {
        public SelectLayers()
        {
            InitializeComponent();

            PopulateForm();
        }

        private void PopulateForm()
        {
            layerStack.Children.Clear();

            foreach (var layer in MapControl.layersName2layersNumberDic)
            {
                CheckBox chk = new CheckBox();

                chk.Name = layer.Key;

                chk.Content = layer.Key;

                chk.Margin = new Thickness(5);

                layerStack.Children.Add(chk);
            }

            //Button but = new Button();

            //but.Content = ApplicationStrings.OKButton;

            //but.Click += ButOnClick;

            //but.Margin = new Thickness(5);

            //but.Width = 60;

            //but.HorizontalAlignment = HorizontalAlignment.Right;

            //rootStack.Children.Add(but);

            CheckLayerStatus();
        }

        public static GeoMapsDBDomainContext context;

        private void CheckLayerStatus()
        {
            //MapOperations.mainBusy.IsBusy = true;

            context = new GeoMapsDBDomainContext();

            context.Load(context.GetLayersWithDocQuery(), LoadBehavior.RefreshCurrent,
                                        callback =>
                                        {
                                            foreach (var layer in context.LayersWithDocs)
                                            {
                                                foreach (var chk in layerStack.Children.OfType<CheckBox>())
                                                {
                                                    if (chk.Name == layer.LayerName)
                                                    {
                                                        chk.IsChecked = true;
                                                    }
                                                }
                                            }

                                            //MapOperations.mainBusy.IsBusy = false;
                                        }, null);
        }

        private void ButOnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            MapOperations.mainBusy.IsBusy = true;

            if (layerStack.Children.OfType<CheckBox>().All(p => p.IsChecked == false))
            {
                MessageWindow win = new MessageWindow();
                win.messageTextBlock.Text = ApplicationStrings.msgSelectAtLeastOneLayer;
                win.Show();

                MapOperations.mainBusy.IsBusy = false;

                return;
            }

            context.ClearSelectedLayers();

            foreach (var layer in layerStack.Children.OfType<CheckBox>().Where(p => p.IsChecked == true).Select(i => new LayersWithDoc() { LayerName = i.Name }))
            {
                context.LayersWithDocs.Add(layer);
            }

            context.SubmitChanges(callback =>
            {
                ((ChildWin)((Grid)((StackPanel)ucSelectLayers.Parent).Parent).Parent).Close();

                MapOperations.mainBusy.IsBusy = false;
            }, null);
        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            this.layerStack.Children.OfType<CheckBox>().ToList<CheckBox>().ForEach(i => i.IsChecked = true);
        }

        private void CheckBox_Unchecked_1(object sender, RoutedEventArgs e)
        {
            this.layerStack.Children.OfType<CheckBox>().ToList<CheckBox>().ForEach(i => i.IsChecked = false);
        }

        private void CheckBox_Checked_2(object sender, RoutedEventArgs e)
        {
            List<CheckBox> chkList = new List<CheckBox>();

            chkList.AddRange(this.layerStack.Children.OfType<CheckBox>().Where(i => i.IsChecked == true));

            List<int> indexes = this.layerStack.Children.OfType<CheckBox>()
                .Where(i => i.IsChecked != true)
                .Select(i => this.layerStack.Children.IndexOf(i)).ToList();

            for (int i = indexes.Count- 1; i >= 0; i--)
            {
                layerStack.Children.RemoveAt(indexes[i]);
            }
            
            //rootStack Children

            //chkList.ForEach(p => rootStack.Children.Add(p));
        }

        private void CheckBox_Unchecked_2(object sender, RoutedEventArgs e)
        {
            PopulateForm();

            if (layerStack.Children.OfType<CheckBox>().All(p => p.IsChecked == true))
            {
                SelectAllLayers.IsChecked = true;
            }
            else
            {
                SelectAllLayers.IsChecked = false;
            }
        }
    }
}