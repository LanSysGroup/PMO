using System.ServiceModel.DomainServices.Client;
using LanSysWebGIS.Web;
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
using LanSysWebGIS.Views.UserManagement;
using LanSysWebGIS.Assets.Resources;

namespace LanSysWebGIS.UserControls
{
    public partial class DataFormNew : UserControl
    {
        //private LanSysWebGIS.Web.ImageMetadatas entityInfo = new ImageMetadatas();

        private object entityInfo;

        public static DataGrid entityDG;

        public static DomainDataSource entityDDS;

        private Type type;

        public DataFormNew()
        {
            InitializeComponent();

            entityInfo = new object();

            type = entityDG.SelectedItem.GetType();

            entityInfo = Activator.CreateInstance(type);

            //// Set the DataContext of this control to the LoginInfo instance to allow for easy binding.
            this.DataContext = entityInfo;

            //entityInfo.EntityToken = new byte[5];
        }

        private void DataFormNewDialog_Opened(object sender, Liquid.DialogEventArgs e)
        {
            
        }

        private void DataForm_AutoGeneratingField(object sender, DataFormAutoGeneratingFieldEventArgs e)
        {
            if (e.PropertyName == "DarsadFasleGhabl" || e.PropertyName == "DarsadSaleGhabl")
            {
                e.Cancel = true;
            }
        }

        private void DataEntryForm_EditEnded(object sender, DataFormEditEndedEventArgs e)
        {
            if (e.EditAction == DataFormEditAction.Commit)
            {
                DBDomainContext context = new DBDomainContext();

                context.EntityContainer.GetEntitySet(type).Add(entityInfo as Entity);

                //context.ImageMetadatas.Add(entityInfo);

                context.SubmitChanges(callback => entityDDS.Load(), null);

                entityInfo = Activator.CreateInstance(type);

                DataEntryForm.CurrentItem = entityInfo;

                MessageWindow win = new MessageWindow();
                win.messageTextBlock.Text = ApplicationStrings.msgRecordStoredSuccessfully;
                win.Show();
            }
        }

        private void UserControl_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                DataEntryForm.CommitEdit();
            }
        }

        private void DataFormNewDialog_Closed(object sender, Liquid.DialogEventArgs e)
        {
            DataEntryForm.CancelEdit();
        }

    }
}
