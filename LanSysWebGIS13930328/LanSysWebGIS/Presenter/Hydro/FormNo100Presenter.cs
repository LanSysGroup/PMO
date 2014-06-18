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

namespace LanSysWebGIS.Presenter.Hydro
{
    public class FormNo100Presenter : Notifier
    {
        Web.HydroContext context = new Web.HydroContext();

        public event EventHandler OnProcessStarted;

        public event EventHandler OnProcessFinished;

        private Models.Hydro.FormNo100Model _currentItem;

        public Models.Hydro.FormNo100Model CurrentItem
        {
            get { return _currentItem; }
            set
            {
                _currentItem = value;
                OnPropertyChanged("CurrentItem");
            }
        }

        public FormNo100Presenter(Models.Hydro.FormNo100Model item)
        {
            this.CurrentItem = item;
        }

        internal void Save()
        {
            if (string.IsNullOrEmpty(this.CurrentItem.NameKamelePeymankar))
                return;

            if (OnProcessStarted != null)
            {
                OnProcessStarted(null, null);
            }

            Web.HydroContext context = new Web.HydroContext();

            context.Peymankars.Add(this.CurrentItem.Parse());

            context.SubmitChanges(callback =>
            {
                if (OnProcessFinished != null)
                {
                    OnProcessFinished(null, null);
                }
            }, null);
        }

        internal void Reset()
        {
            this.CurrentItem = new Models.Hydro.FormNo100Model();
        }

       
    }
}
