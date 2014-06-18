using System;
using System.Linq;
using System.Collections.Generic;
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
    public class IMOPresenter : Notifier
    {
        private Web.HydroContext _context = new Web.HydroContext();

        public Web.HydroContext Context
        {
            get { return _context; }
            set
            {
                _context = value;
                OnPropertyChanged("Context");
            }
        }

        private bool _isBusy;

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged("IsBusy");
            }
        }

        private Web.SummaryOfPermits _currentSummaryOfPermits;

        public Web.SummaryOfPermits CurrentSummaryOfPermits
        {
            get { return _currentSummaryOfPermits; }
            set
            {
                _currentSummaryOfPermits = value;
                OnPropertyChanged("CurrentSummaryOfPermits");
            }
        }

        private Web.DetailsOfCO2 _currentDetailsOfCO2;

        public Web.DetailsOfCO2 CurrentDetailsOfCO2
        {
            get { return _currentDetailsOfCO2; }
            set
            {
                _currentDetailsOfCO2 = value;
                OnPropertyChanged("CurrentDetailsOfCO2");
            }
        }

        private Web.DetailsOfDeposit _currentDetailsOfDeposit;

        public Web.DetailsOfDeposit CurrentDetailsOfDeposit
        {
            get { return _currentDetailsOfDeposit; }
            set
            {
                _currentDetailsOfDeposit = value;
                OnPropertyChanged("CurrentDetailsOfDeposit");
            }
        }

        private ObservableCollection<Web.SummaryOfPermits> _allPermits;

        public ObservableCollection<Web.SummaryOfPermits> AllPermits
        {
            get { return _allPermits; }
            set
            {
                _allPermits = value;
                OnPropertyChanged("AllPermits");
            }
        }

        private ObservableCollection<Web.DetailsOfCO2> _allDetailsOfCO2;

        public ObservableCollection<Web.DetailsOfCO2> AllDetailsOfCO2
        {
            get { return _allDetailsOfCO2; }
            set
            {
                _allDetailsOfCO2 = value;
                OnPropertyChanged("AllDetailsOfCO2");
            }
        }

        public IMOPresenter()
        {
            this.IsBusy = true;

            _context.Load(
                  _context.GetSummaryOfPermitsQuery(),
                  System.ServiceModel.DomainServices.Client.LoadBehavior.RefreshCurrent,
                  callback =>
                  {
                      _context.Load(_context.GetDetailsOfCO2Query(), System.ServiceModel.DomainServices.Client.LoadBehavior.RefreshCurrent,
                          callback2 =>
                          {
                              this.AllDetailsOfCO2 = new ObservableCollection<Web.DetailsOfCO2>();

                              foreach (var item in _context.DetailsOfCO2s)
                              {
                                  this.AllDetailsOfCO2.Add(item);
                              }

                              _context.Load(_context.GetDetailsOfDepositQuery(), System.ServiceModel.DomainServices.Client.LoadBehavior.RefreshCurrent,
                                  callback3 =>
                                  {
                                      //foreach (var item in _context.DetailsOfDeposits)
                                      //{
                                      ////    this.AllDetailsOfDeposit.Add(item);
                                      //}

                                      IsBusy = false;
                                  }, null);
                          }, null);

                      AllPermits = new ObservableCollection<Web.SummaryOfPermits>();

                      foreach (var item in _context.SummaryOfPermits)
                      {
                          AllPermits.Add(item);
                      }

                      this.IsBusy = false;
                  },
                  null);
        }

        internal void RemoveSummaryOfPermits()
        {
            if (this.CurrentSummaryOfPermits == null)
            {
                return;
            }

            _context.SummaryOfPermits.Remove(this.CurrentSummaryOfPermits);

            this.AllPermits.Remove(this.CurrentSummaryOfPermits);

            this.CurrentSummaryOfPermits = _context.SummaryOfPermits.FirstOrDefault();
        }

        internal void NewSummaryOfPermits()
        {
            Web.SummaryOfPermits newItem = new Web.SummaryOfPermits() { Id = int.MinValue };

            _context.SummaryOfPermits.Add(newItem);

            this.AllPermits.Add(newItem);

            this.CurrentSummaryOfPermits = newItem;
        }

        internal void NewCO2Details()
        {
            Web.DetailsOfCO2 newItem = new Web.DetailsOfCO2();

            _context.DetailsOfCO2s.Add(newItem);

            this.AllDetailsOfCO2.Add(newItem);

            this.CurrentDetailsOfCO2 = newItem;
        }

        internal void RemoveCO2Details()
        {
            if (this.CurrentDetailsOfCO2 == null)
            {
                return;
            }

            this.AllDetailsOfCO2.Remove(this.CurrentDetailsOfCO2);

            this.Context.DetailsOfCO2s.Remove(this.CurrentDetailsOfCO2);

            this.CurrentDetailsOfCO2 = this.Context.DetailsOfCO2s.FirstOrDefault();
        }

        internal void Save()
        {
            this.IsBusy = true;

            foreach (var item in _context.DetailsOfCO2InjectionWells)
            {
                System.Diagnostics.Debug.WriteLine("DOCO2 Id: " + item.DetailsOfCO2Id + " Well: " + item.InjectionWell);
            }

            _context.SubmitChanges(new Action<System.ServiceModel.DomainServices.Client.SubmitOperation>((input) => { this.IsBusy = false; }), null);
        }

        internal void RemoveDetailsOfCO2InjectionWell(Web.DetailsOfCO2InjectionWell detailsOfCO2InjectionWell)
        {
            _context.DetailsOfCO2InjectionWells.Remove(detailsOfCO2InjectionWell);
        }

        internal void RemoveDetailsOfCO2Chamical(Web.DetailsOfCO2Chamical detailsOfCO2Chamical)
        {
            _context.DetailsOfCO2Chamicals.Remove(detailsOfCO2Chamical);
        }
    }
}
