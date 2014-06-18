using LanSysWebGIS.Assets.Resources;
using LanSysWebGIS.Views.Login;
using LanSysWebGIS.Views.UserManagement;
using LanSysWebGIS.Web;

namespace LanSysWebGIS.LoginUI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ServiceModel.DomainServices.Client.ApplicationServices;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    /// <summary>
    /// Form that presents the login fields and handles the login process.
    /// </summary>
    public partial class LoginForm : StackPanel
    {
        private LoginWindow parentWindow;
        private LoginInfo loginInfo = new LoginInfo();
        private TextBox userNameTextBox;

        /// <summary>
        /// Creates a new <see cref="LoginForm"/> instance.
        /// </summary>
        public LoginForm()
        {
            InitializeComponent();

            // Set the DataContext of this control to the LoginInfo instance to allow for easy binding.
            this.DataContext = this.loginInfo;
        }

        /// <summary>
        /// Sets the parent window for the current <see cref="LoginForm"/>.
        /// </summary>
        /// <param name="window">The window to use as the parent.</param>
        public void SetParentWindow(LoginWindow window)
        {
            this.parentWindow = window;
        }

        /// <summary>
        /// Handles <see cref="DataForm.AutoGeneratingField"/> to provide the PasswordAccessor.
        /// </summary>
        private void LoginForm_AutoGeneratingField(object sender, DataFormAutoGeneratingFieldEventArgs e)
        {
            if (e.PropertyName == "UserName")
            {
                this.userNameTextBox = (TextBox)e.Field.Content;
            }
            else if (e.PropertyName == "Password")
            {
                PasswordBox passwordBox = new PasswordBox();
                e.Field.ReplaceTextBox(passwordBox, PasswordBox.PasswordProperty);
                this.loginInfo.PasswordAccessor = () => passwordBox.Password;
            }
        }

        /// <summary>
        /// Submits the <see cref="LoginOperation"/> to the server
        /// </summary>
        private void LoginButton_Click(object sender, EventArgs e)
        {
            // We need to force validation since we are not using the standard OK button from the DataForm.
            // Without ensuring the form is valid, we get an exception invoking the operation if the entity is invalid.
            if (this.loginForm.ValidateItem())
            {
                this.loginInfo.CurrentLoginOperation = WebContext.Current.Authentication.Login(this.loginInfo.ToLoginParameters(), this.LoginOperation_Completed, null);
                this.parentWindow.AddPendingOperation(this.loginInfo.CurrentLoginOperation);
            }
        }

        /// <summary>
        /// Completion handler for a <see cref="LoginOperation"/>.
        /// If operation succeeds, it closes the window.
        /// If it has an error, it displays an <see cref="ErrorWindow"/> and marks the error as handled.
        /// If it was not canceled, but login failed, it must have been because credentials were incorrect so a validation error is added to notify the user.
        /// </summary>
        private void LoginOperation_Completed(LoginOperation loginOperation)
        {
            if (loginOperation.LoginSuccess)
            {
                this.parentWindow.DialogResult = true;

                PMOContext context2 = new PMOContext();

                context2.UserLogs.Add(new UserLogs() { Action = "Login", ActionDesc = "Login By Login Form"});

                context2.SubmitChanges();

                if (WebContext.Current.User.IsChangePasswordNeeded.ToUpper() == "TRUE")
                {
                    MessageWindow messageWindow = new MessageWindow();
                    messageWindow.messageTextBlock.Text = "شما باید رمز عبور خود را تغییر دهید!";
                    messageWindow.CancelButton.Visibility = Visibility.Visible;

                    messageWindow.Closed += messageWindow_Closed;

                    messageWindow.Show();
                }
            }
            else if (loginOperation.HasError)
            {
                MessageWindow win = new MessageWindow();
                win.messageTextBlock.Text = loginOperation.Error.Message;
                win.Show();
                loginOperation.MarkErrorAsHandled();
            }
            else if (!loginOperation.IsCanceled)
            {
                this.loginInfo.ValidationErrors.Add(new ValidationResult(ErrorResources.ErrorBadUserNameOrPassword, new string[] { "UserName", "Password" }));
            }
        }

        void messageWindow_Closed(object sender, EventArgs e)
        {
            if (((MessageWindow)sender).DialogResult == true)
            {
                ChangePasswordWindow changePasswordWindow = new ChangePasswordWindow();

                changePasswordWindow.Closed += changePasswordWindow_Closed;

                changePasswordWindow.Show();
            }
            else if (((MessageWindow)sender).DialogResult == false)
            {
                WebContext.Current.Authentication.Logout(logoutOperation =>
                {
                    if (logoutOperation.HasError)
                    {

                        MessageWindow win = new MessageWindow();
                        win.messageTextBlock.Text = logoutOperation.Error.Message;
                        win.Show();
                        logoutOperation.MarkErrorAsHandled();
                    }
                }, /* userState */ null);
            }
        }

        void changePasswordWindow_Closed(object sender, EventArgs e)
        {
            if (((ChangePasswordWindow)sender).DialogResult == true)
            {

            }
            else if (((ChangePasswordWindow)sender).DialogResult == false)
            {
                WebContext.Current.Authentication.Logout(logoutOperation =>
                {
                    if (logoutOperation.HasError)
                    {

                        MessageWindow win = new MessageWindow();
                        win.messageTextBlock.Text = logoutOperation.Error.Message;
                        win.Show();
                        logoutOperation.MarkErrorAsHandled();
                    }
                }, /* userState */ null);
            }
        }

        /// <summary>
        /// Switches to the registration form.
        /// </summary>
        //private void RegisterNow_Click(object sender, RoutedEventArgs e)
        //{
        //    this.parentWindow.NavigateToRegistration();
        //}

        /// <summary>
        /// If a login operation is in progress and is cancellable, cancel it.
        /// Otherwise, close the window.
        /// </summary>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            if (this.loginInfo.CurrentLoginOperation != null && this.loginInfo.CurrentLoginOperation.CanCancel)
            {
                this.loginInfo.CurrentLoginOperation.Cancel();
            }
            else
            {
                this.parentWindow.DialogResult = false;
            }
        }

        /// <summary>
        /// Maps Esc to the cancel button and Enter to the OK button.
        /// </summary>
        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.CancelButton_Click(sender, e);
            }
            else if (e.Key == Key.Enter && this.loginButton.IsEnabled)
            {
                this.LoginButton_Click(sender, e);
            }
        }

        /// <summary>
        /// Sets focus to the user name text box.
        /// </summary>
        public void SetInitialFocus()
        {
            this.userNameTextBox.Focus();
        }
    }
}
