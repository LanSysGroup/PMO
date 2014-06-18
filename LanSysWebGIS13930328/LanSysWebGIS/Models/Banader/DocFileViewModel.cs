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

namespace LanSysWebGIS.Presenter
{
    public class DocFileViewModel : Notifier
    {
        private int _fileId;
        public int FileId
        {
            get { return _fileId; }
            set
            {
                _fileId = value;
                OnPropertyChanged("FileId");
            }
        }

        //public string FilePath
        //{
        //    get { return System.IO.Path.GetDirectoryName(_fullFileName); }
        //}

        private string _filePath;
        public string FilePath
        {
            get { return _filePath; }
            set
            {
                _filePath = value;
                OnPropertyChanged("FilePath");
            }
        }

        private string _fileName;
        public string FileName
        {
            get { return _fileName; }
            set
            {
                _fileName = value;
                OnPropertyChanged("FileName");
            }
        }

        private string _fileExt;
        public string FileExt
        {
            get { return _fileExt; }
            set
            {
                _fileExt = value;
                OnPropertyChanged("FileExt");
            }
        }

        //public string FileName
        //{
        //    get { return System.IO.Path.GetFileNameWithoutExtension(_fullFileName); }
        //}

        //public string FileExt
        //{
        //    get { return System.IO.Path.GetExtension(_fullFileName); }
        //}

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

        private bool _flag;
        public bool Flag
        {
            get { return _flag; }
            set
            {
                _flag = value;
                OnPropertyChanged("Flag");
            }
        }

        private DateTime? _dateAdded;
        public DateTime? DateAdded
        {
            get { return _dateAdded; }
            set
            {
                _dateAdded = value;
                OnPropertyChanged("DateAdded");
            }
        }

        private string _addedByUserName;
        public string AddedByUserName
        {
            get { return _addedByUserName; }
            set
            {
                _addedByUserName = value;
                OnPropertyChanged("AddedByUserName");
            }
        }

        private DateTime? _toDate;
        public DateTime? ToDate
        {
            get { return _toDate; }
            set
            {
                _toDate = value;
                OnPropertyChanged("ToDate");
            }
        }

        private DateTime? _fromDate;
        public DateTime? FromDate
        {
            get { return _fromDate; }
            set
            {
                _fromDate = value;
                OnPropertyChanged("FromDate");
            }
        }

        private double? _latX;
        public double? LatX
        {
            get { return _latX; }
            set
            {
                _latX = value;
                OnPropertyChanged("LatX");
            }
        }

        private double? _longY;
        public double? LongY
        {
            get { return _longY; }
            set
            {
                _longY = value;
                OnPropertyChanged("LongY");
            }
        }

        //private string _fullFileName;
        //public string FullFileName
        //{
        //    get { return _fullFileName; }
        //    set
        //    {
        //        _fullFileName = value;
        //        OnPropertyChanged("FullFileName");
        //        OnPropertyChanged("FilePath");
        //        OnPropertyChanged("FileName");
        //        OnPropertyChanged("FileExt");
        //    }
        //}

        private IList<GenericViewModel<LanSysWebGIS.Web.KeyWordList>> _keywords;

        public IList<GenericViewModel<LanSysWebGIS.Web.KeyWordList>> Keywords
        {
            get { return _keywords; }
            set
            {
                _keywords = value;
                OnPropertyChanged("Keywords");
            }
        }
    }
}
