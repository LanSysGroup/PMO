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
using System.Collections.ObjectModel;

namespace LanSysWebGIS.Models
{
    public class DocTitleTreeViewModel : Notifier
    {
        private int _titleId;

        public int TitleId
        {
            get { return _titleId; }
            set
            {
                _titleId = value;
                OnPropertyChanged("TitleId");
            }
        }

        private string _titleEName;

        public string TitleEName
        {
            get { return _titleEName; }
            set
            {
                _titleEName = value;
                OnPropertyChanged("TitleEName");
            }
        }

        private string _titleFName;

        public string TitleFName
        {
            get { return _titleFName; }
            set
            {
                _titleFName = value;
                OnPropertyChanged("TitleFName");
            }
        }

        private int _parentTitleId;

        public int ParentTitleId
        {
            get { return _parentTitleId; }
            set
            {
                _parentTitleId = value;
                OnPropertyChanged("ParentTitleId");
            }
        }

        private int _titleTypeId;

        public int TitleTypeId
        {
            get { return _titleTypeId; }
            set
            {
                _titleTypeId = value;
                OnPropertyChanged("TitleTypeId");
            }
        }

        private string _basePath;

        public string BasePath
        {
            get { return _basePath; }
            set
            {
                _basePath = value;
                OnPropertyChanged("BasePath");
            }
        }


        private string _fromDate;

        public string FromDate
        {
            get { return _fromDate; }
            set
            {
                _fromDate = value;
                OnPropertyChanged("FromDate");
            }
        }

        private string _toDate;

        public string ToDate
        {
            get { return _toDate; }
            set
            {
                _toDate = value;
                OnPropertyChanged("ToDate");
            }
        }

        private ObservableCollection<DocTitleTreeViewModel> _children;

        public ObservableCollection<DocTitleTreeViewModel> Children
        {
            get { return _children; }
            set
            {
                _children = value;
                OnPropertyChanged("Children");
            }
        }

        public DocTitleTreeViewModel Parent { get; set; }

        private bool _isChecked;

        public bool IsChecked
        {
            get { return _isChecked; }
            set
            {
                _isChecked = value;
                OnPropertyChanged("IsChecked");
            }
        }

        private bool _isExpanded;

        public bool IsExpanded
        {
            get { return _isExpanded; }
            set
            {
                _isExpanded = value;
                OnPropertyChanged("IsExpanded");
            }
        }

        public DocTitleTreeViewModel()
        {
            this._children = new ObservableCollection<DocTitleTreeViewModel>();

            this._isExpanded = false;
        }

        public DocTitleTreeViewModel(Web.DocTitleTree docTitle)
        {
            ParentTitleId = docTitle.ParentTitleId.Value;

            TitleId = docTitle.TitleId;

            TitleFName = docTitle.TitleFName;

            TitleEName = docTitle.TitleEName;

            FromDate = docTitle.FromDate;

            BasePath = docTitle.BasePath;

            ToDate = docTitle.ToDate;

            Children = new ObservableCollection<Models.DocTitleTreeViewModel>();

            this.IsExpanded = false;

            this.IsChecked = false;
        }


    }
}
