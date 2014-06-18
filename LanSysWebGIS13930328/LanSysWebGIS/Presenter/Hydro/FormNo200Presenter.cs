using System;
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

namespace LanSysWebGIS.Presenter.Hydro
{
    public class FormNo200Presenter : Notifier
    {
        private string _nameKamelePeymankar;

        public string NameKamelePeymankar
        {
            get { return _nameKamelePeymankar; }
            set
            {
                _nameKamelePeymankar = value;
                OnPropertyChanged("NameKamelePeymankar");
            }
        }

        private string _tarikhErsalForm;

        public string TarikhErsalForm
        {
            get { return _tarikhErsalForm; }
            set
            {
                _tarikhErsalForm = value;
                OnPropertyChanged("TarikhErsalForm");
            }
        }

        private double _shomareSafePorseshName;

        public double ShomareSafePorseshName
        {
            get { return _shomareSafePorseshName; }
            set
            {
                _shomareSafePorseshName = value;
                OnPropertyChanged("ShomareSafePorseshName");
            }
        }

        private double _tedadSafehayePorseshName;

        public double TedadSafehayePorseshName
        {
            get { return _tedadSafehayePorseshName; }
            set
            {
                _tedadSafehayePorseshName = value;
                OnPropertyChanged("TedadSafehayePorseshName");
            }
        }

        private string _kodeSherkat;

        public string KodeSherkat
        {
            get { return _kodeSherkat; }
            set
            {
                _kodeSherkat = value;
                OnPropertyChanged("KodeSherkat");
            }
        }

        private ObservableCollection<Models.Hydro.FormNo200ItemModel> _items;

        public ObservableCollection<Models.Hydro.FormNo200ItemModel> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged("Items");
            }
        }

        public FormNo200Presenter()
        {
            this.Items = new ObservableCollection<Models.Hydro.FormNo200ItemModel>();
        }

        internal void AddNew()
        {
            this.Items.Add(new Models.Hydro.FormNo200ItemModel());
        }
    }
}
