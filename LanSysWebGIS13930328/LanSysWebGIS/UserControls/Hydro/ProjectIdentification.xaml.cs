using LanSysWebGIS.Views.UserManagement;
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
    public partial class ProjectIdentification : UserControl
    {
        public Presenter.Hydro.ProjectIdentificationPresenter Presenter { get { return this.DataContext as Presenter.Hydro.ProjectIdentificationPresenter; } }

        //public ProjectIdentification()
        //{
        //    this.DataContext = new Presenter.Hydro.ProjectIdentificationPresenter(new Models.Hydro.ProjectIdentificationModel());

        //    InitializeComponent();
        //}

        public ProjectIdentification(Presenter.Hydro.ProjectIdentificationPresenter presenter)
        {
            InitializeComponent();

            this.DataContext = presenter;
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            this.Presenter.Save();

            MessageWindow win = new MessageWindow();
            win.messageTextBlock.Text = "فرم با موفقیت ذخیره شد";
            win.Show();

            (((this.Parent as StackPanel).Parent as Grid).Parent as ChildWin).Close();

            //((ChildWin)((Grid)((StackPanel)(this.Parent)).Parent)).Close();
        }

        //private void TextBox_KeyDown_1(object sender, KeyEventArgs e)
        //{
        //    //// Handle Shift case
        //    //if (Keyboard.Modifiers == ModifierKeys.Shift)
        //    //{
        //    //    e.Handled = true;
        //    //}

        //    //// Handle all other cases
        //    //if (!e.Handled && (e.Key < Key.D0 || e.Key > Key.D9))
        //    //{
        //    //    if (e.Key < Key.NumPad0 || e.Key > Key.NumPad9)
        //    //    {
        //    //        if (e.Key != Key.Back || e.Key != Key.Tab || e.Key != Key.Subtract)
        //    //        {
        //    //            e.Handled = true;
        //    //        }
        //    //    }
        //    //}  

        //    //if (e.Key == Key.D0 || e.Key == Key.D1 || e.Key == Key.D2 || e.Key == Key.D3 || e.Key == Key.D4 || e.Key == Key.D5 || e.Key == Key.D6 || e.Key == Key.D7 || e.Key == Key.D8 || e.Key == Key.D9 || e.Key == Key.NumPad0 || e.Key == Key.NumPad1 || e.Key == Key.NumPad2 || e.Key == Key.NumPad3 || e.Key == Key.NumPad4 || e.Key == Key.NumPad5 || e.Key == Key.NumPad6 || e.Key == Key.NumPad7 || e.Key == Key.NumPad8 || e.Key == Key.NumPad9 || e.Key == Key.Tab || e.Key == Key.Enter || e.Key == Key.Subtract || e.Key == Key.Decimal)
        //    //    e.Handled = false;
        //    //else
        //    //    e.Handled = true;
        //}

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

        private void chkSavLayroobiGhabli_Unchecked(object sender, RoutedEventArgs e)
        {
            txtSavSaleLayroobiGhabli.Text = "";
        }
    }
}
