using System;
using System.ComponentModel;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace LanSysWebGIS.Models
{
    public class GeoMapsLegendItem : INotifyPropertyChanged
    {
        private string _sheetName;

        public String SheetName 
        {
            get { return _sheetName; }
            set
            {
                if (value != _sheetName)
                {
                    _sheetName = value;
                    NotifyPropertyChanged("SheetName");
                }
                _sheetName = value;
            }
        }

        private string _legendURI;

        public String LegendURI
        {
            get { return _legendURI; }
            set
            {
                if (value != _legendURI)
                {
                    _legendURI = value;
                    NotifyPropertyChanged("LegendURI");
                }
                _legendURI = value;
            }
        }

        private string _indexType;

        public String IndexType
        {
            get { return _indexType; }
            set
            {
                if (value != _indexType)
                {
                    _indexType = value;
                    NotifyPropertyChanged("IndexType");
                }
                _indexType = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
