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

namespace LanSysWebGIS.UserControls.Banader
{
    public partial class AddFile : ChildWindow
    {
        public Presenter.AddFilePresenter Presenter { get { return this.DataContext as Presenter.AddFilePresenter; } }

        public AddFile(Presenter.AddFilePresenter presenter)
        {
            InitializeComponent();

            this.DataContext = presenter;
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.Presenter.AddFiles(this);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void ChildWindow_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void addTag_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.tag.Text))
            {
                this.Presenter.AddTag(this.tag.Text);
            }
        }

        private void selectFile_Click(object sender, RoutedEventArgs e)
        {
            this.Presenter.Add();
        }

        private void ChildWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                this.OKButton.Focus();
                this.Presenter.AddFiles(this);
            }
            else if (e.Key == Key.Escape)
            {
                this.DialogResult = false;
            }
        }
    }
}
