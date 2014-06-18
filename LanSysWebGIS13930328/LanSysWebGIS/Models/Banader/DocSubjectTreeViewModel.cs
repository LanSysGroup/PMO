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
    public class DocSubjectTreeViewModel : Notifier
    {
        private int _subjectId;

        public int SubjectId
        {
            get { return _subjectId; }
            set
            {
                _subjectId = value;
                OnPropertyChanged("SubjectId");
            }
        }

        private string _subjectEName;

        public string SubjectEName
        {
            get { return _subjectEName; }
            set
            {
                _subjectEName = value;
                OnPropertyChanged("SubjectEName");
            }
        }

        private string _subjectFName;

        public string SubjectFName
        {
            get { return _subjectFName; }
            set
            {
                _subjectFName = value;
                OnPropertyChanged("SubjectFName");
            }
        }

        private int _parentSubjectId;

        public int ParentSubjectId
        {
            get { return _parentSubjectId; }
            set
            {
                _parentSubjectId = value;
                OnPropertyChanged("ParentSubjectId");
            }
        }

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

        public DocSubjectTreeViewModel Parent { get; set; }

        private ObservableCollection<DocSubjectTreeViewModel> _children;

        public ObservableCollection<DocSubjectTreeViewModel> Children
        {
            get { return _children; }
            set
            {
                _children = value;
                OnPropertyChanged("Children");
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

        public DocSubjectTreeViewModel()
        {
            this._isExpanded = false;

            this.Children = new ObservableCollection<DocSubjectTreeViewModel>();
        }

    }
}
