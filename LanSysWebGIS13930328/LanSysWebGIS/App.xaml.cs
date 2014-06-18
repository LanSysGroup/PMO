using LanSysWebGIS.Web;
using System.Linq;

namespace LanSysWebGIS
{
    using System;
    using System.Runtime.Serialization;
    using System.ServiceModel.DomainServices.Client.ApplicationServices;
    using System.Windows;
    using System.Windows.Controls;
    using LanSysWebGIS.Views.Login;
    using LanSysWebGIS.Views.UserManagement;
    using System.Collections.Generic;

    /// <summary>
    /// Main <see cref="Application"/> class.
    /// </summary>
    public partial class App : Application
    {
        public static List<int> AdminUsersId;

        public static List<tblUsers> allUsers;

        /// <summary>
        /// Creates a new <see cref="App"/> instance.
        /// </summary>
        public App()
        {
            InitializeComponent();

            // Create a WebContext and add it to the ApplicationLifetimeObjects collection.
            // This will then be available as WebContext.Current.
            WebContext webContext = new WebContext();
            webContext.Authentication = new FormsAuthentication();

            //webContext.Authentication = new WindowsAuthentication();
            this.ApplicationLifetimeObjects.Add(webContext);
        }
     
        public static bool IsAdmin(int userId)
        {
            return AdminUsersId.Contains(userId);
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // This will enable you to bind controls in XAML to WebContext.Current properties.
            this.Resources.Add("WebContext", WebContext.Current);

            // This will automatically authenticate a user when using Windows authentication or when the user chose "Keep me signed in" on a previous login attempt.
            WebContext.Current.Authentication.LoadUser(this.Application_UserLoaded, null);

            // Show some UI to the user while LoadUser is in progress
            this.InitializeRootVisual();

            PMOContext context = new PMOContext();

            context.Load(context.GettblAdminUsersQuery(), System.ServiceModel.DomainServices.Client.LoadBehavior.MergeIntoCurrent,
                callback => { AdminUsersId = context.tblAdminUsers.Select(i => i.UserId).ToList(); }, null);

            context.Load(context.GetTblUsersQuery(), System.ServiceModel.DomainServices.Client.LoadBehavior.MergeIntoCurrent,
                callback => { allUsers = context.tblUsers.ToList(); }, null);
        }

        /// <summary>
        /// Invoked when the <see cref="LoadUserOperation"/> completes.
        /// Use this event handler to switch from the "loading UI" you created in <see cref="InitializeRootVisual"/> to the "application UI".
        /// </summary>
        private void Application_UserLoaded(LoadUserOperation operation)
        {
            if (!WebContext.Current.User.IsAuthenticated)
            {
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.Show();
            }
            else
            {
                PMOContext context2 = new PMOContext();

                context2.UserLogs.Add(new UserLogs() { Action = "Login", ActionDesc = "Login Automatically" });

                context2.SubmitChanges();
            }


            if (operation.HasError)
            {
                MessageWindow win = new MessageWindow();
                win.messageTextBlock.Text = operation.Error.Message;
                win.Show();

                //ErrorWindow.CreateNew(operation.Error);
                //operation.MarkErrorAsHandled();
            }
        }

        /// <summary>
        /// Initializes the <see cref="Application.RootVisual"/> property.
        /// The initial UI will be displayed before the LoadUser operation has completed.
        /// The LoadUser operation will cause user to be logged in automatically if using Windows authentication or if the user had selected the "Keep me signed in" option on a previous login.
        /// </summary>
        protected virtual void InitializeRootVisual()
        {
            LanSysWebGIS.Controls.BusyIndicator busyIndicator = new LanSysWebGIS.Controls.BusyIndicator();
            busyIndicator.Content = new MainPage();
            busyIndicator.HorizontalContentAlignment = HorizontalAlignment.Stretch;
            busyIndicator.VerticalContentAlignment = VerticalAlignment.Stretch;

            this.RootVisual = busyIndicator;
        }

        private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            // Log
            // Info For User
            // Handle

            Exception exp = e.ExceptionObject;

            if (exp is AccessViolationException || exp is BadImageFormatException || exp is StackOverflowException)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                //ErrorWindow.CreateNew(exp);

                MessageWindow messageWindow = new MessageWindow();

                messageWindow.messageTextBlock.Text = exp.Message;

                messageWindow.Show();
            }

            //String message = "";
            //if (exp is IOException)
            //{
            //    message = "خطا در تعامل با سیستم فایل";
            //}

            //MessageBox.Show(exp.Message);

            //// If the app is running outside of the debugger then report the exception using a ChildWindow control.
            //if (!System.Diagnostics.Debugger.IsAttached)
            //{
            //    // NOTE: This will allow the application to continue running after an exception has been thrown but not handled. 
            //    // For production applications this error handling should be replaced with something that will report the error to the website and stop the application.
            //    e.Handled = true;
            //    ErrorWindow.CreateNew(e.ExceptionObject);
            //}
        }

        private void Application_Exit(object sender, EventArgs e)
        {
            if (WebContext.Current.User.IsAuthenticated)
            {
                PMOContext context2 = new PMOContext();

                context2.UserLogs.Add(new UserLogs() { Action = "Logout", ActionDesc = "Application Exit" });

                context2.SubmitChanges();
            }
        }
    }
}