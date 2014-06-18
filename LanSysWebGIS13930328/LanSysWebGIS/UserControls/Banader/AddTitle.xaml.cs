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
    public partial class AddTitle : ChildWindow
    {
        Models.DocTitleTreeViewModel parent;

        int _userId;

        public Models.DocTitleTreeViewModel Presenter { get { return this.DataContext as Models.DocTitleTreeViewModel; } }

        public AddTitle(int userId, LanSysWebGIS.Presenter.MainCategoryPresenter mainCategoryPresenter, Models.DocTitleTreeViewModel parent)
        {
            InitializeComponent();

            this._userId = userId;

            this.parent = parent;

            LanSysWebGIS.Web.PMOContext context = new Web.PMOContext();

            context.GetDocTitleWithMaxId(
             action =>
             {
                 this.DataContext = new Models.DocTitleTreeViewModel()
                 {
                     TitleId = action.Value + 1,
                     ParentTitleId = mainCategoryPresenter.SelectedTitle.TitleId
                 };
             },
             null);

            this.title.Content = mainCategoryPresenter.SelectedTitle.TitleFName;
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            LanSysWebGIS.Web.PMOContext context = new Web.PMOContext();

            var docTitleQuery = context.GetDocTitleTreeQuery();

            List<Models.DocTitleTreeViewModel> tree = new List<Models.DocTitleTreeViewModel>();

            context.DocTitleTrees.Add(new Web.DocTitleTree()
            {
                ParentTitleId = this.Presenter.ParentTitleId,
                TitleFName = this.Presenter.TitleFName,
                ToDate = this.Presenter.ToDate,
                FromDate = this.Presenter.FromDate,
                TitleEName = this.Presenter.TitleEName,
                TitleId = this.Presenter.TitleId,
                BasePath = @"\\cpedsrv\Archive"
            });

            context.SubmitChanges(callback2 =>
            {
                this.parent.Children.Add(this.Presenter);

                context.DocTitleUserFilters.Add(new Web.DocTitleUserFilter()
                    {
                        TitleId = this.Presenter.TitleId,
                        UserId = this._userId
                    });

                context.SubmitChanges(callback3 => { }, null);
            }, null);

            //this.mainCategoryPresenter.DocTitleCollection.Add(this.Presenter);
            //},
            //null);


            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(this.Presenter.TitleFName);
            this.DialogResult = false;
        }

        private void ChildWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                this.OKButton.Focus();
                OKButton_Click(null, null);
            }
            else if (e.Key == Key.Escape)
            {
                this.DialogResult = false;
            }
        }
    }
}

