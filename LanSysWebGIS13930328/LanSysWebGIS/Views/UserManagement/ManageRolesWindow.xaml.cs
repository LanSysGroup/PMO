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

namespace LanSysWebGIS.Views.UserManagement
{
    public partial class ManageRolesWindow : ChildWindow
    {
        private string[] userRolesStrings = new string[10];

        private UserRegistrationContext userRegistrationContext = new UserRegistrationContext();

        public ManageRolesWindow()
        {
            InitializeComponent();

            //RolesDomainDataSource.Load();

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
            RolesDomainDataSource.FilterDescriptors.Clear();

            if (SearchByRoleComboBox.SelectedIndex != 0)
            {
                ComboBoxItem comboBoxItem = (ComboBoxItem)SearchByRoleComboBox.SelectedItem;
                string filter = comboBoxItem.Content.ToString();

                //UserRole userRole = AccessProfile.SelectRole(filter);

                FilterDescriptor filterDescriptor = new FilterDescriptor("UserRole", FilterOperator.IsEqualTo, filter);

                RolesDomainDataSource.FilterDescriptors.Add(filterDescriptor);
            }

            RolesDomainDataSource.Load();
        }

        private void RolesDomainDataSource_LoadedData(object sender, LoadedDataEventArgs e)
        {
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

        private void ChildWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }

        }
    }
}

