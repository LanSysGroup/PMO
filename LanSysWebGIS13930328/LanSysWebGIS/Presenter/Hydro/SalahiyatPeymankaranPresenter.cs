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
using LanSysWebGIS.Models.Hydro;

namespace LanSysWebGIS.Presenter.Hydro
{
    public class SalahiyatPeymankaranPresenter : Notifier
    {
        Web.HydroContext context = new Web.HydroContext();

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

        private ObservableCollection<Web.Peymankar> _peymankarha;

        public ObservableCollection<Web.Peymankar> Peymankarha
        {
            get { return _peymankarha; }
            set
            {
                _peymankarha = value;
                OnPropertyChanged("Peymankarha");
            }
        }

        private Web.Peymankar _currentPeymankar;

        public Web.Peymankar CurrentPeymankar
        {
            get { return _currentPeymankar; }
            set
            {
                _currentPeymankar = value;
                OnPropertyChanged("CurrentPeymankar");
            }
        }

        private Web.Persons _currentPerson;

        public Web.Persons CurrentPerson
        {
            get { return _currentPerson; }
            set
            {
                _currentPerson = value;
                OnPropertyChanged("CurrentPerson");
            }
        }


        public SalahiyatPeymankaranPresenter()
        {
            this.IsBusy = true;

            context.Load(
                  context.GetPeymankarQuery(),
                  System.ServiceModel.DomainServices.Client.LoadBehavior.RefreshCurrent,
                  callback =>
                  {
                      Peymankarha = new ObservableCollection<Web.Peymankar>();

                      foreach (var item in context.Peymankars)
                      {
                          //Peymankarha.Add(Models.Hydro.FormNo100Model.Parse(item));
                          Peymankarha.Add(item);
                      }

                      this.IsBusy = false;
                  },
                  null);
        }

        internal void RemovePeymankar()
        {
            if (this.CurrentPeymankar == null)
            {
                return;
            }

            context.Peymankars.Remove(this.CurrentPeymankar);

            //this.Peymankarha.Remove(this.CurrentPeymankar);

            this.CurrentPeymankar = this.Peymankarha.FirstOrDefault();

            //this.IsBusy = true;

            //System.Diagnostics.Debug.WriteLine("Removing inside if... " + this.CurrentPeymankar.Id);

            //var queryBuilder = new Microsoft.Windows.Data.DomainServices.QueryBuilder<Web.Peymankar>();

            //queryBuilder = queryBuilder.Where(i => i.Id == this.CurrentPeymankar.Id);

            //var query = context.GetPeymankarQuery();

            //query = queryBuilder.ApplyTo(query);

            //context.Load(query, System.ServiceModel.DomainServices.Client.LoadBehavior.RefreshCurrent,
            //    callback =>
            //    {
            //        System.Diagnostics.Debug.WriteLine("Removing after load ... " + this.CurrentPeymankar.Id);

            //context.Peymankars.Remove(context.Peymankars.Single(i => i.Id == this.CurrentPeymankar.Id));

            //    context.SubmitChanges(callback2 =>
            //    {
            //        //This code is not redundant!
            //        this.Peymankarha.Remove(this.CurrentPeymankar);

            //        this.CurrentPeymankar = this.Peymankarha.FirstOrDefault();

            //        this.IsBusy = false;

            //    }, null);
            //}, null);
        }

        internal void NewPeymankar()
        {
            Web.Peymankar newPeymankar = new Web.Peymankar() { NameKamelePeymankar="شرکت ", Id = int.MinValue };

            context.Peymankars.Add(newPeymankar);

            this.Peymankarha.Add(newPeymankar);

            this.CurrentPeymankar = newPeymankar;
        }

