using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using LanSysWebGIS.Web;
using LanSysWebGIS.Views.UserManagement;
using LanSysWebGIS.Models;
using LanSysWebGIS.Helpers;
using LanSysWebGIS.UserControls;
using LanSysWebGIS.UserControls.Banader;

namespace LanSysWebGIS.Presenter
{
    public class MainCategoryPresenter : Notifier
    {
        LanSysWebGIS.Web.PMOContext context;

        private int _userId;

        public int UserId
        {
            get { return _userId; }
            set
            {
                _userId = value;
                OnPropertyChanged("UserId");
            }
        }

        private bool _isAdmin;
        public bool IsAdmin
        {
            get { return _isAdmin; }
            set
            {
                _isAdmin = value;
                OnPropertyChanged("IsAdmin");
                OnPropertyChanged("IsAdminAndNotAccepted");
            }
        }

        private bool _isPasteTitleEnabled;

        public bool IsPasteTitleEnabled
        {
            get { return _isPasteTitleEnabled; }
            set
            {
                _isPasteTitleEnabled = value;
                OnPropertyChanged("IsPasteTitleEnabled");
            }
        }

        private bool _isPasteSubjectEnabled;

        public bool IsPasteSubjectEnabled
        {
            get { return _isPasteSubjectEnabled; }
            set
            {
                _isPasteSubjectEnabled = value;
                OnPropertyChanged("IsPasteSubjectEnabled");
                System.Diagnostics.Debug.WriteLine("IsPasteSubjectEnabled: " + value.ToString());
            }
        }

        //private bool _isAdminAndNotAccepted;
        //public bool IsAdminAndNotAccepted
        //{
        //    get { return _isAdminAndNotAccepted; }
        //    set
        //    {
        //        _isAdminAndNotAccepted = value;
        //        OnPropertyChanged("IsAdminAndNotAccepted");
        //    }
        //}

        public bool IsAdminAndNotAccepted
        {
            get
            {
                //System.Diagnostics.Debug.WriteLine("notIsFlag: ", !SelectedFile.Flag);
                return IsAdmin && !SelectedFile.Flag;
            }
        }

