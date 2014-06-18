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
using LanSysWebGIS.Helpers;
using LanSysWebGIS.Web;
using System.Windows.Data;

namespace LanSysWebGIS.Views.UserManagement
{
    public partial class ShowOnlineUsersWindow : ChildWindow
    {
        private string[] userRolesStrings = new string[10];

        private UserRegistrationContext userRegistrationContext = new UserRegistrationContext();

        public ShowOnlineUsersWindow()
        {
            InitializeComponent();

            //OnlineUsersDomainDataSource.Load();

            //userRolesStrings = Enum.GetNames(typeof(UserRole));

            InvokeOperation<string[]> io = userRegistrationContext.GetAllRoles();

            io.Completed += (sender, e1) =>
            {
                if (!io.HasError)
                {
                    userRolesStrings = io.Value;

                    FillComboBox();

                }
            };

        }

        //private void OKButton_Click(object sender, RoutedEventArgs e)
        //{
        //    this.DialogResult = true;
        //}

        //private void CancelButton_Click(object sender, RoutedEventArgs e)
        //{
        //    this.DialogResult = false;
        //}

        private void SearchByRoleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OnlineUsersDomainDataSource.FilterDescriptors.Clear();

            if (SearchByRoleComboBox.SelectedIndex != 0)
            {
                ComboBoxItem comboBoxItem = (ComboBoxItem)SearchByRoleComboBox.SelectedItem;
                string filter = comboBoxItem.Content.ToString();

                //UserRole userRole = AccessProfile.SelectRole(filter);

                FilterDescriptor filterDescriptor = new FilterDescriptor("UserRole", FilterOperator.IsEqualTo, filter);

                OnlineUsersDomainDataSource.FilterDescriptors.Add(filterDescriptor);
            }

            OnlineUsersDomainDataSource.Load();
        }

        private void OnlineUsersDomainDataSource_LoadedData(object sender, LoadedDataEventArgs e)
        {
            //todo get total count of online users

            PagedCollectionView pcv = new PagedCollectionView(OnlineUsersDomainDataSource.Data.OfType<CustomizedProfile>());

            numberOfOnlineUsers.Text = pcv.Count.ToString();

            //UsersManagementSearchButton.IsEnabled = true;

            //if (UsersDomainDataSource.Data.OfType<CustomizedProfile>().Count() == 0)
            //{
            //    MessageWindow messageWindow = new MessageWindow();

            //    messageWindow.Show();
            //}

            //MessageBox.Show(UsersDataPager..ToString());

            //FillSearchByComboBox();
            //isDataLoaded = false;
        }

        private void FillComboBox()
        {
            ComboBoxItem item0 = new ComboBoxItem();
            item0.Content = "تمام گروههای کاربری";

            SearchByRoleComboBox.Items.Add(item0);

            SearchByRoleComboBox.SelectedIndex = 0;

            foreach (var userRolesString in userRolesStrings)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = userRolesString;

                SearchByRoleComboBox.Items.Add(item);
            }
        }

        //private void OnlineUsersDomainDataSource_LoadingData(object sender, LoadingDataEventArgs e)
        //{
        //    //e.MergeOption = MergeOption.OverwriteCurrentValues;

        //    e.LoadBehavior = LoadBehavior.RefreshCurrent;
        //}

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            OnlineUsersDomainDataSource.Load();
        }

        private void ChildWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
            else if (e.Key == Key.Enter)
            {
                this.RefreshButton_Click(sender, e);
            }
        }
    }
}

