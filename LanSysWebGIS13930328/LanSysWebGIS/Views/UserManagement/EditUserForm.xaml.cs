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
using LanSysWebGIS.Web;

namespace LanSysWebGIS.Views.UserManagement
{
    public partial class EditUserForm : StackPanel
    {
        private EditUserWindow parentWindow;
        private CustomizedProfile customizedProfile = new CustomizedProfile();

        private UserRegistrationContext userRegistrationContext = new UserRegistrationContext();

        //private DBDomainContext dbContext = new DBDomainContext();
        private PMOContext dbContext = new PMOContext();

        /// <summary>
        /// Creates a new <see cref="EditUserForm"/> instance.
        /// </summary>
        public EditUserForm()
        {
            InitializeComponent();

            // Set the DataContext of this control to the Registration instance to allow for easy binding.
            this.DataContext = this.customizedProfile;

            //editForm.CommandButtonsVisibility = DataFormCommandButtonsVisibility.Commit;
        }

        /// <summary>
        /// Sets the parent window for the current <see cref="EditUserForm"/>.
        /// </summary>
        /// <param name="window">The window to use as the parent.</param>
        public void SetParentWindow(EditUserWindow window)
        {
            this.parentWindow = window;
        }

        /// <summary>
        /// Maps Esc to the cancel button and Enter to the OK button.
        /// </summary>
        private void EditUserForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.CancelButton_Click(sender, e);
            }
            else if (e.Key == Key.Enter && this.editButton.IsEnabled)
            {
                this.EditButton_Click(sender, e);
            }


        }

        private void EditUserForm_AutoGeneratingField(object sender, DataFormAutoGeneratingFieldEventArgs e)
        {
            if (e.PropertyName == "UserRole")
            {
                ComboBox roleComboBox = new ComboBox();

                InvokeOperation<string[]> io = userRegistrationContext.GetAllRoles();

                io.Completed += (sender2, e1) =>
                {
                    if (!io.HasError)
                    {
                        roleComboBox.ItemsSource = io.Value;

                        for (int i = 0; i < roleComboBox.Items.Count; i++)
                        {
                            if (roleComboBox.Items[i].ToString() == customizedProfile.UserRole)
                            {
                                roleComboBox.SelectedIndex = i;
                            }
                        }
                    }
                };

                e.Field.ReplaceTextBox(roleComboBox, ComboBox.SelectedItemProperty, binding => binding.Converter = new TargetNullValueConverter());

                //roleComboBox.SelectedIndex = 0;
            }
            else if (e.PropertyName == "UserOrganization")
            {
                ComboBox organizationComboBox = new ComboBox();

                dbContext.Load(dbContext.GetOrganizationsQuery(), LoadBehavior.RefreshCurrent,
                                        callback =>
                                        {
                                            organizationComboBox.ItemsSource =
                                                dbContext.Organizations.OrderBy(p => p.NameFa).Select(o => o.NameFa.ToString());

                                            for (int i = 0; i < organizationComboBox.Items.Count; i++)
                                            {
                                                if (organizationComboBox.Items[i].ToString() == customizedProfile.UserOrganization)
                                                {
                                                    organizationComboBox.SelectedIndex = i;
                                                }
                                            }
                                        }, null);

                e.Field.ReplaceTextBox(organizationComboBox, ComboBox.SelectedItemProperty, binding => binding.Converter = new TargetNullValueConverter());

                //organizationComboBox.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Submit changes.
        /// </summary>
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.editForm.ValidateItem())
            {
                editForm.CommitEdit();

                this.parentWindow.DialogResult = true;

                //this.parentWindow.AddPendingOperation(this.registrationData.CurrentOperation);
            }


        }

        /// <summary>
        /// If a edit operation is in progress and is cancellable, cancel it.
        /// Otherwise, close the window.
        /// </summary>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            //if (this.registrationData.CurrentOperation != null && this.registrationData.CurrentOperation.CanCancel)
            //{
            //    this.registrationData.CurrentOperation.Cancel();
            //}
            //else
            //{

            //}

            editForm.CancelEdit();

            this.parentWindow.DialogResult = false;
        }













        /// <summary>
        /// Sets focus to the user name text box.
        /// </summary>
        //public void SetInitialFocus()
        //{
        //    this.userNameTextBox.Focus();
        //}
    }
}
