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
using System.Collections.ObjectModel;

namespace LanSysWebGIS.Presenter
{
    public class DocTitlePresenter : Notifier
    {
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

        private string _fName;

        public string FName
        {
            get { return _fName; }
            set
            {
                _fName = value;
                OnPropertyChanged("FName");
            }
        }

        private string _eName;

        public string EName
        {
            get { return _eName; }
            set
            {
                _eName = value;
                OnPropertyChanged("EName");
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

    }
}
