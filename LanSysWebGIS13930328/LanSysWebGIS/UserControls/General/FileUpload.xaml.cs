using Liquid.Components;
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
    public partial class FileUpload : UserControl
    {
        private Uploader _uploader = new Uploader(string.Format("{0}/UploadService.asmx", Application.Current.Host.Source.AbsoluteUri.Replace(@"/ClientBin/LanSysWebGIS.xap", "")));

		public FileUpload()
		{
			InitializeComponent();

			_uploader.UploadProgressChange += new UploadEventHandler(Uploader_UploadProgressChange);
			_uploader.UploadFinished += new UploadEventHandler(Uploader_UploadFinished);
		}

		private void Uploader_UploadFinished(object sender, UploadEventArgs e)
		{
			progress.Text = "اتمام آپلود";
			progress.Complete = e.Progress;
		}

		private void Uploader_UploadProgressChange(object sender, UploadEventArgs e)
		{
			progress.Text = "Uploading " + Math.Round(e.Progress) + "% (" + e.Text + ")";
			progress.Complete = e.Progress;
		}

		private void StartUpload_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();

			dialog.Filter = "Zip files (*.zip)|*.zip";
			dialog.Multiselect = true;

			if (dialog.ShowDialog() == true)
			{
				_uploader.UploadFiles("myUpload1", dialog.Files, "Uploads/ZipDir/", true, "");
			}
		}
    }
}
