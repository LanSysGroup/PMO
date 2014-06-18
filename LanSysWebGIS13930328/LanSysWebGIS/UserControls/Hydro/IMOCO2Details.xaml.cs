using LanSysWebGIS.Presenter.Hydro;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace LanSysWebGIS.UserControls.Hydro
{
    public partial class IMOCO2Details : UserControl
    {
        IMOPresenter Presenter { get { return this.DataContext as IMOPresenter; } }

        public IMOCO2Details()
        {
            InitializeComponent();
        }

        public Web.DetailsOfCO2InjectionWell SelectedDetailsOfCO2InjectionWell
        {
            get { return injectionWellsDataGrid.SelectedItem as Web.DetailsOfCO2InjectionWell; }
        }


        private void addChemicalComposition_Click(object sender, RoutedEventArgs e)
        {
            if (this.DataContext == null)
            {
                return;
            }

            this.Presenter.CurrentDetailsOfCO2.DetailsOfCO2Chamical.Add(new Web.DetailsOfCO2Chamical() { DetailsOfCO2Id = this.Presenter.CurrentDetailsOfCO2.Id });
        }

        private void removeChemicalComposition_Click(object sender, RoutedEventArgs e)
        {
            if (this.chemicalCompositionDataGrid.SelectedItem == null)
            {
                return;
            }

            this.Presenter.RemoveDetailsOfCO2Chamical(this.chemicalCompositionDataGrid.SelectedItem as Web.DetailsOfCO2Chamical);

            //this.Presenter.CurrentDetailsOfCO2.DetailsOfCO2Chamical.Remove(this.chemicalCompositionDataGrid.SelectedItem as Web.DetailsOfCO2Chamical);
        }

        private void addInjectionWell_Click(object sender, RoutedEventArgs e)
        {
            if (this.DataContext == null)
            {
                return;
            }

            this.Presenter.CurrentDetailsOfCO2.DetailsOfCO2InjectionWell.Add(new Web.DetailsOfCO2InjectionWell() { DetailsOfCO2Id = this.Presenter.CurrentDetailsOfCO2.Id });
        }

        private void removeInjectionWell_Click(object sender, RoutedEventArgs e)
        {
            if (this.injectionWellsDataGrid.SelectedItem == null)
            {
                return;
            }
            //System.Diagnostics.Debug.WriteLine(new StackTrace().GetFrame(0).GetMethod().Name + " started before remove");

            //foreach (var item in this.Presenter.DetailsOfCO2InjectionWell)
            //{
            //    System.Diagnostics.Debug.WriteLine("DOCO2 Id: " + item.DetailsOfCO2Id + " Well: " + item.InjectionWell);
            //}

            //this.Presenter.CurrentDetailsOfCO2.DetailsOfCO2InjectionWell.Remove(this.SelectedDetailsOfCO2InjectionWell);

            this.Presenter.RemoveDetailsOfCO2InjectionWell(this.SelectedDetailsOfCO2InjectionWell);

            //System.Diagnostics.Debug.WriteLine(string.Empty);
            //System.Diagnostics.Debug.WriteLine(new StackTrace().GetFrame(0).GetMethod().Name + " started after remove");

            //foreach (var item in this.Presenter.DetailsOfCO2InjectionWell)
            //{
            //    System.Diagnostics.Debug.WriteLine("DOCO2 Id: " + item.DetailsOfCO2Id + " Well: " + item.InjectionWell);
            //}

            //System.Diagnostics.Debug.WriteLine(new StackTrace().GetFrame(0).GetMethod().Name + " ended");

        }
    }
}
