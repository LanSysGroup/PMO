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
using System.Linq;
using LanSysWebGIS.Views.UserManagement;
using LanSysWebGIS.Models;
using System.Collections.Generic;

namespace LanSysWebGIS.Presenter.Banader
{
    public class EmployeesFormPresenter : Notifier
    {
        Web.PMOContext context = new Web.PMOContext();

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

        private ObservableCollection<Web.EmployeesInfo> _karmandha;

        public ObservableCollection<Web.EmployeesInfo> Karmandha
        {
            get { return _karmandha; }
            set
            {
                _karmandha = value;
                OnPropertyChanged("Karmandha");
            }
        }


        private Web.EmployeesInfo _currentItem;

        public Web.EmployeesInfo CurrentItem
        {
            get { return _currentItem; }
            set
            {
                _currentItem = value;
                OnPropertyChanged("CurrentItem");
            }
        }

        public List<string> EdarehHa
        {
            get
            {
                return new List<string>() {"اداره کل مهندسی سواحل و بنادر تهران", "اداره کل بنادر و دریانوردی استان گیلان", "اداره کل بنادر و دریانوردی استان مازندران"
        ,"اداره کل بنادر و دریانوردی استان گلستان" ,"اداره کل بنادر و دریانوردی استان خوزستان" , "اداره کل بنادر و دریانوردی استان بوشهر" ,"اداره کل بنادر و دریانوردی استان هرمزگان" 
        ,"اداره کل بنادر و دریانوردی استان سیستان بلوچستان"};
            }
        }

        public List<string> NoeGharardad
        {
            get
            {
                return new List<string>() { "رسمی", "پیمانی", "قرارداد مستقیم", "خدمات مشاوره ای" };
            }
        }


        public EmployeesFormPresenter()
        {
            this.IsBusy = true;

            context.Load(
                  context.GetEmployeesInfoQuery(),
                  System.ServiceModel.DomainServices.Client.LoadBehavior.RefreshCurrent,
                  callback =>
                  {
                      Karmandha = new ObservableCollection<Web.EmployeesInfo>();

                      foreach (var item in context.EmployeesInfos)
                      {
                          //Peymankarha.Add(Models.Hydro.FormNo100Model.Parse(item));
                          Karmandha.Add(item);
                      }

                      this.CurrentItem = this.Karmandha.FirstOrDefault();

                      this.IsBusy = false;
                  },
                  null);
        }

        public EmployeesFormPresenter(Web.EmployeesInfo item)
        {
            this.CurrentItem = item;
        }

        public void Save()
        {
            if (string.IsNullOrWhiteSpace(CurrentItem.FirstName) || string.IsNullOrWhiteSpace(CurrentItem.LastName))
            {
                MessageWindow messageWindow = new MessageWindow();
                messageWindow.messageTextBlock.Text = "لطفا نام و نام خانوادگی را پر کنید";
                messageWindow.Show();

                return;
            }
            context.SubmitChanges();
        }

        public void NewEmployee()
        {
            Web.EmployeesInfo newEmployee = new Web.EmployeesInfo() { FirstName = "کارمند", PersonalPicture = @"./pic.jpg" };

            context.EmployeesInfos.Add(newEmployee);

            this.Karmandha.Add(newEmployee);

            this.CurrentItem = newEmployee;
        }

        public void RemoveEmployee()
        {
            if (this.CurrentItem == null)
            {
                return;
            }

            context.EmployeesInfos.Remove(CurrentItem);

            Karmandha.Remove(CurrentItem);

            this.CurrentItem = this.Karmandha.FirstOrDefault();
        }

        internal void UploadPersonalPic()
        {
            FileUploader uploader = new FileUploader();

            IEnumerable<System.IO.FileInfo> filesInfo = uploader.StartUpload(@"cpedsrv\Archive\EmployeePics", null);

            this.CurrentItem.PersonalPicture = filesInfo.FirstOrDefault().FullName;
        }
    }
}
