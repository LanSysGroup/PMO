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

namespace LanSysWebGIS.Models.Banader
{
    public class UserModel : Notifier
    {
        private int _usersId;

        public int UsersId
        {
            get { return _usersId; }
            set
            {
                _usersId = value;
                OnPropertyChanged("UsersId");
            }
        }

        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                OnPropertyChanged("UserName");
            }
        }

        //private bool _isChecked;

        //public bool IsChecked
        //{
        //    get { return _isChecked; }
        //    set
        //    {
        //        _isChecked = value;
        //        OnPropertyChanged("IsChecked");
        //    }
        //}

        public UserModel()
        {
            //IsChecked = false;
        }
    }
}
