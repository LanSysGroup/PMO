using LanSysWebGIS.Models;
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

namespace LanSysWebGIS.UserControls.Banader
{
    public partial class EmployeesForm : UserControl
    {
        public Presenter.Banader.EmployeesFormPresenter Presenter { get { return this.DataContext as Presenter.Banader.EmployeesFormPresenter; } }

        

        public EmployeesForm()
        {
            InitializeComponent();

            this.DataContext = new Presenter.Banader.EmployeesFormPresenter();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            this.Presenter.Save(); ;
        }

        private void new_Click(object sender, RoutedEventArgs e)
        {
            this.Presenter.NewEmployee();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            Controls.YesNoQuestion dialog = new Controls.YesNoQuestion(
                new Presenter.YesNoQuestionPresenter()
                {
                    Message = "آیا از حذف کارمند جاری مطمئن هستید؟",
                    Title = "حذف کارمند"
                });

            dialog.Show();

            dialog.Closed += delegate
            {
                if (dialog.DialogResult == true)
                {
                    this.Presenter.RemoveEmployee();
                }
            };
        }

        string nums = "1234567890.-";
        string lastText = "";
        int lastSelStart = 0;

        private void ValidateNumericInput(object sender, TextChangedEventArgs e)
        {
            if (((TextBox)sender).Text.Length > 0 && !nums.Contains(((TextBox)sender).Text.Substring(((TextBox)sender).Text.Length - 1)))
            {
                ((TextBox)sender).Text = lastText;
                ((TextBox)sender).SelectionStart = lastSelStart;
                return;
            }

            lastText = ((TextBox)sender).Text;
            lastSelStart = ((TextBox)sender).SelectionStart;
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            ValidateNumericInput(sender, e);
        }

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Presenter.UploadPersonalPic();
        }
    }
}
