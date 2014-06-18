using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Linq;
using LanSysWebGIS.Models;
using LanSysWebGIS.Web;
using LanSysWebGIS.Views.UserManagement;

namespace LanSysWebGIS.Presenter.Banader
{
    public class SetAccessLevelPresenter : Notifier
    {
        Web.PMOContext context;

        private bool _isBusy;

        List<Models.DocTitleTreeViewModel> allTitles = new List<DocTitleTreeViewModel>();

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged("IsBusy");
            }
        }

        private Models.Banader.UserModel _currentUser;

        public Models.Banader.UserModel CurrentUser
        {
            get { return _currentUser; }
            set
            {
                _currentUser = value;
                OnPropertyChanged("CurrentUser");
                Refresh();
            }
        }

        private void Refresh()
        {
            this.IsBusy = true;

            if (this.CurrentUser == null)
                return;

            RefreshAllTitles();

            Web.PMOContext context2 = new Web.PMOContext();

            context2.Load(context2.GetTitlesForQuery(
                this.CurrentUser.UsersId), System.ServiceModel.DomainServices.Client.LoadBehavior.RefreshCurrent,
                callback =>
                {
                    foreach (var item in this.allTitles)
                    {
                        item.IsChecked = context2.DocTitleUserFilters.Any(i => i.TitleId == item.TitleId);

                        item.IsExpanded = context2.DocTitleUserFilters.Any(i => i.TitleId == item.TitleId);
                    }

                    MakeTheTree();

                    this.IsBusy = false;
                }, null);
        }

        void Uncheck(Models.DocTitleTreeViewModel docTitle)
        {
            docTitle.IsChecked = false;

            foreach (var item in docTitle.Children)
            {
                Uncheck(item);
            }
        }

        private ObservableCollection<Models.DocTitleTreeViewModel> _docTitleCollection;
        public ObservableCollection<Models.DocTitleTreeViewModel> DocTitleCollection
        {
            get { return _docTitleCollection; }
            set
            {
                _docTitleCollection = value;
                OnPropertyChanged("DocTitleCollection");
            }
        }

        //NEW CODE ------
        public List<Models.DocTitleTreeViewModel> GetCheckedTitles()
        {
            List<Models.DocTitleTreeViewModel> result = new List<DocTitleTreeViewModel>();

            foreach (var item in this.DocTitleCollection[0].Children)
            {
                result.AddRange(GetCheckedTitles(item));
            }

            return result;
        }

        private IEnumerable<DocTitleTreeViewModel> GetCheckedTitles(DocTitleTreeViewModel docTitleTreeViewModel)
        {
            List<Models.DocTitleTreeViewModel> temp = new List<DocTitleTreeViewModel>();

            if (docTitleTreeViewModel.IsChecked)
            {
                ExpandNode(docTitleTreeViewModel);

                temp.Add(docTitleTreeViewModel);

                System.Diagnostics.Debug.WriteLine(docTitleTreeViewModel.TitleFName);
            }

            foreach (var item in docTitleTreeViewModel.Children)
            {
                temp.AddRange(GetCheckedTitles(item));
            }

            return temp;
        }

        public void ExpandNode(DocTitleTreeViewModel node)
        {
            if (node.Parent != null)
            {
                node.Parent.IsChecked = true;

                node.Parent.IsExpanded = true;

                ExpandNode(node.Parent);
            }
        }
        //-------END NEW CODE
        public ObservableCollection<Models.Banader.UserModel> UsersCollection { get; set; }

        public SetAccessLevelPresenter()
        {
            this.DocTitleCollection = new ObservableCollection<DocTitleTreeViewModel>();

            this.context = new Web.PMOContext();

            this.UsersCollection = new ObservableCollection<Models.Banader.UserModel>();

            LoadUsers();
        }

        private void LoadUsers()
        {
            this.IsBusy = true;

            context.Load(context.GetTblUsersQuery(), System.ServiceModel.DomainServices.Client.LoadBehavior.RefreshCurrent,
                callback =>
                {
                    foreach (var item in context.tblUsers)
                    {
                        this.UsersCollection.Add(new Models.Banader.UserModel()
                        {
                            UserName = item.UserID,
                            UsersId = item.UsersID
                        });
                    }

                    context.Load(context.GetDocTitleTreeQuery(), System.ServiceModel.DomainServices.Client.LoadBehavior.MergeIntoCurrent,
                        callback2 =>
                        {
                            RefreshAllTitles();

                            MakeTheTree();

                            this.IsBusy = false;
                        }, null);

                }, null);
        }

        void RefreshAllTitles()
        {
            this.allTitles.Clear();

            foreach (var item in context.DocTitleTrees)
            {
                this.allTitles.Add(new Models.DocTitleTreeViewModel(item));
            }
        }

        void MakeTheTree()
        {
            //Make the tree
            foreach (var item in this.allTitles)
                foreach (var childs in this.allTitles)
                    if (childs.ParentTitleId == item.TitleId)
                    {
                        childs.Parent = item;

                        item.Children.Add(childs);

                        if (childs.IsChecked)
                        {
                            ExpandNode(childs);
                        }
                    }

            //Add the Root
            this.allTitles.Add(new Models.DocTitleTreeViewModel()
            {
                ParentTitleId = -1,
                TitleFName = "سر فصل ها",
                TitleId = 0,
                Children = new ObservableCollection<Models.DocTitleTreeViewModel>(),
                IsExpanded = true,
                IsChecked = true
            });

            //Assign some children to the root
            foreach (var item in this.allTitles.Where(i => i.ParentTitleId == 0))
            {
                var root = this.allTitles.Single(i => i.TitleId == 0);

                root.Children.Add(item);

                item.Parent = root;
            }

            //Get the root
            var temp = this.allTitles.Where(i => i.ParentTitleId == -1).ToList();

            this.DocTitleCollection.Clear();

            foreach (var item in temp)
            {
                this.DocTitleCollection.Add(item);
            }
        }

        public void Save()
        {
            PMOContext savingContext = new PMOContext();

            savingContext.Load(savingContext.GetTitlesForQuery(this.CurrentUser.UsersId),
                 System.ServiceModel.DomainServices.Client.LoadBehavior.RefreshCurrent,
                 callback =>
                 {
                     //Remove current values
                     var temp = savingContext.DocTitleUserFilters.Where(i => i.UserId == this.CurrentUser.UsersId).ToList();

                     for (int i = 0; i < temp.Count; i++)
                     {
                         savingContext.DocTitleUserFilters.Remove(temp[i]);
                     }


                     var titles = GetCheckedTitles();

                     foreach (var item in titles)
                     {
                         DocTitleUserFilter docTitleUserFilter = new DocTitleUserFilter()
                         {
                             TitleId = item.TitleId,
                             UserId = this.CurrentUser.UsersId
                         };

                         savingContext.DocTitleUserFilters.Add(docTitleUserFilter);
                     }

                     savingContext.SubmitChanges();

                     MessageWindow win = new MessageWindow();

                     win.messageTextBlock.Text = "تغییرات ثبت شد.";

                     win.Show(); 
                 }, null);


        }
       
    }
}
