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
    public partial class IMO : UserControl
    {
        Presenter.Hydro.IMOPresenter Presenter { get { return this.DataContext as Presenter.Hydro.IMOPresenter; } }

        public IMO()
        {
            InitializeComponent();

            this.DataContext = new Presenter.Hydro.IMOPresenter();
        }

        private void savePermitSummary_Click(object sender, RoutedEventArgs e)
        {
            this.Presenter.Save();
        }

        private void newPermitSummary_Click(object sender, RoutedEventArgs e)
        {
            this.Presenter.NewSummaryOfPermits();
        }

        private void deletePermitSummary_Click(object sender, RoutedEventArgs e)
        {
            Controls.YesNoQuestion dialog = new Controls.YesNoQuestion(
               new Presenter.YesNoQuestionPresenter()
               {
                   Message = "Are you sure?",
                   Title = "Delete Summary of Permit"
               });

            dialog.Show();

            dialog.Closed += delegate
            {
                if (dialog.DialogResult == true)
                {
                    this.Presenter.RemoveSummaryOfPermits();
                }
            };
        }


        private void newDepositeDetails_Click(object sender, RoutedEventArgs e)
        {
            this.Presenter.Context.DetailsOfDeposits.Add(new Web.DetailsOfDeposit());
        }

        private void deleteDepositeDetails_Click(object sender, RoutedEventArgs e)
        {
            this.Presenter.Context.DetailsOfDeposits.Remove(this.detailsOfDepositDataGrid.SelectedItem as Web.DetailsOfDeposit);
        }

        private void newCO2Details_Click(object sender, RoutedEventArgs e)
        {
            this.Presenter.NewCO2Details();
        }

        private void deleteCO2Details_Click(object sender, RoutedEventArgs e)
        {
            Controls.YesNoQuestion dialog = new Controls.YesNoQuestion(
             new Presenter.YesNoQuestionPresenter()
             {
                 Message = "Are you sure?",
                 Title = "Delete CO2 Details"
             });

            dialog.Show();

            dialog.Closed += delegate
            {
                if (dialog.DialogResult == true)
                {
                    this.Presenter.RemoveCO2Details();
                }
            };
        }

    }
}
