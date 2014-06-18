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
using System.ServiceModel.DomainServices.Client;
using Newtonsoft.Json;
using LanSysWebGIS.Views.UserManagement;
using LanSysWebGIS.WebMethodsService;

namespace LanSysWebGIS.Presenter
{
    public class AddSubjectPresenter : Notifier
    {
        private Models.DocSubjectTreeViewModel _current;

        public Models.DocSubjectTreeViewModel Current
        {
            get { return _current; }
            set
            {
                _current = value;
                OnPropertyChanged("Current");
            }
        }

        private int _userId;

        private bool _isLoading;

        public LanSysWebGIS.Presenter.MainCategoryPresenter mainCategoryPresenter;

        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                OnPropertyChanged("IsLoading");
            }
        }

        LanSysWebGIS.Web.PMOContext context;

        private Models.DocSubjectTreeViewModel _parent;

        public Models.DocSubjectTreeViewModel Parent
        {
            get { return _parent; }
            set
            {
                _parent = value;
                OnPropertyChanged("Parent");
            }
        }


        private IList<GenericViewModel<LanSysWebGIS.Web.Ostan>> _provinces;

        public IList<GenericViewModel<LanSysWebGIS.Web.Ostan>> Provinces
        {
            get { return _provinces; }
            set
            {
                _provinces = value;
                OnPropertyChanged("Provinces");
            }
        }


        private IList<GenericViewModel<LanSysWebGIS.Web.tblDataType>> _dataTypes;

        public IList<GenericViewModel<LanSysWebGIS.Web.tblDataType>> DataTypes
        {
            get { return _dataTypes; }
            set
            {
                _dataTypes = value;
                OnPropertyChanged("DataTypes");
            }
        }


        private IList<GenericViewModel<LanSysWebGIS.Web.tblInfoType>> _infoTypes;

        public IList<GenericViewModel<LanSysWebGIS.Web.tblInfoType>> InfoTypes
        {
            get { return _infoTypes; }
            set
            {
                _infoTypes = value;
                OnPropertyChanged("InfoTypes");
            }
        }


        private IList<GenericViewModel<LanSysWebGIS.Web.tblPorts>> _ports;

        public IList<GenericViewModel<LanSysWebGIS.Web.tblPorts>> Ports
        {
            get { return _ports; }
            set
            {
                _ports = value;
                OnPropertyChanged("Ports");
            }
        }


        private IList<GenericViewModel<LanSysWebGIS.Web.Zone>> _zones;

        public IList<GenericViewModel<LanSysWebGIS.Web.Zone>> Zones
        {
            get { return _zones; }
            set
            {
                _zones = value;
                OnPropertyChanged("Zones");
            }
        }

        private IList<GenericViewModel<LanSysWebGIS.Web.DocSubjectTree>> _docSubjectTrees;

        public IList<GenericViewModel<LanSysWebGIS.Web.DocSubjectTree>> DocSubjectTrees
        {
            get { return _docSubjectTrees; }
            set
            {
                _docSubjectTrees = value;
                OnPropertyChanged("DocSubjectTrees");
            }
        }

        public AddSubjectPresenter(LanSysWebGIS.Presenter.MainCategoryPresenter mainCategoryPresenter)
        {
            this._userId = mainCategoryPresenter.UserId;

            this.mainCategoryPresenter = mainCategoryPresenter;

            this.context = new Web.PMOContext();

            this.Parent = mainCategoryPresenter.SelectedSubject;

            //var provinces = context.GetOstanQuery();

            //var zones = context.GetZoneQuery();

            //var ports = context.GetTblPortsQuery();

            //var infoTypes = context.GetTblInfoTypeQuery();

            //var dataTypes = context.GetTblDataTypeQuery();

            var docSubjectTree = context.GetDocSubjectTreeQuery();

            this.IsLoading = true;

            int numberOfFinishedTasks = 0;

            int threashold = 6;

            context.GetDocSubjectWithMaxId(
             action =>
             {
                 this.Current = new Models.DocSubjectTreeViewModel()
                 {
                     SubjectId = action.Value + 1,
                     TitleId = mainCategoryPresenter.SelectedTitle.TitleId,
                     ParentSubjectId = Parent.SubjectId
                 };

                 this.IsLoading = ++numberOfFinishedTasks == threashold;
             },
             null);

            context.Load(docSubjectTree, System.ServiceModel.DomainServices.Client.LoadBehavior.RefreshCurrent,
                callback =>
                {
                    this.DocSubjectTrees = context.DocSubjectTrees.Parse();

                    this.IsLoading = ++numberOfFinishedTasks == threashold;
                }, null);

            context.Load(context.GetZoneQuery(), System.ServiceModel.DomainServices.Client.LoadBehavior.MergeIntoCurrent,
                callback =>
                {
                    this.Zones = context.Zones.Parse();

                    this.IsLoading = ++numberOfFinishedTasks == threashold;
                }, null);

            context.Load(context.GetOstanQuery(), System.ServiceModel.DomainServices.Client.LoadBehavior.MergeIntoCurrent,
                callback =>
                {
                    this.Provinces = context.Ostans.Parse();

                    this.IsLoading = ++numberOfFinishedTasks == threashold;
                }, null);

            context.Load(context.GetTblPortsQuery(), System.ServiceModel.DomainServices.Client.LoadBehavior.MergeIntoCurrent,
                callback =>
                {
                    this.Ports = context.tblPorts.Parse();

                    this.IsLoading = ++numberOfFinishedTasks == threashold;
                }, null);

            context.Load(context.GetTblInfoTypeQuery(), System.ServiceModel.DomainServices.Client.LoadBehavior.MergeIntoCurrent,
                callback =>
                {
                    this.InfoTypes = context.tblInfoTypes.Parse();

                    this.IsLoading = ++numberOfFinishedTasks == threashold;
                }, null);

            context.Load(context.GetTblDataTypeQuery(), System.ServiceModel.DomainServices.Client.LoadBehavior.MergeIntoCurrent,
                callback =>
                {
                    this.DataTypes = context.tblDataTypes.Parse();

                    this.IsLoading = ++numberOfFinishedTasks == threashold;
                }, null);
        }

        public void Add(AddSubject view)
        {
            this.IsLoading = true;

            var provinces = this.Provinces.Where(i => i.IsSelected == true).Select(i => i.Entity).Select(i => i.ID);

            var ports = this.Ports.Where(i => i.IsSelected == true).Select(i => i.Entity).Select(i => i.ID);

            var infoTypes = this.InfoTypes.Where(i => i.IsSelected == true).Select(i => i.Entity).Select(i => i.ID);

            var dataTypes = this.DataTypes.Where(i => i.IsSelected == true).Select(i => i.Entity).Select(i => i.ID);

            var zones = this.Zones.Where(i => i.IsSelected == true).Select(i => i.Entity).Select(i => i.ID);

            List<string> provincesList = new List<string>();

            Web.DocSubjectTree docSubjectTree = new Web.DocSubjectTree()
            {
                SubjectID = this.Current.SubjectId,
                SubjectEName = this.Current.SubjectEName,
                SubjectFName = this.Current.SubjectFName,
                SubjectParentID = this.Current.ParentSubjectId,
                TitleID = this.Current.TitleId,
            };

            var method = context.SaveDocSubjectTree(JsonConvert.SerializeObject(docSubjectTree), provinces, dataTypes, infoTypes, ports, zones);

            method.Completed += delegate
            {
                if (method.HasError)
                {
                    MessageWindow win = new MessageWindow();
                    win.messageTextBlock.Text = method.Error.Message;
                    win.Show();
                    IsLoading = false;
                }
                else
                {
                    context.DocSubjectUserFilters.Add(new Web.DocSubjectUserFilter()
                    {
                        SubjectId = this.Current.SubjectId,
                        UserId = this._userId
                    });

                    context.SubmitChanges(callback3 =>
                    {
                        this.mainCategoryPresenter.AddDocSubjectTree(Current);

                        IsLoading = false;
                        view.DialogResult = true;
                        MessageWindow win = new MessageWindow();
                        win.messageTextBlock.Text = "اضافه کردن موضوع با موفقیت انجام شد.";
                        win.Show();
                    }, null);

                }
            };
        }


    }
}
