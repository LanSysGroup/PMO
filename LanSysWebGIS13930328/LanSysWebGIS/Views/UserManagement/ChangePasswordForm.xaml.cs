using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.ServiceModel.DomainServices.Client;
using System.ServiceModel.DomainServices.Client.ApplicationServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using LanSysWebGIS.Assets.Resources;
using LanSysWebGIS.Models;
using LanSysWebGIS.Views.Login;
using LanSysWebGIS.Web;
using LanSysWebGIS.Web.Resources;
using System.Globalization;

namespace LanSysWebGIS.Views.UserManagement
{
    public partial class ChangePasswordForm : StackPanel
    {
        //todo
        private ChangePasswordWindow parentWindow;

        private ChangePasswordInfo changePasswordInfo = new ChangePasswordInfo();

        private UserRegistrationContext userRegistrationContext = new UserRegistrationContext();

        private bool PasswordChangedSuccessfully;

        private InvokeOperation changePasswordOperation;

        private string EmailAddress;

        public ChangePasswordForm()
        {
            InitializeComponent();

            // Set the DataContext of this control to the Registration instance to allow for easy binding.
            this.DataContext = this.changePasswordInfo;
        }

        /// <summary>
        /// Sets the parent window for the current <see cref="CreateUserForm"/>.
        /// </summary>
        /// <param name="window">The window to use as the parent.</param>
        public void SetParentWindow(ChangePasswordWindow window)
        {
            this.parentWindow = window;
        }

        /// <summary>
        /// Wire up the Password and PasswordConfirmation accessors as the fields get generated.
        /// Also bind the Question field to a ComboBox full of security questions, and handle the LostFocus event for the UserName TextBox.
        /// </summary>
        private void ChangePasswordForm_AutoGeneratingField(object dataForm, DataFormAutoGeneratingFieldEventArgs e)
        {
            //// Put all the fields in adding mode
            e.Field.Mode = DataFieldMode.AddNew;

            if (e.PropertyName == "OldPassword")
            {
                PasswordBox passwordBox = new PasswordBox();

                passwordBox.PasswordChanged += passwordBox_PasswordChanged;

                e.Field.ReplaceTextBox(passwordBox, PasswordBox.PasswordProperty);
                this.changePasswordInfo.OldPasswordAccessor = () => passwordBox.Password;
            }
            else if (e.PropertyName == "NewPassword")
            {
                PasswordBox passwordBox = new PasswordBox();

                passwordBox.PasswordChanged += passwordBox_PasswordChanged;

                e.Field.ReplaceTextBox(passwordBox, PasswordBox.PasswordProperty);
                this.changePasswordInfo.NewPasswordAccessor = () => passwordBox.Password;
            }
            else if (e.PropertyName == "NewPasswordConfirmation")
            {
                PasswordBox passwordBox = new PasswordBox();

                passwordBox.PasswordChanged += passwordBox_PasswordChanged;

                e.Field.ReplaceTextBox(passwordBox, PasswordBox.PasswordProperty);
                this.changePasswordInfo.PasswordConfirmationAccessor = () => passwordBox.Password;
            }
        }

        void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {

        }



        /// <summary>
        /// Submit the new registration.
        /// </summary>
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            // We need to force validation since we are not using the standard OK button from the DataForm.
            // Without ensuring the form is valid, we would get an exception invoking the operation if the entity is invalid.


            //if (this.changePasswordForm.ValidateItem())

            //changePasswordForm.CommitEdit();

            this.changePasswordInfo.IsChangingPasswordHelper = true;

            if (this.changePasswordForm.ValidateItem())
            {

                this.changePasswordInfo.UserName = WebContext.Current.User.Name;
                //this.changePasswordInfo.RememberMe = WebContext.Current.Authentication.is
                CheckOldPassword(this.changePasswordInfo.UserName, this.changePasswordInfo.OldPassword);

                AuthenticationContext authenticationContext = new AuthenticationContext();

                authenticationContext.Load(authenticationContext
                                               .GetProfileQuery(this.changePasswordInfo.UserName),
                                           LoadBehavior.RefreshCurrent
                                           , callback =>
                                           {
                                               EmailAddress =
                                                   authenticationContext.CustomizedProfiles.FirstOrDefault().
                                                       UserEmail;
                                           }, null);




                //this.userRegistrationContext.ChangePassword(
                //    this.changePasswordInfo,
                //    this.ChangingPasswordOperation_Completed, null);

                //this.changePasswordInfo.CurrentOperation = this.userRegistrationContext.ChangePassword(WebContext.Current.User.Name,);

                //this.parentWindow.AddPendingOperation(this.changePasswordInfo.CurrentOperation);
            }
            else
            {
                this.changePasswordInfo.IsChangingPasswordHelper = false;
            }
        }

        private void CheckOldPassword(string userName, string password)
        {
            this.changePasswordInfo.CurrentOperation = WebContext.Current.Authentication.Login(this.changePasswordInfo.ToLoginParameters(), this.LoginOperation_Completed, null);
            this.parentWindow.AddPendingOperation(this.changePasswordInfo.CurrentOperation);
        }

