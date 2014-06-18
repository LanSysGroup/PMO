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
using LanSysWebGIS.Web.Models;

namespace LanSysWebGIS.Views.UserManagement
{
    public partial class MessageWindow : ChildWindow
    {
        public MessageWindow()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            //string username = ManageUsersWindow.selectedUser.UserName;

            //AuthenticationContext context = new AuthenticationContext();

            //context.Load(context.GetAllUsersQuery(), LoadBehavior.RefreshCurrent, callback =>
            //{
            //    AuthenticationServiceUser serviceUser = context.AuthenticationServiceUsers.First(u => u.UserName == username);

            //    context.AuthenticationServiceUsers.Remove(serviceUser);

            //    SubmitOperation submitOperation = context.SubmitChanges();
            //    submitOperation.Completed += submitOperation_Completed;

            //}, null);

            this.DialogResult = true;
        }

        //private void submitOperation_Completed(object sender, System.EventArgs e)
        //{
        //    SubmitOperation submitOperation = sender as SubmitOperation;

        //    if (submitOperation.HasError)
        //    {
        //        MessageBox.Show(submitOperation.Error.Message);
        //        submitOperation.MarkErrorAsHandled();
        //    }
        //    //else
        //    //{


        //    //    MessageBox.Show("حذف کاربر مورد نظر با موفقیت انجام شد");
        //    //}


        //}

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void ChildWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.CancelButton_Click(sender, e);
            }
            else if (e.Key == Key.Enter)
            {
                this.OKButton_Click(sender, e);
            }
        }
    }
}

