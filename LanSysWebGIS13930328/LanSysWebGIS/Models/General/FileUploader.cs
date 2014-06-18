using LanSysWebGIS.Presenter;
using Liquid.Components;
using System;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace LanSysWebGIS.Models
{
    public class FileUploader
    {
        private Uploader _uploader;

        public FileUploader()
        {

            string servicePath = string.Format("{0}/UploadService.asmx", Application.Current.Host.Source.AbsoluteUri.Replace(@"/ClientBin/LanSysWebGIS.xap", ""));
            _uploader = new Uploader(servicePath, "Upload");

            //MessageBox.Show(servicePath);

            _uploader.UploadProgressChange += new UploadEventHandler(Uploader_UploadProgressChange);
            _uploader.UploadFinished += new UploadEventHandler(Uploader_UploadFinished);
        }

        public void Uploader_UploadFinished(object sender, UploadEventArgs e)
        {

        }

        public void Uploader_UploadProgressChange(object sender, UploadEventArgs e)
        {

        }

        void _uploader_UploadFinished(object sender, UploadEventArgs e)
        {
            throw new NotImplementedException();
        }

        internal IEnumerable<System.IO.FileInfo> StartUpload(string selectedTitleFullPath, AddFilePresenter addFilePresenter)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            //dialog.Filter = "Zip files (*.zip)|*.zip";
            dialog.Multiselect = true;

            if (dialog.ShowDialog() == true)
            {
                if (addFilePresenter != null)
                {
                    addFilePresenter.IsLoading = true;
                }

                string path = @"\" + selectedTitleFullPath.Replace("cpedsrv", "172.16.1.243").Replace(@"//", @"\").Replace(@"\\", @"\");
                ///////////////////////////


                _uploader.UploadFiles("myUpload1", dialog.Files, path + @"\Uploads\" + WebContext.Current.User.Name + @"\", true, "");

                if (addFilePresenter != null)
                {
                    _uploader.UploadFinished += (s, e) =>
                    {
                        addFilePresenter.IsLoading = false;
                        addFilePresenter.LoadingContent = "لطفا شکیبا باشید...";
                    };

                    _uploader.UploadProgressChange += (s, e) =>
                    {
                        addFilePresenter.LoadingContent = string.Format("لطفا شکیبا باشید... ({0}%)", (Convert.ToInt32(e.Progress)).ToString());
                    };
                }

                return dialog.Files;
            }

            return null;
        }
    }
}
