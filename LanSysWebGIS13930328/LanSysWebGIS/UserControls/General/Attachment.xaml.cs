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

namespace LanSysWebGIS.UserControls
{
    public partial class Attachment : UserControl
    {
        public Attachment()
        {
            InitializeComponent();

            RibbonBar.AttachmentDialog = AttachmentDialog;

            MapControl.attEditor = MyAttachmentEditor;
        }

        private void AttachmentDialog_MouseEnter(object sender, MouseEventArgs e)
        {
            AttachmentDialog.Opacity = 1;
        }

        private void AttachmentDialog_MouseLeave(object sender, MouseEventArgs e)
        {
            AttachmentDialog.Opacity = 0.7;
        }

        private void AttachmentDialog_Closed(object sender, Liquid.DialogEventArgs e)
        {

        }

        private void AttachmentDialog_Opened(object sender, Liquid.DialogEventArgs e)
        {

        }

        private void MyAttachmentEditor_UploadFailed(object sender, ESRI.ArcGIS.Client.Toolkit.AttachmentEditor.UploadFailedEventArgs e)
        {
            throw new Exception(e.Result.Message);
        }

        internal static void SetGraphic(ESRI.ArcGIS.Client.Graphic graphic)
        {
            MapControl.attEditor.GraphicSource = graphic;
        }
    }
}