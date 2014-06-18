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
using System.Collections.ObjectModel;

namespace LanSysWebGIS
{
    public partial class AddSubject : ChildWindow
    {
        public Presenter.AddSubjectPresenter Presenter { get { return this.DataContext as Presenter.AddSubjectPresenter; } }

        public AddSubject(Presenter.AddSubjectPresenter presenter)
        {
            InitializeComponent();

            LanSysWebGIS.Web.PMOContext context = new Web.PMOContext();

            this.DataContext = presenter;

            this.title.Content = presenter.mainCategoryPresenter.SelectedSubject.SubjectFName;
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.Presenter.Add(this);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void ChildWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                this.OKButton.Focus();
                this.Presenter.Add(this);
            }
            else if (e.Key == Key.Escape)
            {
                this.DialogResult = false;
            }
        }

    }
}