        public bool IsOwnerAndNotAccepted
        {
            get { return SelectedFile.AddedByUserName == WebContext.Current.User.Name && !SelectedFile.Flag; }
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

        private ObservableCollection<Models.DocSubjectTreeViewModel> _docSubjectCollection;
        public ObservableCollection<Models.DocSubjectTreeViewModel> DocSubjectCollection
        {
            get { return _docSubjectCollection; }
            set
            {
                _docSubjectCollection = value;
                OnPropertyChanged("DocSubjectCollection");
            }
        }

        private ObservableCollection<Presenter.DocFileViewModel> _docFileList = new ObservableCollection<Presenter.DocFileViewModel>();
        public ObservableCollection<Presenter.DocFileViewModel> DocFileList
        {
            get { return _docFileList; }
            set
            {
                _docFileList = value;
                OnPropertyChanged("DocFileList");
            }
        }

        List<Models.DocSubjectTreeViewModel> allSubjects = new List<Models.DocSubjectTreeViewModel>();

        private Models.DocTitleTreeViewModel _selectedTitle;
        public Models.DocTitleTreeViewModel SelectedTitle
        {
            get { return _selectedTitle; }
            set
            {
                _selectedTitle = value;
                OnPropertyChanged("SelectedTitle");
                OnPropertyChanged("SelecteTitleBasePath");
            }
        }

        private Models.DocSubjectTreeViewModel _selectedSubject;
        public Models.DocSubjectTreeViewModel SelectedSubject
        {
            get { return _selectedSubject; }
            set
            {
                _selectedSubject = value;
                OnPropertyChanged("SelectedSubject");
            }
        }

        private Presenter.DocFileViewModel _selectedDocFile;
        public Presenter.DocFileViewModel SelectedFile
        {
            get { return _selectedDocFile; }
            set
            {
                _selectedDocFile = value;
                OnPropertyChanged("SelectedFile");
                if (value != null)
                {
                    OnPropertyChanged("IsAdminAndNotAccepted");
                    OnPropertyChanged("IsOwnerAndNotAccepted");
                }
            }
        }

        private int _copiedDocTitleID;

        public int CopiedDocTitleID
        {
            get { return _copiedDocTitleID; }
            set
            {
                _copiedDocTitleID = value;
                OnPropertyChanged("CopiedDocTitleID");
            }
        }

        private Models.DocSubjectTreeViewModel _copiedDocSubject;

        public Models.DocSubjectTreeViewModel CopiedDocSubject
        {
            get { return _copiedDocSubject; }
            set
            {
                _copiedDocSubject = value;
                OnPropertyChanged("CopiedDocSubject");
            }
        }


        //private bool _selectedDocFileFlag;
        //public bool SelectedFileFlag
        //{
        //    get { return _selectedDocFileFlag; }
        //    set
        //    {
        //        _selectedDocFileFlag = value;
        //        OnPropertyChanged("SelectedFileFlag");
        //        OnPropertyChanged("IsAdminAndNotAccepted");
        //        //IsAdminAndNotAccepted = _isAdmin && !_selectedDocFileFlag;
        //    }
        //}

        public string SelecteTitleBasePath
        {
            get
            {
                return this.SelectedTitle.BasePath;
            }
        }

        //public string FileToolTip
        //{
        //    get
        //    {
        //        return string.Format("آپلود شده توسط: {0}\r\nآپلود شده در تاریخ: {1}\r\n", SelectedFile.AddedByUserName, SelectedFile.DateAdded);
        //    }
        //}

        public string SelectedFileFullPath
        {
            get
            {
                string path;

                string selectedFilePath = SelectedFile.FilePath;

                if (selectedFilePath.StartsWith(@"\"))
                {
                    selectedFilePath = selectedFilePath.TrimStart('\\');
                }

                if (selectedFilePath.EndsWith(@"\"))
                {
                    selectedFilePath = selectedFilePath.TrimEnd('\\');
                }

                if (this.SelectedFile.FilePath.Contains("cpedsrv") || this.SelectedFile.FilePath.Contains("CPEDSRV"))
                {
                    path = selectedFilePath + @"\" + this.SelectedFile.FileName + this.SelectedFile.FileExt;

                    path = @"\\" + path.Replace("cpedsrv", "172.16.1.243").Replace("CPEDSRV", "172.16.1.243").Replace(@"//", @"\").Replace(@"\\", @"\");
                }
                else
                {
                    path = SelecteTitleBasePath + @"\" + selectedFilePath + @"\" + this.SelectedFile.FileName + this.SelectedFile.FileExt;

                    path = @"\" + path.Replace("cpedsrv", "172.16.1.243").Replace(@"//", @"\").Replace(@"\\", @"\");
                }

                return path;

                //if (this.SelectedFile.FilePath.Contains("cpedsrv") || this.SelectedFile.FilePath.Contains("CPEDSRV"))
                //{
                //    path = this.SelectedFile.FilePath + @"\" + this.SelectedFile.FileName + this.SelectedFile.FileExt;

                //    path = @"file:" + path.Replace("cpedsrv", "172.16.1.243").Replace("CPEDSRV", "172.16.1.243");
                //}
                //else
                //{
                //    path = SelecteTitleBasePath + this.SelectedFile.FilePath + @"\" + this.SelectedFile.FileName + this.SelectedFile.FileExt;

                //    path = @"file:" + path.Replace("cpedsrv", "172.16.1.243");
                //}
            }
        }

        private bool titleLoading = true, subjectLoading = true;
        private bool _isLoadingData;

        public bool IsLoadingData
        {
            get { return _isLoadingData; }
            set
            {
                _isLoadingData = value;
                OnPropertyChanged("IsLoadingData");
            }
        }

        public MainCategoryPresenter(int userId)
        {
            System.Diagnostics.Debug.WriteLine("Constructor Entered");


            System.Diagnostics.Debug.WriteLine("MainCategoryPresenter: this.IsLoadingData = true;");

            this.IsLoadingData = true;

            this._userId = userId;

            //Potentially error prone
            this.IsAdmin = App.IsAdmin(int.Parse(WebContext.Current.User.UserID));

            this.DocSubjectCollection = new ObservableCollection<Models.DocSubjectTreeViewModel>();

            this.DocTitleCollection = new ObservableCollection<Models.DocTitleTreeViewModel>();

            GetAllTitles();

            GetAllSubjects();
        }

        private void GetAllTitles()
        {
            System.Diagnostics.Debug.WriteLine("GetAllTitles Entered");

            this.DocTitleCollection.Clear();

            context = new Web.PMOContext();

            var docTitleQuery = context.GetDocTitleTreeQuery();

            var docTitleUserFilter = context.GetTitlesForQuery(this._userId);

            context.Load(docTitleUserFilter, System.ServiceModel.DomainServices.Client.LoadBehavior.RefreshCurrent,
                callback0 =>
                {
                    //Get accessible titles by current user
                    var filteredTitles = context.DocTitleUserFilters.Select(i => i.TitleId).ToList();

                    //Load all the titles from DB using EF
                    context.Load(docTitleQuery, System.ServiceModel.DomainServices.Client.LoadBehavior.RefreshCurrent,
                        callback =>
                        {
                            var tree = context.DocTitleTrees
                                .ToList()
                                .Select(i => new Models.DocTitleTreeViewModel()
                                {
                                    ParentTitleId = i.ParentTitleId.Value,
                                    TitleId = i.TitleId,
                                    TitleFName = i.TitleFName,
                                    TitleEName = i.TitleEName,
                                    FromDate = i.FromDate,
                                    BasePath = i.BasePath,
                                    ToDate = i.ToDate,
                                    Children = new ObservableCollection<Models.DocTitleTreeViewModel>()
                                })
                                .ToList();

                            //Apply the Filtering for non-admin users
                            if (!App.IsAdmin(_userId))
                            {
                                tree = tree.Where(i => filteredTitles.Contains(i.TitleId)).ToList();
                            }

                            //Make the tree
                            foreach (var item in tree)
                            {
                                foreach (var childs in tree)
                                {
                                    if (childs.ParentTitleId == item.TitleId)
                                    {
                                        childs.Parent = item;

                                        item.Children.Add(childs);
                                    }
                                }
                            }

                            //Add the Root
                            tree.Add(new Models.DocTitleTreeViewModel()
                            {
                                ParentTitleId = -1,
                                TitleFName = "سر فصل ها",
                                TitleId = 0,
                                Children = new ObservableCollection<Models.DocTitleTreeViewModel>(),
                                IsExpanded = true
                            });

                            //Assign some children to the root
                            foreach (var item in tree.Where(i => i.ParentTitleId == 0))
                            {
                                tree.Single(i => i.TitleId == 0).Children.Add(item);
                            }

                            //Get the root
                            var temp = tree.Where(i => i.ParentTitleId == -1).ToList();

                            foreach (var item in temp)
                            {
                                this.DocTitleCollection.Add(item);
                            }

                            System.Diagnostics.Debug.WriteLine("TitleLoaded");

                            titleLoading = false;

                            this.IsLoadingData = titleLoading || subjectLoading;


                            System.Diagnostics.Debug.WriteLine(string.Format("GetAllTitles: this.IsLoadingData = {0}", titleLoading && subjectLoading));
                            this.IsLoadingData = titleLoading || subjectLoading;
                        },
                        null);
                }, null);
        }

        private void GetAllSubjects()
        {
            System.Diagnostics.Debug.WriteLine("GetAllSubjects Entered");

            //this.IsLoadingData = true;

            LanSysWebGIS.Web.PMOContext context = new Web.PMOContext();

            var docSubjectQuery = context.GetDocSubjectTreeQuery();
            context.Load(context.GetDocSubjectUserFilterQuery(), System.ServiceModel.DomainServices.Client.LoadBehavior.RefreshCurrent,
             callback0 =>
             {
                 var filteredSubjects = context.DocSubjectUserFilters.Select(i => i.SubjectId).ToList();

                 context.Load(docSubjectQuery, System.ServiceModel.DomainServices.Client.LoadBehavior.RefreshCurrent,
                     callback =>
                     {
                         var tree = context.DocSubjectTrees
                             .ToList()
                             .Select(i => new Models.DocSubjectTreeViewModel()
                             {
                                 ParentSubjectId = i.SubjectParentID,
                                 SubjectId = i.SubjectID,
                                 SubjectFName = i.SubjectFName,
                                 SubjectEName = i.SubjectEName,
                                 TitleId = i.TitleID.Value,
                             })
                             .ToList();

                         //foreach (var item in tree)
                         //    foreach (var childs in tree)
                         //        if (childs.ParentSubjectId == item.SubjectId)
                         //            item.Children.Add(childs);

                         this.allSubjects = tree;

                         System.Diagnostics.Debug.WriteLine("subjectLoaded");

                         subjectLoading = false;

                         System.Diagnostics.Debug.WriteLine(string.Format("GetAllSubjects: this.IsLoadingData = {0}", titleLoading && subjectLoading));
                         this.IsLoadingData = titleLoading || subjectLoading;
                     },
                 null);
             }, null);
        }

        internal void AddDocSubjectTree(Models.DocSubjectTreeViewModel current)
        {
            this.allSubjects.Add(current);

            //foreach (var item in this.allSubjects)
            //    if (current.ParentSubjectId == item.SubjectId)
            //        item.Children.Add(current);

            RefreshDocSubjectTree();
        }

        bool HaveSubject(DocTitleTreeViewModel item)
        {
            return this.allSubjects.Any(i => i.TitleId == item.TitleId);
        }

        public void RefreshDocSubjectTree()
        {
            System.Diagnostics.Debug.WriteLine("this.IsLoadingData = true;", "RefreshDocSubjectTree");

            this.IsLoadingData = true;

            System.Diagnostics.Debug.WriteLine("RefreshDocSubjectTree Entered");

            this.DocSubjectCollection.Clear();

            var tree = this.allSubjects.Where(i => i.TitleId == this.SelectedTitle.TitleId).ToList();

            tree.Add(new Models.DocSubjectTreeViewModel() { ParentSubjectId = -1, SubjectFName = "موضوعات", SubjectId = 0, IsExpanded = true });

            foreach (var item in tree)
            {
                item.Children.Clear();

                foreach (var childs in tree)
                {
                    if (childs.ParentSubjectId == item.SubjectId)
                    {
                        childs.Parent = item;

                        item.Children.Add(childs);
                    }
                }
            }

            tree.Single(i => i.SubjectId == 0).Children =
                new ObservableCollection<Models.DocSubjectTreeViewModel>(tree.Where(i => i.ParentSubjectId == 0));

            var temp = tree.Where(i => i.ParentSubjectId == -1).ToList();

            foreach (var item in temp)
            {
                this.DocSubjectCollection.Add(item);
            }

            System.Diagnostics.Debug.WriteLine("RefreshDocSubjectTree: this.IsLoadingData = false;");

            this.IsLoadingData = false;
        }

        internal void RefreshDocFileList()
        {
            System.Diagnostics.Debug.WriteLine("RefreshDocFileList: this.IsLoadingData = true;");

            this.IsLoadingData = true;

            LanSysWebGIS.Web.PMOContext context = new Web.PMOContext();

            var docFileQuery = context.GetDocFilesForQuery(this.SelectedSubject.SubjectId);

            context.Load(docFileQuery, System.ServiceModel.DomainServices.Client.LoadBehavior.RefreshCurrent,
                callback =>
                {
                    var tree = context.DocFiles
                        .ToList()
                        .Select(i => new Presenter.DocFileViewModel()
                        {
                            FileId = i.FileID,
                            Title = i.Title,
                            FileExt = i.FileExt,
                            FileName = i.FileName,
                            FilePath = i.FilePath,
                            SubjectId = i.SubjectID.Value,
                            AddedByUserName = i.AddedByUserName,
                            DateAdded = i.DateAdded,
                            FromDate = i.fromDate,
                            ToDate = i.toDate,
                            LatX = i.LatX,
                            LongY = i.LongY,
                            Flag = i.Flag == null ? true : (bool)i.Flag,
                        })
                        .ToList();

                    tree = tree.Where(i => i.SubjectId == this.SelectedSubject.SubjectId).ToList();

                    //Apply the Filtering for non-admin users
                    if (!App.IsAdmin(_userId))
                    {
                        tree = tree.Where(i => i.Flag == true || i.Flag == null || i.AddedByUserName == WebContext.Current.User.Name).ToList();
                    }

                    this.DocFileList.Clear();

                    foreach (var item in tree)
                    {
                        this.DocFileList.Add(item);
                    }

                    System.Diagnostics.Debug.WriteLine("RefreshDocFileList: this.IsLoadingData = false;");

                    this.IsLoadingData = false;
                },
                null);
        }

        internal void RemoveDocTitle()
        {
            if (this.SelectedTitle == null)
            {
                return;
            }

            if (this.SelectedTitle.Children.Count > 0 || HaveSubject(this.SelectedTitle))
            {
                MessageWindow win = new MessageWindow();

                win.messageTextBlock.Text = "کاربر گرامی لطفا ابتدا زیر مجموعه های این دسته بندی را حذف کنید.";

                win.Show();

                return;
            }

            this.IsLoadingData = true;

            context.Load(context.GetDocTitleTreeQuery(), System.ServiceModel.DomainServices.Client.LoadBehavior.MergeIntoCurrent,
                callback =>
                {
                    context.DocTitleTrees.Remove(context.DocTitleTrees.First(i => i.TitleId == this.SelectedTitle.TitleId));

                    context.SubmitChanges(callback1 =>
                    {
                        GetAllTitles();

                        this.SelectedTitle = null;

                        this.IsLoadingData = false;
                    }, null);

                }, null);
        }

        bool HaveFile(DocSubjectTreeViewModel item)
        {
            return DocFileList.Any(i => i.SubjectId == item.SubjectId);
        }

        internal void RemoveDocSubject()
        {
            if (this.SelectedSubject == null)
            {
                return;
            }

            if (this.SelectedSubject.Children.Count > 0 || HaveFile(this.SelectedSubject))
            {
                MessageWindow win = new MessageWindow();

                win.messageTextBlock.Text = "کاربر گرامی لطفا ابتدا زیر مجموعه های این دسته بندی را حذف کنید.";

                win.Show();

                return;
            }

            this.IsLoadingData = true;

            context.Load(context.GetDocSubjectTreeQuery(), System.ServiceModel.DomainServices.Client.LoadBehavior.RefreshCurrent,
                callback =>
                {
                    var docSubjectTree = context.DocSubjectTrees.First(i => i.SubjectID == this.SelectedSubject.SubjectId);

                    context.DocSubjectTrees.Remove(docSubjectTree);

                    context.SubmitChanges(callback1 =>
                    {
                        if (callback1.HasError)
                        {
                            MessageWindow win = new MessageWindow();
                            win.messageTextBlock.Text = callback1.Error.Message;
                            win.Show();
                        }

                        this.allSubjects.Remove(this.SelectedSubject);

                        RefreshDocSubjectTree();

                        this.SelectedSubject = null;

                        this.IsLoadingData = false;
                    }, null);

                }, null);
        }

        internal void RemoveDocFile(System.Collections.IList docFiles)
        {
            //if (this.SelectedFile == null)
            if (docFiles == null)
            {
                return;
            }

            this.IsLoadingData = true;

            var docFileQuery = context.GetDocFilesForQuery(this.SelectedSubject.SubjectId);

            context.Load(docFileQuery, System.ServiceModel.DomainServices.Client.LoadBehavior.MergeIntoCurrent,
                callback =>
                {
                    foreach (var item in docFiles)
                    {
                        var docFile = context.DocFiles.First(i => i.FileID == ((DocFileViewModel)item).FileId);

                        context.DocFiles.Remove(docFile);
                    }

                    context.SubmitChanges(callback1 =>
                    {
                        if (callback1.HasError)
                        {
                            MessageWindow win = new MessageWindow();
                            win.messageTextBlock.Text = callback1.Error.Message;
                            win.Show();
                        }

                        RefreshDocFileList();

                        this.SelectedFile = null;

                        this.IsLoadingData = false;
                    }, null);

                }, null);
        }

        internal void ViewFileLog()
        {
            RibbonBar.GenerateChildWin<FileLog>("مشاهده لاگ", 0, "fileLog", this);
        }

        internal void ChangeSelectedFileFlag()
        {
            this.SelectedFile.Flag = true;

            var docFileQuery = context.GetDocFilesForQuery(this.SelectedSubject.SubjectId);

            context.Load(docFileQuery, System.ServiceModel.DomainServices.Client.LoadBehavior.RefreshCurrent,
                callback =>
                {
                    context.DocFiles.FirstOrDefault(i => i.FileID == this.SelectedFile.FileId).Flag = !context.DocFiles.FirstOrDefault(i => i.FileID == this.SelectedFile.FileId).Flag;

                    context.SubmitChanges();

                    MessageWindow win = new MessageWindow();

                    win.messageTextBlock.Text = "تغییر با موفقیت اعمال شد";

                    win.Show();
                }, null);
        }

        internal void ChangeSelectedSubjectFilesFlag()
        {
            var docFileQuery = context.GetDocFilesForQuery(this.SelectedSubject.SubjectId);

            context.Load(docFileQuery, System.ServiceModel.DomainServices.Client.LoadBehavior.RefreshCurrent,
                callback1 =>
                {
                    for (int i = 0; i < context.DocFiles.Count; i++)
                    {
                        (context.DocFiles.Skip(i).First() as DocFile).Flag = true;
                    }

                    context.SubmitChanges(callback2 => { RefreshDocFileList(); }, null);

                    MessageWindow win = new MessageWindow();

                    win.messageTextBlock.Text = "تغییر با موفقیت اعمال شد";

                    win.Show();
                }, null);
        }

        internal void EditDocTitle(string newName)
        {
            this.SelectedTitle.TitleFName = newName;

            context.DocTitleTrees.FirstOrDefault(i => i.TitleId == this.SelectedTitle.TitleId).TitleFName = newName;

            context.SubmitChanges();
        }

        internal void EditDocSubject(string newName)
        {
            this.SelectedSubject.SubjectFName = newName;

            var queryBuilder = new Microsoft.Windows.Data.DomainServices.QueryBuilder<DocSubjectTree>();

            queryBuilder = queryBuilder.Where(i => i.SubjectID == this.SelectedSubject.SubjectId);

            var query = context.GetDocSubjectTreeQuery();

            query = queryBuilder.ApplyTo(query);

            context.DocSubjectTrees.Clear();

            context.Load(query, System.ServiceModel.DomainServices.Client.LoadBehavior.RefreshCurrent,
                callback =>
                {
                    context.DocSubjectTrees.FirstOrDefault().SubjectFName = newName;

                    context.SubmitChanges();
                }, null);
        }

        internal void CutSelectedDocTitle()
        {
            this.IsPasteTitleEnabled = true;

            this.CopiedDocTitleID = this.SelectedTitle.TitleId;
        }

        internal void PasteSelectedDocTitle()
        {
            this.IsPasteTitleEnabled = false;

            this.IsLoadingData = true;

            PMOContext pasteContext = new PMOContext();

            var queryBuilder = new Microsoft.Windows.Data.DomainServices.QueryBuilder<DocTitleTree>();

            queryBuilder = queryBuilder.Where(i => i.TitleId == this.CopiedDocTitleID);

            var query = pasteContext.GetDocTitleTreeQuery();

            query = queryBuilder.ApplyTo(query);

            pasteContext.Load(query, System.ServiceModel.DomainServices.Client.LoadBehavior.RefreshCurrent,
                callback =>
                {
                    pasteContext.DocTitleTrees.FirstOrDefault().ParentTitleId = this.SelectedTitle.TitleId;

                    pasteContext.SubmitChanges(callback2 =>
                        {
                            GetAllTitles();
                        }, null);

                }, null);
        }

        internal void CutSelectedDocSubject()
        {
            this.CopiedDocSubject = this.SelectedSubject;

            this.IsPasteSubjectEnabled = true;
        }

        internal void PasteSelectedDocSubject()
        {
            this.IsPasteSubjectEnabled = false;

            this.IsLoadingData = true;

            PMOContext pasteContext = new PMOContext();

            var queryBuilder = new Microsoft.Windows.Data.DomainServices.QueryBuilder<DocSubjectTree>();

            queryBuilder = queryBuilder.Where(i => i.SubjectID == this.CopiedDocSubject.SubjectId);

            var query = pasteContext.GetDocSubjectTreeQuery();

            query = queryBuilder.ApplyTo(query);

            pasteContext.Load(query, System.ServiceModel.DomainServices.Client.LoadBehavior.RefreshCurrent,
                callback =>
                {
                    pasteContext.DocSubjectTrees.FirstOrDefault().SubjectParentID = this.SelectedSubject.SubjectId;

                    pasteContext.DocSubjectTrees.FirstOrDefault().TitleID = this.SelectedSubject.TitleId;

                    pasteContext.SubmitChanges(callback2 =>
                    {
                        this.allSubjects.Single(i => i.SubjectId == this.CopiedDocSubject.SubjectId).ParentSubjectId = this.SelectedSubject.SubjectId;

                        this.allSubjects.Single(i => i.SubjectId == this.CopiedDocSubject.SubjectId).TitleId = this.SelectedSubject.TitleId;

                        RefreshDocSubjectTree();
                    }, null);

                }, null);
        }

        //NEW CHANGES 92.12.19
        internal void CreateFoldersForTitles()
        {
            foreach (var item in this.DocTitleCollection)
            {
                foreach (var child in item.Children)
                {
                    CreateFoldersForTitles(item);
                }
            }
        }

        private void CreateFoldersForTitles(DocTitleTreeViewModel item)
        {
            string folderPath = GetFolderPath(item);

            //YOUR CODE HERE:
            //Create your folder useing "folderPath"
        }

        private string GetFolderPath(DocTitleTreeViewModel item)
        {
            string temp = item.TitleFName;

            if (item.Parent != null)
            {
                return System.IO.Path.Combine(GetFolderPath(item.Parent), temp);
            }

            return temp;

        }

        internal void CreateFoldersForSubjects()
        {
            foreach (var item in this.DocSubjectCollection)
            {
                foreach (var child in item.Children)
                {
                    CreateFoldersForSubjects(item);
                }
            }
        }

        private void CreateFoldersForSubjects(DocSubjectTreeViewModel item)
        {
            string folderPath = GetFolderPath(item);

            //YOUR CODE HERE:
            //Create your folder useing "folderPath"
        }

        private string GetFolderPath(DocSubjectTreeViewModel item)
        {
            string temp = item.SubjectFName;

            if (item.Parent != null)
            {
                return System.IO.Path.Combine(GetFolderPath(item.Parent), temp);
            }

            return temp;

        }
        //NEW CHANGES 92.12.19
    }
}
