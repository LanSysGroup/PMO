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

namespace LanSysWebGIS.Models.Hydro
{
    public class ProjectIdentificationModel : Notifier
    {
        private string _projectName;

        public string ProjectName
        {
            get { return _projectName; }
            set
            {
                _projectName = value;
                OnPropertyChanged("ProjectName");
            }
        }

        private bool _isEhdasi;

        public bool IsEhdasi
        {
            get { return _isEhdasi; }
            set
            {
                _isEhdasi = value;
                OnPropertyChanged("IsEhdasi");
            }
        }

        private bool _isNegahdari;

        public bool IsNegahdari
        {
            get { return _isNegahdari; }
            set
            {
                _isNegahdari = value;
                OnPropertyChanged("IsNegahdari");
            }
        }

        private bool _isTamighi;

        public bool IsTamighi
        {
            get { return _isTamighi; }
            set
            {
                _isTamighi = value;
                OnPropertyChanged("IsTamighi");
            }
        }

        private string _mahdodeLayroobi;

        public string MahdodeLayroobi
        {
            get { return _mahdodeLayroobi; }
            set
            {
                _mahdodeLayroobi = value;
                OnPropertyChanged("MahdodeLayroobi");
            }
        }

        public ProjectIdentificationModel()
        {
            this.MahdodeLayroobi = string.Empty;
        }
    }
}
