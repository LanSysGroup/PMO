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
    public partial class SalahiyatPeymankaran : UserControl
    {
        Presenter.Hydro.SalahiyatPeymankaranPresenter Presenter { get { return this.DataContext as Presenter.Hydro.SalahiyatPeymankaranPresenter; } }

        public SalahiyatPeymankaran()
        {
            InitializeComponent();

            this.DataContext = new Presenter.Hydro.SalahiyatPeymankaranPresenter();
        }

        private void savePaymankar_Click(object sender, RoutedEventArgs e)
        {
            this.Presenter.SavePaymankar();
        }

        private void newPeymankar_Click(object sender, RoutedEventArgs e)
        {
            this.Presenter.NewPeymankar();
        }

        private void deletePeymankar_Click(object sender, RoutedEventArgs e)
        {
            Controls.YesNoQuestion dialog = new Controls.YesNoQuestion(
                new Presenter.YesNoQuestionPresenter()
                {
                    Message = "آیا از حذف پیمان کار جاری مطمئن هستید؟",
                    Title = "حذف پیمان کار"
                });

            dialog.Show();

            dialog.Closed += delegate
            {
                if (dialog.DialogResult == true)
                {
                    this.Presenter.RemovePeymankar();
                }
            };
        }

        private void newPerson_Click(object sender, RoutedEventArgs e)
        {
            this.Presenter.AddPerson();
        }

        private void deletePerson_Click(object sender, RoutedEventArgs e)
        {
            Controls.YesNoQuestion dialog = new Controls.YesNoQuestion(
               new Presenter.YesNoQuestionPresenter()
               {
                   Message = "آیا از حذف فرد/افراد جاری مطمئن هستید؟",
                   Title = "حذف فرد/افراد"
               });

            dialog.Show();

            dialog.Closed += delegate
            {
                if (dialog.DialogResult == true)
                {
                    this.Presenter.RemovePerson(this.formNo200.SelectedItems.Cast<Web.Persons>().ToList());
                }
            };
        }

        private void newSavabeg_Click(object sender, RoutedEventArgs e)
        {
            if (this.Presenter.CurrentPerson == null)
            {
                Controls.YesNoQuestion dialog = new Controls.YesNoQuestion(
             new Presenter.YesNoQuestionPresenter()
             {
                 Message = "برای اضافه کردن سوابق ابتدا بایستی فرد مورد نظر را انتخاب کنید.",
                 Title = "اضافه کردن سوابق"
             });

                dialog.Show();

                return;
            }

            this.Presenter.CurrentPerson.PersonsSavabeg.Add(new Web.PersonsSavabeg());
        }

        private void removeSavabeg_Click(object sender, RoutedEventArgs e)
        {
            Controls.YesNoQuestion dialog = new Controls.YesNoQuestion(
              new Presenter.YesNoQuestionPresenter()
              {
                  Message = "آیا از حذف سابقه(های) جاری مطمئن هستید؟",
                  Title = "حذف سابقه(ها)"
              });

            dialog.Show();

            dialog.Closed += delegate
            {
                if (dialog.DialogResult == true)
                {
                    this.Presenter.RemoveSavabeg(this.formNo300.SelectedItems.Cast<Web.PersonsSavabeg>().ToList());
                }
            };
        }

        private void newPeyman_Click(object sender, RoutedEventArgs e)
        {
            this.Presenter.AddPeyman();
        }

        private void removePeyman_Click(object sender, RoutedEventArgs e)
        {
            Controls.YesNoQuestion dialog = new Controls.YesNoQuestion(
             new Presenter.YesNoQuestionPresenter()
             {
                 Message = "آیا از حذف پیمان(های) جاری مطمئن هستید؟",
                 Title = "حذف پیمان(ها)"
             });

            dialog.Show();

            dialog.Closed += delegate
            {
                if (dialog.DialogResult == true)
                {
                    this.Presenter.RemovePeyman(this.formNo400.SelectedItems.Cast<Web.Peymanha>().ToList());
                }
            };
        }

        private void newMashin_Click(object sender, RoutedEventArgs e)
        {
            this.Presenter.AddMashin();
        }

        private void removeMashin_Click(object sender, RoutedEventArgs e)
        {
            Controls.YesNoQuestion dialog = new Controls.YesNoQuestion(
            new Presenter.YesNoQuestionPresenter()
            {
                Message = "آیا از حذف ماشین/تجهیز(های) جاری مطمئن هستید؟",
                Title = "حذف ماشین/تجهیز(ها)"
            });

            dialog.Show();

            dialog.Closed += delegate
            {
                if (dialog.DialogResult == true)
                {
                    this.Presenter.RemoveMashin(this.formNo500.SelectedItems.Cast<Web.MashinAlatVaTajhizat>().ToList());
                }
            };
        }
    }
}
