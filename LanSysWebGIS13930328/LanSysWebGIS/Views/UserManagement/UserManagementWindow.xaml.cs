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
using LanSysWebGIS.Helpers;
using LanSysWebGIS.Web;
using System.ServiceModel.DomainServices.Client;

namespace LanSysWebGIS.Views.UserManagement
{
    public partial class UserManagementWindow : ChildWindow
    {
        public UserManagementWindow()
        {
            InitializeComponent();

            if (AccessLevelChecker.CheckAuthentication(Constants.Administrator))
            {
            }

        }

        //private void OKButton_Click(object sender, RoutedEventArgs e)
        //{
        //    this.DialogResult = true;
        //}

        //private void CancelButton_Click(object sender, RoutedEventArgs e)
        //{
        //    this.DialogResult = false;
        //}

        private void createNewUserHButton_Click(object sender, RoutedEventArgs e)
        {
            if (AccessLevelChecker.CheckAuthentication(Constants.Administrator))
            {
                CreateUserWindow createUserWindow = new CreateUserWindow();

                createUserWindow.Show();
            }
        }

        private void manageUsersHButton_Click(object sender, RoutedEventArgs e)
        {
            if (AccessLevelChecker.CheckAuthentication(Constants.Administrator))
            {
                ManageUsersWindow manageUsersWindow = new ManageUsersWindow();

                manageUsersWindow.Show();
            }
        }

        private void manageRolesHButton_Click(object sender, RoutedEventArgs e)
        {
            if (AccessLevelChecker.CheckAuthentication(Constants.Administrator))
            {
                ManageRolesWindow manageRolesWindow = new ManageRolesWindow();

                manageRolesWindow.Show();
            }
        }

        private void showOnlineUsersHButton_Click(object sender, RoutedEventArgs e)
        {
            if (AccessLevelChecker.CheckAuthentication(Constants.Administrator))
            {
                ShowOnlineUsersWindow showOnlineUsersWindow = new ShowOnlineUsersWindow();

                showOnlineUsersWindow.Show();
            }
        }

        private void showLogHButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ChildWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }

        }

        private void CreateFormsHButton_Click(object sender, RoutedEventArgs e)
        {
            //DBDomainContext context = new DBDomainContext();
            PMOContext context = new PMOContext();

            try
            {
                context.Load(context.GetOrganizationsQuery(), LoadBehavior.RefreshCurrent,
                                        callback =>
                                        {
                                            //PMOContext context2 = new PMOContext();

                                            //foreach (var org in context.Organizations)
                                            //{
                                            //    //context2.GenerateDataForms("Unknown",org.NameFa);
                                            //}

                                        }, null);
            }
            catch (Exception)
            {

            }

            //context.GenerateDataForms(this.registrationData.UserName,
            //                          this.registrationData.Organization.ToString());
        }
    }
}

