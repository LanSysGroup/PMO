using LanSysWebGIS.Presenter.Banader;
using LanSysWebGIS.Views.UserManagement;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace LanSysWebGIS.UserControls.Banader
{
    public partial class SetAccessLevels : ChildWindow
    {


        SetAccessLevelPresenter Presenter { get { return this.DataContext as SetAccessLevelPresenter; } }

        public SetAccessLevels(SetAccessLevelPresenter presenter)
        {
            InitializeComponent();

            this.DataContext = presenter;
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.Presenter.Save();

                
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void userList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.Presenter.CurrentUser = this.userList.SelectedItem as Models.Banader.UserModel;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            this.Presenter.ExpandNode((sender as System.Windows.Controls.CheckBox).DataContext as Models.DocTitleTreeViewModel);
        }
    }
}

