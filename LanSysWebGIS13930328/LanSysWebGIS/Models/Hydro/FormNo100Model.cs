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
    public class FormNo100Model : Notifier
    {
        private int? _id;

        public int? Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

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

        private DateTime? _tarikhErsalForm;

        public DateTime? TarikhErsalForm
        {
            get { return _tarikhErsalForm; }
            set
            {
                _tarikhErsalForm = value;

                OnPropertyChanged("TarikhErsalForm");
            }
        }

        private double? _shomareSafePorseshName;

        public double? ShomareSafePorseshName
        {
            get { return _shomareSafePorseshName; }
            set
            {
                _shomareSafePorseshName = value;
                OnPropertyChanged("ShomareSafePorseshName");
            }
        }

        private double? _tedadSafehayePorseshName;

        public double? TedadSafehayePorseshName
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

        private string _nameGabliPeymankar1;

        public string NameGabliPeymankar1
        {
            get { return _nameGabliPeymankar1; }
            set
            {
                _nameGabliPeymankar1 = value;
                OnPropertyChanged("NameGabliPeymankar1 ");
            }
        }

        private string _nameGabliPeymankar2;

        public string NameGabliPeymankar2
        {
            get { return _nameGabliPeymankar2; }
            set
            {
                _nameGabliPeymankar2 = value;
                OnPropertyChanged("NameGabliPeymankar2 ");
            }
        }

        private string _shomareTelefonDaftarMarkazi;

        public string ShomareTelefonDaftarMarkazi
        {
            get { return _shomareTelefonDaftarMarkazi; }
            set
            {
                _shomareTelefonDaftarMarkazi = value;
                OnPropertyChanged("ShomareTelefonDaftarMarkazi");
            }
        }

        private double? _shomareSabt;

        public double? ShomareSabt
        {
            get { return _shomareSabt; }
            set
            {
                _shomareSabt = value;
                OnPropertyChanged("ShomareSabt");
            }
        }

        private string _mahaleSabt;

        public string MahaleSabt
        {
            get { return _mahaleSabt; }
            set
            {
                _mahaleSabt = value;
                OnPropertyChanged("MahaleSabt");
            }
        }

        private DateTime? _tarikhSabt;

        public DateTime? TarikhSabt
        {
            get { return _tarikhSabt; }
            set
            {
                _tarikhSabt = value;
                OnPropertyChanged("TarikhSabt");
            }
        }

        private string _noeSabt;

        public string NoeSabt
        {
            get { return _noeSabt; }
            set
            {
                _noeSabt = value;
                OnPropertyChanged("NoeSabt");
            }
        }

        private DateTime? _tarikhTasis;

        public DateTime? TarikhTasis
        {
            get { return _tarikhTasis; }
            set
            {
                _tarikhTasis = value;
                OnPropertyChanged("TarikhTasis");
            }
        }

        private string _neshaniSherkat;

        public string NeshaniSherkat
        {
            get { return _neshaniSherkat; }
            set
            {
                _neshaniSherkat = value;
                OnPropertyChanged("NeshaniSherkat");
            }
        }

        private string _noeMalekiyatDaftarMarkazi;

        public string NoeMalekiyatDaftarMarkazi
        {
            get { return _noeMalekiyatDaftarMarkazi; }
            set
            {
                _noeMalekiyatDaftarMarkazi = value;
                OnPropertyChanged("NoeMalekiyatDaftarMarkazi");
            }
        }

        private double? _satheZirbanayeDaftarMarkazi;

        public double? SatheZirbanayeDaftarMarkazi
        {
            get { return _satheZirbanayeDaftarMarkazi; }
            set
            {
                _satheZirbanayeDaftarMarkazi = value;
                OnPropertyChanged("SatheZirbanayeDaftarMarkazi");
            }
        }

        private double _tedadKarkonanModir;

        public double TedadKarkonanModir
        {
            get { return _tedadKarkonanModir; }
            set
            {
                _tedadKarkonanModir = value;

                OnPropertyChanged("TedadKarkonanModir");
            }
        }

        private double _tedadShoraka;

        public double TedadShoraka
        {
            get { return _tedadShoraka; }
            set
            {
                _tedadShoraka = value;
                OnPropertyChanged("TedadShoraka");
            }
        }

        private double _tedadKarkonanFani;

        public double TedadKarkonanFani
        {
            get { return _tedadKarkonanFani; }
            set
            {
                _tedadKarkonanFani = value;
                OnPropertyChanged("TedadKarkonanFani");
            }
        }

        private double _tedadKarkonanKhadamati;

        public double TedadKarkonanKhadamati
        {
            get { return _tedadKarkonanKhadamati; }
            set
            {
                _tedadKarkonanKhadamati = value;
                OnPropertyChanged("TedadKarkonanKhadamati");
            }
        }

        private DateTime GetDateTime(string dateTime)
        {
            DateTime result;

            DateTime.TryParse(dateTime, out result);

            return result;
        }

        public FormNo100Model()
        {
            this.Id = null;
        }

        public Web.Peymankar Parse()
        {
            return new Web.Peymankar()
            {
                KodeSherkat = this.KodeSherkat,
                MahaleSabt = this.MahaleSabt,
                NameGabliPeymankar1 = this.NameGabliPeymankar1,
                NameGabliPeymankar2 = this.NameGabliPeymankar2,
                NameKamelePeymankar = this.NameKamelePeymankar,
                NoeMalekiyatDaftarMarkazi = this.NoeMalekiyatDaftarMarkazi,
                //TarikhTasis = GetDateTime(this.TarikhTasis),
                TarikhTasis = this.TarikhTasis,
                TedadShoraka = this.TedadShoraka,
                TedadKarkonanFani = this.TedadKarkonanFani,
                TedadKarkonanKhadamati = this.TedadKarkonanKhadamati,
                TedadKarkonanModir = this.TedadKarkonanModir,
                NoeSabt = this.NoeSabt,
                NeshaniSherkat = this.NeshaniSherkat,
                SatheZirbanayeDaftarMarkazi = this.SatheZirbanayeDaftarMarkazi,
                //TarikhSabt = GetDateTime(this.TarikhSabt),
                TarikhSabt = this.TarikhSabt,
                TedadSafehayePorseshName = this.TedadSafehayePorseshName,
                //TarikhErsalForm = GetDateTime(this.TarikhErsalForm),
                TarikhErsalForm = this.TarikhErsalForm,
                ShomareSabt = this.ShomareSabt,
                ShomareTelefonDaftarMarkazi = this.ShomareTelefonDaftarMarkazi,
                ShomareSafePorseshName = this.ShomareSafePorseshName
            };
        }

        public static FormNo100Model Parse(Web.Peymankar value)
        {
            return new FormNo100Model()
            {
                Id = value.Id,
                KodeSherkat = value.KodeSherkat,
                MahaleSabt = value.MahaleSabt,
                NameGabliPeymankar1 = value.NameGabliPeymankar1,
                NameGabliPeymankar2 = value.NameGabliPeymankar2,
                NameKamelePeymankar = value.NameKamelePeymankar,
                NeshaniSherkat = value.NeshaniSherkat,
                NoeMalekiyatDaftarMarkazi = value.NoeMalekiyatDaftarMarkazi,
                NoeSabt = value.NoeSabt,
                //SatheZirbanayeDaftarMarkazi = value.SatheZirbanayeDaftarMarkazi.HasValue ? value.SatheZirbanayeDaftarMarkazi.Value : 0,
                //ShomareSabt = value.ShomareSabt.HasValue ? (int)value.ShomareSabt.Value : 0,
                //ShomareSafePorseshName = value.ShomareSafePorseshName.HasValue ? (int)value.ShomareSafePorseshName.Value : 0,
                SatheZirbanayeDaftarMarkazi = value.SatheZirbanayeDaftarMarkazi,
                ShomareSabt = value.ShomareSabt,
                ShomareSafePorseshName = value.ShomareSafePorseshName,
                ShomareTelefonDaftarMarkazi = value.ShomareTelefonDaftarMarkazi,
                //TarikhErsalForm = value.TarikhErsalForm.HasValue ? value.TarikhErsalForm.Value.ToShortDateString() : string.Empty,
                //TarikhSabt = value.TarikhSabt.HasValue ? value.TarikhSabt.Value.ToShortDateString() : string.Empty,
                //TarikhTasis = value.TarikhTasis.HasValue ? value.TarikhTasis.Value.ToShortDateString() : string.Empty,
                TarikhErsalForm = value.TarikhErsalForm,
                TarikhSabt = value.TarikhSabt,
                TarikhTasis = value.TarikhTasis,
                TedadKarkonanFani = (int)value.TedadKarkonanFani.Value,
                TedadKarkonanKhadamati = (int)value.TedadKarkonanKhadamati.Value,
                TedadKarkonanModir = (int)value.TedadKarkonanModir.Value
            };
        }

        public static implicit operator Web.Peymankar(FormNo100Model value)
        {
            return value.Parse();
        }
    }
}
