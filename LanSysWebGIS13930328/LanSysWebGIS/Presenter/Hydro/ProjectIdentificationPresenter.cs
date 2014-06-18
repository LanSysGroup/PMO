using LanSysWebGIS.Models.Hydro;
using LanSysWebGIS.Web;
using System;
using System.Net;
using System.Reflection;
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
    public class ProjectIdentificationPresenter : Notifier
    {
        private Web.ProjectIdentification  _currentItem;

        public Web.ProjectIdentification CurrentItem
        {
            get { return _currentItem; }
            set
            {
                _currentItem = value;
                OnPropertyChanged("CurrentItem");
            }
        }

        private PropertyInfo[] allProps;

        public ProjectIdentificationPresenter()
        {
            this.CurrentItem = new Web.ProjectIdentification();

            SetBooleanValuesToFalse();
        }

        public ProjectIdentificationPresenter(Web.ProjectIdentification item)
        {
            this.CurrentItem = item;

            SetBooleanValuesToFalse();
        }

        private void SetBooleanValuesToFalse()
        {
            allProps = this.CurrentItem.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);

            foreach (var prop in allProps)
            {
                if (prop.PropertyType == typeof(Nullable<bool>))
                {
                    prop.SetValue(this.CurrentItem, false, null);
                }
            }
        }

        public void Save()
        {
            HydroContext context = new HydroContext();

            CurrentItem.Token = new byte[5];

            CurrentItem.UserId = int.Parse(WebContext.Current.User.UserID);

            context.ProjectIdentifications.Add(CurrentItem);

            context.SubmitChanges();
        }
    }
}
