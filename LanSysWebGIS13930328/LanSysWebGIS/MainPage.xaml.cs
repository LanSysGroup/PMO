using LanSysWebGIS.Models;
using LanSysWebGIS.Presenter;
using LanSysWebGIS.Presenter.Hydro;

namespace LanSysWebGIS
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Navigation;
    using LanSysWebGIS.LoginUI;
    using System;

    /// <summary>
    /// <see cref="UserControl"/> class providing the main UI for the application.
    /// </summary>
    public partial class MainPage : UserControl
    {

        public static Grid layoutRoot;

        public static DateTime CurrentDate;

        //public static BusyIndicator mainBusy = mainBusyIndicator;

        /// <summary>
        /// Creates a new <see cref="MainPage"/> instance.
        /// </summary>
        public MainPage()
        {
            InitializeComponent();

            MapOperations.mainBusy = mainBusyIndicator;
            ContourMapViewModel.ContourMapBusyIndicator = mainBusyIndicator;
            HydrographyToolsViewModel.ProfileBusyIndicator = mainBusyIndicator;
            AreaVolumeViewModel.AreaVolumeBusyIndicator = mainBusyIndicator;
            RasterComparisonViewModel.RasterComparisonBusyIndicator = mainBusyIndicator;

            layoutRoot = this.LayoutRoot;

            LanSysWebGIS.WebMethodsService.WebMethodsServiceSoapClient soap = new WebMethodsService.WebMethodsServiceSoapClient();

            soap.GetDateCompleted += soap_GetDateCompleted;

            soap.GetDateAsync();     
        }

        void soap_GetDateCompleted(object sender, WebMethodsService.GetDateCompletedEventArgs e)
        {
            CurrentDate = e.Result;
        }

        /// <summary>
        /// After the Frame navigates, ensure the <see cref="HyperlinkButton"/> representing the current page is selected
        /// </summary>
        //private void ContentFrame_Navigated(object sender, NavigationEventArgs e)
        //{
        //    foreach (UIElement child in LinksStackPanel.Children)
        //    {
        //        HyperlinkButton hb = child as HyperlinkButton;
        //        if (hb != null && hb.NavigateUri != null)
        //        {
        //            if (hb.NavigateUri.ToString().Equals(e.Uri.ToString()))
        //            {
        //                VisualStateManager.GoToState(hb, "ActiveLink", true);
        //            }
        //            else
        //            {
        //                VisualStateManager.GoToState(hb, "InactiveLink", true);
        //            }
        //        }
        //    }
        //}

        /// <summary>
        /// If an error occurs during navigation, show an error window
        /// </summary>
        private void ContentFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            //e.Handled = true;
            //ErrorWindow.CreateNew(e.Exception);
        }
    }
}