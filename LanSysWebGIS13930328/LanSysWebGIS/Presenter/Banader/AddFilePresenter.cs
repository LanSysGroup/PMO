using System;
using System.Collections.Generic;
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
using LanSysWebGIS.Views.UserManagement;
using System.Collections.ObjectModel;
using LanSysWebGIS.Models;
using LanSysWebGIS.Web;

namespace LanSysWebGIS.Presenter
{
    public class AddFilePresenter : Notifier
    {
        private bool _isLoading;

        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                OnPropertyChanged("IsLoading");
            }
        }

        public string _loadingContent;

        public string LoadingContent
        {
            get { return _loadingContent; }
            set
            {
                _loadingContent = value;
                OnPropertyChanged("LoadingContent");
            }
        }

        LanSysWebGIS.Web.PMOContext context;

        private Models.DocSubjectTreeViewModel _docSubject;

        MainCategoryPresenter mainCategoryPresenter;

        private string _title;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }

        public Models.DocSubjectTreeViewModel DocSubject
        {
            get { return _docSubject; }
            set
            {
                _docSubject = value;
                OnPropertyChanged("DocSubject");
            }
        }

        private ObservableCollection<DocFileViewModel> _docFiles;

        public ObservableCollection<DocFileViewModel> DocFiles
        {
            get { return _docFiles; }
            set
            {
                _docFiles = value;
                OnPropertyChanged("DocFiles");
            }
        }

        private ObservableCollection<GenericViewModel<LanSysWebGIS.Web.KeyWordList>> _keywords;

        public ObservableCollection<GenericViewModel<LanSysWebGIS.Web.KeyWordList>> Keywords
        {
            get { return _keywords; }
            set
            {
                _keywords = value;
                OnPropertyChanged("Provinces");
            }
        }

        public AddFilePresenter(Models.DocSubjectTreeViewModel parentDocSubject, MainCategoryPresenter mainCategoryPresenter)
        {
            this.LoadingContent = "لطفا شکیبا باشید...";

            this.context = new Web.PMOContext();

            this.DocSubject = parentDocSubject;

            this.DocFiles = new ObservableCollection<DocFileViewModel>();

            this.Keywords = new ObservableCollection<GenericViewModel<Web.KeyWordList>>();

            this.mainCategoryPresenter = mainCategoryPresenter;

            LoadKeywords();
        }

        //این متد رو باید کامل کنی
        public void Add()
        {
            //************************** توضیحات ************************************
            //اینجا بایستی یک 
            //DocFileViewModel
            //بسازی و دیگه باقی کد کارا رو انجام می ده
            //**********************************************************************

            FileUploader uploader = new FileUploader();

            IEnumerable<System.IO.FileInfo> filesInfo = uploader.StartUpload(mainCategoryPresenter.SelecteTitleBasePath, this);

            

            try
            {
                foreach (var info in filesInfo)
                {
                    DocFileViewModel docFileViewModel = new DocFileViewModel()
                    {
                        FileExt = info.Extension,
                        FileName = System.IO.Path.GetFileNameWithoutExtension(info.Name),
                        FilePath = @"Uploads\" + WebContext.Current.User.Name + @"\" + MainPage.CurrentDate.Year + '-' + MainPage.CurrentDate.Month + '-' + MainPage.CurrentDate.Day + @"\",
                        Title = this.Title,
                        SubjectId = this.DocSubject.SubjectId,
                        AddedByUserName = WebContext.Current.User.Name,
                        DateAdded = DateTime.Now,
                        Flag = false
                    };

                    this.DocFiles.Add(docFileViewModel);
                }
            }
            catch (Exception)
            {
            }
        }

        internal void LoadKeywords()
        {
            this.IsLoading = true;

            this.Keywords.Clear();

            context.Load(context.GetKeyWordListQuery(), System.ServiceModel.DomainServices.Client.LoadBehavior.RefreshCurrent,
                callback =>
                {
                    if (callback.HasError)
                    {
                        MessageWindow win = new MessageWindow();
                        win.messageTextBlock.Text = callback.Error.Message;
                        win.Show();
                    }

                    var list = context.KeyWordLists.Parse();

                    foreach (var item in list)
                    {
                        this.Keywords.Add(item);
                    }

                    this.IsLoading = false;
                }, null);
        }

        internal void AddTag(string newTag)
        {
            this.IsLoading = true;

            var maxId = context.GetKeywordListMaxId(
                callback =>
                {
                    context.Load(context.GetKeyWordListQuery(), System.ServiceModel.DomainServices.Client.LoadBehavior.RefreshCurrent,
                        callback2 =>
                        {
                            context.KeyWordLists.Add(new Web.KeyWordList() { Name = newTag, Id = callback.Value + 1 });

                            context.SubmitChanges(callback3 =>
                            {
                                if (callback3.HasError)
                                {
                                    MessageWindow win = new MessageWindow();
                                    win.messageTextBlock.Text = callback.Error.Message;
                                    win.Show();
                                    this.IsLoading = false;
                                }
                                else
                                {
                                    LoadKeywords();
                                }

                            }, null);
                        }, null);
                }, null);
        }

        public void AddFiles(UserControls.Banader.AddFile view)
        {
            System.Diagnostics.Debug.WriteLine("AddFiles Entered");
            this.IsLoading = true;

            context.GetDocFileWithMaxId(callback0 =>
            {
                System.Diagnostics.Debug.WriteLine("GetDocFileWithMaxId Loaded");

                int tempId = callback0.Value + 1;

                //context.Load(context.GetDocFileQuery(), System.ServiceModel.DomainServices.Client.LoadBehavior.MergeIntoCurrent,
                //     callback1 =>
                //     {
                System.Diagnostics.Debug.WriteLine("GetDocFile Loaded");

                context.Load(context.GetDocKeyWordQuery(), System.ServiceModel.DomainServices.Client.LoadBehavior.MergeIntoCurrent,
                        callback2 =>
                        {
                            System.Diagnostics.Debug.WriteLine("GetDocKeyWord Loaded");

                            foreach (var item in this.DocFiles)
                            {
                                context.DocFiles.Add(new Web.DocFile()
                                    {
                                        FileID = tempId,
                                        FilePath = item.FilePath,
                                        FileName = item.FileName,
                                        FileExt = item.FileExt,
                                        SubjectID = this.DocSubject.SubjectId,
                                        Title = this.Title,
                                        DateAdded = item.DateAdded,
                                        Flag = item.Flag,
                                        AddedByUserName = item.AddedByUserName
                                    });

                                var selectedKeywords = this.Keywords.Where(i => i.IsSelected).ToList();

                                foreach (var keyword in selectedKeywords)
                                {
                                    context.DocKeyWords.Add(new Web.DocKeyWord() { FileId = tempId, KeyWordId = keyword.Entity.Id });
                                }

                                tempId++;

                            }

                            context.SubmitChanges(callback3 =>
                            {
                                System.Diagnostics.Debug.WriteLine("SubmitChanges Raised");

                                if (callback3.HasError)
                                {
                                    MessageWindow win = new MessageWindow();
                                    win.messageTextBlock.Text = callback3.Error.Message;
                                    win.Show();
                                    view.DialogResult = true;
                                }

                                mainCategoryPresenter.RefreshDocFileList();

                                view.DialogResult = true;

                                IsLoading = false;
                            }, null);

                        }, null);

            }, null);

            //}, null);
        }
    }
}
