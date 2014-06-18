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
    public class FormNo200ItemModel : Notifier
    {
        private string _nam;

        public string Nam
        {
            get { return _nam; }
            set
            {
                _nam = value;
                OnPropertyChanged("Nam");
            }
        }

        private string _nameKhanevadegi;

        public string NameKhanevadegi
        {
            get { return _nameKhanevadegi; }
            set
            {
                _nameKhanevadegi = value;
                OnPropertyChanged("NameKhanevadegi");
            }
        }

        private string _namePedar;

        public string NamePedar
        {
            get { return _namePedar; }
            set
            {
                _namePedar = value;
                OnPropertyChanged("NamePedar");
            }
        }

        private string _kodeMelli;

        public string KodeMelli
        {
            get { return _kodeMelli; }
            set
            {
                _kodeMelli = value;
                OnPropertyChanged("KodeMelli");
            }
        }

        private string _shomareShenasname;

        public string ShomareShenasname
        {
            get { return _shomareShenasname; }
            set
            {
                _shomareShenasname = value;
                OnPropertyChanged("ShomareShenasname");
            }
        }

        private string _semat;

        private string _shomarePerseneli;

        public string ShomarePerseneli
        {
            get { return _shomarePerseneli; }
            set
            {
                _shomarePerseneli = value;
                OnPropertyChanged("ShomarePerseneli");
            }
        }

        public string Semat
        {
            get { return _semat; }
            set
            {
                _semat = value;
                OnPropertyChanged("Semat");
            }
        }

        private double _mablagSahm;

        public double MablagSahm
        {
            get { return _mablagSahm; }
            set
            {
                _mablagSahm = value;
                OnPropertyChanged("MablagSahm");
            }
        }

        private double _tedadeSahm;

        public double TedadeSahm
        {
            get { return _tedadeSahm; }
            set
            {
                _tedadeSahm = value;
                OnPropertyChanged("TedadeSahm");
            }
        }

        private string darsadSahm;

        public string DarsadSahm
        {
            get { return darsadSahm; }
            set
            {
                darsadSahm = value;
                OnPropertyChanged("DarsadSahm");
            }
        }

        private string _madrakTahsili;

        public string MadrakTahsili
        {
            get { return _madrakTahsili; }
            set
            {
                _madrakTahsili = value;
                OnPropertyChanged("MadrakTahsili");
            }
        }

        private string _reshteyeTahsili;

        public string ReshteyeTahsili
        {
            get { return _reshteyeTahsili; }
            set
            {
                _reshteyeTahsili = value;
                OnPropertyChanged("ReshteyeTahsili");
            }
        }

        private string _daneshgah;

        public string Daneshgah
        {
            get { return _daneshgah; }
            set
            {
                _daneshgah = value;
                OnPropertyChanged("Daneshgah");
            }
        }

        private double _saleAkhz;

        public double SaleAkhz
        {
            get { return _saleAkhz; }
            set
            {
                _saleAkhz = value;
                OnPropertyChanged("SaleAkhz");
            }
        }

        private string _keshvar;

        public string Keshvar
        {
            get { return _keshvar; }
            set
            {
                _keshvar = value;
                OnPropertyChanged("Keshvar");
            }
        }


    }
}
