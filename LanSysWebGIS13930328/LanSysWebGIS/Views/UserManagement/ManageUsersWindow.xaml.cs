using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.DomainServices.Client;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.ComponentModel.DataAnnotations;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using LanSysWebGIS.Assets.Resources;
using LanSysWebGIS.Web;
using LanSysWebGIS.Web.Models;
using LanSysWebGIS.Helpers;
using LanSysWebGIS.Web.Resources;

namespace LanSysWebGIS.Views.UserManagement
{
    public partial class ManageUsersWindow : ChildWindow
    {
        #region Fields & Properties

        //private string[] userRolesStrings = new string[10];

        private UserRegistrationContext userRegistrationContext = new UserRegistrationContext();

        //private string[] userOrganizationsStrings = new string[20];

        //private DBDomainContext dbContext = new DBDomainContext();
        private PMOContext dbContext = new PMOContext();

        public static CustomizedProfile selectedUser;

        private MessageWindow messageWindow;

        private string operationName = "";

        private bool PasswordResetedSuccessfully = false;

        private Dictionary<string, string> fieldAlias2fieldName = new Dictionary<string, string>()
                                                                      {
                                                                          {"نام","UserFirstName"},
                                                                          {"نام خانوادگی","UserLastName"},
                                                                          {"نام کاربری","UserName"},
                                                                          {"پست الکترونیک","UserEmail"},
                                                                          {"اداره","UserOrganization"},
                                                                          {"نقش","UserRole"},
                                                                          {"توضیحات","UserComment"},
                                                                          {"شناسه","UserID"}
                                                                      };

        private int fieldCount = 0;

        private List<string> fields = new List<string>
                                      {
                                          "UserFirstName",
                                          "UserLastName",
                                          "UserName",
                                          "UserEmail",
                                          "UserOrganization",
                                          "UserRole",
                                          "UserComment",
                                          "UserID"
                                      };

        private EditUserWindow editUserWindow;

        #endregion

        #region Initializing

        public ManageUsersWindow()
        {
            InitializeComponent();

            UsersDomainDataSource.Load();

            UsersDomainDataSource.SubmittedChanges += UsersDomainDataSource_SubmittedChanges;

            //InvokeOperation<string[]> io = userRegistrationContext.GetAllRoles();

            //io.Completed += (sender, e1) =>
            //{
            //    if (!io.HasError)
            //    {
            //        userRolesStrings = io.Value;
            //    }
            //};

            //dbContext.Load(dbContext.GetOrganizationsQuery(), LoadBehavior.RefreshCurrent,
            //                            callback =>
            //                            {
            //                                userOrganizationsStrings =
            //                                    dbContext.Organizations.Select(o => o.NameFa.ToString()).ToArray();
            //                            }, null);
        }

        private void UsersDomainDataSource_LoadedData(object sender, LoadedDataEventArgs e)
        {
            UsersManagementSearchButton.IsEnabled = true;

            if (UsersDomainDataSource.Data.OfType<CustomizedProfile>().Count() == 0)
            {
                MessageWindow messageWindow = new MessageWindow();

                messageWindow.Show();
            }
        }

        private void UsersDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (fieldCount < fields.Count)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = e.Column.Header.ToString();

                SearchByComboBox.Items.Add(item);
            }

