using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.ServiceModel.DomainServices.Client;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace LanSysWebGIS.Presenter
{
    public class GenericViewModel<T> : Notifier
    {
        private T _entity;

        public T Entity
        {
            get { return _entity; }
            set
            {
                _entity = value;
                OnPropertyChanged("Entity");
            }
        }

        private bool _isSelected;

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }

    }

    public static class EntitySetExtensions
    {
        public static List<GenericViewModel<T>> Parse<T>(this EntitySet<T> value) where T : Entity
        {
            List<GenericViewModel<T>> result =
                new List<GenericViewModel<T>>();

            foreach (var item in value)
            {
                result.Add(new GenericViewModel<T>() { Entity = item, IsSelected = false });
            }

            return result;
        }
    }
}