        private void LoginOperation_Completed(LoginOperation loginOperation)
        {
            if (!loginOperation.IsCanceled)
            {
                //this.parentWindow.DialogResult = true;

                if (loginOperation.HasError)
                {
                    this.changePasswordInfo.ValidationErrors.Add(new ValidationResult(ErrorResources.ErrorBadPassword, new string[] { "UserName", "OldPassword" }));

                    this.changePasswordInfo.IsChangingPasswordHelper = false;

                    loginOperation.MarkErrorAsHandled();
                }
                else if (loginOperation.LoginSuccess == false)
                {
                    // The operation was successful, but the actual login was not

                    this.changePasswordInfo.ValidationErrors.Add(new ValidationResult(ErrorResources.ErrorBadPassword, new string[] { "UserName", "OldPassword" }));

                    this.changePasswordInfo.IsChangingPasswordHelper = false;
                }
                else if (loginOperation.LoginSuccess == true)
                {
                    changePasswordOperation = userRegistrationContext.ChangePassword(WebContext.Current.User.Name, this.changePasswordInfo.OldPassword, this.changePasswordInfo.NewPassword);

                    Binding binding = new Binding();
                    binding.Source = changePasswordOperation;
                    binding.Path = new PropertyPath("CanCancel");
                    registerCancel.SetBinding(Button.IsEnabledProperty, binding);

                    registerCancel.SetBinding(Button.IsEnabledProperty, binding);

                    changePasswordOperation.Completed += (sender2, e1) =>
                    {
                        if (!changePasswordOperation.HasError)
                        {
                            PasswordChangedSuccessfully = (bool)changePasswordOperation.Value;

                            MessageWindow messageWindow = new MessageWindow();

                            if (PasswordChangedSuccessfully)
                            {
                                messageWindow.messageTextBlock.Text =
                                string.Format(System.Globalization.CultureInfo.CurrentUICulture,
                                              ApplicationStrings.PasswordChangedSuccessfully);
                            }
                            else
                            {
                                messageWindow.messageTextBlock.Text =
                                string.Format(System.Globalization.CultureInfo.CurrentUICulture,
                                              ApplicationStrings.PasswordChangedUnSuccessfully);
                            }

                            messageWindow.Show();

                            this.changePasswordInfo.IsChangingPasswordHelper = false;

                            messageWindow.Closed += messageWindow_Closed;
                        }
                        else
                        {
                            this.changePasswordInfo.IsChangingPasswordHelper = false;
                        }
                    };
                }
            }
            //this.changePasswordInfo.test = false;
        }

        void messageWindow_Closed(object sender, EventArgs e)
        {
            if (PasswordChangedSuccessfully)
            {
                this.parentWindow.Close();

                //for PMO
                //SendMailToUser();




                //MessageWindow messageW = new MessageWindow();

                //messageW.messageTextBlock.Text = ApplicationStrings.LoginAgainMessage;

                //messageW.Closed +=messageW_Closed;

                //messageW.Show();
            }
        }

        void messageW_Closed(object sender, EventArgs e)
        {
            WebContext.Current.Authentication.Logout(logoutOperation =>
            {
                if (logoutOperation.HasError)
                {
                    MessageWindow errorMessage = new MessageWindow();

                    errorMessage.messageTextBlock.Text = logoutOperation.Error.ToString();

                    errorMessage.Show();

                    logoutOperation.MarkErrorAsHandled();
                }
                else
                {
                    LoginWindow loginWindow = new LoginWindow();
                    loginWindow.Show();
                }
            }, /* userState */ null);
        }

        private void SendMailToUser()
        {
            UserRegistrationContext context = new UserRegistrationContext();

            if (!String.IsNullOrEmpty(EmailAddress))
            {
                string emailTemplate = string.Format(
                    CultureInfo.CurrentUICulture,
                    RegistrationDataResources.EmailTemplate, RegistrationDataResources.EmailBodyPasswordChangedSuccessfully);


                InvokeOperation operation = context.SendEmail("LanSysGroup@gmail.com", EmailAddress, null, null,
                                                          RegistrationDataResources.EmailSubjectPasswordChangedSuccessfully,
                                                          emailTemplate);

                operation.Completed += (s, x) =>
                {
                    if (!operation.HasError)
                    {
                        //MessageBox.Show("Hooray");                       
                    }
                    else
                    {
                        MessageBox.Show(operation.Error.ToString());
                    }
                };
            }
        }


        /// <summary>
        /// If a registration or login operation is in progress and is cancellable, cancel it.
        /// Otherwise, close the window.
        /// </summary>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            if (this.changePasswordInfo.CurrentOperation != null && this.changePasswordInfo.CurrentOperation.CanCancel && this.changePasswordOperation != null && this.changePasswordOperation.CanCancel)
            {
                this.changePasswordInfo.CurrentOperation.Cancel();

                this.changePasswordOperation.Cancel();
            }
            else
            {
                this.parentWindow.DialogResult = false;
            }
        }

        /// <summary>
        /// Maps Esc to the cancel button and Enter to the OK button.
        /// </summary>
        private void ChangePasswordForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.CancelButton_Click(sender, e);
            }
            else if (e.Key == Key.Enter && this.registerButton.IsEnabled)
            {
                this.SubmitButton_Click(sender, e);
            }
        }

        /// <summary>
        /// Sets focus to the user name text box.
        /// </summary>
        public void SetInitialFocus()
        {
            //this.userNameTextBox.Focus();
        }

    }
}