        internal void SavePaymankar()
        {
            //var newPeymankars = this.Peymankarha.Where(i => !i.Id.HasValue).ToList();

            //var editedPeymankars = this.Peymankarha.Where(i => i.Id.HasValue).ToList();


            //var newPeymankars = this.Peymankarha.Where(i => i.Id == int.MinValue).ToList();

            //var editedPeymankars = this.Peymankarha.Where(i => i.Id != int.MinValue).ToList();


            //context.Load(context.GetPeymankarQuery(), System.ServiceModel.DomainServices.Client.LoadBehavior.RefreshCurrent,
            //    callback =>
            //    {
            //foreach (var item in newPeymankars)
            //{
            //    //context.Peymankars.Add(item.Parse());
            //    context.Peymankars.Add(item);
            //}

            //foreach (var item in editedPeymankars)
            //{
            //    System.Diagnostics.Debug.WriteLine("Updating... " + item.Id);

            //    object temp = context.Peymankars.Single(i => i.Id == item.Id);

            //    ReflectionHelper.Copy(item, temp);
            //    //temp.KodeSherkat = item.KodeSherkat;
            //    //temp.MahaleSabt = item.MahaleSabt;
            //    //temp.NameGabliPeymankar1 = item.NameGabliPeymankar1;
            //    //temp.NameGabliPeymankar2 = item.NameGabliPeymankar2;
            //    //temp.NameKamelePeymankar = item.NameKamelePeymankar;
            //    //temp.NoeMalekiyatDaftarMarkazi = item.NoeMalekiyatDaftarMarkazi;
            //    //temp.TarikhTasis = GetDateTime(item.TarikhTasis);
            //    //temp.TedadShoraka = item.TedadShoraka;
            //    //temp.TedadKarkonanFani = item.TedadKarkonanFani;
            //    //temp.TedadKarkonanKhadamati = item.TedadKarkonanKhadamati;
            //    //temp.TedadKarkonanModir = item.TedadKarkonanModir;
            //    //temp.NoeSabt = item.NoeSabt;
            //    //temp.NeshaniSherkat = item.NeshaniSherkat;
            //    //temp.SatheZirbanayeDaftarMarkazi = item.SatheZirbanayeDaftarMarkazi;
            //    //temp.TarikhSabt = GetDateTime(item.TarikhSabt);
            //    //temp.TedadSafehayePorseshName = item.TedadSafehayePorseshName;
            //    //temp.TarikhErsalForm = GetDateTime(item.TarikhErsalForm);
            //    //temp.ShomareSabt = item.ShomareSabt;
            //    //temp.ShomareTelefonDaftarMarkazi = item.ShomareTelefonDaftarMarkazi;
            //    //temp.ShomareSafePorseshName = item.ShomareSafePorseshName;
            //}

            context.SubmitChanges();
            //},
            //null);
        }

        internal void AddPerson()
        {
            if (this.CurrentPeymankar == null)
            {
                return;
            }

            this.CurrentPeymankar.Persons.Add(new Web.Persons());
        }

        internal void RemovePerson(List<Web.Persons> persons)
        {
            //var ids = persons.Select(i => i.Id);

            //this.IsBusy = true;

            //var queryBuilder = new Microsoft.Windows.Data.DomainServices.QueryBuilder<Web.Persons>();

            ////queryBuilder = queryBuilder.Where(i => ids.Any(j => j == i.Id));
            //queryBuilder = queryBuilder.Where(i => i.PeymankarId == this.CurrentPeymankar.Id);

            //var query = context.GetPersonsQuery();

            //query = queryBuilder.ApplyTo(query);

            //context.Load(query, System.ServiceModel.DomainServices.Client.LoadBehavior.RefreshCurrent,
            //    callback =>
            //    {
            //        foreach (var item in persons)
            //        {
            //            context.Persons.Remove(context.Persons.Single(i => i.Id == item.Id));
            //        }

            //        context.SubmitChanges(callback2 =>
            //        {
            //            This code is not redundant!
            //            foreach (var item in persons)
            //            {
            //                context.Persons.Remove(context.Persons.Single(i => i.Id == item.Id));

            //                this.CurrentPeymankar.Persons.Remove(item);

            //            }

            //            this.IsBusy = false;

            //        }, null);
            //    }, null);

            for (int i = 0; i < persons.Count(); i++)
            {
                //    var temp = persons.Skip(i).First();

                context.Persons.Remove(persons[i]);

                //this.CurrentPeymankar.Persons.Remove(persons[i]);
            }

            //foreach (var item in ids)
            //{
            //    var temp = context.Persons.Single(i => i.Id == item);

            //    context.Persons.Remove(temp);

            //    this.CurrentPeymankar.Persons.Remove(temp);
            //}

        }


        internal void RemoveSavabeg(List<Web.PersonsSavabeg> personsSavabeg)
        {
            foreach (var item in personsSavabeg)
            {
                
                //context.Persons.Single(i => i.Id == CurrentPerson.Id).PersonsSavabeg.Remove(item);

                this.CurrentPerson.PersonsSavabeg.Remove(item);
            }
        }

        internal void AddPeyman()
        {
            if (this.CurrentPeymankar == null)
            {
                return;
            }

            //this.CurrentPeymankar.Peymanha.Add(new Web.Peymanha() { VaziatPeyman = string.Empty });
            this.CurrentPeymankar.Peymanha.Add(new Web.Peymanha());
        }

        internal void RemovePeyman(List<Web.Peymanha> list)
        {
            foreach (var item in list)
            {
                this.CurrentPeymankar.Peymanha.Remove(item);
            }
        }

        internal void AddMashin()
        {
            if (this.CurrentPeymankar == null)
            {
                return;
            }

            this.CurrentPeymankar.MashinAlatVaTajhizat.Add(new Web.MashinAlatVaTajhizat());
        }

        internal void RemoveMashin(List<Web.MashinAlatVaTajhizat> list)
        {
            foreach (var item in list)
            {
                this.CurrentPeymankar.MashinAlatVaTajhizat.Remove(item);
            }
        }
    }
}
