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

namespace LanSysWebGIS.Models
{
    public class ApplicationPresenter : Notifier
    {
        private bool _isBusy;

        public bool IsBusy
        {
            get { return this._isBusy; }
            set
            {
                if (value != _isBusy)
                {
                    this._isBusy = value;
                    OnPropertyChanged("IsBusy");
                }
            }
        }

    }
}
