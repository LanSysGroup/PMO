using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace LanSysWebGIS.UserControls.Hydro
{
    public partial class ArzyabiVaTashkisSalahiyat : UserControl
    {
        Presenter.Hydro.SalahiyatPeymankaranPresenter Presenter { get { return this.DataContext as Presenter.Hydro.SalahiyatPeymankaranPresenter; } }

        public ArzyabiVaTashkisSalahiyat()
        {
            InitializeComponent();

            this.DataContext = new Presenter.Hydro.SalahiyatPeymankaranPresenter();
        }

        private void savePaymankar_Click(object sender, RoutedEventArgs e)
        {
            this.Presenter.SavePaymankar();
        }
    }
}