            fieldCount++;
        }

        #endregion

        //private void FillSearchByComboBox()
        //{
        //    //fieldAlias2fieldName

        //    //todo by reflection



        //    int i = 0;

        //    foreach (var column in UsersDataGrid.Columns)
        //    {
        //        ComboBoxItem item = new ComboBoxItem();
        //        item.Content = column.Header.ToString();

        //        SearchByComboBox.Items.Add(item);

        //        fieldAlias2fieldName.Add(column.Header.ToString(),fields[i++]);
        //    }
        //}



        //private void OKButton_Click(object sender, RoutedEventArgs e)
        //{
        //    this.DialogResult = true;
        //}

        //private void CancelButton_Click(object sender, RoutedEventArgs e)
        //{
        //    this.DialogResult = false;
        //}

        #region Search User

        private void UsersManagementSearchButton_Click(object sender, RoutedEventArgs e)
        {
            SearchUser();
        }

        private void SearchUser()
        {
            if (SearchByComboBox.SelectedIndex < 0)
            {
                SearchByComboBox.SelectedIndex = 0;
            }

            ComboBoxItem comboBoxItem = (ComboBoxItem)SearchByComboBox.SelectedItem;
            string filter = comboBoxItem.Content.ToString();

            UsersDomainDataSource.FilterDescriptors.Clear();

            if (!String.IsNullOrEmpty(filter))
            {
                FilterDescriptor filterDescriptor;

                filterDescriptor = new FilterDescriptor(fieldAlias2fieldName[filter], FilterOperator.Contains,
                                                        UsersManagementTextBox.Text);

                UsersDomainDataSource.FilterDescriptors.Add(filterDescriptor);

                UsersDataGrid.ItemsSource = UsersDomainDataSource.Data;
            }

            UsersDomainDataSource.Load();
        }

        #endregion

        #region Create User

        private void NewUserButton_Click(object sender, RoutedEventArgs e)
        {
            CreateUserWindow createUserWindow = new CreateUserWindow();

            createUserWindow.Show();

            createUserWindow.Closed += createUserWindow_Closed;
        }
        private void createUserWindow_Closed(object sender, EventArgs e)
        {
            UsersDomainDataSource.Load();
        }

        #endregion

        #region Edit User

        private void EditUserButton_Click(object sender, RoutedEventArgs e)
        {
            editUserWindow = new EditUserWindow();

            editUserWindow.editUserForm.editForm.CurrentItem = UsersDataGrid.SelectedItem;

            editUserWindow.Closed += editUserWindow_Closed;

            editUserWindow.Show();
        }

        private void editUserWindow_Closed(object sender, EventArgs e)
        {
            selectedUser = (CustomizedProfile)UsersDataGrid.SelectedItem;

            if (editUserWindow.DialogResult == true)
            {
                AuthenticationContext context = new AuthenticationContext();

                CustomizedProfile editedUser = (CustomizedProfile)editUserWindow.editUserForm.editForm.CurrentItem;

                UsersDomainDataSource.SubmitChanges();

            }
            else if (editUserWindow.DialogResult == false)
            {
                UsersDomainDataSource.RejectChanges();
            }

            //while (!UsersDomainDataSource.CanLoad)
            //{

            //}

            //UsersDomainDataSource.Load();
        }

        #endregion

        #region Delete User

        private void DeleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            operationName = "DeleteUser";

            DeleteSelectedUser();
        }

        private void DeleteSelectedUser()
        {
            selectedUser = (CustomizedProfile)UsersDataGrid.SelectedItem;

            if (selectedUser == null)
            {
                throw new Exception("ابتدا باید یک کاربر را انتخاب کنید");
            }

            messageWindow = new MessageWindow();

            messageWindow.CancelButton.Visibility = Visibility.Visible;

            messageWindow.messageTextBlock.Text = ApplicationStrings.DeleteUser;

            messageWindow.Closed += messageWindow_Closed;

            messageWindow.Show();
        }

        #endregion

        #region Reset Password

        private void ResetPasswordButton_Click(object sender, RoutedEventArgs e)
        {
            operationName = "ResetPassword";

            selectedUser = (CustomizedProfile)UsersDataGrid.SelectedItem;

            if (selectedUser == null)
            {
                throw new Exception("ابتدا باید یک کاربر را انتخاب کنید");
            }

            messageWindow = new MessageWindow();

            messageWindow.CancelButton.Visibility = Visibility.Visible;

            messageWindow.messageTextBlock.Text = ApplicationStrings.ResetPasswordAsk;

            messageWindow.Closed += messageWindow_Closed;

            messageWindow.Show();
        }

        private void ResetPassword()
        {
            this.busyIndicator1.IsBusy = true;

            InvokeOperation resetPasswordOperation = userRegistrationContext.ResetPassword(selectedUser.UserName, selectedUser.UserEmail);

            resetPasswordOperation.Completed += (sender2, e1) =>
            {
                if (!resetPasswordOperation.HasError)
                {
                    PasswordResetedSuccessfully = (bool)resetPasswordOperation.Value;

                    operationName = "";

                    messageWindow = new MessageWindow();

                    if (PasswordResetedSuccessfully)
                    {

                        this.busyIndicator1.IsBusy = false;

                        //messageWindow.CancelButton.Visibility = Visibility.Visible;

                        messageWindow.messageTextBlock.Text = RegistrationDataResources.ResetPasswordSuccessfullyMessage;


                    }
                    else
                    {
                        this.busyIndicator1.IsBusy = false;

                        messageWindow.messageTextBlock.Text = RegistrationDataResources.ResetPasswordUnSuccessfullyMessage;
                    }


                    messageWindow.Closed += messageWindow_Closed;

                    messageWindow.Show();

                    //this.changePasswordInfo.IsChangingPasswordHelper = false;


                }
                else
                {
                    this.busyIndicator1.IsBusy = false;

                    operationName = "";

                    messageWindow = new MessageWindow();

                    messageWindow.messageTextBlock.Text = RegistrationDataResources.ResetPasswordUnSuccessfullyMessage;

                    messageWindow.Closed += messageWindow_Closed;

                    messageWindow.Show();
                }
            };
        }

        #endregion

        private void messageWindow_Closed(object sender, EventArgs e)
        {
            if (messageWindow.DialogResult == true)
            {
                if (operationName == "DeleteUser")
                {
                    //tempUser = (CustomizedProfile)(UsersDataGrid.SelectedItem);

                    UsersDomainDataSource.DataView.Remove(UsersDataGrid.SelectedItem);
                    
                    UsersDomainDataSource.SubmitChanges();
                }
                else if (operationName == "ResetPassword")
                {
                    ResetPassword();
                }
                else if (operationName == "ResetToDefaultPassword")
                {
                    ResetToDefaultPassword();
                }
                else if (String.IsNullOrEmpty(operationName))
                {

                }
            }
        }

        private void UsersDomainDataSource_SubmittedChanges(object sender, SubmittedChangesEventArgs e)
        {
            if (e.HasError)
            {
                MessageWindow win = new MessageWindow();
                win.messageTextBlock.Text = e.Error.ToString();
                win.Show();
            }
            else
            {
                if (operationName == "DeleteUser")
                {
                    dbContext.Load(dbContext.GetTblUsersQuery(), System.ServiceModel.DomainServices.Client.LoadBehavior.RefreshCurrent, callback =>
                    {
                        dbContext.tblUsers.Remove(dbContext.tblUsers.First(i => i.UsersID == int.Parse(selectedUser.UserID) && i.UserID == selectedUser.UserName));

                        dbContext.SubmitChanges(callback1 =>
                                                    {
                                                        if (callback1.HasError)
                                                        {
                                                            MessageWindow win = new MessageWindow();
                                                            win.messageTextBlock.Text = callback1.Error.ToString();
                                                            win.Show();
                                                        }
                                                        else
                                                        {

                                                        }
                                                    }, null);
                    }, null);

                }

                operationName = "";
            }
        }

        private void ChildWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                this.UsersManagementSearchButton_Click(sender, e);
            }
            else if (e.Key == Key.Escape)
            {
                this.Close();
            }

        }

        private void ChangePasswordButton_Click(object sender, RoutedEventArgs e)
        {
            operationName = "ResetToDefaultPassword";

            selectedUser = (CustomizedProfile)UsersDataGrid.SelectedItem;

            if (selectedUser == null)
            {
                throw new Exception("ابتدا باید یک کاربر را انتخاب کنید");
            }

            messageWindow = new MessageWindow();

            messageWindow.CancelButton.Visibility = Visibility.Visible;

            messageWindow.messageTextBlock.Text = ApplicationStrings.ResetPasswordAsk;

            messageWindow.Closed += messageWindow_Closed;

            messageWindow.Show();
        }
        private void ResetToDefaultPassword()
        {
            this.busyIndicator1.IsBusy = true;

            InvokeOperation resetPasswordOperation = userRegistrationContext.ChangePasswordByAdmin(selectedUser.UserName, "123");

            resetPasswordOperation.Completed += (sender2, e1) =>
            {
                if (!resetPasswordOperation.HasError)
                {
                    PasswordResetedSuccessfully = (bool)resetPasswordOperation.Value;

                    operationName = "";

                    messageWindow = new MessageWindow();

                    if (PasswordResetedSuccessfully)
                    {
                        this.busyIndicator1.IsBusy = false;

                        //messageWindow.CancelButton.Visibility = Visibility.Visible;

                        messageWindow.messageTextBlock.Text = RegistrationDataResources.ResetPasswordSuccessfullyMessage;

                    }
                    else
                    {
                        this.busyIndicator1.IsBusy = false;

                        messageWindow.messageTextBlock.Text = RegistrationDataResources.ResetPasswordUnSuccessfullyMessage;
                    }

                    messageWindow.Closed += messageWindow_Closed;

                    messageWindow.Show();

                    //this.changePasswordInfo.IsChangingPasswordHelper = false;
                }
                else
                {
                    this.busyIndicator1.IsBusy = false;

                    operationName = "";

                    messageWindow = new MessageWindow();

                    messageWindow.messageTextBlock.Text = RegistrationDataResources.ResetPasswordUnSuccessfullyMessage;

                    messageWindow.Closed += messageWindow_Closed;

                    messageWindow.Show();
                }
            };
        }
    }
}

